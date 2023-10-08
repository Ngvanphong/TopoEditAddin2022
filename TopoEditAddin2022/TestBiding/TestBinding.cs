using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Linq;

namespace TopoEditAddin2022.TestBiding
{
    [Transaction(TransactionMode.Manual)]
    public class TestBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc= uiDoc.Document;
            CreateSectionAppShow.ShowCreateSection();

            var typeSection = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).
                Cast<ViewFamilyType>().Where(x=>x.ViewFamily==ViewFamily.Section || x.ViewFamily==ViewFamily.Detail);
            CreateSectionAppShow.formCreateSection.comboboxTypeSections.ItemsSource= typeSection;

            return Result.Succeeded;
        }
    }
}
