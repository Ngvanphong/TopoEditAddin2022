using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TopoEditAddin2022.TestBiding
{
    public static class TestAppShow
    {
        public static TestWpf formTest;
        public static void ShowForm()
        {
            try
            {
                formTest.Close();
            }
            catch { }
            formTest= new TestWpf();
            formTest.Show();
        }
    }
}
