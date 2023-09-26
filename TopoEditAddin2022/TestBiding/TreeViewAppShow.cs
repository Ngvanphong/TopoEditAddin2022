using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditAddin2022.TestBiding
{
    public static class TreeViewAppShow
    {
        public static TreeViewWpf TreeViewForm { get; set; }

        public static void ShowTreeView()
        {
            try { TreeViewForm.Close(); } catch { }
            TreeViewForm = new TreeViewWpf();
            TreeViewForm.Show();
        }
    }
}
