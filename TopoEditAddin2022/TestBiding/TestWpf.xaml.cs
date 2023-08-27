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
    /// Interaction logic for TestWpf.xaml
    /// </summary>
    public partial class TestWpf : Window
    {
        public TestWpf()
        {
            InitializeComponent();

            // tao giao dien bang code behide
            //TextBlock textBlock = new TextBlock();
            //textBlock.Name = "txtName";
            //textBlock.Width = 100;
            //textBlock.Height = 30;
            //textBlock.HorizontalAlignment = HorizontalAlignment.Left;
            //textBlock.VerticalAlignment = VerticalAlignment.Top;
            //textBlock.Inlines.Add("This is textblock behind");
            //this.Content = textBlock;

        }

        private void btnClickButton(object sender, RoutedEventArgs e)
        {
            TaskDialog.Show("Title",txtName.Text);
        }
    }
}
