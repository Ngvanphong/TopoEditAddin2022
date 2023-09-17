using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace TopoEditAddin2022.TestBiding
{
    public static class Test5AppShow
    {
        public static  Test5Wpf test5Wpf;
        public static void ShowTest5Wpf()
        {
            try { test5Wpf.Close(); } catch { }

            ChangeTypeWallHandler changeTypeWallHandler = new ChangeTypeWallHandler();
            ExternalEvent changeWallEvent= ExternalEvent.Create(changeTypeWallHandler);

            test5Wpf= new Test5Wpf(changeWallEvent);
            test5Wpf.Show();
        }
    }
}
