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
    /// Interaction logic for Test2Wpf.xaml
    /// </summary>
    public partial class Test2Wpf : Window
    {
        private bool IsCheckColumn = false;
        private bool IsCheckBeam= false;
        private bool IsCheckSlab = false;
        public Test2Wpf()
        {
            InitializeComponent();
        }

        private void btnClickButton2(object sender, RoutedEventArgs e)
        {
            //string contentCheck = string.Empty;
            //if (IsCheckBeam) contentCheck+=" Beam";
            //if (IsCheckSlab) contentCheck += " Slab";
            //if (IsCheckColumn) contentCheck += " Column";
            //TaskDialog.Show("Title", contentCheck);

            //string content2 = string.Empty;
            //if (checkBeam.IsChecked == true) content2 += " Beam";
            //if (checkColumn.IsChecked == true) content2 += " Column";
            //if (checkSlab.IsChecked == true) content2 += " Slab";
            //TaskDialog.Show("Title", content2);

        }
        

        private void checkBeamChecked(object sender, RoutedEventArgs e)
        {
            IsCheckBeam = true;
        }

        private void checkColumnChecked(object sender, RoutedEventArgs e)
        {
            IsCheckColumn = true;
        }

        private void checkSlabCheck(object sender, RoutedEventArgs e)
        {
            IsCheckSlab = true;
        }

        private void unCheckColumn(object sender, RoutedEventArgs e)
        {
            IsCheckColumn = false;
        }

        private void unCheckSlab(object sender, RoutedEventArgs e)
        {
            IsCheckSlab = false;
        }

        private void unCheckBeam(object sender, RoutedEventArgs e)
        {
            IsCheckBeam = false;
        }

        private void checkedAll(object sender, RoutedEventArgs e)
        {
           /* checkSlab.IsChecked = true;
            checkBeam.IsChecked = true;
            checkColumn.IsChecked = true;*/
        }

        private void UnCheckedAll(object sender, RoutedEventArgs e)
        {
           /* checkSlab.IsChecked = false;
            checkBeam.IsChecked = false;
            checkColumn.IsChecked = false;*/
        }
    }
}
