using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditAddin2022.TestBiding
{
    public class Folder
    {
        public Folder()
        {
            Childrens = new List<Folder>();
        }
        public string Name { get; set; }
        public List<Folder> Childrens { get; set;}
       
    }
}
