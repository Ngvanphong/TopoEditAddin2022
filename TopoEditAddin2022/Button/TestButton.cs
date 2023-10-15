using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TopoEditAddin2022.Properties;

namespace TopoEditAddin2022.Button
{
    public class TestButton
    {
            public void Test(UIControlledApplication application)
            {
                try
                {
                    application.CreateRibbonTab(AppConstants.RibbonName1); // tao riboon neu ribbon da ton tai thi xuong ham catch
                }
                catch { }
                RibbonPanel panelArchitect = null;
                List<RibbonPanel> allPanelOfRevitAPI = application.GetRibbonPanels(AppConstants.RibbonName1); // de get toan bo panel cua ribbon
                foreach (RibbonPanel panelItem in allPanelOfRevitAPI) // kiem tra panel da ton tai hay chua
                {
                    if (panelItem.Name == AppConstants.Panel1)
                    {
                        panelArchitect = panelItem;
                        break;
                    }
                }
                if (panelArchitect == null) // tao panel
                {
                    panelArchitect = application.CreateRibbonPanel(AppConstants.RibbonName1, AppConstants.Panel1); // tao panel
                }

                ImageSource imageSource = Extension.GetImageSource(Resources.Copy);
                PushButtonData testButton = new PushButtonData("TestAddin", "Test \n Function",
                    Assembly.GetExecutingAssembly().Location, "TopoEditAddin2022.TestBiding.TestBinding");
                testButton.ToolTip = "Test button";
                testButton.LongDescription = "Test button";
                testButton.Image = imageSource;
                testButton.LargeImage = imageSource;
                panelArchitect.AddItem(testButton).Enabled = true;
            }
    }
}
