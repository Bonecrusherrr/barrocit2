﻿using BarrocITApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarrocITApp
{
    public partial class MainForm : Form
    {
        private EnrollBill enrollBill;
        private Role role;
        private int selectedClientIndex;

        public MainForm(Role role)
        {
            InitializeComponent();
            this.role = role;
            DBHandler.Init();
        }
        //Fill the datagrid on form load
        #region FormLoadData
        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'barrocITDBDataSet2.tbl_projecten' table. You can move, or remove it, as needed.
            this.tbl_projectenTableAdapter.Fill(this.barrocITDBDataSet2.tbl_projecten);
            // TODO: This line of code loads data into the 'barrocITDBDataSet1.tbl_klantendata' table. You can move, or remove it, as needed.
            this.tbl_klantendataTableAdapter1.Fill(this.barrocITDBDataSet1.tbl_klantendata);
            // TODO: This line of code loads data into the 'barrocITDBDataSet.tbl_klantendata' table. You can move, or remove it, as needed.
            this.tbl_klantendataTableAdapter.Fill(this.barrocITDBDataSet.tbl_klantendata);

        }
        #endregion

        private void button10_Click(object sender, EventArgs e)
        {

            if (enrollBill != null)
            {
                enrollBill.Hide();
                enrollBill = null;
            }

            enrollBill = new Forms.EnrollBill();
            enrollBill.Show();

        }

        private void dataGrid_clients_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedClientIndex = e.RowIndex;

            dataGrid_clientsInfos.DataSource = null;
            dataGrid_clientsInfos.Rows.Clear();
            dataGrid_clientsInfos.Rows.Add(DBHandler.GetRow(DBHandler.FillDT("SELECT * FROM tbl_klantendata"), e.RowIndex));
        }
    }
}
