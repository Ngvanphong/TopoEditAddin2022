using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditAddin2022.TestBiding
{
    public static class Test4AppShow
    {
        public static Test4Wpf test4Wpf { get; set; }
        public static void ShowTest4Wpf()
        {
            try { test4Wpf.Close(); }
            catch { }
            test4Wpf= new Test4Wpf();
            test4Wpf.Show();
        }
    }
}
