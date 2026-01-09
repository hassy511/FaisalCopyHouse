using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Reporting
{
    public partial class frm_PurchasesOrderReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_PurchasesOrderReport()
        {
            InitializeComponent();
        }

        private void UpdateDiscardPO() {
            try
            {
                if (grdPOList.Rows.Count > 0)
                {
                    string poIds = "";
                    foreach (DataGridViewRow dgvr in grdPOList.Rows)
                    {
                        if (dgvr.Cells["discard"].Value.ToString().Equals("True")) {
                            poIds += "'" + dgvr.Cells["poID"].Value.ToString() + "',";
                        }
                    }
                    if (!poIds.Equals(""))
                    {
                        poIds = poIds.TrimEnd(',');
                        classHelper.query = @"UPDATE PURCHASES_ORDER SET [STATUS] = 'Y' WHERE PO_ID IN (" + poIds + ")";
                        if (classHelper.InsertUpdateDelete(classHelper.query) > 0) {
                            LoadPO();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadPO() {
            classHelper.query = @"SELECT A.PO_ID,A.[DATE],A.PO_NUMBER AS [P.O #],C.COA_NAME AS [SUPPLIER],B.MATERIAL_NAME AS [RAW MATERIAL],A.[WEIGHT] AS [PO WEIGHT],A.KG_RATE AS [RATE (KG)],
            (A.WEIGHT / A.MUAND_VALUE) AS [MUAND WEIGHT], A.MUAND_RATE AS [MUAND RATE],
            CASE WHEN A.CREDIT_DAYS <= 0 THEN 'CASH' ELSE CONVERT(VARCHAR,A.CREDIT_DAYS)+' DAYS' END AS [CONDITON],
            DATEADD(DAY,A.CREDIT_DAYS,A.[DATE]) AS [DUE DATE],SUM(ISNULL(D.NET_WEIGHT,0)) AS [PI WEIGHT],(A.[WEIGHT] - SUM(ISNULL(D.NET_WEIGHT,0))) AS [BALANCE]
            FROM PURCHASES_ORDER A
            LEFT JOIN PURCHASES D ON A.PO_ID = D.PO_ID
            INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
            INNER JOIN COA C ON A.SUPPLIER_ID = C.COA_ID
            WHERE A.[STATUS] = 'N' AND A.[DATE] BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";

            if(cmbSupplier.SelectedIndex>0)
            {
                classHelper.query += @" AND A.SUPPLIER_ID = '"+cmbSupplier.SelectedValue.ToString()+"' ";
            }

            classHelper.query += @"
            GROUP BY A.[DATE],A.PO_NUMBER,C.COA_NAME,B.MATERIAL_NAME,A.[WEIGHT],A.KG_RATE,A.MUAND_VALUE,A.MUAND_RATE,A.CREDIT_DAYS,A.PO_ID";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                grdPOList.Rows.Clear();
                if (classHelper.dr.HasRows == true)
                {
                    while (classHelper.dr.Read())
                    {
                        if (classHelper.dr["RAW MATERIAL"].ToString().Equals("CANOLA"))
                        {
                            grdPOList.Rows.Add(false, classHelper.dr["PO_ID"].ToString(), classHelper.dr["DATE"].ToString(),
                            classHelper.dr["P.O #"].ToString(), classHelper.dr["SUPPLIER"].ToString(),
                            classHelper.dr["RAW MATERIAL"].ToString(), Math.Round(Convert.ToDecimal(classHelper.dr["PO WEIGHT"].ToString())),
                            Math.Round(Convert.ToDecimal(classHelper.dr["PI WEIGHT"].ToString())), Math.Round(Convert.ToDecimal(classHelper.dr["BALANCE"].ToString())),
                            Math.Round(Convert.ToDecimal(classHelper.dr["RATE (KG)"].ToString()),2));
                        }
                        else
                        {
                            grdPOList.Rows.Add(false, classHelper.dr["PO_ID"].ToString(), classHelper.dr["DATE"].ToString(),
                            classHelper.dr["P.O #"].ToString(), classHelper.dr["SUPPLIER"].ToString(),
                            classHelper.dr["RAW MATERIAL"].ToString(), Math.Round(Convert.ToDecimal(classHelper.dr["PO WEIGHT"].ToString())),
                            Math.Round(Convert.ToDecimal(classHelper.dr["PI WEIGHT"].ToString())), Math.Round(Convert.ToDecimal(classHelper.dr["BALANCE"].ToString())),
                            Math.Round(Convert.ToDecimal(classHelper.dr["MUAND RATE"].ToString()), 2));
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void ShowReport()
        {
            if (rdbAll.Checked == true)
            {
                classHelper.query = @"SELECT A.[DATE],A.PO_NUMBER AS [P.O #],C.COA_NAME AS [SUPPLIER],B.MATERIAL_NAME AS [RAW MATERIAL],A.[WEIGHT] AS [PO WEIGHT],A.KG_RATE AS [RATE (KG)],
                (A.WEIGHT / A.MUAND_VALUE) AS [MUAND WEIGHT], A.MUAND_RATE AS [MUAND RATE],
                CASE WHEN A.CREDIT_DAYS <= 0 THEN 'CASH' ELSE CONVERT(VARCHAR,A.CREDIT_DAYS)+' DAYS' END AS [CONDITON],
                DATEADD(DAY,A.CREDIT_DAYS,A.[DATE]) AS [DUE DATE],SUM(ISNULL(D.NET_WEIGHT,0)) AS [PI WEIGHT],(A.[WEIGHT] - SUM(ISNULL(D.NET_WEIGHT,0))) AS [BALANCE]
                FROM PURCHASES_ORDER A
                LEFT JOIN PURCHASES D ON A.PO_ID = D.PO_ID
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                INNER JOIN COA C ON A.SUPPLIER_ID = C.COA_ID
                WHERE A.[DATE] BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";

                if (cmbSupplier.SelectedIndex > 0)
                {
                    classHelper.query += @" AND A.SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + "' ";
                }

                classHelper.query += @"
                GROUP BY A.PO_ID,A.[DATE],A.PO_NUMBER,C.COA_NAME,B.MATERIAL_NAME,A.[WEIGHT],A.KG_RATE,A.MUAND_VALUE,A.MUAND_RATE,A.CREDIT_DAYS
                ORDER BY A.PO_ID";
            }
            else {
                classHelper.query = @"SELECT A.[DATE],A.PO_NUMBER AS [P.O #],C.COA_NAME AS [SUPPLIER],B.MATERIAL_NAME AS [RAW MATERIAL],A.[WEIGHT] AS [PO WEIGHT],A.KG_RATE AS [RATE (KG)],
                (A.WEIGHT / A.MUAND_VALUE) AS [MUAND WEIGHT], A.MUAND_RATE AS [MUAND RATE],
                CASE WHEN A.CREDIT_DAYS <= 0 THEN 'CASH' ELSE CONVERT(VARCHAR,A.CREDIT_DAYS)+' DAYS' END AS [CONDITON],
                DATEADD(DAY,A.CREDIT_DAYS,A.[DATE]) AS [DUE DATE],SUM(ISNULL(D.NET_WEIGHT,0)) AS [PI WEIGHT],(A.[WEIGHT] - SUM(ISNULL(D.NET_WEIGHT,0))) AS [BALANCE]
                FROM PURCHASES_ORDER A
                LEFT JOIN PURCHASES D ON A.PO_ID = D.PO_ID
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                INNER JOIN COA C ON A.SUPPLIER_ID = C.COA_ID
                WHERE A.[STATUS] = 'N' AND A.[DATE] BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";

                if (cmbSupplier.SelectedIndex > 0)
                {
                    classHelper.query += @" AND A.SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + "' ";
                }

                classHelper.query += @"
                GROUP BY A.PO_ID,A.[DATE],A.PO_NUMBER,C.COA_NAME,B.MATERIAL_NAME,A.[WEIGHT],A.KG_RATE,A.MUAND_VALUE,A.MUAND_RATE,A.CREDIT_DAYS
                ORDER BY A.PO_ID";
            }

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.mds.Tables["PO_Report"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PO_Report"].NewRow();
                        classHelper.dataR["DATE"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["P.O #"] = classHelper.dr["P.O #"].ToString();
                        classHelper.dataR["SUPPLIER"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["RAW MATERIAL"] = classHelper.dr["RAW MATERIAL"].ToString();
                        classHelper.dataR["BALANCE_WEIGHT"] = Convert.ToDecimal(classHelper.dr["BALANCE"].ToString());
                        classHelper.dataR["PO_WEIGHT"] = Convert.ToDecimal(classHelper.dr["PO WEIGHT"].ToString());
                        classHelper.dataR["PURCHASES_WEIGHT"] = Convert.ToDecimal(classHelper.dr["PI WEIGHT"].ToString());
                        if (classHelper.dr["RAW MATERIAL"].ToString().Equals("CANOLA"))
                        {
                            classHelper.dataR["RATE (KG)"] = Convert.ToDecimal(classHelper.dr["RATE (KG)"].ToString());
                        }
                        else {
                            classHelper.dataR["RATE (KG)"] = Convert.ToDecimal(classHelper.dr["MUAND RATE"].ToString());
                        }
                        classHelper.dataR["MUAND WEIGHT"] = Convert.ToDecimal(classHelper.dr["MUAND WEIGHT"].ToString());
                        classHelper.dataR["MUAND RATE"] = Convert.ToDecimal(classHelper.dr["MUAND RATE"].ToString());
                        classHelper.dataR["CONDITION"] = classHelper.dr["CONDITON"].ToString();
                        classHelper.dataR["DUE DATE"] = Convert.ToDateTime(classHelper.dr["DUE DATE"].ToString());
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PO_Report"].Rows.Add(classHelper.dataR);
                    }
                }
                else {
                    MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }

            if (rdbAll.Checked == true)
            {
                classHelper.query = @"SELECT B.MATERIAL_NAME AS [MATERIAL_NAME],(SUM(ISNULL(A.WEIGHT,0)) - C.[PI WEIGHT]) AS [TOTAL WEIGHT],AVG(A.KG_RATE) AS [AVERAGE RATE],
                (SUM(ISNULL(A.WEIGHT,0)) - C.[PI WEIGHT]) * AVG(A.KG_RATE) AS [AMOUNT]
                FROM PURCHASES_ORDER A
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                INNER JOIN (SELECT B.MATERIAL_NAME AS [MATERIAL NAME],SUM(ISNULL(C.NET_WEIGHT,0)) AS [PI WEIGHT]
                FROM PURCHASES_ORDER A
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                LEFT JOIN PURCHASES C ON A.PO_ID = C.PO_ID
                GROUP BY B.MATERIAL_NAME) C ON B.MATERIAL_NAME = C.[MATERIAL NAME]
                WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";

                if (cmbSupplier.SelectedIndex > 0)
                {
                    classHelper.query += @" AND A.SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + "' ";
                }

                classHelper.query += @"
                GROUP BY B.MATERIAL_NAME,C.[PI WEIGHT]";
            }
            else {
                classHelper.query = @"SELECT B.MATERIAL_NAME AS [MATERIAL_NAME],(SUM(ISNULL(A.WEIGHT,0)) - C.[PI WEIGHT]) AS [TOTAL WEIGHT],AVG(A.KG_RATE) AS [AVERAGE RATE],
                (SUM(ISNULL(A.WEIGHT,0)) - C.[PI WEIGHT]) * AVG(A.KG_RATE) AS [AMOUNT]
                FROM PURCHASES_ORDER A
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                INNER JOIN (SELECT B.MATERIAL_NAME AS [MATERIAL NAME],SUM(ISNULL(C.NET_WEIGHT,0)) AS [PI WEIGHT]
                FROM PURCHASES_ORDER A
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                LEFT JOIN PURCHASES C ON A.PO_ID = C.PO_ID
                WHERE A.[STATUS] = 'N'            
                GROUP BY B.MATERIAL_NAME) C ON B.MATERIAL_NAME = C.[MATERIAL NAME]
                WHERE A.[STATUS] = 'N' AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";

                if (cmbSupplier.SelectedIndex > 0)
                {
                    classHelper.query += @" AND A.SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + "' ";
                }
                classHelper.query += @"
                GROUP BY B.MATERIAL_NAME,C.[PI WEIGHT]";
            }
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["PO_Summary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PO_Summary"].NewRow();
                        classHelper.dataR["MATERIAL"] = classHelper.dr["MATERIAL_NAME"].ToString();
                        classHelper.dataR["WEIGHT"] = Convert.ToDecimal(classHelper.dr["TOTAL WEIGHT"].ToString());
                        classHelper.dataR["RATE"] = Convert.ToDecimal(classHelper.dr["AVERAGE RATE"].ToString());
                        classHelper.dataR["AMOUNT"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.mds.Tables["PO_Summary"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                   // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Reports.POSummary rptPOS = new Reports.POSummary();
                //rptPOS.SetDataSource(classHelper.mds.Tables["PO_Summary"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("PO_Report", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            LoadPO();
        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            classHelper.LoadSuppliers(cmbSupplier);
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void grdPOList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdPOList.Rows.Count > 0) {
                if (grdPOList.Rows[e.RowIndex].Cells["discard"].Value.ToString().Equals("True"))
                {
                    grdPOList.Rows[e.RowIndex].Cells["discard"].Value = false;
                }
                else {
                    grdPOList.Rows[e.RowIndex].Cells["discard"].Value = true;
                }
            }
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            UpdateDiscardPO();
        }
    }
}
