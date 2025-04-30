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
using System.Xml.Linq;
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

            //Check if the same parts available
            List<ProductDataModel> productDatas = CountUniqueNames(products);

            foreach (var product in productDatas)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = Text = product.Quantity + "x | " + product.ProductRef.get_PartNumber();
                product.ParentNode = treeNode;
                parentNode.Nodes.Add(treeNode);
            }

            foreach (var product in productDatas)
            {
                if (product.ProductRef.Products.Count > 0)
                {
                    GetSubProducts(product.ProductRef.Products, product.ParentNode);
                }
            }
        }

        public List<ProductDataModel> CountUniqueNames(Products products)
        {
            List<string> productNames = new List<string>();
            List<Product> productList = new List<Product>();
            List<string> uniqueProductNames;
            List<ProductDataModel> uniqueProducts = new List<ProductDataModel>();

            for (int i = 1; i <= products.Count; i++)
            {
                productNames.Add(products.Item(i).get_PartNumber());
                productList.Add(products.Item(i));
            }

            //get unique product names
            uniqueProductNames = productNames.Distinct().ToList();

            foreach (var uniqueName in uniqueProductNames)
            {
                Product catchProduct = null;
                int count = 0;
                for (int i = 0; i < productNames.Count; i++)
                {
                    if (uniqueName == productNames[i])
                    {
                        catchProduct = productList[i].ReferenceProduct;
                        count++;
                    }
                }

                uniqueProducts.Add(new ProductDataModel()
                {
                    ProductRef = catchProduct,
                    Quantity = count
                });
            }
            
            return uniqueProducts;
        }

        private void buttonExpandAll_Click(object sender, EventArgs e)
        {
            productTreeView.ExpandAll();
        }
    }
}
