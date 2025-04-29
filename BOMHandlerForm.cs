using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFITF;
using MECMOD;
using PARTITF;
using ProductStructureTypeLib;

namespace BOM_Handler
{
    public partial class BOMHandlerForm : Form
    {
        private INFITF.Application CATIA;
        private Document _document;
        private ProductDocument _productDocument;
        private Product _rootProduct;

        public BOMHandlerForm()
        {
            InitializeComponent();
        }

        private void BOMHandlerForm_Load(object sender, EventArgs e)
        {
            CATIA = (INFITF.Application)Marshal.GetActiveObject("CATIA.Application");

            _document = CATIA.ActiveDocument;
            if (_document is ProductDocument)
            {
                _productDocument = (ProductDocument)_document;
                _rootProduct = (Product)_productDocument.Product;
            }
            else
            {
                Debug.Print("Wrong type of document");
                this.Close();
            }
        }

        private void buttonListTree_Click(object sender, EventArgs e)
        {

            TreeNode rootNode = new TreeNode() { Text = _rootProduct.get_PartNumber() };
            
            Products products = _rootProduct.Products;

            if (products.Count > 0)
            {
                GetSubProducts(products, rootNode);
            }

            productTreeView.Nodes.Add(rootNode);
        }

        private void GetSubProducts(Products products, TreeNode parentNode)
        {
            if (parentNode == null) { return; }

            for (int i = 1; i <= products.Count; i++)
            {
                TreeNode treeNode = new TreeNode() { Text = products.Item(i).get_PartNumber() };
                parentNode.Nodes.Add(treeNode);

                if (products.Item(i).Products.Count > 0)
                {
                    GetSubProducts(products.Item(i).Products, treeNode);
                }
            }
        }

        private void buttonExpandAll_Click(object sender, EventArgs e)
        {
            productTreeView.ExpandAll();
        }
    }
}
