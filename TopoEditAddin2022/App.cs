using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopoEditAddin2022.Button;

namespace TopoEditAddin2022
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            TopoEditButton topoEditButton= new TopoEditButton();
            topoEditButton.EditTopo(a);
            TestButton testButton= new TestButton();
            testButton.Test(a);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
