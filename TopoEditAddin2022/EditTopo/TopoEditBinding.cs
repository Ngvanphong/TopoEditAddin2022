using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Architecture;

namespace TopoEditAddin2022.EditTopo
{
    [Transaction(TransactionMode.Manual)]
    public class TopoEditBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = commandData.Application.ActiveUIDocument.Document;
            var selectedIts = uiDoc.Selection.GetElementIds();
            TopographySurface topo = null;
            foreach (ElementId id in selectedIts) // tim topo selected
            {
                Element element = doc.GetElement(id);
                if (element.Category != null && element.Category.Id.IntegerValue == (int)BuiltInCategory.OST_TopographySurface)
                {
                    topo = element as TopographySurface;
                }
            }
            if (topo == null) return Result.Succeeded;
            XYZ firstPoint = null;
            XYZ endPoint = null;
            try
            {
                firstPoint = uiDoc.Selection.PickPoint("Pick a point");
            }
            catch { }
            try
            {
                endPoint = uiDoc.Selection.PickPoint("Pick a point");
            }
            catch { }
            if (firstPoint == null || endPoint == null) return Result.Succeeded;

            IList<XYZ> listPointOfTopos = topo.GetPoints();
            XYZ firstPointTopo = null;
            XYZ endPointTopo = null;
            foreach (XYZ point in listPointOfTopos)
            {
                if (point.X == firstPoint.X && point.Y == firstPoint.Y)
                {
                    firstPointTopo = point;
                }
                if (point.X == endPoint.X && point.Y == endPoint.Y)
                {
                    endPointTopo = point;
                }
            }
            if (firstPointTopo == null || endPointTopo == null) return Result.Succeeded;
            int countDevide = EditTopoCommon.CountDivide;
            List<XYZ> listPointDevide = new List<XYZ>();

            Line line = Line.CreateBound(firstPointTopo, endPointTopo);
            double length = line.Length;
            double firstPara = line.GetEndParameter(0);
            double endPara = line.GetEndParameter(1);
            double distanceDivide = length / (countDevide + 1);
            int totalPoint = countDevide + 2;

            double lengthItem = 0;
            for (int i = 0; i < totalPoint; i++)
            {
                if (i == 0 || i == totalPoint - 1) continue;
                Line lineItem = Line.CreateBound(firstPointTopo, endPointTopo);
                lengthItem += distanceDivide * i;
                double paraItem = firstPara + (lengthItem / length) * (endPara - firstPara);
                lineItem.MakeBound(firstPara, paraItem);
                XYZ pointItem = lineItem.GetEndPoint(1);
                listPointDevide.Add(pointItem);
            }
            using (TopographyEditScope topoScopre = new TopographyEditScope(doc, "ModifyTopo"))
            {
                topoScopre.Start(topo.Id);
                using(Transaction t= new Transaction(doc, "edit"))
                {
                    t.Start();
                    topo.AddPoints(listPointDevide);
                    t.Commit();
                }
                topoScopre.Commit(new FailTopo());

            }


            return Result.Succeeded;
        }
    }

    class FailTopo : IFailuresPreprocessor
    {
        public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
        {
            return FailureProcessingResult.ProceedWithRollBack;
        }
    }
}
