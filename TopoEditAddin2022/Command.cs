using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditAddin2022
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //// Lay view dang hoat dong
            //View actionView = doc.ActiveView;
            //// get tat ca cac doi tuong trong view bao gom ca type
            //FilteredElementCollector allElementOfView = new FilteredElementCollector(doc, actionView.Id);
            //// Loai bo type chi lay element;
            //var allElementNotType = allElementOfView.WhereElementIsNotElementType();
            //// Tao bo loc thong qua category;
            ////ElementCategoryFilter doorCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Doors);
            //// Ap dung bo loc de lay doi tuong theo category;
            ////var allDoors= allElementNotType.WherePasses(doorCategoryFilter).ToElements();
            ////IList<Element> doorCollection = allElementNotType.OfCategory(BuiltInCategory.OST_Doors).ToElements();

            //ElementCategoryFilter wallCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Walls);
            ////var allWalls= allElementNotType.WherePasses(wallCategoryFilter).ToElements();

            ////IList<ElementFilter> listFilter= new List<ElementFilter>(){ doorCategoryFilter,wallCategoryFilter };
            ////listFilter.Add(doorCategoryFilter);
            ////listFilter.Add(wallCategoryFilter);
            ////LogicalOrFilter orFilter = new LogicalOrFilter(listFilter); // Bo loc OR
            ////IList<Element> wallDoors= allElementNotType.WherePasses(orFilter).ToElements();

            //var allWall = allElementNotType.WherePasses(wallCategoryFilter).ToElements();
            //var allWallHasW =
            //    allWall.Where(item => item.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS) != null
            //    && item.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).AsString() == "300").ToList();

            //ParameterValueProvider paraFilter = new ParameterValueProvider(
            //    new ElementId((int)BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS));
            //FilterStringRule stringRule = new FilterStringRule(paraFilter, new FilterStringEquals(), "W");
            //ElementParameterFilter elementParameterFilter = new ElementParameterFilter(stringRule);
            //var allWallHasW2 = allWall.WherePasses(elementParameterFilter).ToList();

            //using (TransactionGroup tg = new TransactionGroup(doc, "GroupEditWall"))
            //{
            //    tg.Start();
            //    foreach (Element el in allWallHasW)
            //    {
            //        using (Transaction t = new Transaction(doc, "EditThickness"))
            //        {
            //            t.Start();
            //            Wall wall = el as Wall;
            //            WallType wallType = wall.WallType;
            //            wallType.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_COMMENTS).Set("300");

            //            CompoundStructure compoundStructure = wallType.GetCompoundStructure();
            //            IList<CompoundStructureLayer> compoundStructureLayers = compoundStructure.GetLayers();

            //            foreach (CompoundStructureLayer layer in compoundStructureLayers)
            //            {
            //                int index = layer.LayerId;
            //                compoundStructure.SetLayerWidth(index, 900 / 304.8);
            //            }
            //            wallType.SetCompoundStructure(compoundStructure);
            //            t.Commit();
            //        }
            //    }
            //    tg.Assimilate();
            //}
            return Result.Succeeded;
        }
    }
}
