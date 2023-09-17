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
using Autodesk.Revit.UI;

namespace TopoEditAddin2022.TestBiding
{
    /// <summary>
    /// Interaction logic for Test5Wpf.xaml
    /// </summary>
    public partial class Test5Wpf : Window
    {
        private ExternalEvent _changeTypeWallEvent;
        public Test5Wpf(ExternalEvent changeTypeWallEvent)
        {
            InitializeComponent();
            _changeTypeWallEvent = changeTypeWallEvent;
        }

        private void btnClickOk(object sender, RoutedEventArgs e)
        {
            _changeTypeWallEvent.Raise();
        }
    }
}
