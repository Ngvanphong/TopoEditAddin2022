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

            ////lay doi tuong dang chon
            //ICollection<ElementId> ids= uiDoc.Selection.GetElementIds();
            //if (ids.Count() == 0) return Result.Succeeded;
            //ElementId id= ids.First(); // lay id dau tien trong mang
            //Element element = doc.GetElement(id); // tu id lay doi tuong

            //// lay hop bounding box cua doi tuong trong view hien tai
            //BoundingBoxXYZ boundingBox = element.get_BoundingBox(doc.ActiveView); 
            //XYZ p1 = boundingBox.Min; // 2 diem tren duong cheo hinh chu nhat
            //XYZ p2= boundingBox.Max;

            //// tim diem goc trai duoi 
            //XYZ min = new XYZ(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y),Math.Min(p1.Z, p2.Z));
            //// tim diem goc phai tren
            //XYZ max = new XYZ(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y),Math.Max(p1.Z, p2.Z));
            //// tao outline de ap dung bo loc
            //Outline outLine = new Outline(min, max);
            //// tao bo loc giao voi bounding box
            //BoundingBoxIntersectsFilter boundingBoxFilter= new BoundingBoxIntersectsFilter(outLine);

            //// lay tat ca cac doi tuong trong view khong phai la type
            //var collection = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType();

            //// ap dung bo loc giao voi bounding box
            //var intersectionBoundingBox = collection.WherePasses(boundingBoxFilter).ToElements()
            //    .Where(x=>x.Id!=id).ToList();

            /////


            ICollection<ElementId> elementsIds = uiDoc.Selection.GetElementIds();
            if (elementsIds.Count() == 0) return Result.Succeeded;
            IList<DetailCurve> listDetailCurve= new List<DetailCurve>(); // khoi tao list de luu cac detail curve lai
            foreach(ElementId id in elementsIds)
            {
                Element element = doc.GetElement(id);
                DetailCurve detailItem= element as DetailCurve; // ep kieu element thanh detail curve;
                if(detailItem != null)
                {
                    listDetailCurve.Add(detailItem);
                }
            }

            // tim tat ca cac family theo ten trong du an
            var family = new FilteredElementCollector(doc).OfClass(typeof(Family))
                .Where(x => x.Name == "UB-Universal Beams (AS 3679_1)").Cast<Family>().First();
            // lay id type dau tien cua family 
            ElementId idFamilySymbol= family.GetFamilySymbolIds().First(); 
            // lay type tu id
            FamilySymbol familySymbol= doc.GetElement(idFamilySymbol) as FamilySymbol;

            // level hien tai cua view
            Level level = doc.ActiveView.GenLevel;

            using (TransactionGroup tg= new TransactionGroup(doc, "groupTransaction"))
            {
                tg.Start();
                foreach(DetailCurve detail in listDetailCurve)
                {
                    using (Transaction t = new Transaction(doc, "CreateBeam"))
                    {
                        t.Start();
                        try
                        {
                            // kiem tra type co dang duoc active hay khong, neu khong thi active
                            if (!familySymbol.IsActive) familySymbol.Activate();

                            // tao dam theo curve
                            FamilyInstance beam = doc.Create.NewFamilyInstance(detail.GeometryCurve,
                                familySymbol, level, Autodesk.Revit.DB.Structure.StructuralType.Beam);

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
