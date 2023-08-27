using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditAddin2022.TestBiding
{
    public static class Test2AppShow
    {
        public static Test2Wpf test2Form;
        public static void ShowTest2Form()
        {
            try
            {
                test2Form.Close();
            }
            catch { }
            test2Form= new Test2Wpf();
            test2Form.Show();
        }
    }
}
