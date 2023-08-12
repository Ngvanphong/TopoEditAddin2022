using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace TopoEditAddin2022.TestBiding
{
    [Transaction(TransactionMode.Manual)]
    public class TestBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument; // quan ly click , selecion, thao tac..
            Document doc = uiDoc.Document; // quan ly toan bo du lieu

            ICollection<ElementId> ids= uiDoc.Selection.GetElementIds();  // lay toan bo id cua doi tuong dang chon.
            IList<Wall> walls = new List<Wall>();
            foreach(ElementId id in ids )
            {
                Element element= doc.GetElement(id); // get element tu element id thong qua doc
                // Kiem tra category cua element co phai la wall khong
                if(element.Category != null && element.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Walls)
                {
                    Wall wall = element as Wall;
                    walls.Add(wall); // ep kieu element thanh wall, do wall ke thua tu element nen ep kieu duoc
                }
            }
            
            string value = "Tuong 1";
            // se sua hoac tao moi bat cu thu gi trong revit.
            using(TransactionGroup tg = new TransactionGroup(doc, "GroupTransaaction"))
            {
                tg.Start();
                foreach (Wall item in walls)
                {
                    using (Transaction t = new Transaction(doc, "SetComments"))
                    {
                        t.Start();
                        //Parameter paraComment = item.LookupParameter("Type Comments"); // get parameter theo name truyen vao.
                        //if (paraComment != null) paraComment.Set(value); //set gia tri cho parameter;
                        //Parameter para = item.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                        //para.Set(value);
                        ParameterSet parameters= item.Parameters;
                        foreach (Parameter p in parameters)
                        {
                            if(p.Definition.Name== "Type Comments")
                            {
                                p.Set(value);
                                break;
                            }
                        }
                        t.Commit();
                    }
                }
                tg.Assimilate();
            }
            
            


            return Result.Succeeded;
        }
    }
}
