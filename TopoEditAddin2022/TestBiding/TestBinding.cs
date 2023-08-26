using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System.Windows.Forms;

namespace TopoEditAddin2022.TestBiding
{
    [Transaction(TransactionMode.Manual)]
    public class TestBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument; // quan ly click , selecion, thao tac..
            Document doc = uiDoc.Document; // quan ly toan bo du lieu

            ICollection<ElementId> ids = uiDoc.Selection.GetElementIds();
            IList<Room> listRoom= new List<Room>(); 
            foreach (ElementId id in ids)
            {
                Room room= doc.GetElement(id) as Room;
                if(room != null)
                {
                    listRoom.Add(room);
                }
            }

            SpatialElementBoundaryOptions option = new SpatialElementBoundaryOptions();
            // lay hinh dang room theo finish
            option.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish; 

            using (TransactionGroup tg= new TransactionGroup(doc, "GroupEdit"))
            {
                tg.Start();

                foreach (Room room in listRoom)
                {
                    var boundarySegment = room.GetBoundarySegments(option);
                    // tim ra curveloop lon nhat
                    double lengthMax = 0;
                    IList<BoundarySegment> curveLoopMax = null;
                    foreach (IList<BoundarySegment> curveLoopItem in boundarySegment)
                    {
                        // xac dinh tong chieu dai cua curve loop
                        double totalLengthItem = 0;
                        foreach (BoundarySegment curve in curveLoopItem)
                        {
                            totalLengthItem += curve.GetCurve().Length;
                        }

                        // kiem tra xem chieu dai curve loop co lon hon chieu dai max khong
                        if (totalLengthItem > lengthMax)
                        {
                            curveLoopMax = curveLoopItem;
                            lengthMax = totalLengthItem;
                        }
                    }
                    if (curveLoopMax.Count == 0) continue;

                    CurveLoop curveLoop = new CurveLoop();
                    foreach(BoundarySegment curve in curveLoopMax)
                    {
                        curveLoop.Append(curve.GetCurve());
                    }

                    //var typeCeilling = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Ceilings)
                    //    .WhereElementIsElementType().Where(x=>x.Name== "3000 x 3000mm Grid").First();

                    var typeWall = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Walls).
                        WhereElementIsElementType().Where(x => x.Name == "CL_W1").First();
                    using(Transaction t = new Transaction(doc, "CreateCeiling"))
                    {
                        t.Start();
                        try
                        {
                            //IList<CurveLoop> listCurveLoop= new List<CurveLoop>() { curveLoop };
                            //Ceiling ceiling = Autodesk.Revit.DB.Ceiling.Create(doc,
                            //    listCurveLoop, typeCeilling.Id, doc.ActiveView.GenLevel.Id);
                            foreach(var curve in curveLoop)
                            {
                                Wall wall = Autodesk.Revit.DB.Wall.Create(doc, curve, doc.ActiveView.GenLevel.Id,
                                    false);

                                wall.get_Parameter(BuiltInParameter.WALL_KEY_REF_PARAM).Set(5);
                                var locationInner = wall.Location as LocationCurve;
                                var curveInter = locationInner.Curve;



                                wall.get_Parameter(BuiltInParameter.WALL_KEY_REF_PARAM).Set(0);
                                var newLocation = (wall.Location as LocationCurve);
                                var newCurve = newLocation.Curve;
                                newLocation.Curve = curveInter;

                            }

                            t.Commit();
                        }
                        catch
                        {
                            t.RollBack();
                        }
                    }
                }

                tg.Assimilate();
            }
           
           




            






            return Result.Succeeded;
        }
    }
}
