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
using ClosedXML.Excel;
using DashboardUI;
using DocumentFormat.OpenXml.Spreadsheet;
using INFITF;
using MECMOD;
using PARTITF;
using ProductStructureTypeLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

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
            new DropShadow().ApplyShadows(this);
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

        #region List Product Tree Method

        private void buttonListTree_Click(object sender, EventArgs e)
        {
            FetchProductListAsync();
        }

        private void FetchProductListAsync()
        {
            TreeNode rootNode = new TreeNode() { Text = _rootProduct.get_PartNumber() };

            Products products = _rootProduct.Products;

            if (products.Count > 0)
            {
                GetSubProductsAsync(products, rootNode);
            }

            productTreeView.ImageList = productTreeImages;
            productTreeView.Nodes.Add(rootNode);
            rootNode.ImageIndex = 1;

        }

        private void GetSubProductsAsync(Products products, TreeNode parentNode)
        {
            if (parentNode == null) { return; }

            //Check if the same parts available
            List<ProductDataModel> productDatas = CountUniqueNames(products);

            foreach (var product in productDatas)
            {
                TreeNode subTreeNode;
                if (product.ProductRef.Products.Count > 0)
                {
                    subTreeNode = new TreeNode();
                    subTreeNode.Text = Text = product.Quantity + "x | " + product.ProductRef.get_PartNumber();
                    parentNode.Nodes.Add(subTreeNode);
                    subTreeNode.ImageIndex = 1;
                    GetSubProductsAsync(product.ProductRef.Products, subTreeNode);
                }
                else
                {
                    subTreeNode = new TreeNode();
                    subTreeNode.Text = Text = product.Quantity + "x | " + product.ProductRef.get_PartNumber();
                    parentNode.Nodes.Add(subTreeNode);
                    subTreeNode.ImageIndex = 0;
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

        #endregion

        #region Utility Buttons

        private void buttonExpandAll_Click(object sender, EventArgs e)
        {
            productTreeView.ExpandAll();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void buttonExportToExcel_Click(object sender, EventArgs e)
        {
            var workbook = new XLWorkbook();

            string sheetName = _rootProduct.get_PartNumber() + "-BOM";

            workbook.AddWorksheet(sheetName);
            var ws = workbook.Worksheet(sheetName);

            xlsRow = 1;
            for (int i = 0; i < productTreeView.Nodes.Count; i++)
            {
                ws.Cell(1, 1).Value = productTreeView.Nodes[i].Text;

                if (productTreeView.Nodes[i].Nodes.Count > 0)
                {
                    GetSubTreeNodes(ws, 1, productTreeView.Nodes[i]);
                }
            }

            string path = "C:\\Users\\ECETINALP\\Desktop\\test.xlsx";
            workbook.SaveAs(path);

            MessageBox.Show("Exported successfuly on location:" + Environment.NewLine + path, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int xlsRow = 1;

        private void GetSubTreeNodes(IXLWorksheet ws, int col, TreeNode parentNode)
        {
            for (int i = 0; i < parentNode.Nodes.Count; i++)
            {
                xlsRow++;
                ws.Cell(xlsRow, col + 1).Value = parentNode.Nodes[i].Text;
                
                if (parentNode.Nodes[i].Nodes.Count > 0)
                {
                    GetSubTreeNodes(ws, col + 1, parentNode.Nodes[i]);
                    //row += parentNode.Nodes[i].Nodes.Count;
                }
            }
        }

        #region Drag To Move

        //Form window drag to move
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void BOMHandlerForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion
    }
}
