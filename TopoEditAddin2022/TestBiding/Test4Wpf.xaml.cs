using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TopoEditAddin2022.TestBiding
{
    /// <summary>
    /// Interaction logic for Test4Wpf.xaml
    /// </summary>
    public partial class Test4Wpf : Window
    {
        public Test4Wpf()
        {
            InitializeComponent();
        }

        private void checkboxChecked(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowName(object sender, RoutedEventArgs e)
        {
            //var itemSelected = listBoxSheet.SelectedItem as ViewSheet;
            //if(itemSelected != null)
            //{
            //    TaskDialog.Show("Show", $"{itemSelected.SheetNumber} - {itemSelected.Name}");

            //    //TaskDialog.Show("SHow",string.Format("{0} - {1}",itemSelected.SheetNumber,itemSelected.Name));

            //}

            var combobox = comboboxSheets.SelectedItem as ViewSheet;
            if(combobox != null)
            {
                TaskDialog.Show("Show", $"{combobox.SheetNumber} - {combobox.Name}");
            }



        }
    }
}
