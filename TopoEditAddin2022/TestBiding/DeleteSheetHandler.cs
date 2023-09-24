
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace TopoEditAddin2022.TestBiding
{
    public class DeleteSheetHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc = uiDoc.Document;
            ////
            ///

            var allItems = ListViewAppShow.ListViewForm.listViewSheets.Items;

            using(Transaction t= new Transaction(doc, "DeleteSheet"))
            {
                t.Start();
                foreach (var item in allItems)
                {
                    SheetAction sheetAction = item as SheetAction;
                    if(sheetAction != null && sheetAction.IsCheck) 
                    {
                        doc.Delete(sheetAction.Sheet.Id);
                    }
                }
                t.Commit();
            }


        }

        public string GetName()
        {
            return "DeleteSheetHandler";
        }
    }
}
