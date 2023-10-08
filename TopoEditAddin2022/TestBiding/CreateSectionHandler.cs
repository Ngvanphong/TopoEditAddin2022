
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TopoEditAddin2022.TestBiding
{
    public class CreateSectionHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;

            var beamCollection = new FilteredElementCollector(doc, doc.ActiveView.Id)
                .OfCategory(BuiltInCategory.OST_StructuralFraming)
                .WhereElementIsNotElementType().ToList();

            var typeSection = CreateSectionAppShow.formCreateSection.comboboxTypeSections.SelectedItem as ViewFamilyType;
            using (TransactionGroup tg = new TransactionGroup(doc, "SectionGroup"))
            {
                tg.Start();
                foreach (Element ele in beamCollection)
                {
                    LocationCurve locationCurve = ele.Location as LocationCurve;
                    if (locationCurve != null)
                    {
                        Line line = locationCurve.Curve as Line;
                        if (line != null)
                        {
                            XYZ directionLine = line.Direction;
                            XYZ directionView = doc.ActiveView.ViewDirection;
                            XYZ normalLine = directionLine.CrossProduct(directionView).Normalize();

                            Transform translate500 = Transform.CreateTranslation(normalLine * 500 / 304.8);
                            Transform translate500Neg = Transform.CreateTranslation(-normalLine * 500 / 304.8);

                            using (Transaction t = new Transaction(doc, "CreateSection"))
                            {
                                t.Start();

                                Transform transform = Transform.Identity;
                                transform.BasisX = directionLine.Normalize();
                                transform.BasisY = directionView.Normalize();
                                transform.BasisZ = normalLine;

                                XYZ st = line.GetEndPoint(0);
                                XYZ ed = line.GetEndPoint(1);
                                XYZ mid = st.Add(ed).Divide(2);
                                transform.Origin = mid;

                                XYZ newSt = translate500.OfPoint(st);
                                XYZ newEd = translate500Neg.OfPoint(ed);

                                double length = line.Length;
                                BoundingBoxXYZ boundingBoxBeam = ele.get_BoundingBox(null);
                                double z = boundingBoxBeam.Max.Z - boundingBoxBeam.Min.Z;
                                XYZ min = new XYZ(-length / 2 - 200 / 304.8, -z - 200 / 304.8, -500 / 304.8);
                                XYZ max = new XYZ(length / 2 + 200 / 304.8, 200 / 304.8, 500 / 304.8);

                                BoundingBoxXYZ boundingBox = new BoundingBoxXYZ();
                                boundingBox.Transform = transform;
                                boundingBox.Min = min;
                                boundingBox.Max = max;
                                ViewSection section = null;
                                if (typeSection.ViewFamily == ViewFamily.Section)
                                {
                                    section = Autodesk.Revit.DB.ViewSection.CreateSection(doc, typeSection.Id, boundingBox);
                                }
                                else
                                {
                                    section = Autodesk.Revit.DB.ViewSection.CreateDetail(doc, typeSection.Id, boundingBox);
                                }
                               
                                section.DetailLevel = ViewDetailLevel.Fine;
                                t.Commit();
                            }


                        }
                    }
                }
                tg.Assimilate();
            }
        }

        public string GetName()
        {
            return "CreateSectionHandler";
        }
    }
}