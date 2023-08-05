using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;


namespace TopoEditAddin2022.EditTopo
{
    [Transaction(TransactionMode.Manual)]
    public class TopoEditBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Addin", EditTopoCommon.CountDivide.ToString());
            return Result.Succeeded;
        }
    }
}
