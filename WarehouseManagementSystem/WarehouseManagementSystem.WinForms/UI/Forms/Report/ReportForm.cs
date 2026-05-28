using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WarehouseManagementSystem.WinForms.Controllers;
using WarehouseManagementSystem.WinForms.Files;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Report
{
    public partial class ReportForm : UserControl
    {
        private ReportController controller;
        private DataGridView currentGrid;
        private List<Product> products;
        private List<InventoryItem> inventory;
        private List<ImportInvoice> imports;
        private List<ExportInvoice> exports;
        private List<Batch> batches;

        public ReportForm()
        {
            InitializeComponent();

            controller = new ReportController();

            products = FileHelper.ReadJsonList<Product>("products.json");
            batches = FileHelper.ReadJsonList<Batch>("batch.json");
            imports = FileHelper.ReadJsonList<ImportInvoice>("import.json");
            exports = FileHelper.ReadJsonList<ExportInvoice>("export.json");

            if (products == null) products = new List<Product>();
            if (inventory == null) inventory = new List<InventoryItem>();
            if (imports == null) imports = new List<ImportInvoice>();
            if (exports == null) exports = new List<ExportInvoice>();

            cboType.Items.Add("Inventory Report");
            cboType.Items.Add("Low Stock Report");
            cboType.Items.Add("Import/Export Statistics");

            cboType.SelectedIndexChanged += RefreshEvent;
            cboCategory.SelectedIndexChanged += RefreshEvent;
            dtStart.ValueChanged += RefreshEvent;
            dtEnd.ValueChanged += RefreshEvent;

            LoadCategories();

            cboType.SelectedIndex = 0;

            RefreshReport();
        }
        private string GetProductCategory(
    string productId)
        {
            int i = 0;

            while (i < products.Count)
            {
                if (products[i].ProductID == productId)
                {
                    return products[i].Category;
                }

                i++;
            }

            return "";
        }

        private void RefreshEvent(object sender, EventArgs e)
        {
            RefreshReport();
        }

        private void RefreshReport()
        {
            chartReport.Series.Clear();
            chartReport.ChartAreas.Clear();
            chartReport.Titles.Clear();
            chartReport.Legends.Clear();

            chartReport.ChartAreas.Add(
                new ChartArea("Main"));

            dgvReport.DataSource = null;

            pnlSummary.Controls.Clear();

            if (cboType.SelectedIndex == 0)
            {
                // INVENTORY

                tlContent.RowStyles[0].Height = 55;
                tlContent.RowStyles[1].Height = 0;
                tlContent.RowStyles[2].Height = 45;

                tlContent.RowStyles[1].SizeType =
                    SizeType.Percent;

                chartReport.Visible = true;
                pnlSummary.Visible = false;
                dgvReport.Visible = true;

                LoadInventory();
            }
            else if (cboType.SelectedIndex == 1)
            {
                // LOW STOCK

                tlContent.RowStyles[0].Height = 0;
                tlContent.RowStyles[1].Height = 0;
                tlContent.RowStyles[2].Height = 100;

                chartReport.Visible = false;
                pnlSummary.Visible = false;
                dgvReport.Visible = true;

                LoadLowStock();
            }
            else
            {
                // IMPORT EXPORT

                tlContent.RowStyles[0].Height = 55;
                tlContent.RowStyles[1].Height = 15;
                tlContent.RowStyles[2].Height = 0;

                chartReport.Visible = true;
                pnlSummary.Visible = true;
                dgvReport.Visible = false;

                LoadImportExport();
            }
        }


        private void LoadCategories()
        {
            List<Product> products = FileHelper.ReadJsonList<Product>("products.json");

            if (products == null)
                products = new List<Product>();

            List<string> categories = new List<string>();

            for (int i = 0; i < products.Count; i++)
            {
                if (!categories.Contains(products[i].Category))
                    categories.Add(products[i].Category);
            }

            cboCategory.Items.Clear();
            cboCategory.Items.Add("All Categories");

            for (int i = 0; i < categories.Count; i++)
                cboCategory.Items.Add(categories[i]);

            cboCategory.SelectedIndex = 0;
        }


        // ================= INVENTORY =================
        private void LoadInventory()
        {
            List<InventoryReport> result =
                new List<InventoryReport>();

            string category =
                cboCategory.Text;

            Series current =
     new Series("Current Stock");

            Series min =
                new Series("Min Stock");

            current.ChartType =
                SeriesChartType.Column;

            min.ChartType =
                SeriesChartType.Column;

            current.IsXValueIndexed = true;
            min.IsXValueIndexed = true;

            current["PointWidth"] = "0.35";
            min["PointWidth"] = "0.35";

            current["DrawSideBySide"] = "true";
            min["DrawSideBySide"] = "true";

            current.IsValueShownAsLabel = true;
            min.IsValueShownAsLabel = true;
            current.Color = Color.SteelBlue;
            min.Color = Color.IndianRed;
            

            int i = 0;

            while (i < products.Count)
            {
                Product p = products[i];

                if (category != "All Categories")
                {
                    if (p.Category != category)
                    {
                        i++;
                        continue;
                    }
                }

                int total = 0;

                int j = 0;

                while (j < batches.Count)
                {
                    if (batches[j].ProductId == p.ProductID)
                    {
                        total += batches[j].Quantity;
                    }

                    j++;
                }

                InventoryReport r =
                    new InventoryReport();

                r.Product = p.Name;
                r.Category = p.Category;
                r.CurrentStock = total;
                r.MinStock = p.MinStock;

                if (total <= p.MinStock)
                    r.Status = "Low";
                else
                    r.Status = "Normal";

                result.Add(r);

                current.Points.AddXY(
                    p.Name,
                    total);

                min.Points.AddXY(
                    p.Name,
                    p.MinStock);

                i++;
            }

            chartReport.Series.Add(current);
            chartReport.Series.Add(min);

            chartReport.ChartAreas[0]
                .AxisX.Interval = 1;

            chartReport.ChartAreas[0]
                .AxisX.MajorGrid.Enabled = false;

            chartReport.Legends.Add(
                new Legend());

            chartReport.Titles.Add(
                "Current Inventory Levels");

            dgvReport.DataSource = result;

            currentGrid = dgvReport;
        }


        // ================= LOW STOCK =================
        private void LoadLowStock()
        {
            List<LowStockReport> data =
                new List<LowStockReport>();

            string category =
                cboCategory.Text;

            int i = 0;

            while (i < products.Count)
            {
                Product p = products[i];

                // FILTER CATEGORY
                if (category != "All Categories")
                {
                    if (p.Category != category)
                    {
                        i++;
                        continue;
                    }
                }

                int total = 0;

                int j = 0;

                while (j < batches.Count)
                {
                    if (batches[j].ProductId == p.ProductID)
                    {
                        total += batches[j].Quantity;
                    }

                    j++;
                }

                // LOW STOCK ONLY
                if (total <= p.MinStock)
                {
                    LowStockReport r =
                        new LowStockReport();

                    r.Product =
                        p.Name;

                    r.Category =
                        p.Category;

                    r.CurrentStock =
                        total;

                    r.MinStock =
                        p.MinStock;

                    r.Shortage =
                        p.MinStock - total;

                    data.Add(r);
                }

                i++;
            }

            dgvReport.DataSource = data;

            currentGrid = dgvReport;
        }

        // ================= IMPORT EXPORT =================
        private void LoadImportExport()
        {
            DateTime start =
                dtStart.Value.Date;

            DateTime end =
                dtEnd.Value.Date;

            chartReport.Series.Clear();
            chartReport.ChartAreas.Clear();
            chartReport.Legends.Clear();
            chartReport.Titles.Clear();

            // =========================
            // CHART AREA
            // =========================

            ChartArea area =
                new ChartArea("MainArea");

            area.AxisX.Interval = 1;

            area.AxisX.MajorGrid.Enabled =
                false;
            area.AxisX.LabelStyle.Interval = 1;

            area.AxisX.Interval = 1;

            area.AxisY.MajorGrid.LineColor =
                Color.LightGray;

            area.AxisY.Minimum = 0;

            area.AxisX.LabelStyle.Angle = -45;

            area.AxisX.Title = "Date";

            area.AxisY.Title = "Quantity";

            area.AxisX.IsMarginVisible =
                true;

            area.AxisX.LabelStyle.Font =
                new Font(
                    "Times New Roman",
                    9,
                    FontStyle.Bold);

            area.AxisY.LabelStyle.Font =
                new Font(
                    "Times New Roman",
                    9,
                    FontStyle.Bold);

            chartReport.ChartAreas.Add(area);

            // =========================
            // LEGEND
            // =========================

            chartReport.Legends.Add(
                new Legend());

            // =========================
            // IMPORT SERIES
            // =========================

            Series importSeries =
                new Series("Import");

            importSeries.ChartType =
                SeriesChartType.Spline;

            importSeries.BorderWidth = 4;

            importSeries.Color =
                Color.SteelBlue;

            importSeries.MarkerStyle =
                MarkerStyle.Circle;

            importSeries.MarkerSize = 8;

            importSeries.IsValueShownAsLabel =
                true;

            importSeries.XValueType =
                ChartValueType.String;

            // =========================
            // EXPORT SERIES
            // =========================

            Series exportSeries =
                new Series("Export");

            exportSeries.ChartType =
                SeriesChartType.Spline;

            exportSeries.BorderWidth = 4;

            exportSeries.Color =
                Color.OrangeRed;

            exportSeries.MarkerStyle =
                MarkerStyle.Circle;

            exportSeries.MarkerSize = 8;

            exportSeries.IsValueShownAsLabel =
                true;

            exportSeries.XValueType =
                ChartValueType.String;
            importSeries.IsXValueIndexed =
    true;

            exportSeries.IsXValueIndexed =
                true;

            // =========================
            // DATA
            // =========================

            int totalImport = 0;
            int totalExport = 0;

            DateTime currentDate = start;

            while (currentDate <= end)
            {
                int importQty = 0;
                int exportQty = 0;

                // ================= IMPORT
                int i = 0;

                while (i < imports.Count)
                {
                    if (imports[i].ImportDate.Date
                        == currentDate.Date)
                    {
                        int j = 0;

                        while (j < imports[i]
    .OrderDetails.Count)
                        {
                            string productId =
                                imports[i]
                                .OrderDetails[j]
                                .ProductId;

                            string productCategory =
                                GetProductCategory(productId);

                            if (
                                cboCategory.Text == "All Categories"
                                ||
                                productCategory == cboCategory.Text
                            )
                            {
                                importQty +=
                                    imports[i]
                                    .OrderDetails[j]
                                    .Quantity;
                            }

                            j++;
                        }
                    }

                    i++;
                }

                // ================= EXPORT

                i = 0;

                while (i < exports.Count)
                {
                    if (exports[i].ExportDate.Date
                        == currentDate.Date)
                    {
                        int j = 0;

                        while (j <
    exports[i]
    .OrderDetails.Count)
                        {
                            string productId =
                                exports[i]
                                .OrderDetails[j]
                                .ProductId;

                            string productCategory =
                                GetProductCategory(productId);

                            if (
                                cboCategory.Text == "All Categories"
                                ||
                                productCategory == cboCategory.Text
                            )
                            {
                                exportQty +=
                                    exports[i]
                                    .OrderDetails[j]
                                    .Quantity;
                            }

                            j++;
                        }
                    }

                    i++;
                }

                int xIndex =
    importSeries.Points.Count;

                DataPoint importPoint =
                    new DataPoint();

                importPoint.SetValueXY(
                    xIndex,
                    importQty);

                importPoint.AxisLabel =
                    currentDate.ToString("dd/MM");

                importSeries.Points.Add(
                    importPoint);

                DataPoint exportPoint =
                    new DataPoint();

                exportPoint.SetValueXY(
                    xIndex,
                    exportQty);

                exportPoint.AxisLabel =
                    currentDate.ToString("dd/MM");

                exportSeries.Points.Add(
                    exportPoint);

                totalImport += importQty;
                totalExport += exportQty;

                currentDate =
                    currentDate.AddDays(1);
            }

            // =========================
            // ADD SERIES
            // =========================

            chartReport.Series.Add(
                importSeries);

            chartReport.Series.Add(
                exportSeries);

            // =========================
            // TITLE
            // =========================

            chartReport.Titles.Add(
                "Import vs Export Trend");

            chartReport.BackColor =
                Color.White;

            // =========================
            // SUMMARY
            // =========================

            BuildSummary(
                totalImport,
                totalExport);

            currentGrid = dgvReport;
        }

        private void BuildSummary(
    int totalImport,
    int totalExport)
        {
            pnlSummary.Controls.Clear();

            TableLayoutPanel tl =
                new TableLayoutPanel();

            tl.Dock = DockStyle.Fill;

            tl.ColumnCount = 3;

            tl.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33));

            tl.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33));

            tl.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 34));

            Label l1 = new Label();
            Label l2 = new Label();
            Label l3 = new Label();

            l1.Dock = DockStyle.Fill;
            l2.Dock = DockStyle.Fill;
            l3.Dock = DockStyle.Fill;

            l1.TextAlign =
                ContentAlignment.MiddleCenter;

            l2.TextAlign =
                ContentAlignment.MiddleCenter;

            l3.TextAlign =
                ContentAlignment.MiddleCenter;

            l1.Font =
                new Font("Times New Roman", 15,
                FontStyle.Bold);

            l2.Font =
                new Font("Times New Roman", 15,
                FontStyle.Bold);

            l3.Font =
                new Font("Times New Roman", 15,
                FontStyle.Bold);

            l1.ForeColor = Color.Blue;
            l2.ForeColor = Color.Red;
            l3.ForeColor = Color.Green;

            l1.Text =
                "Total Import\n" +
                totalImport;

            l2.Text =
                "Total Export\n" +
                totalExport;

            l3.Text =
                "Net Change\n" +
                (totalImport - totalExport);

            tl.Controls.Add(l1, 0, 0);
            tl.Controls.Add(l2, 1, 0);
            tl.Controls.Add(l3, 2, 0);

            pnlSummary.Controls.Add(tl);
        }
        private void exportBtn_Click(
    object sender,
    EventArgs e)
        {
            FolderBrowserDialog folder =
                new FolderBrowserDialog();

            if (folder.ShowDialog()
                != DialogResult.OK)
            {
                return;
            }

            string folderPath =
                folder.SelectedPath;

            int originalIndex =
                cboType.SelectedIndex;

            // =========================
            // EXPORT INVENTORY
            // =========================

            cboType.SelectedIndex = 0;

            RefreshReport();

            ExportCurrentReport(
                folderPath,
                "Inventory_Report"
            );

            // =========================
            // EXPORT LOW STOCK
            // =========================

            cboType.SelectedIndex = 1;

            RefreshReport();

            ExportCurrentReport(
                folderPath,
                "Low_Stock_Report"
            );

            // =========================
            // EXPORT IMPORT EXPORT
            // =========================

            cboType.SelectedIndex = 2;

            RefreshReport();

            ExportCurrentReport(
                folderPath,
                "Import_Export_Report"
            );

            // RESTORE

            cboType.SelectedIndex =
                originalIndex;

            RefreshReport();

            MessageBox.Show(
                "All reports exported successfully!");
        }

        private void SaveChartImage(string path)
        {
            chartReport.SaveImage(path, ChartImageFormat.Png);
        }

        private void ExportCurrentReport(
    string folderPath,
    string fileName)
        {
            // =========================
            // EXPORT TABLE
            // =========================

            if (dgvReport.Visible
                &&
                dgvReport.DataSource != null)
            {
                StringBuilder sb =
                    new StringBuilder();

                // HEADER

                for (int i = 0;
                    i < dgvReport.Columns.Count;
                    i++)
                {
                    sb.Append(
                        dgvReport.Columns[i]
                        .HeaderText
                        + ",");
                }

                sb.AppendLine();

                // DATA

                for (int i = 0;
                    i < dgvReport.Rows.Count;
                    i++)
                {
                    for (int j = 0;
                        j < dgvReport.Columns.Count;
                        j++)
                    {
                        object value =
                            dgvReport.Rows[i]
                            .Cells[j].Value;

                        sb.Append(
                            value + ",");
                    }

                    sb.AppendLine();
                }

                System.IO.File.WriteAllText(
                    folderPath + "\\" +
                    fileName + ".csv",
                    sb.ToString());
            }

            // =========================
            // EXPORT CHART
            // =========================

            if (chartReport.Visible
                &&
                chartReport.Series.Count > 0)
            {
                chartReport.SaveImage(
                    folderPath + "\\" +
                    fileName + "_Chart.png",
                    ChartImageFormat.Png);
            }
        }

    }
}