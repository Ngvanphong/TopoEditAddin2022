using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditAddin2022.TestBiding
{
    public static class ListViewAppShow
    {
        public static ListViewWpf ListViewForm { get; set; }

        public static void ShowListView()
        {
            try { ListViewForm.Close(); } catch { }
            DeleteSheetHandler deleteSheetHandler = new DeleteSheetHandler();
            ExternalEvent deleteSheetEvent= ExternalEvent.Create(deleteSheetHandler);

            ListViewForm = new ListViewWpf(deleteSheetEvent);
            ListViewForm.Show();    
        }
    }
}
