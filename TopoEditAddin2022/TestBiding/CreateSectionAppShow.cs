using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditAddin2022.TestBiding
{
    public static class CreateSectionAppShow
    {
        public static CreateSectionWpf formCreateSection;
        public static void ShowCreateSection()
        {
            try { formCreateSection.Close(); } catch { }

            CreateSectionHandler handler = new CreateSectionHandler();
            ExternalEvent createSectionEvent= ExternalEvent.Create(handler);
            formCreateSection = new CreateSectionWpf(createSectionEvent);
            formCreateSection.Show();
            
        }
    }
}
