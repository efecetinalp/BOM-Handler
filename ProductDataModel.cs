using ProductStructureTypeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOM_Handler
{
    public class ProductDataModel
    {
        public Product ProductRef { get; set; }
        public int Quantity { get; set; }
        public TreeNode ParentNode { get; set; }
    }
}
