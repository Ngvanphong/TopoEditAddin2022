using Autodesk.Revit.UI.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TopoEditAddin2022.Properties;
using TopoEditAddin2022.EditTopo;

namespace TopoEditAddin2022.Button
{
    public class TopoEditButton
    {
        public void EditTopo(UIControlledApplication application) // uicontrolledapplication la de quan ly ribbon, panel , button,...
        {
            try
            {
                application.CreateRibbonTab(AppConstants.RibbonName1); // tao riboon neu ribbon da ton tai thi xuong ham catch
            }
            catch{}
            RibbonPanel panelArchitect = null;
            List<RibbonPanel> allPanelOfRevitAPI= application.GetRibbonPanels(AppConstants.RibbonName1); // de get toan bo panel cua ribbon
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
            PushButtonData topoEditButton = new PushButtonData("TopoEditPoint", "Topo \n Edit",
                Assembly.GetExecutingAssembly().Location, "TopoEditAddin2022.EditTopo.TopoEditBinding");
            topoEditButton.ToolTip = "Edit topo";
            topoEditButton.LongDescription = "Edit topo description";
            topoEditButton.Image = imageSource;
            topoEditButton.LargeImage = imageSource;
            panelArchitect.AddItem(topoEditButton).Enabled = true;

            TextBoxData textBoxData = new TextBoxData("textPointCountTopo");
            var textBox = panelArchitect.AddItem(textBoxData) as TextBox;    // them text box vao panel

            string name = textBox.Name;
            if (name == "textPointCountTopo")
            {
                textBox.Width = 70.0;
                textBox.Value = "1";
                textBox.EnterPressed += new EventHandler<TextBoxEnterPressedEventArgs>(SetCountDivide);
            }
            panelArchitect.AddSeparator();
        }

        private void SetCountDivide(object sender, TextBoxEnterPressedEventArgs args)
        {
            int count = 0;
            bool isInterger = int.TryParse((sender as TextBox).Value as string, out count);
            if(isInterger)
            {
                EditTopoCommon.CountDivide = count;
            }  
        }


    }
}
