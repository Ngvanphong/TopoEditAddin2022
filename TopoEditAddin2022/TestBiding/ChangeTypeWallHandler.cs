using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditAddin2022.TestBiding
{
    public class ChangeTypeWallHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc = uiDoc.Document;

            var selectIds = uiDoc.Selection.GetElementIds();
            IList<Wall> listWallSelected= new List<Wall>();
            foreach(ElementId id in selectIds)
            { 
                Element element= doc.GetElement(id);
                if(element is Wall) listWallSelected.Add(element as Wall);
            }

            var wallTypeSelected = Test5AppShow.test5Wpf.comboboxWallTypes.SelectedItem as WallType;
            if(wallTypeSelected != null)
            {
                using(Transaction t= new Transaction(doc, "ChangeWallType"))
                {
                    t.Start();
                    foreach(Wall wall in listWallSelected)
                    {
                        wall.WallType= wallTypeSelected;
                    }

                    t.Commit();
                }
            }

            

        }

        public string GetName()
        {
            return "ChangeTypeWallHandler";
        }
    }
}
