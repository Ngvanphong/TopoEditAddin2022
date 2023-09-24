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

            //var collection = new FilteredElementCollector(doc)
            //    .OfCategory(BuiltInCategory.OST_Sheets).WhereElementIsNotElementType()
            //    .Cast<ViewSheet>().ToList();


            //Test4AppShow.ShowTest4Wpf();

            //Test4AppShow.test4Wpf.itemControlSheets.ItemsSource = collection;

            //Test4AppShow.test4Wpf.listBoxSheet.ItemsSource = collection;

            //Test4AppShow.test4Wpf.comboboxSheets.ItemsSource = collection;

            //Test5AppShow.ShowTest5Wpf();

            //var wallTypes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Walls)
            //    .WhereElementIsElementType().Cast<WallType>().ToList();

            //Test5AppShow.test5Wpf.comboboxWallTypes.ItemsSource= wallTypes;


            ListViewAppShow.ShowListView();

            var collection = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Sheets)
                .WhereElementIsNotElementType().Cast<ViewSheet>().ToList();

            List<SheetAction> sheetActions = new List<SheetAction>();
            foreach(var sheet in collection)
            {
                SheetAction sheetAction = new SheetAction();
                sheetAction.Sheet = sheet;
                sheetAction.IsCheck = false;
                sheetActions.Add(sheetAction);
            }

            ListViewAppShow.ListViewForm.listViewSheets.ItemsSource = sheetActions;


          


           









            return Result.Succeeded;
        }
    }
}
