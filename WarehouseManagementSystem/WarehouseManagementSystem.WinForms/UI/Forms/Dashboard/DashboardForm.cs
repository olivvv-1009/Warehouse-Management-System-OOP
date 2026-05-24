using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WarehouseManagementSystem.WinForms.Controllers;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.UI.Forms.Dashboard
{
    public partial class DashboardForm : UserControl
    {
        private DashboardController controller;

        public DashboardForm()
        {
            InitializeComponent();

            controller =
                new DashboardController();

            this.Load +=
                DashboardForm_Load;
        }

        private void DashboardForm_Load(
            object sender,
            EventArgs e
        )
        {
            SetupUI();

            LoadDashboard();
        }

        // =====================================================
        // UI
        // =====================================================

        private void SetupUI()
        {
            SetupGrid(dgvAlerts);

            SetupGrid(dgvTransactions);

            chartImportExport.Titles.Clear();

            chartCategory.Titles.Clear();

            chartImportExport.Series.Clear();

            chartCategory.Series.Clear();

            chartImportExport.ChartAreas.Clear();

            chartCategory.ChartAreas.Clear();

            chartImportExport.ChartAreas.Add(
                new ChartArea()
            );

            chartCategory.ChartAreas.Add(
                new ChartArea()
            );
        }

        private void SetupGrid(
            DataGridView dgv
        )
        {
            dgv.EnableHeadersVisualStyles =
                false;

            dgv.ColumnHeadersDefaultCellStyle
                .BackColor =
                    Color.FromArgb(
                        30,
                        41,
                        59
                    );

            dgv.ColumnHeadersDefaultCellStyle
                .ForeColor =
                    Color.White;

            dgv.ColumnHeadersDefaultCellStyle
                .Font =
                    new Font(
                        "Times New Roman",
                        11,
                        FontStyle.Bold
                    );

            dgv.DefaultCellStyle.Font =
                new Font(
                    "Times New Roman",
                    11
                );

            dgv.RowTemplate.Height =
                35;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode
                    .Fill;

            dgv.SelectionMode =
                DataGridViewSelectionMode
                    .FullRowSelect;

            dgv.MultiSelect =
                false;

            dgv.ReadOnly =
                true;

            dgv.AllowUserToAddRows =
                false;

            dgv.AllowUserToDeleteRows =
                false;

            dgv.BackgroundColor =
                Color.White;

            dgv.BorderStyle =
                BorderStyle.None;
        }

        // =====================================================
        // DASHBOARD
        // =====================================================

        private void LoadDashboard()
        {
            LoadStatistics();

            LoadCharts();

            LoadAlerts();

            LoadTransactions();
        }

        // =====================================================
        // LOAD STATS
        // =====================================================

        private void LoadStatistics()
        {
            DashboardStatistic stat =
                controller.GetStatistics();

            lblTotalProductsValue.Text =
                stat.TotalProducts
                    .ToString();

            lblTotalInventoryValue.Text =
                stat.TotalInventory
                    .ToString();

            lblLowStockValue.Text =
                stat.LowStockItems
                    .ToString();

            lblInventoryValue.Text =
                stat.InventoryValue
                    .ToString("N0")
                + " VND";
        }

        // =====================================================
        // LOAD CHARTS
        // =====================================================

        private void LoadCharts()
        {
            LoadImportExportChart();

            LoadCategoryChart();
        }

        private void LoadImportExportChart()
        {
            chartImportExport.Series.Clear();

            chartImportExport.ChartAreas.Clear();

            chartImportExport.Legends.Clear();

            chartImportExport.Titles.Clear();

            ChartArea area =
                new ChartArea();

            area.AxisX.Interval = 1;

            area.AxisX.LabelStyle.Angle =
                0;

            area.AxisX.MajorGrid.Enabled =
                false;

            area.AxisY.Minimum =
                0;

            chartImportExport.ChartAreas.Add(
                area
            );

            chartImportExport.Legends.Add(
                new Legend()
            );

            Series importSeries =
                new Series("Import");

            importSeries.ChartType =
                SeriesChartType.Column;

            importSeries.Color =
                Color.SteelBlue;

            importSeries.IsXValueIndexed =
                true;

            importSeries["PointWidth"] =
                "0.35";

            Series exportSeries =
                new Series("Export");

            exportSeries.ChartType =
                SeriesChartType.Column;

            exportSeries.Color =
                Color.Goldenrod;

            exportSeries.IsXValueIndexed =
                true;

            exportSeries["PointWidth"] =
                "0.35";

            List<Transaction>
                transactions =
                    controller
                        .GetAllTransactions();

            if (
                transactions == null
                || transactions.Count == 0
            )
            {
                return;
            }

            DateTime latestDate =
                transactions[0].Date;

            int i;

            for (
                i = 1;
                i < transactions.Count;
                i++
            )
            {
                if (
                    transactions[i].Date
                    >
                    latestDate
                )
                {
                    latestDate =
                        transactions[i].Date;
                }
            }

            for (
                i = 0;
                i < 7;
                i++
            )
            {
                DateTime currentDate =
                    latestDate.Date.AddDays(
                        -(6 - i)
                    );

                string label =
                    currentDate.ToString(
                        "dd/MM"
                    );

                int importTotal = 0;

                int exportTotal = 0;

                int j;

                for (
                    j = 0;
                    j < transactions.Count;
                    j++
                )
                {
                    Transaction transaction =
                        transactions[j];

                    if (
                        transaction.Date.Date
                        ==
                        currentDate.Date
                    )
                    {
                        if (
                            transaction.TransactionType
                            ==
                            Transaction.Types.Import
                        )
                        {
                            importTotal +=
                                transaction.Quantity;
                        }

                        if (
                            transaction.TransactionType
                            ==
                            Transaction.Types.Export
                        )
                        {
                            exportTotal +=
                                transaction.Quantity;
                        }
                    }
                }

                DataPoint importPoint =
                    new DataPoint();

                importPoint.AxisLabel =
                    label;

                importPoint.YValues =
                    new double[]
                    {
                importTotal
                    };

                importSeries.Points.Add(
                    importPoint
                );

                DataPoint exportPoint =
                    new DataPoint();

                exportPoint.AxisLabel =
                    label;

                exportPoint.YValues =
                    new double[]
                    {
                exportTotal
                    };

                exportSeries.Points.Add(
                    exportPoint
                );
            }

            chartImportExport.Series.Add(
                importSeries
            );

            chartImportExport.Series.Add(
                exportSeries
            );

            chartImportExport.Titles.Add(
                "Import vs Export (Last 7 Days)"
            );
        }

        private void LoadCategoryChart()
        {
            chartCategory.Series.Clear();

            chartCategory.ChartAreas.Clear();

            chartCategory.ChartAreas.Add(
                new ChartArea()
            );

            Series pieSeries =
                new Series();

            pieSeries.ChartType =
                SeriesChartType.Pie;

            pieSeries.IsValueShownAsLabel =
                true;

            pieSeries.Label =
                "#PERCENT{P0}";

            Dictionary<string, int>
                data =
                    controller
                        .GetCategoryDistribution();

            foreach (
                KeyValuePair<string, int>
                item in data
            )
            {
                pieSeries.Points.AddXY(
                    item.Key,
                    item.Value
                );
            }

            chartCategory.Series.Add(
                pieSeries
            );

            chartCategory.Titles.Clear();

            chartCategory.Titles.Add(
                "Product Category Distribution"
            );

            chartCategory.Legends.Clear();

            chartCategory.Legends.Add(
                new Legend()
            );
        }

        // =====================================================
        // ALERTS
        // =====================================================

        private void LoadAlerts()
        {
            dgvAlerts.Columns.Clear();

            dgvAlerts.Rows.Clear();

            dgvAlerts.Columns.Add(
                "ProductId",
                "Product ID"
            );

            dgvAlerts.Columns.Add(
                "ProductName",
                "Product Name"
            );

            dgvAlerts.Columns.Add(
                "Category",
                "Category"
            );

            dgvAlerts.Columns.Add(
                "Quantity",
                "Quantity"
            );

            dgvAlerts.Columns.Add(
                "Status",
                "Status"
            );

            List<InventoryItem>
                items =
                    controller
                        .GetLowStockItems();

            if (
                items == null
                || items.Count == 0
            )
            {
                return;
            }

            int i;

            for (
                i = 0;
                i < items.Count;
                i++
            )
            {
                int rowIndex =
                    dgvAlerts.Rows.Add();

                dgvAlerts.Rows[rowIndex]
                    .Cells[0]
                    .Value =
                        items[i].ProductId;

                dgvAlerts.Rows[rowIndex]
                    .Cells[1]
                    .Value =
                        items[i].ProductName;

                dgvAlerts.Rows[rowIndex]
                    .Cells[2]
                    .Value =
                        controller.GetProductCategory(
                            items[i].ProductId
                        );

                dgvAlerts.Rows[rowIndex]
                    .Cells[3]
                    .Value =
                        items[i].Quantity;

                dgvAlerts.Rows[rowIndex]
                    .Cells[4]
                    .Value =
                        items[i].StockStatus;
            }

            dgvAlerts.Refresh();
        }

        // =====================================================
        // TRANSACTIONS
        // =====================================================

        private void LoadTransactions()
        {
            dgvTransactions.Columns.Clear();

            dgvTransactions.Rows.Clear();

            dgvTransactions.Columns.Add(
                "TransactionId",
                "Transaction ID"
            );

            dgvTransactions.Columns.Add(
                "ProductId",
                "Product ID"
            );

            dgvTransactions.Columns.Add(
                "Type",
                "Type"
            );

            dgvTransactions.Columns.Add(
                "Quantity",
                "Quantity"
            );

            dgvTransactions.Columns.Add(
                "Date",
                "Date"
            );

            List<Transaction>
                transactions =
                    controller
                        .GetRecentTransactions();

            if (
                transactions == null
                || transactions.Count == 0
            )
            {
                return;
            }

            int i;

            for (
                i = 0;
                i < transactions.Count;
                i++
            )
            {
                int rowIndex =
                    dgvTransactions.Rows.Add();

                dgvTransactions.Rows[rowIndex]
                    .Cells[0]
                    .Value =
                        transactions[i]
                            .TransactionId;

                dgvTransactions.Rows[rowIndex]
                    .Cells[1]
                    .Value =
                        transactions[i]
                            .ProductId;

                dgvTransactions.Rows[rowIndex]
                    .Cells[2]
                    .Value =
                        transactions[i]
                            .TransactionType;

                dgvTransactions.Rows[rowIndex]
                    .Cells[3]
                    .Value =
                        transactions[i]
                            .Quantity;

                dgvTransactions.Rows[rowIndex]
                    .Cells[4]
                    .Value =
                        transactions[i]
                            .Date
                            .ToString(
                                "dd/MM/yyyy"
                            );
            }

            dgvTransactions.Refresh();
        }
    }
}