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
            TreeNode treeNode = new TreeNode();
            foreach (var product in productDatas)
            {
                treeNode.Text = Text = product.Quantity + "x | " + product.ProductRef.get_PartNumber();
                parentNode.Nodes.Add(treeNode);
            }

            foreach (var product in productDatas)
            {
                if (product.ProductRef.Products.Count > 0)
                {
                    GetSubProducts(product.ProductRef.Products, treeNode);
                }
            }

            //for (int i = 0; i < productsList.Count; i++)
            //{
            //    //Next iteration
            //    if (productsList[i].Products.Count > 0)
            //    {
            //        GetSubProducts(productsList[i].Products, treeNode);
            //    }
            //}
        }

        public List<ProductDataModel> CountUniqueNames(Products products)
        {
            List<string> productNames = new List<string>();
            List<ProductDataModel> uniqueProducts = new List<ProductDataModel>();

            for (int i = 1; i <= products.Count; i++)
            {
                productNames.Add(products.Item(i).get_PartNumber());
            }

            for (int i = 1; i <= products.Count; i++)
            {
                Debug.Print(uniqueProducts.Select(x => x.ProductRef.get_PartNumber()).Equals(products.Item(i).get_PartNumber()).ToString());

                if (!uniqueProducts.Select(x => x.ProductRef.get_PartNumber()).Equals( products.Item(i).get_PartNumber()))
                {
                    uniqueProducts.Add(new ProductDataModel
                    {
                        ProductRef = products.Item(i).ReferenceProduct,
                        Quantity = 1
                    });
                }
                else
                {
                    foreach (var item in uniqueProducts)
                    {
                        if (item.ProductRef.get_PartNumber() == products.Item(i).get_PartNumber())
                        {
                            item.Quantity++;
                        }
                    }
                }
            }
            Debug.Print(uniqueProducts.Count.ToString());
            return uniqueProducts;
        }

        public Dictionary<Product, int> CountUniqueNamesOld(Products products)
        {
            Dictionary<Product, int> tempDict = new Dictionary<Product, int>();
            Dictionary<Product, int> uniqueProducts = new Dictionary<Product, int>();

            for (int i = 1; i <= products.Count; i++)
            {
                tempDict = uniqueProducts;
                bool isFound = false;
                foreach (var uniqueProduct in tempDict)
                {
                    if (uniqueProduct.Key.get_PartNumber() == products.Item(i).get_PartNumber())
                    {
                        int tempCount = uniqueProduct.Value;
                        tempCount++;
                        uniqueProducts[uniqueProduct.Key] = tempCount;
                        isFound = true;
                        continue;
                    }
                }

                if (!isFound)
                {
                    uniqueProducts.Add(products.Item(i), 1);
                }

            }

            return uniqueProducts;
        }

        private void buttonExpandAll_Click(object sender, EventArgs e)
        {
            productTreeView.ExpandAll();
        }
    }
}
