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
            //UIDocument uiDoc = commandData.Application.ActiveUIDocument; // quan ly click , selecion, thao tac..
            //Document doc = uiDoc.Document; // quan ly toan bo du lieu

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



            //TreeViewAppShow.ShowTreeView();

            //List<Folder> treeFolder= new List<Folder>();

            //Folder folder1= new Folder();
            //folder1.Name = "C";

            //var folerChild1= new Folder();
            //folerChild1.Name = "Autodesk";
            //folder1.Childrens.Add(folerChild1);

            //var folerChild2 = new Folder();
            //folerChild2.Name = "Dell";
            //folder1.Childrens.Add(folerChild2);

            //var folerChild3 = new Folder();
            //folerChild3.Name = "Child Autodesk";
            //folerChild1.Childrens.Add(folerChild3);
            //treeFolder.Add(folder1);

            //TreeViewAppShow.TreeViewForm.treeView.ItemsSource = treeFolder;




            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;


            var collecitonIDs = uiDoc.Selection.GetElementIds();

            List<FamilyInstance> familyInstances = new List<FamilyInstance>();
            foreach (ElementId id in collecitonIDs)
            {
                Element element = doc.GetElement(id);
                FamilyInstance instance = element as FamilyInstance;
                if (instance != null)
                {
                    if (instance.Category != null && instance.Category.Id.IntegerValue
                        == (int)BuiltInCategory.OST_Columns)
                    {
                        familyInstances.Add(instance);
                    }
                }
            }

            //var point1 = uiDoc.Selection.PickPoint("Pick a point");
            //var point2 = uiDoc.Selection.PickPoint("Pick a point");
            //var pickRectange = uiDoc.Selection.PickElementsByRectangle("Pick a rectange");

            //var pickObject = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
            //Element elementPick = doc.GetElement(pickObject);


            var pickObjectFace = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Face);
            Face face = doc.GetElement(pickObjectFace).GetGeometryObjectFromReference(pickObjectFace) as Face;


            var colleciton= new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructuralFraming).WhereElementIsElementType().ToList();
            
            using(Transaction t= new Transaction(doc, "CreateBeam"))
            {
                t.Start();

                for( int i = 0;i < colleciton.Count; i++)
                {
                    XYZ point1 = XYZ.Zero - XYZ.BasisY * i * 500/304.8;
                    XYZ point2 = point1 + XYZ.BasisX * 3000 / 304.8;
                    Line line = Line.CreateBound(point1, point2);
                    FamilySymbol symbol = colleciton[i] as FamilySymbol;
                    if (!symbol.IsActive) symbol.Activate();
                    var beam = doc.Create.NewFamilyInstance(line, symbol,
                        doc.ActiveView.GenLevel, Autodesk.Revit.DB.Structure.StructuralType.Beam);

                    var colum = doc.Create.NewFamilyInstance(new XYZ(0, 0, 0), symbol,
                        Autodesk.Revit.DB.Structure.StructuralType.Column);
                    //Revit

                    var familyInstance3 = doc.Create.NewFamilyInstance(new XYZ(0, 0, 0), symbol,
                        Autodesk.Revit.DB.Structure.StructuralType.NonStructural);

                    
                    var lighting = doc.Create.NewFamilyInstance(face, new XYZ(0,0,0), XYZ.BasisZ,symbol);


                    var floor = Floor.Create(doc, new List<CurveLoop>(), symbol.Id, doc.ActiveView.GenLevel.Id);

                    ReferencePlane referencePlane = null;
                    Plane plane = Plane.CreateByNormalAndOrigin(XYZ.BasisX, XYZ.Zero);
                    SketchPlane sk = SketchPlane.Create(doc, plane);
                    referencePlane = sk.getRe

                    RoofType roofType = null;
                    var roof = doc.Create.NewExtrusionRoof(new CurveArray(),
                        plannarFace.Reference, doc.ActiveView.GenLevel.Id, roofType, 0, 1000);




                    Element beamType= doc.GetElement(beam.GetTypeId());
                    beamType.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("11");
                    
                    double vaule= beam.LookupParameter("MinhDinhNghia").AsDouble();




                } 
                    
                t.Commit();
            }














            return Result.Succeeded;
        }
    }
}
