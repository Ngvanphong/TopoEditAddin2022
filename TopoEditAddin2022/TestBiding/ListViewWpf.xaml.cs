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
    /// Interaction logic for ListViewWpf.xaml
    /// </summary>
    public partial class ListViewWpf : Window
    {
        private readonly ExternalEvent _deleteSheetEvent;
        public ListViewWpf(ExternalEvent deleteSheetEvent)
        {
            InitializeComponent();
            _deleteSheetEvent = deleteSheetEvent;
        }

        private void btnChooseSheet(object sender, RoutedEventArgs e)
        {
            //var allItem = listViewSheets.Items;
            //List<SheetAction> listChecked= new List<SheetAction>();
            //foreach ( var item in allItem ) 
            //{
            //    SheetAction sheet = item as SheetAction;
            //    if( sheet != null && sheet.IsCheck)
            //    {
            //        listChecked.Add(sheet);
            //    }
            //}
            //TaskDialog.Show("Title", listChecked.FirstOrDefault().Sheet.Name);

            _deleteSheetEvent.Raise();
        }
    }
}
