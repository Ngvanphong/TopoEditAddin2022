﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

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


            //var collecitonIDs = uiDoc.Selection.GetElementIds();

            //List<FamilyInstance> familyInstances = new List<FamilyInstance>();
            //foreach (ElementId id in collecitonIDs)
            //{
            //    Element element = doc.GetElement(id);
            //    FamilyInstance instance = element as FamilyInstance;
            //    if (instance != null)
            //    {
            //        if (instance.Category != null && instance.Category.Id.IntegerValue
            //            == (int)BuiltInCategory.OST_Columns)
            //        {
            //            familyInstances.Add(instance);
            //        }
            //    }
            //}

            ////var point1 = uiDoc.Selection.PickPoint("Pick a point");
            ////var point2 = uiDoc.Selection.PickPoint("Pick a point");
            ////var pickRectange = uiDoc.Selection.PickElementsByRectangle("Pick a rectange");

            ////var pickObject = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
            ////Element elementPick = doc.GetElement(pickObject);


            //var pickObjectFace = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Face);
            //Face face = doc.GetElement(pickObjectFace).GetGeometryObjectFromReference(pickObjectFace) as Face;


            //var colleciton= new FilteredElementCollector(doc)
            //    .OfCategory(BuiltInCategory.OST_StructuralFraming).WhereElementIsElementType().ToList();

            //using(Transaction t= new Transaction(doc, "CreateBeam"))
            //{
            //    t.Start();

            //    for( int i = 0;i < colleciton.Count; i++)
            //    {
            //        XYZ point1 = XYZ.Zero - XYZ.BasisY * i * 500/304.8;
            //        XYZ point2 = point1 + XYZ.BasisX * 3000 / 304.8;
            //        Line line = Line.CreateBound(point1, point2);
            //        FamilySymbol symbol = colleciton[i] as FamilySymbol;
            //        if (!symbol.IsActive) symbol.Activate();
            //        var beam = doc.Create.NewFamilyInstance(line, symbol,
            //            doc.ActiveView.GenLevel, Autodesk.Revit.DB.Structure.StructuralType.Beam);

            //        var colum = doc.Create.NewFamilyInstance(new XYZ(0, 0, 0), symbol,
            //            Autodesk.Revit.DB.Structure.StructuralType.Column);
            //        //Revit

            //        var familyInstance3 = doc.Create.NewFamilyInstance(new XYZ(0, 0, 0), symbol,
            //            Autodesk.Revit.DB.Structure.StructuralType.NonStructural);


            //        var lighting = doc.Create.NewFamilyInstance(face, new XYZ(0,0,0), XYZ.BasisZ,symbol);


            //        var floor = Floor.Create(doc, new List<CurveLoop>(), symbol.Id, doc.ActiveView.GenLevel.Id);

            //        ReferencePlane referencePlane = null;
            //        Plane plane = Plane.CreateByNormalAndOrigin(XYZ.BasisX, XYZ.Zero);
            //        SketchPlane sk = SketchPlane.Create(doc, plane);
            //        referencePlane = sk.getRe

            //        RoofType roofType = null;
            //        var roof = doc.Create.NewExtrusionRoof(new CurveArray(),
            //            plannarFace.Reference, doc.ActiveView.GenLevel.Id, roofType, 0, 1000);




            //        Element beamType= doc.GetElement(beam.GetTypeId());
            //        beamType.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("11");

            //        double vaule= beam.LookupParameter("MinhDinhNghia").AsDouble();




            //    } 

            //t.Commit();

            //Line line = null;
            //XYZ start = line.GetEndPoint(0);
            //XYZ end= line.GetEndPoint(1);

            //XYZ vector = end - start;
            //double lenth = vector.GetLength();
            //XYZ normalizeVector= vector.Normalize();


            //Wall wall = null;
            //LocationCurve locationCurve = wall.Location as LocationCurve;
            //Curve curve = locationCurve.Curve;
            //Line line = curve as Line;
            //if (line != null)
            //{
            //    // tuong thang
            //    XYZ directionLine = line.Direction;
            //    XYZ vuonggocLine = directionLine.CrossProduct(XYZ.BasisZ).Normalize(); // vector vuong 

            //    XYZ vectorTranslate = vuonggocLine * 200 / 304.8;

            //    Transform moveTransform = Transform.CreateTranslation(vectorTranslate);
            //    XYZ newStart = moveTransform.OfPoint(line.GetEndPoint(0));
            //    XYZ endStart = moveTransform.OfPoint(line.GetEndPoint(1));
            //    Line lineOffset1 = Line.CreateBound(newStart, newStart);

            //    Transform moveTransform2 = Transform.CreateTranslation(-vectorTranslate);
            //    XYZ newStart1 = moveTransform.OfPoint(line.GetEndPoint(0));
            //    XYZ endStart1 = moveTransform.OfPoint(line.GetEndPoint(1));
            //    Line lineOffset2 = Line.CreateBound(newStart1, newStart1);


            //    // quay line
            //    XYZ start = line.GetEndPoint(0);
            //    XYZ end = line.GetEndPoint(1);

            //    // Move truc Z den diem start cua line;
            //    XYZ vectorToStart = start - XYZ.Zero;
            //    Transform translate = Transform.CreateTranslation(vectorToStart);
            //    XYZ axis = translate.OfVector(XYZ.BasisZ);

            //    // quay diem cuoi cua line mot goc 45 quanh truc tai diem start
            //    Transform rotionTransoform = Transform.CreateRotation(axis, Math.PI / 4);
            //    XYZ newEndP = rotionTransoform.OfPoint(end);

            //    Line lineRotaion = Line.CreateBound(start, newEndP);



            //    Line line1 = null;
            //    Line line2 = null;

            //    XYZ direction1 = line1.Direction;
            //    XYZ direction2 = line2.Direction;
            //    double tichVoHuong = direction1.DotProduct(direction2);
            //    //if(tichVoHuong==0) thi line1 va line2 vuong goc

            //    //if (tichVoHuong == 1||  tichVoHuong == -1) thi 2 vector song song


            //    //var isIntersection = line1.Intersect(line2, out var listPoint);
            //    //if(isIntersection== SetComparisonResult.Disjoint)
            //    //{
            //    //    // 2 line khong giao nhau
            //    //}else if(isIntersection==SetComparisonResult.Overlap)
            //    //{
            //    //    // 2 line co it nhat 1 diem chung
            //    //}




            //    Transform transform = Transform.Identity;
            //    transform.BasisX = XYZ.BasisY;
            //    transform.BasisY = XYZ.BasisZ;
            //    transform.BasisZ = XYZ.BasisX;

            //    XYZ pointOrigin = XYZ.Zero;










            //}
            //else
            //{
            //    // Lam tuong cong
            //}








            //}








            Transform transform = Transform.Identity;
            transform.BasisX = XYZ.BasisY;
            transform.BasisY = XYZ.BasisZ;
            transform.BasisZ = XYZ.BasisX;

            XYZ pointOrigin = new XYZ(1,2,3);

            XYZ newPoint = transform.OfPoint(pointOrigin);


            ViewSection view = null; ;
            XYZ upVector = view.UpDirection;
            XYZ rightVector= view.RightDirection;
            XYZ directionView = view.ViewDirection;


            Transform transform2 = Transform.Identity;
            transform.BasisX = rightVector;
            transform.BasisY = upVector;
            transform.BasisZ = directionView;



            Transform trasfromMatBang = Transform.Identity;
            trasfromMatBang.BasisX = XYZ.BasisY;
            trasfromMatBang.BasisY = XYZ.BasisZ;
            trasfromMatBang.BasisZ = XYZ.BasisX;
            XYZ newPoint1= trasfromMatBang.OfPoint(pointOrigin);

            Transform transformMatDung= trasfromMatBang;
            transformMatDung.BasisX = rightVector;
            transformMatDung.BasisY = upVector;
            transformMatDung.BasisZ = directionView;

            XYZ newPont2= transformMatDung.OfPoint(newPoint1);









            return Result.Succeeded;
        }
    }
}
