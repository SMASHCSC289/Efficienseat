using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Microsoft.Reporting.WinForms;

namespace Efficienseat
{
    public partial class ReportForm : Form
    {
        int wed_id;

        public ReportForm()
        {
            InitializeComponent();
        }

        public ReportForm(int id)
        {
            InitializeComponent();
            wed_id = id;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            WedReport dsWedReport = GetData();
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsWedReport.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();
        }

        private WedReport GetData()
        {
            string constr = @"Data Source=|DataDirectory|\Efficienseat.sqlite;Version=3;";
            using (SQLiteConnection con = new SQLiteConnection(constr))
            {
                string sql = "SELECT FIRST_NAME, LAST_NAME, GUEST_TABLE, TABLE_NAME, FOOD_ALLERGY, SEAT_NUM, COMMENTS " +
                    "FROM WED_VIEW WHERE WED_ID = " + wed_id + 
                     " ORDER BY GUEST_TABLE, SEAT_NUM";
                using (SQLiteCommand cmd = new SQLiteCommand(sql))
                {
                    using (SQLiteDataAdapter sda = new SQLiteDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (WedReport dsWedReport = new WedReport())
                        {
                            sda.Fill(dsWedReport, "DataTable1");
                            return dsWedReport;
                        }
                    }
                }
            }
        }
    }
}
