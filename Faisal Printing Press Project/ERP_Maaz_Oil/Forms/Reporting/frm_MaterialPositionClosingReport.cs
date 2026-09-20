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
    public partial class frm_MaterialPositionClosingReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_MaterialPositionClosingReport()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                ShowClosingReport();
                //GenerateReport();
                //if (grdData.Rows.Count > 0)
                //{
                //    ShowClosingReport();
                //}
                ShowClosingSummaryReport();
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GenerateReport()
        {
            double olienSalesWeight = 0;
            double canolaSalesWeight = 0;
            double soyaSalesWeight = 0;
            double hardSalesWeight = 0;

            double olienAdjustmentWeight = 0;
            double canolaAdjustmentWeight = 0;
            double soyaAdjustmentWeight = 0;
            double hardAdjustmentWeight = 0;

            grdData.Rows.Clear();
            classHelper.query = @"SELECT A.MATERIAL_ID,CONVERT(DATETIME,FORMAT(A.DATE,'yyyy-MM-dd')) AS [DATE],B.INVOICE_NO,
            SUM(A.STOCK_IN) AS [OLIEN / RBD],'PURCHASES' AS [TYPE],
            B.KG_RATE,B.MUAND_RATE,B.MUAND_VALUE,
            ISNULL(C.BALANCE,0) + ISNULL(Q.QTY,0) AS [BALANCE],ISNULL(W.[ADJUSTED QTY],0) AS [ADJUSTED QTY]
            FROM MATERIAL_ITEM_LEDGER A
            INNER JOIN PURCHASES B ON A.REF_NO = B.PI_ID
            INNER JOIN (
                SELECT A.MATERIAL_ID,(A.OPENING_QTY+ISNULL(X.BALANCE,0)-ISNULL(Y.OUT,0)) AS [OPENING BALANCE],(ISNULL(Z.SALES,0) + ISNULL(W.SALES,0)) AS [SALES],
                (ISNULL(Z.SALES,0) + ISNULL(W.SALES,0)) - (A.OPENING_QTY+ISNULL(X.BALANCE,0)-ISNULL(Y.OUT,0)) AS [BALANCE],'OPENING' AS [TYPE]
                FROM MATERIALS A
                LEFT JOIN (
                SELECT MATERIAL_ID,ISNULL(SUM(STOCK_IN),0) AS [BALANCE] 
                FROM MATERIAL_ITEM_LEDGER 
                WHERE [DATE] < '2000-01-01' AND ENTRY_FROM = 'PURCHASES'
                        GROUP BY MATERIAL_ID
                ) X ON A.MATERIAL_ID = X.MATERIAL_ID
                LEFT JOIN (
                SELECT F.MATERIAL_ID,SUM(C.[WEIGHT]) AS [OUT]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
                WHERE A.[DATE] < '2000-01-01'
                        GROUP BY F.MATERIAL_ID
                ) Y ON Y.MATERIAL_ID = A.MATERIAL_ID
                LEFT JOIN (
                SELECT F.MATERIAL_ID,SUM(C.[WEIGHT]) AS [SALES]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
                WHERE A.[DATE] BETWEEN '2000-01-01' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND C.ITEM_TYPE = 'P'
                        GROUP BY F.MATERIAL_ID
                ) Z ON A.MATERIAL_ID = Z.MATERIAL_ID

	            LEFT JOIN (
                SELECT F.MATERIAL_ID,SUM(C.[WEIGHT]) AS [SALES]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN MATERIALS F ON C.PRODUCT_ID = F.MATERIAL_ID
                WHERE A.[DATE] BETWEEN '2000-01-01' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND C.ITEM_TYPE = 'R'
                        GROUP BY F.MATERIAL_ID
                ) W ON A.MATERIAL_ID = W.MATERIAL_ID
			 
                WHERE A.MATERIAL_ID IN (5003,5005,3002,5017)
            ) C ON A.MATERIAL_ID = C.MATERIAL_ID
            LEFT JOIN (
	            SELECT MATERIAL_ID,SUM(
		            CASE WHEN ADD_LESS = 'D' THEN QTY ELSE -QTY END
	            ) AS [ADJUSTED QTY]
	            FROM INVENTORY_ADJUSTMENTS
	            WHERE [DATE] BETWEEN '2000-01-01' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
	            GROUP BY MATERIAL_ID
            ) W ON A.MATERIAL_ID = W.MATERIAL_ID
            LEFT JOIN (
				SELECT F.MATERIAL_ID,SUM(A.sales_weight) AS [QTY]
				FROM AA_SALES A
				INNER JOIN SALES_ORDER_DIRECT G ON A.SO_ID = G.SOD_ID
				INNER JOIN MATERIALS F ON G.MATERIAL_ID = F.MATERIAL_ID
				WHERE A.[DATE] BETWEEN '2000-01-01' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
				GROUP BY F.MATERIAL_ID
			) Q ON A.MATERIAL_ID = Q.MATERIAL_ID
            WHERE A.[DATE] BETWEEN '2000-01-01' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND ENTRY_FROM = 'PURCHASES'
                    GROUP BY B.INVOICE_NO,A.MATERIAL_ID,CONVERT(DATETIME,FORMAT(A.DATE,'yyyy-MM-dd')),A.ENTRY_FROM,B.PI_ID,C.BALANCE,
            B.KG_RATE,B.MUAND_RATE,B.MUAND_VALUE,W.[ADJUSTED QTY],Q.QTY
            ORDER BY B.PI_ID,[DATE]";

            Classes.Helper.conn.Open();
            try
            {
                bool isOlienSalesFound = false;
                bool isCanolaSalesFound = false;
                bool isSoyaSalesFound = false;
                bool isHardSalesFound = false;

                bool isOlienAdjustmentFound = false;
                bool isCanolaAdjustmentFound = false;
                bool isSoyaAdjustmentFound = false;
                bool isHardAdjustmentFound = false;

                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    while (classHelper.dr.Read())
                    {
                        if (!isOlienSalesFound) {
                            if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5003")) {
                                olienSalesWeight = Convert.ToDouble(classHelper.dr["BALANCE"].ToString());
                                isOlienSalesFound = true;
                            }
                        }
                        if (!isCanolaSalesFound)
                        {
                            if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5005"))
                            {
                                canolaSalesWeight = Convert.ToDouble(classHelper.dr["BALANCE"].ToString());
                                isCanolaSalesFound = true;
                            }
                        }
                        if (!isSoyaSalesFound)
                        {
                            if (classHelper.dr["MATERIAL_ID"].ToString().Equals("3002"))
                            {
                                soyaSalesWeight = Convert.ToDouble(classHelper.dr["BALANCE"].ToString());
                                isSoyaSalesFound = true;
                            }
                        }
                        if (!isHardSalesFound)
                        {
                            if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5017"))
                            {
                                hardSalesWeight = Convert.ToDouble(classHelper.dr["BALANCE"].ToString());
                                isHardSalesFound = true;
                            }
                        }

                        if (!isOlienAdjustmentFound)
                        {
                            if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5003"))
                            {
                                olienAdjustmentWeight = Convert.ToDouble(classHelper.dr["ADJUSTED QTY"].ToString());
                                isOlienAdjustmentFound = true;
                            }
                        }
                        if (!isCanolaAdjustmentFound)
                        {
                            if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5005"))
                            {
                                canolaAdjustmentWeight = Convert.ToDouble(classHelper.dr["ADJUSTED QTY"].ToString());
                                isCanolaAdjustmentFound = true;
                            }
                        }
                        if (!isSoyaAdjustmentFound)
                        {
                            if (classHelper.dr["MATERIAL_ID"].ToString().Equals("3002"))
                            {
                                soyaAdjustmentWeight = Convert.ToDouble(classHelper.dr["ADJUSTED QTY"].ToString());
                                isSoyaAdjustmentFound = true;
                            }
                        }
                        if (!isHardAdjustmentFound)
                        {
                            if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5017"))
                            {
                                hardAdjustmentWeight = Convert.ToDouble(classHelper.dr["ADJUSTED QTY"].ToString());
                                isHardAdjustmentFound = true;
                            }
                        }

                        if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5005"))
                        {
                            grdData.Rows.Add(classHelper.dr["DATE"].ToString(), classHelper.dr["INVOICE_NO"].ToString(),
                            classHelper.dr["OLIEN / RBD"].ToString(), classHelper.dr["KG_RATE"].ToString(),
                            Convert.ToDouble(classHelper.dr["OLIEN / RBD"].ToString()) * Convert.ToDouble(classHelper.dr["KG_RATE"].ToString()),
                            0, 0, 0, classHelper.dr["MUAND_RATE"].ToString(), classHelper.dr["MATERIAL_ID"].ToString(),
                            0, 0, 0, 0, 0, 0);
                        }
                        else if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5003"))
                        {
                            grdData.Rows.Add(classHelper.dr["DATE"].ToString(), classHelper.dr["INVOICE_NO"].ToString(),
                            0, 0, 0,
                            classHelper.dr["OLIEN / RBD"].ToString(), classHelper.dr["KG_RATE"].ToString(),
                            Convert.ToDouble(classHelper.dr["OLIEN / RBD"].ToString()) * Convert.ToDouble(classHelper.dr["KG_RATE"].ToString()),
                            classHelper.dr["MUAND_RATE"].ToString(), classHelper.dr["MATERIAL_ID"].ToString(),
                            0, 0, 0, 0, 0, 0);
                        }
                        else if (classHelper.dr["MATERIAL_ID"].ToString().Equals("3002"))
                        {
                            grdData.Rows.Add(classHelper.dr["DATE"].ToString(), classHelper.dr["INVOICE_NO"].ToString(),
                            0,0,0,0,0,0,
                            classHelper.dr["MUAND_RATE"].ToString(), classHelper.dr["MATERIAL_ID"].ToString(), classHelper.dr["OLIEN / RBD"].ToString(),
                            classHelper.dr["KG_RATE"].ToString(), Convert.ToDouble(classHelper.dr["OLIEN / RBD"].ToString()) * Convert.ToDouble(classHelper.dr["KG_RATE"].ToString()),
                            0,0,0);
                        }
                        else if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5017"))
                        {
                            grdData.Rows.Add(classHelper.dr["DATE"].ToString(), classHelper.dr["INVOICE_NO"].ToString(),
                            0, 0, 0, 0, 0, 0,
                            classHelper.dr["MUAND_RATE"].ToString(), classHelper.dr["MATERIAL_ID"].ToString(), 0, 0, 0,
                            classHelper.dr["OLIEN / RBD"].ToString(),classHelper.dr["KG_RATE"].ToString(), Convert.ToDouble(classHelper.dr["OLIEN / RBD"].ToString()) * Convert.ToDouble(classHelper.dr["KG_RATE"].ToString()));
                        }
                    }
                }

                foreach (DataGridViewRow dg in grdData.Rows) {
                    if (dg.Cells["materialId"].Value.ToString().Equals("5005"))
                    {
                        double canola = Convert.ToDouble(dg.Cells["canolaKg"].Value.ToString());
                        if (canola < canolaSalesWeight)
                        {
                            canolaSalesWeight = canolaSalesWeight - canola;
                            dg.Cells["canolaKg"].Value = 0;
                            dg.Cells["canolaRate"].Value = 0;
                            dg.Cells["canolaAmount"].Value = Convert.ToDouble(dg.Cells["canolaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["canolaRate"].Value.ToString());
                        }
                        else {
                            dg.Cells["canolaKg"].Value = canola - canolaSalesWeight;
                            dg.Cells["canolaAmount"].Value = Convert.ToDouble(dg.Cells["canolaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["canolaRate"].Value.ToString());
                            canolaSalesWeight = 0;
                        }

                        canola = Convert.ToDouble(dg.Cells["canolaKg"].Value.ToString());
                        if (canola < canolaAdjustmentWeight)
                        {
                            canolaAdjustmentWeight = canolaAdjustmentWeight - canola;
                            dg.Cells["canolaKg"].Value = 0;
                            dg.Cells["canolaRate"].Value = 0;
                            dg.Cells["canolaAmount"].Value = Convert.ToDouble(dg.Cells["canolaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["canolaRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["canolaKg"].Value = canola - canolaAdjustmentWeight;
                            dg.Cells["canolaAmount"].Value = Convert.ToDouble(dg.Cells["canolaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["canolaRate"].Value.ToString());
                            canolaAdjustmentWeight = 0;
                        }
                    }
                    else if (dg.Cells["materialId"].Value.ToString().Equals("5003"))
                    {
                        double olien = Convert.ToDouble(dg.Cells["olienKg"].Value.ToString());
                        if (olien < olienSalesWeight)
                        {
                            olienSalesWeight = olienSalesWeight - olien;
                            dg.Cells["olienKg"].Value = 0;
                            dg.Cells["olienRate"].Value = 0;
                            dg.Cells["olienAmount"].Value = Convert.ToDouble(dg.Cells["olienKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["olienRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["olienKg"].Value = olien - olienSalesWeight;
                            dg.Cells["olienAmount"].Value = Convert.ToDouble(dg.Cells["olienKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["olienRate"].Value.ToString());
                            olienSalesWeight = 0;
                        }

                        olien = Convert.ToDouble(dg.Cells["olienKg"].Value.ToString());
                        if (olien < olienAdjustmentWeight)
                        {
                            olienAdjustmentWeight = olienAdjustmentWeight - olien;
                            dg.Cells["olienKg"].Value = 0;
                            dg.Cells["olienRate"].Value = 0;
                            dg.Cells["olienAmount"].Value = Convert.ToDouble(dg.Cells["olienKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["olienRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["olienKg"].Value = olien - olienAdjustmentWeight;
                            dg.Cells["olienAmount"].Value = Convert.ToDouble(dg.Cells["olienKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["olienRate"].Value.ToString());
                            olienAdjustmentWeight = 0;
                        }
                    }
                    else if (dg.Cells["materialId"].Value.ToString().Equals("3002"))
                    {
                        double soya = Convert.ToDouble(dg.Cells["soyaKg"].Value.ToString());
                        if (soya < soyaSalesWeight)
                        {
                            soyaSalesWeight = soyaSalesWeight - soya;
                            dg.Cells["soyaKg"].Value = 0;
                            dg.Cells["soyaRate"].Value = 0;
                            dg.Cells["soyaAmount"].Value = Convert.ToDouble(dg.Cells["soyaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["soyaRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["soyaKg"].Value = soya - soyaSalesWeight;
                            dg.Cells["soyaAmount"].Value = Convert.ToDouble(dg.Cells["soyaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["soyaRate"].Value.ToString());
                            soyaSalesWeight = 0;
                        }

                        soya = Convert.ToDouble(dg.Cells["soyaKg"].Value.ToString());
                        if (soya < soyaAdjustmentWeight)
                        {
                            soyaAdjustmentWeight = soyaAdjustmentWeight - soya;
                            dg.Cells["soyaKg"].Value = 0;
                            dg.Cells["soyaRate"].Value = 0;
                            dg.Cells["soyaAmount"].Value = Convert.ToDouble(dg.Cells["soyaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["soyaRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["soyaKg"].Value = soya - soyaAdjustmentWeight;
                            dg.Cells["soyaAmount"].Value = Convert.ToDouble(dg.Cells["soyaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["soyaRate"].Value.ToString());
                            soyaAdjustmentWeight = 0;
                        }
                    }
                    else if (dg.Cells["materialId"].Value.ToString().Equals("5017"))
                    {
                        double hard = Convert.ToDouble(dg.Cells["hardKg"].Value.ToString());
                        if (hard < hardSalesWeight)
                        {
                            hardSalesWeight = hardSalesWeight - hard;
                            dg.Cells["hardKg"].Value = 0;
                            dg.Cells["hardRate"].Value = 0;
                            dg.Cells["hardAmount"].Value = Convert.ToDouble(dg.Cells["hardKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["hardRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["hardKg"].Value = hard - hardSalesWeight;
                            dg.Cells["hardAmount"].Value = Convert.ToDouble(dg.Cells["hardKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["hardRate"].Value.ToString());
                            hardSalesWeight = 0;
                        }

                        hard = Convert.ToDouble(dg.Cells["hardKg"].Value.ToString());
                        if (hard < hardAdjustmentWeight)
                        {
                            hardAdjustmentWeight = hardAdjustmentWeight - hard;
                            dg.Cells["hardKg"].Value = 0;
                            dg.Cells["hardRate"].Value = 0;
                            dg.Cells["hardAmount"].Value = Convert.ToDouble(dg.Cells["hardKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["hardRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["hardKg"].Value = hard - hardAdjustmentWeight;
                            dg.Cells["hardAmount"].Value = Convert.ToDouble(dg.Cells["hardKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["hardRate"].Value.ToString());
                            hardAdjustmentWeight = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        decimal canolaClosingWeight = 0;
        decimal olienClosingWeight = 0;
        decimal hardClosingWeight = 0;
        decimal soyaClosingWeight = 0;

        private void ShowClosingReport()
        {
            DataTable dt = classHelper.GetClosingStockData(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
            classHelper.nds.Tables["MaterialClosingDetail"].Clear();
            decimal totalKgs = 0;
            decimal totalAmount = 0;

            foreach (DataRow dr in dt.Rows) {
                
                if (dr["MATERIAL_ID"].ToString().Equals("5005")) {
                    classHelper.dataR = classHelper.nds.Tables["MaterialClosingDetail"].NewRow();
                    classHelper.dataR["date"] = Convert.ToDateTime(dr["DATE"].ToString());
                    classHelper.dataR["invoice"] = dr["INVOICE_NO"].ToString();
                    classHelper.dataR["canolaKg"] = Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    classHelper.dataR["canolaRate"] = Convert.ToDecimal(dr["KG_RATE"].ToString());
                    classHelper.dataR["canolaAmount"] = Convert.ToDecimal(dr["AMOUNT"].ToString());
                    classHelper.dataR["olienKg"] = 0;
                    classHelper.dataR["olienRate"] = 0;
                    classHelper.dataR["olienAmount"] = 0;
                    classHelper.dataR["soyaKg"] = 0;
                    classHelper.dataR["soyaRate"] = 0;
                    classHelper.dataR["soyaAmount"] = 0;
                    classHelper.dataR["hardKg"] = 0;
                    classHelper.dataR["hardRate"] = 0;
                    classHelper.dataR["hardAmount"] = 0;

                    canolaClosingWeight += Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    totalKgs += Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    totalAmount += Convert.ToDecimal(dr["AMOUNT"].ToString());

                    classHelper.dataR["totalKgs"] = totalKgs;
                    classHelper.dataR["totalAmount"] = totalAmount;
                    classHelper.dataR["from"] = dtp_FROM.Value.Date;
                    classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));

                    classHelper.nds.Tables["MaterialClosingDetail"].Rows.Add(classHelper.dataR);
                }
                else if (dr["MATERIAL_ID"].ToString().Equals("5003")) {
                    classHelper.dataR = classHelper.nds.Tables["MaterialClosingDetail"].NewRow();
                    classHelper.dataR["date"] = Convert.ToDateTime(dr["DATE"].ToString());
                    classHelper.dataR["invoice"] = dr["INVOICE_NO"].ToString();
                    classHelper.dataR["canolaKg"] = 0;
                    classHelper.dataR["canolaRate"] = 0;
                    classHelper.dataR["canolaAmount"] = 0;
                    classHelper.dataR["olienKg"] = Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    classHelper.dataR["olienRate"] = Convert.ToDecimal(dr["MUAND_RATE"].ToString());
                    classHelper.dataR["olienAmount"] = Convert.ToDecimal(dr["AMOUNT"].ToString());
                    classHelper.dataR["soyaKg"] = 0;
                    classHelper.dataR["soyaRate"] = 0;
                    classHelper.dataR["soyaAmount"] = 0;
                    classHelper.dataR["hardKg"] = 0;
                    classHelper.dataR["hardRate"] = 0;
                    classHelper.dataR["hardAmount"] = 0;

                    olienClosingWeight += Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    totalKgs += Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    totalAmount += Convert.ToDecimal(dr["AMOUNT"].ToString());

                    classHelper.dataR["totalKgs"] = totalKgs;
                    classHelper.dataR["totalAmount"] = totalAmount;
                    classHelper.dataR["from"] = dtp_FROM.Value.Date;
                    classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));

                    classHelper.nds.Tables["MaterialClosingDetail"].Rows.Add(classHelper.dataR);
                }
                else if (dr["MATERIAL_ID"].ToString().Equals("3002")) {
                    classHelper.dataR = classHelper.nds.Tables["MaterialClosingDetail"].NewRow();
                    classHelper.dataR["date"] = Convert.ToDateTime(dr["DATE"].ToString());
                    classHelper.dataR["invoice"] = dr["INVOICE_NO"].ToString();
                    classHelper.dataR["canolaKg"] = 0;
                    classHelper.dataR["canolaRate"] = 0;
                    classHelper.dataR["canolaAmount"] = 0;
                    classHelper.dataR["olienKg"] = 0;
                    classHelper.dataR["olienRate"] = 0;
                    classHelper.dataR["olienAmount"] = 0;
                    classHelper.dataR["soyaKg"] = Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    classHelper.dataR["soyaRate"] = Convert.ToDecimal(dr["MUAND_RATE"].ToString());
                    classHelper.dataR["soyaAmount"] = Convert.ToDecimal(dr["AMOUNT"].ToString());
                    classHelper.dataR["hardKg"] = 0;
                    classHelper.dataR["hardRate"] = 0;
                    classHelper.dataR["hardAmount"] = 0;

                    soyaClosingWeight += Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    totalKgs += Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    totalAmount += Convert.ToDecimal(dr["AMOUNT"].ToString());

                    classHelper.dataR["totalKgs"] = totalKgs;
                    classHelper.dataR["totalAmount"] = totalAmount;
                    classHelper.dataR["from"] = dtp_FROM.Value.Date;
                    classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));

                    classHelper.nds.Tables["MaterialClosingDetail"].Rows.Add(classHelper.dataR);
                }
                else if (dr["MATERIAL_ID"].ToString().Equals("5017")) {
                    classHelper.dataR = classHelper.nds.Tables["MaterialClosingDetail"].NewRow();
                    classHelper.dataR["date"] = Convert.ToDateTime(dr["DATE"].ToString());
                    classHelper.dataR["invoice"] = dr["INVOICE_NO"].ToString();
                    classHelper.dataR["canolaKg"] = 0;
                    classHelper.dataR["canolaRate"] = 0;
                    classHelper.dataR["canolaAmount"] = 0;
                    classHelper.dataR["olienKg"] = 0;
                    classHelper.dataR["olienRate"] = 0;
                    classHelper.dataR["olienAmount"] = 0;
                    classHelper.dataR["soyaKg"] = 0;
                    classHelper.dataR["soyaRate"] = 0;
                    classHelper.dataR["soyaAmount"] = 0;
                    classHelper.dataR["hardKg"] = Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    classHelper.dataR["hardRate"] = Convert.ToDecimal(dr["MUAND_RATE"].ToString());
                    classHelper.dataR["hardAmount"] = Convert.ToDecimal(dr["AMOUNT"].ToString());

                    hardClosingWeight += Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    totalKgs += Convert.ToDecimal(dr["NET_WEIGHT"].ToString());
                    totalAmount += Convert.ToDecimal(dr["AMOUNT"].ToString());

                    classHelper.dataR["totalKgs"] = totalKgs;
                    classHelper.dataR["totalAmount"] = totalAmount;
                    classHelper.dataR["from"] = dtp_FROM.Value.Date;
                    classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));

                    classHelper.nds.Tables["MaterialClosingDetail"].Rows.Add(classHelper.dataR);
                }
            }

            //foreach (DataGridViewRow dg in grdData.Rows)
            //{
            //    if (
            //            (
            //                !dg.Cells["canolaKg"].Value.ToString().Equals("0") ||
            //                !dg.Cells["olienKg"].Value.ToString().Equals("0") ||
            //                !dg.Cells["soyaKg"].Value.ToString().Equals("0") ||
            //                !dg.Cells["hardKg"].Value.ToString().Equals("0")
            //            ) 
            //            //||
            //            //(
            //            //    dg.Cells["canolaKg"].Value.ToString().Equals("0") && 
            //            //    !dg.Cells["olienKg"].Value.ToString().Equals("0") &&
            //            //    !dg.Cells["soyaKg"].Value.ToString().Equals("0") &&
            //            //    !dg.Cells["hardKg"].Value.ToString().Equals("0")
            //            //) ||
            //            //(
            //            //    !dg.Cells["canolaKg"].Value.ToString().Equals("0") && 
            //            //    dg.Cells["olienKg"].Value.ToString().Equals("0") &&
            //            //    !dg.Cells["soyaKg"].Value.ToString().Equals("0") &&
            //            //    !dg.Cells["hardKg"].Value.ToString().Equals("0")
            //            //) ||
            //            //(
            //            //    !dg.Cells["canolaKg"].Value.ToString().Equals("0") &&
            //            //    !dg.Cells["olienKg"].Value.ToString().Equals("0") &&
            //            //    dg.Cells["soyaKg"].Value.ToString().Equals("0") &&
            //            //    !dg.Cells["hardKg"].Value.ToString().Equals("0")
            //            //) ||
            //            //(
            //            //    !dg.Cells["canolaKg"].Value.ToString().Equals("0") &&
            //            //    !dg.Cells["olienKg"].Value.ToString().Equals("0") &&
            //            //    !dg.Cells["soyaKg"].Value.ToString().Equals("0") &&
            //            //    dg.Cells["hardKg"].Value.ToString().Equals("0")
            //            //)
            //        ) {
            //        classHelper.dataR = classHelper.nds.Tables["MaterialClosingDetail"].NewRow();
            //        classHelper.dataR["date"] = Convert.ToDateTime(dg.Cells["purchasesDate"].Value.ToString());
            //        classHelper.dataR["invoice"] = dg.Cells["invoice"].Value.ToString();

            //        classHelper.dataR["canolaKg"] = Convert.ToDecimal(dg.Cells["canolaKg"].Value.ToString());
            //        if (Convert.ToDecimal(dg.Cells["canolaKg"].Value.ToString()) == 0)
            //        {
            //            classHelper.dataR["canolaRate"] = 0;
            //        }
            //        else {
            //            classHelper.dataR["canolaRate"] = Convert.ToDecimal(dg.Cells["canolaRate"].Value.ToString());
            //        }
            //        classHelper.dataR["canolaAmount"] = Convert.ToDecimal(dg.Cells["canolaAmount"].Value.ToString());

            //        classHelper.dataR["olienKg"] = Convert.ToDecimal(dg.Cells["olienKg"].Value.ToString());
            //        if (Convert.ToDecimal(dg.Cells["olienRate"].Value.ToString()) == 0)
            //        {
            //            classHelper.dataR["olienRate"] = 0;
            //        }
            //        else
            //        {
            //            classHelper.dataR["olienRate"] = Convert.ToDecimal(dg.Cells["muandRate"].Value.ToString());
            //        }
            //        classHelper.dataR["olienAmount"] = Convert.ToDecimal(dg.Cells["olienAmount"].Value.ToString());

            //        classHelper.dataR["soyaKg"] = Convert.ToDecimal(dg.Cells["soyaKg"].Value.ToString());
            //        if (Convert.ToDecimal(dg.Cells["soyaRate"].Value.ToString()) == 0)
            //        {
            //            classHelper.dataR["soyaRate"] = 0;
            //        }
            //        else
            //        {
            //            classHelper.dataR["soyaRate"] = Convert.ToDecimal(dg.Cells["muandRate"].Value.ToString());
            //        }
            //        classHelper.dataR["soyaAmount"] = Convert.ToDecimal(dg.Cells["soyaAmount"].Value.ToString());

            //        classHelper.dataR["hardKg"] = Convert.ToDecimal(dg.Cells["hardKg"].Value.ToString());
            //        if (Convert.ToDecimal(dg.Cells["hardRate"].Value.ToString()) == 0)
            //        {
            //            classHelper.dataR["hardRate"] = 0;
            //        }
            //        else
            //        {
            //            classHelper.dataR["hardRate"] = Convert.ToDecimal(dg.Cells["muandRate"].Value.ToString());
            //        }
            //        classHelper.dataR["hardAmount"] = Convert.ToDecimal(dg.Cells["hardAmount"].Value.ToString());

            //        totalKgs += Convert.ToDecimal(dg.Cells["canolaKg"].Value.ToString()) + 
            //                    Convert.ToDecimal(dg.Cells["olienKg"].Value.ToString()) +
            //                    Convert.ToDecimal(dg.Cells["soyaKg"].Value.ToString()) +
            //                    Convert.ToDecimal(dg.Cells["hardKg"].Value.ToString());

            //        totalAmount += Convert.ToDecimal(dg.Cells["canolaAmount"].Value.ToString()) + 
            //                       Convert.ToDecimal(dg.Cells["olienAmount"].Value.ToString()) +
            //                       Convert.ToDecimal(dg.Cells["soyaAmount"].Value.ToString()) +
            //                       Convert.ToDecimal(dg.Cells["hardAmount"].Value.ToString());

            //        classHelper.dataR["totalKgs"] = totalKgs;
            //        classHelper.dataR["totalAmount"] = totalAmount;
            //        classHelper.dataR["from"] = dtp_FROM.Value.Date;
            //        classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));

            //        classHelper.nds.Tables["MaterialClosingDetail"].Rows.Add(classHelper.dataR);
            //    }
            //}
            //classHelper.rpt = new frmReports();
            //classHelper.rpt.GenerateReport("MaterialClosingDetail", classHelper.nds);
            //classHelper.rpt.ShowDialog();
        }

        private void ShowClosingSummaryReport()
        {
            classHelper.query = @"declare @from datetime;
            declare @to datetime;

            set @from = '2000-01-01';
            set @to = '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"';

            WITH AB AS (
	        SELECT MATERIAL_ID,SUM(([WEIGHT] - REC_WEIGHT)) AS [PO BALANCE] 
	        FROM PURCHASES_ORDER 
	        WHERE [STATUS] = 'N' AND [DATE] BETWEEN @from AND @to
	        GROUP BY MATERIAL_ID

	        --SELECT B.MATERIAL_ID,(A.[WEIGHT] - SUM(ISNULL(D.NET_WEIGHT,0))) AS [PO BALANCE]
            --   FROM PURCHASES_ORDER A
            --   LEFT JOIN PURCHASES D ON A.PO_ID = D.PO_ID
            --   INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
            --   WHERE A.[STATUS] = 'N' AND A.[DATE] BETWEEN @from AND @to
            --   GROUP BY B.MATERIAL_ID,A.[WEIGHT]
        )
			
        SELECT A.MATERIAL_NAME,(A.OPENING_QTY+ISNULL(X.BALANCE,0)-ISNULL(Y.OUT,0)-ISNULL(Q.OUT,0)) AS [OPENNIG BALANCE],
        ISNULL(Z.[PURCHASES BALANCE],0)+ISNULL(W.[ADJUSTED QTY],0) AS [PURCHASES BALANCE],
        ISNULL(M.[SALES BALANCE],0) + ISNULL(R.[SALES BALANCE],0) + ISNULL(T.[AA QTY],0) AS [SALES BALANCE],
        ISNULL(N.[SO BALANCE],0) AS [SO BALANCE],ISNULL(O.[PO BALANCE],0) AS [PO BALANCE]
        FROM MATERIALS A
        LEFT JOIN (
	        SELECT MATERIAL_ID,ISNULL(SUM(STOCK_IN),0) AS [BALANCE] 
	        FROM MATERIAL_ITEM_LEDGER 
	        WHERE [DATE] < @from AND ENTRY_FROM = 'PURCHASES'
	        GROUP BY MATERIAL_ID
        ) X ON A.MATERIAL_ID = X.MATERIAL_ID
        LEFT JOIN (
	        SELECT MATERIAL_ID,ISNULL(SUM(
		        CASE WHEN ADD_LESS = 'D' THEN ISNULL(-QTY,0) ELSE ISNULL(QTY,0) END
	        ),0) AS [ADJUSTED QTY]
	        FROM INVENTORY_ADJUSTMENTS
	        WHERE [DATE] BETWEEN @from AND @to
	        GROUP BY MATERIAL_ID
        ) W ON A.MATERIAL_ID = W.MATERIAL_ID
        LEFT JOIN (
	        SELECT F.MATERIAL_ID,SUM(C.[WEIGHT]) AS [OUT]
	        FROM SALES A
	        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
	        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
	        INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
	        INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
	        INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
	        WHERE A.[DATE] < @from AND C.ITEM_TYPE = 'P'
	        GROUP BY F.MATERIAL_ID
        ) Y ON Y.MATERIAL_ID = A.MATERIAL_ID
        LEFT JOIN (
	        SELECT F.MATERIAL_ID,SUM(C.[WEIGHT]) AS [OUT]
	        FROM SALES A
	        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
	        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
	        INNER JOIN MATERIALS F ON C.PRODUCT_ID = F.MATERIAL_ID
	        WHERE A.[DATE] < @from AND C.ITEM_TYPE = 'R'
	        GROUP BY F.MATERIAL_ID
        ) Q ON Q.MATERIAL_ID = A.MATERIAL_ID
        LEFT JOIN
        (
	        SELECT MATERIAL_ID,SUM(STOCK_IN) AS [PURCHASES BALANCE]
	        FROM MATERIAL_ITEM_LEDGER 
	        WHERE [DATE] BETWEEN @from AND @to AND ENTRY_FROM = 'PURCHASES'
	        GROUP BY MATERIAL_ID,ENTRY_FROM
        )Z ON A.MATERIAL_ID = Z.MATERIAL_ID
        LEFT JOIN (
	        SELECT F.MATERIAL_ID,SUM(C.[WEIGHT]) AS [SALES BALANCE]
	        FROM SALES A
	        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
	        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
	        INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
	        INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
	        INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
	        WHERE A.[DATE] BETWEEN @from AND @to AND C.ITEM_TYPE = 'P'
	        GROUP BY F.MATERIAL_ID
        ) M ON A.MATERIAL_ID = M.MATERIAL_ID
        LEFT JOIN (
	        SELECT F.MATERIAL_ID,SUM(C.[WEIGHT]) AS [SALES BALANCE]
	        FROM SALES A
	        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
	        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
	        INNER JOIN MATERIALS F ON C.PRODUCT_ID = F.MATERIAL_ID
	        WHERE A.[DATE] BETWEEN @from AND @to AND C.ITEM_TYPE = 'R'
	        GROUP BY F.MATERIAL_ID
        ) R ON A.MATERIAL_ID = R.MATERIAL_ID
        LEFT JOIN (
	        SELECT F.MATERIAL_ID,SUM(A.sales_weight) AS [AA QTY]
	        FROM AA_SALES A
	        INNER JOIN SALES_ORDER_DIRECT G ON A.SO_ID = G.SOD_ID
	        INNER JOIN MATERIALS F ON G.MATERIAL_ID = F.MATERIAL_ID
	        WHERE A.[DATE] BETWEEN @from AND @to
	        GROUP BY F.MATERIAL_ID
        ) T ON A.MATERIAL_ID = T.MATERIAL_ID
        LEFT JOIN (
	        SELECT C.MATERIAL_ID,SUM(A.[REMAINING_WEIGHT]) AS [SO BALANCE]
	        FROM SALES_ORDER_DIRECT A
	        INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
	        INNER JOIN MATERIALS C ON A.MATERIAL_ID = C.MATERIAL_ID
	        INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
	        INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
	        WHERE A.DATE BETWEEN @from AND @to AND A.STATUS = '1'
	        GROUP BY C.MATERIAL_ID
	        --SELECT A.MATERIAL_ID,sum(A.REMAINING_WEIGHT) AS [SO BALANCE]
	        --FROM SALES_ORDER_DIRECT A
	        --INNER JOIN MATERIALS C ON A.MATERIAL_ID = C.MATERIAL_ID
	        --WHERE A.DATE BETWEEN @from AND @to AND A.STATUS = '1'
	        --GROUP BY A.MATERIAL_ID
        ) N ON A.MATERIAL_ID = N.MATERIAL_ID
        LEFT JOIN (
	        SELECT AB.MATERIAL_ID,SUM(AB.[PO BALANCE]) AS [PO BALANCE] 
	        FROM AB 
	        GROUP BY AB.MATERIAL_ID
        ) O ON A.MATERIAL_ID = O.MATERIAL_ID
        WHERE A.MATERIAL_ID IN (5003,5005,3002,5017)";

            Classes.Helper.conn.Open();
            try
            {
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["MaterialClosingSummary"].Clear();
                    classHelper.dataR = classHelper.nds.Tables["MaterialClosingSummary"].NewRow();
                    while (classHelper.dr.Read())
                    {
                        if (classHelper.dr["MATERIAL_NAME"].ToString().Equals("OLIEN/RBD")) {
                            classHelper.dataR["olienOpening"] = Convert.ToDecimal(classHelper.dr["OPENNIG BALANCE"].ToString());
                            classHelper.dataR["olienPurchases"] = Convert.ToDecimal(classHelper.dr["PURCHASES BALANCE"].ToString());
                            classHelper.dataR["olienSales"] = Convert.ToDecimal(classHelper.dr["SALES BALANCE"].ToString());
                            classHelper.dataR["olienSO"] = Convert.ToDecimal(classHelper.dr["SO BALANCE"].ToString());
                            classHelper.dataR["olienPO"] = Convert.ToDecimal(classHelper.dr["PO BALANCE"].ToString());
                            classHelper.dataR["from"] = dtp_FROM.Value.Date;
                            classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                            classHelper.dataR["olienClosingBalance"] = olienClosingWeight;
                        }
                        else if (classHelper.dr["MATERIAL_NAME"].ToString().Equals("CANOLA"))
                        {
                            classHelper.dataR["canolaOpening"] = Convert.ToDecimal(classHelper.dr["OPENNIG BALANCE"].ToString());
                            classHelper.dataR["canolaPurchases"] = Convert.ToDecimal(classHelper.dr["PURCHASES BALANCE"].ToString());
                            classHelper.dataR["canolaSales"] = Convert.ToDecimal(classHelper.dr["SALES BALANCE"].ToString());
                            classHelper.dataR["canolaSO"] = Convert.ToDecimal(classHelper.dr["SO BALANCE"].ToString());
                            classHelper.dataR["canolaPO"] = Convert.ToDecimal(classHelper.dr["PO BALANCE"].ToString());
                            classHelper.dataR["from"] = dtp_FROM.Value.Date;
                            classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                            classHelper.dataR["canolaClosingBalance"] = canolaClosingWeight;
                        }
                        else if (classHelper.dr["MATERIAL_NAME"].ToString().Equals("SOYA BEAN"))
                        {
                            classHelper.dataR["soyaOpening"] = Convert.ToDecimal(classHelper.dr["OPENNIG BALANCE"].ToString());
                            classHelper.dataR["soyaPurchases"] = Convert.ToDecimal(classHelper.dr["PURCHASES BALANCE"].ToString());
                            classHelper.dataR["soyaSales"] = Convert.ToDecimal(classHelper.dr["SALES BALANCE"].ToString());
                            classHelper.dataR["soyaSO"] = Convert.ToDecimal(classHelper.dr["SO BALANCE"].ToString());
                            classHelper.dataR["soyaPO"] = Convert.ToDecimal(classHelper.dr["PO BALANCE"].ToString());
                            classHelper.dataR["from"] = dtp_FROM.Value.Date;
                            classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                            classHelper.dataR["soyaClosingBalance"] = soyaClosingWeight;
                        }
                        else if (classHelper.dr["MATERIAL_NAME"].ToString().Equals("HARD OIL"))
                        {
                            classHelper.dataR["hardOpening"] = Convert.ToDecimal(classHelper.dr["OPENNIG BALANCE"].ToString());
                            classHelper.dataR["hardPurchases"] = Convert.ToDecimal(classHelper.dr["PURCHASES BALANCE"].ToString());
                            classHelper.dataR["hardSales"] = Convert.ToDecimal(classHelper.dr["SALES BALANCE"].ToString());
                            classHelper.dataR["hardSO"] = Convert.ToDecimal(classHelper.dr["SO BALANCE"].ToString());
                            classHelper.dataR["hardPO"] = Convert.ToDecimal(classHelper.dr["PO BALANCE"].ToString());
                            classHelper.dataR["from"] = dtp_FROM.Value.Date;
                            classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                            classHelper.dataR["hardClosingBalance"] = hardClosingWeight;
                        }
                    }
                    classHelper.nds.Tables["MaterialClosingSummary"].Rows.Add(classHelper.dataR);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
            classHelper.rpt = new frmReports();
            classHelper.rpt.GenerateReport("MaterialClosingSummary", classHelper.nds);
            classHelper.rpt.ShowDialog();
        }

        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            ShowClosingReport();
            //GenerateReport();
            //if (grdData.Rows.Count > 0)
            //{
            //    ShowClosingReport();
            //}
            ShowClosingSummaryReport();
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
