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
    /// Interaction logic for CreateSectionWpf.xaml
    /// </summary>
    public partial class CreateSectionWpf : Window
    {
        private readonly ExternalEvent _createSectionEvent;
        public CreateSectionWpf(ExternalEvent createSectionEvent)
        {
            InitializeComponent();
            _createSectionEvent = createSectionEvent;
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            _createSectionEvent.Raise();
        }
    }
}
