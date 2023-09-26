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
using System.ComponentModel;
using System.Windows.Data;

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


            //ListViewAppShow.ShowListView();

            //var collection = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Sheets)
            //    .WhereElementIsNotElementType().Cast<ViewSheet>().ToList();

            //List<SheetAction> sheetActions = new List<SheetAction>();
            //foreach(var sheet in collection)
            //{
            //    SheetAction sheetAction = new SheetAction();
            //    sheetAction.Sheet = sheet;
            //    sheetAction.IsCheck = false;
            //    sheetActions.Add(sheetAction);
            //}

            //ListViewAppShow.ListViewForm.listViewSheets.ItemsSource = sheetActions;

            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewAppShow.ListViewForm.listViewSheets.ItemsSource);
            //view.SortDescriptions.Add(new SortDescription("Sheet.SheetNumber", ListSortDirection.Ascending));



            TreeViewAppShow.ShowTreeView();

            List<Folder> treeFolder= new List<Folder>();

            Folder folder1= new Folder();
            folder1.Name = "C";
            
            var folerChild1= new Folder();
            folerChild1.Name = "Autodesk";
            folder1.Childrens.Add(folerChild1);

            var folerChild2 = new Folder();
            folerChild2.Name = "Dell";
            folder1.Childrens.Add(folerChild2);

            var folerChild3 = new Folder();
            folerChild3.Name = "Child Autodesk";
            folerChild1.Childrens.Add(folerChild3);
            treeFolder.Add(folder1);

            TreeViewAppShow.TreeViewForm.treeView.ItemsSource = treeFolder;











            return Result.Succeeded;
        }
    }
}
