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
    public partial class frm_IncomeStatementReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_IncomeStatementReport()
        {
            InitializeComponent();
        }


        private void GenerateOpeningReport()
        {
            double olienSalesWeight = 0;
            double canolaSalesWeight = 0;
            double soyaSalesWeight = 0;
            double hardSalesWeight = 0;

            double olienAdjustmentWeight = 0;
            double canolaAdjustmentWeight = 0;
            double soyaAdjustmentWeight = 0;
            double hardAdjustmentWeight = 0;

            grdOpening.Rows.Clear();
            //classHelper.query = @"SELECT A.MATERIAL_ID,CONVERT(DATETIME,FORMAT(A.DATE,'yyyy-MM-dd')) AS [DATE],B.INVOICE_NO,
            //SUM(A.STOCK_IN) AS [OLIEN / RBD],'PURCHASES' AS [TYPE],
            //B.KG_RATE,B.MUAND_RATE,B.MUAND_VALUE,
            //C.BALANCE
            //FROM MATERIAL_ITEM_LEDGER A
            //INNER JOIN PURCHASES B ON A.REF_NO = B.PI_ID
            //INNER JOIN (
            // SELECT A.MATERIAL_ID,(A.OPENING_QTY+ISNULL(X.BALANCE,0)-ISNULL(Y.OUT,0)) AS [OPENING BALANCE],Z.SALES,
            // Z.SALES - (A.OPENING_QTY+ISNULL(X.BALANCE,0)-ISNULL(Y.OUT,0)) AS [BALANCE],'OPENING' AS [TYPE]
            // FROM MATERIALS A
            // LEFT JOIN (
            // SELECT MATERIAL_ID,ISNULL(SUM(STOCK_IN),0) AS [BALANCE] 
            // FROM MATERIAL_ITEM_LEDGER 
            // WHERE [DATE] < '2000-01-01' AND ENTRY_FROM = 'PURCHASES'
            //          GROUP BY MATERIAL_ID
            // ) X ON A.MATERIAL_ID = X.MATERIAL_ID
            // LEFT JOIN (
            // SELECT F.MATERIAL_ID,SUM(C.WEIGHT) AS [OUT]
            // FROM SALES A
            // INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            // INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            // INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
            // INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
            // INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
            // WHERE A.[DATE] < '2000-01-01'
            //          GROUP BY F.MATERIAL_ID
            // ) Y ON Y.MATERIAL_ID = A.MATERIAL_ID
            // INNER JOIN (
            // SELECT F.MATERIAL_ID,SUM(C.WEIGHT) AS [SALES]
            // FROM SALES A
            // INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            // INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            // INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
            // INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
            // INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
            // WHERE A.[DATE] >= '2000-01-01' AND A.[DATE] < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"'
            //          GROUP BY F.MATERIAL_ID
            // ) Z ON A.MATERIAL_ID = Z.MATERIAL_ID
            // WHERE A.MATERIAL_ID IN (5003,5005)
            //) C ON A.MATERIAL_ID = C.MATERIAL_ID
            //WHERE A.[DATE] >= '2000-01-01' AND A.[DATE] < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND ENTRY_FROM = 'PURCHASES'
            //      GROUP BY B.INVOICE_NO,A.MATERIAL_ID,CONVERT(DATETIME,FORMAT(A.DATE,'yyyy-MM-dd')),A.ENTRY_FROM,B.PI_ID,C.BALANCE,
            //B.KG_RATE,B.MUAND_RATE,B.MUAND_VALUE
            //ORDER BY [DATE]";

            classHelper.query = @"SELECT A.MATERIAL_ID,CONVERT(DATETIME,FORMAT(A.DATE,'yyyy-MM-dd')) AS [DATE],B.INVOICE_NO,
            SUM(A.STOCK_IN) AS [OLIEN / RBD],'PURCHASES' AS [TYPE],
            B.KG_RATE,B.MUAND_RATE,B.MUAND_VALUE,
            ISNULL(C.BALANCE,0) + ISNULL(Q.QTY,0) AS [BALANCE],ISNULL(W.[ADJUSTED QTY],0) AS [ADJUSTED QTY],B.PI_ID
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
                WHERE A.[DATE] <'" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND C.ITEM_TYPE = 'P'
                        GROUP BY F.MATERIAL_ID
                ) Z ON A.MATERIAL_ID = Z.MATERIAL_ID

	            LEFT JOIN (
                SELECT F.MATERIAL_ID,SUM(C.[WEIGHT]) AS [SALES]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN MATERIALS F ON C.PRODUCT_ID = F.MATERIAL_ID
                WHERE A.[DATE] <'" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND C.ITEM_TYPE = 'R'
                        GROUP BY F.MATERIAL_ID
                ) W ON A.MATERIAL_ID = W.MATERIAL_ID
			 
                WHERE A.MATERIAL_ID IN (5003,5005,3002,5017)
            ) C ON A.MATERIAL_ID = C.MATERIAL_ID
            LEFT JOIN (
	            SELECT MATERIAL_ID,SUM(
		            CASE WHEN ADD_LESS = 'D' THEN QTY ELSE -QTY END
	            ) AS [ADJUSTED QTY]
	            FROM INVENTORY_ADJUSTMENTS
	            WHERE [DATE] <'" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"'
	            GROUP BY MATERIAL_ID
            ) W ON A.MATERIAL_ID = W.MATERIAL_ID
            LEFT JOIN (
				SELECT F.MATERIAL_ID,SUM(A.sales_weight) AS [QTY]
				FROM AA_SALES A
				INNER JOIN SALES_ORDER_DIRECT G ON A.SO_ID = G.SOD_ID
				INNER JOIN MATERIALS F ON G.MATERIAL_ID = F.MATERIAL_ID
				WHERE A.[DATE] <'" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"'
				GROUP BY F.MATERIAL_ID
			) Q ON A.MATERIAL_ID = Q.MATERIAL_ID
            WHERE A.[DATE] <'" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND ENTRY_FROM = 'PURCHASES'
                    GROUP BY B.INVOICE_NO,A.MATERIAL_ID,CONVERT(DATETIME,FORMAT(A.DATE,'yyyy-MM-dd')),A.ENTRY_FROM,B.PI_ID,C.BALANCE,
            B.KG_RATE,B.MUAND_RATE,B.MUAND_VALUE,W.[ADJUSTED QTY],Q.QTY
            UNION ALL 
            SELECT MATERIAL_ID,'2000-01-01' AS [DATE],'-' AS [INVOICE_NO],OPENING_QTY AS [OLIEN/RBD],
            'OPENING' AS [TYPE],OPENING_RATE AS [KG_RATE],OPENING_RATE * 37.324 AS [MUAND_RATE],
            '37.324' AS [MUAND_VALUE],0 AS [BALANCE],'0' AS [ADJUSTED QTY],'0' AS [PI_ID]
            FROM MATERIALS
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
                        if (!isOlienSalesFound)
                        {
                            if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5003"))
                            {
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
                            grdOpening.Rows.Add(classHelper.dr["DATE"].ToString(), classHelper.dr["INVOICE_NO"].ToString(),
                            classHelper.dr["OLIEN / RBD"].ToString(), classHelper.dr["KG_RATE"].ToString(),
                            Convert.ToDouble(classHelper.dr["OLIEN / RBD"].ToString()) * Convert.ToDouble(classHelper.dr["KG_RATE"].ToString()),
                            0, 0, 0, classHelper.dr["MUAND_RATE"].ToString(), classHelper.dr["MATERIAL_ID"].ToString(),
                            0, 0, 0, 0, 0, 0);
                        }
                        else if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5003"))
                        {
                            grdOpening.Rows.Add(classHelper.dr["DATE"].ToString(), classHelper.dr["INVOICE_NO"].ToString(),
                            0, 0, 0,
                            classHelper.dr["OLIEN / RBD"].ToString(), classHelper.dr["KG_RATE"].ToString(),
                            Convert.ToDouble(classHelper.dr["OLIEN / RBD"].ToString()) * Convert.ToDouble(classHelper.dr["KG_RATE"].ToString()),
                            classHelper.dr["MUAND_RATE"].ToString(), classHelper.dr["MATERIAL_ID"].ToString(),
                            0, 0, 0, 0, 0, 0);
                        }
                        else if (classHelper.dr["MATERIAL_ID"].ToString().Equals("3002"))
                        {
                            grdOpening.Rows.Add(classHelper.dr["DATE"].ToString(), classHelper.dr["INVOICE_NO"].ToString(),
                            0, 0, 0, 0, 0, 0,
                            classHelper.dr["MUAND_RATE"].ToString(), classHelper.dr["MATERIAL_ID"].ToString(), classHelper.dr["OLIEN / RBD"].ToString(),
                            classHelper.dr["KG_RATE"].ToString(), Convert.ToDouble(classHelper.dr["OLIEN / RBD"].ToString()) * Convert.ToDouble(classHelper.dr["KG_RATE"].ToString()),
                            0, 0, 0);
                        }
                        else if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5017"))
                        {
                            grdOpening.Rows.Add(classHelper.dr["DATE"].ToString(), classHelper.dr["INVOICE_NO"].ToString(),
                            0, 0, 0, 0, 0, 0,
                            classHelper.dr["MUAND_RATE"].ToString(), classHelper.dr["MATERIAL_ID"].ToString(), 0, 0, 0,
                            classHelper.dr["OLIEN / RBD"].ToString(), classHelper.dr["KG_RATE"].ToString(), Convert.ToDouble(classHelper.dr["OLIEN / RBD"].ToString()) * Convert.ToDouble(classHelper.dr["KG_RATE"].ToString()));
                        }
                    }
                }

                foreach (DataGridViewRow dg in grdOpening.Rows)
                {
                    if (dg.Cells["openMaterialId"].Value.ToString().Equals("5005"))
                    {
                        double canola = Convert.ToDouble(dg.Cells["openCanolaKg"].Value.ToString());
                        if (canola < canolaSalesWeight)
                        {
                            canolaSalesWeight = canolaSalesWeight - canola;
                            dg.Cells["openCanolaKg"].Value = 0;
                            dg.Cells["openCanolaRate"].Value = 0;
                            dg.Cells["openCanolaAmount"].Value = Convert.ToDouble(dg.Cells["openCanolaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openCanolaRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["openCanolaKg"].Value = canola - canolaSalesWeight;
                            dg.Cells["openCanolaAmount"].Value = Convert.ToDouble(dg.Cells["openCanolaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openCanolaRate"].Value.ToString());
                            canolaSalesWeight = 0;
                        }

                        canola = Convert.ToDouble(dg.Cells["openCanolaKg"].Value.ToString());
                        if (canola < canolaAdjustmentWeight)
                        {
                            canolaAdjustmentWeight = canolaAdjustmentWeight - canola;
                            dg.Cells["openCanolaKg"].Value = 0;
                            dg.Cells["openCanolaRate"].Value = 0;
                            dg.Cells["openCanolaAmount"].Value = Convert.ToDouble(dg.Cells["openCanolaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openCanolaRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["openCanolaKg"].Value = canola - canolaAdjustmentWeight;
                            dg.Cells["openCanolaAmount"].Value = Convert.ToDouble(dg.Cells["openCanolaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openCanolaRate"].Value.ToString());
                            canolaAdjustmentWeight = 0;
                        }
                    }
                    else if (dg.Cells["openMaterialId"].Value.ToString().Equals("5003"))
                    {
                        double olien = Convert.ToDouble(dg.Cells["openOlienKg"].Value.ToString());
                        if (olien < olienSalesWeight)
                        {
                            olienSalesWeight = olienSalesWeight - olien;
                            dg.Cells["openOlienKg"].Value = 0;
                            dg.Cells["openOlienRate"].Value = 0;
                            dg.Cells["openOlienAmount"].Value = Convert.ToDouble(dg.Cells["openOlienKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openOlienRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["openOlienKg"].Value = olien - olienSalesWeight;
                            dg.Cells["openOlienAmount"].Value = Convert.ToDouble(dg.Cells["openOlienKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openOlienRate"].Value.ToString());
                            olienSalesWeight = 0;
                        }

                        olien = Convert.ToDouble(dg.Cells["openOlienKg"].Value.ToString());
                        if (olien < olienAdjustmentWeight)
                        {
                            olienAdjustmentWeight = olienAdjustmentWeight - olien;
                            dg.Cells["openOlienKg"].Value = 0;
                            dg.Cells["openOlienRate"].Value = 0;
                            dg.Cells["openOlienAmount"].Value = Convert.ToDouble(dg.Cells["openOlienKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openOlienRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["openOlienKg"].Value = olien - olienAdjustmentWeight;
                            dg.Cells["openOlienAmount"].Value = Convert.ToDouble(dg.Cells["openOlienKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openOlienRate"].Value.ToString());
                            olienAdjustmentWeight = 0;
                        }
                    }
                    else if (dg.Cells["openMaterialId"].Value.ToString().Equals("3002"))
                    {
                        double soya = Convert.ToDouble(dg.Cells["openSoyaKg"].Value.ToString());
                        if (soya < soyaSalesWeight)
                        {
                            soyaSalesWeight = soyaSalesWeight - soya;
                            dg.Cells["openSoyaKg"].Value = 0;
                            dg.Cells["openSoyaRate"].Value = 0;
                            dg.Cells["openSoyaAmount"].Value = Convert.ToDouble(dg.Cells["openSoyaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openSoyaRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["openSoyaKg"].Value = soya - soyaSalesWeight;
                            dg.Cells["openSoyaAmount"].Value = Convert.ToDouble(dg.Cells["openSoyaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openSoyaRate"].Value.ToString());
                            soyaSalesWeight = 0;
                        }

                        soya = Convert.ToDouble(dg.Cells["openSoyaKg"].Value.ToString());
                        if (soya < soyaAdjustmentWeight)
                        {
                            soyaAdjustmentWeight = soyaAdjustmentWeight - soya;
                            dg.Cells["openSoyaKg"].Value = 0;
                            dg.Cells["openSoyaRate"].Value = 0;
                            dg.Cells["openSoyaAmount"].Value = Convert.ToDouble(dg.Cells["openSoyaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openSoyaRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["openSoyaKg"].Value = soya - soyaAdjustmentWeight;
                            dg.Cells["openSoyaAmount"].Value = Convert.ToDouble(dg.Cells["openSoyaKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openSoyaRate"].Value.ToString());
                            soyaAdjustmentWeight = 0;
                        }
                    }
                    else if (dg.Cells["openMaterialId"].Value.ToString().Equals("5017"))
                    {
                        double hard = Convert.ToDouble(dg.Cells["openHardKg"].Value.ToString());
                        if (hard < hardSalesWeight)
                        {
                            hardSalesWeight = hardSalesWeight - hard;
                            dg.Cells["openHardKg"].Value = 0;
                            dg.Cells["openHardRate"].Value = 0;
                            dg.Cells["openHardAmount"].Value = Convert.ToDouble(dg.Cells["openHardKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openHardRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["openHardKg"].Value = hard - hardSalesWeight;
                            dg.Cells["openHardAmount"].Value = Convert.ToDouble(dg.Cells["openHardKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openHardRate"].Value.ToString());
                            hardSalesWeight = 0;
                        }

                        hard = Convert.ToDouble(dg.Cells["openHardKg"].Value.ToString());
                        if (hard < hardAdjustmentWeight)
                        {
                            hardAdjustmentWeight = hardAdjustmentWeight - hard;
                            dg.Cells["openHardKg"].Value = 0;
                            dg.Cells["openHardRate"].Value = 0;
                            dg.Cells["openHardAmount"].Value = Convert.ToDouble(dg.Cells["openHardKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openHardRate"].Value.ToString());
                        }
                        else
                        {
                            dg.Cells["openHardKg"].Value = hard - hardAdjustmentWeight;
                            dg.Cells["openHardAmount"].Value = Convert.ToDouble(dg.Cells["openHardKg"].Value.ToString()) * Convert.ToDouble(dg.Cells["openHardRate"].Value.ToString());
                            hardAdjustmentWeight = 0;
                        }
                    }
                }
                lblOpenCanola.Text = grdOpening.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["openCanolaAmount"].Value)).ToString();
                lblOpenOlien.Text = grdOpening.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["openOlienAmount"].Value)).ToString();
                lblOpenSoya.Text = grdOpening.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["openSoyaAmount"].Value)).ToString();
                lblOpenHard.Text = grdOpening.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["openHardAmount"].Value)).ToString();
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
                        if (!isOlienSalesFound)
                        {
                            if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5003"))
                            {
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
                            0, 0, 0, 0, 0, 0,
                            classHelper.dr["MUAND_RATE"].ToString(), classHelper.dr["MATERIAL_ID"].ToString(), classHelper.dr["OLIEN / RBD"].ToString(),
                            classHelper.dr["KG_RATE"].ToString(), Convert.ToDouble(classHelper.dr["OLIEN / RBD"].ToString()) * Convert.ToDouble(classHelper.dr["KG_RATE"].ToString()),
                            0, 0, 0);
                        }
                        else if (classHelper.dr["MATERIAL_ID"].ToString().Equals("5017"))
                        {
                            grdData.Rows.Add(classHelper.dr["DATE"].ToString(), classHelper.dr["INVOICE_NO"].ToString(),
                            0, 0, 0, 0, 0, 0,
                            classHelper.dr["MUAND_RATE"].ToString(), classHelper.dr["MATERIAL_ID"].ToString(), 0, 0, 0,
                            classHelper.dr["OLIEN / RBD"].ToString(), classHelper.dr["KG_RATE"].ToString(), Convert.ToDouble(classHelper.dr["OLIEN / RBD"].ToString()) * Convert.ToDouble(classHelper.dr["KG_RATE"].ToString()));
                        }
                    }
                }

                foreach (DataGridViewRow dg in grdData.Rows)
                {
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
                        else
                        {
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
                lblTotalCanola.Text = grdData.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["canolaAmount"].Value)).ToString();
                lblTotalOlien.Text = grdData.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["olienAmount"].Value)).ToString();
                lblTotalSoya.Text = grdData.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["soyaAmount"].Value)).ToString();
                lblTotalHard.Text = grdData.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["hardAmount"].Value)).ToString();
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

        private void ShowReport()
        {
            char hasRows = 'N';
            if(rdbDetailed.Checked == true) { 
            classHelper.query = @"WITH A AS( SELECT 'TRADING / MANUFACTURING A/C.' AS [GROUP],
                'OPENING STOCK AS ON " + dtp_FROM.Value.Date.ToString("dd-MM-yyyy")+ @"' AS [ACCOUNT NAME],
                --(SUM(STOCK_IN) - SUM(STOCK_OUT)) * 
                --AVG(CASE WHEN COST_AMT = '0' THEN NULL ELSE COST_AMT END) 
                0 AS [AMOUNT]
                --FROM MATERIAL_ITEM_LEDGER
                --WHERE DATE < '"+ Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"'
                UNION ALL
                SELECT 'TRADING / MANUFACTURING A/C.' AS [GROUP],
                'CLOSING STOCK AS ON " + dtp_TO.Value.Date.ToString("dd-MM-yyyy") + @"' AS [ACCOUNT NAME],
                --((SUM(STOCK_IN) - SUM(STOCK_OUT)) * 
                --AVG(CASE WHEN COST_AMT = '0' THEN NULL ELSE COST_AMT END))*-1 
                '0' AS [AMOUNT]
                --FROM MATERIAL_ITEM_LEDGER
                --WHERE DATE <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                UNION ALL
                SELECT 'PROFIT & LOSS A/C.' AS [GROUP],
                B.COA_NAME AS [ACCOUNT],
                (
                SELECT ISNULL(SUM(DEBIT),'0') - ISNULL(SUM(CREDIT),'0') 
                FROM LEDGERS WHERE COA_ID = B.COA_ID
                AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) 
                AS [AMOUNT]
                FROM COA B
                WHERE B.CA_ID IN (10,11,17,25,27)
                UNION ALL
                SELECT 'PROFIT & LOSS A/C.' AS [GROUP],
                B.COA_NAME AS [ACCOUNT],
                (
                SELECT ISNULL(SUM(DEBIT),'0') - ISNULL(SUM(CREDIT),'0') 
                FROM LEDGERS WHERE COA_ID = B.COA_ID
                AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) 
                AS [AMOUNT]
                FROM COA B
                WHERE B.CA_ID IN (9,12,13)
                UNION ALL
                --SELECT 'PROFIT & LOSS A/C.' AS [GROUP],'PURCHASES A/C' AS [ACCOUNT],
                --SUM(CASE WHEN C.MATERIAL_NAME = 'OLIEN/RBD' THEN (A.NET_WEIGHT * (A.MUAND_RATE / A.MUAND_VALUE)) ELSE
                --(A.NET_WEIGHT * A.KG_RATE) END) AS [AMOUNT]
                --FROM PURCHASES A
                --INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
                --INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID  
                --WHERE A.DATE <= '2020-08-03 00:00:00'
                SELECT 'PROFIT & LOSS A/C.' AS [GROUP],'PURCHASES A/C' AS [ACCOUNT],
                SUM(DEBIT) - SUM(CREDIT)  AS [AMOUNT] 
                FROM LEDGERS 
                WHERE COA_ID = 4012 AND [DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                UNION ALL
                SELECT 'PROFIT & LOSS A/C.' AS [GROUP],
                B.COA_NAME AS [ACCOUNT],
                (
                SELECT ISNULL(SUM(DEBIT),'0') - ISNULL(SUM(CREDIT),'0') 
                FROM LEDGERS WHERE COA_ID = B.COA_ID
                AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) 
                AS [AMOUNT]
                FROM COA B
                WHERE B.CA_ID IN (22,23) AND B.COA_ID <> '4012'
                )
				SELECT * FROM A
				ORDER BY 
                CASE
	                WHEN [ACCOUNT NAME] LIKE '%OPENING STOCK AS ON%' THEN '1'
	                WHEN [ACCOUNT NAME] LIKE '%CLOSING STOCK AS ON%' THEN '2'
	                ELSE [ACCOUNT NAME]
                END ASC";
            }
            else
            {
                classHelper.query = @"WITH A AS ( SELECT 'TRADING / MANUFACTURING A/C.' AS [GROUP],
                'OPENING STOCK AS ON " + dtp_FROM.Value.Date.ToString("dd-MM-yyyy") + @"' AS [ACCOUNT NAME],
                --(SUM(STOCK_IN) - SUM(STOCK_OUT)) * 
                --AVG(CASE WHEN COST_AMT = '0' THEN NULL ELSE COST_AMT END) 
                0 AS [AMOUNT]
                --FROM MATERIAL_ITEM_LEDGER
                --WHERE DATE < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"'
                UNION ALL
                SELECT 'TRADING / MANUFACTURING A/C.' AS [GROUP],
                'CLOSING STOCK AS ON " + dtp_TO.Value.Date.ToString("dd-MM-yyyy") + @"' AS [ACCOUNT NAME],
                --((SUM(STOCK_IN) - SUM(STOCK_OUT)) * 
                --AVG(CASE WHEN COST_AMT = '0' THEN NULL ELSE COST_AMT END))*-1 
                '0' AS [AMOUNT]
                --FROM MATERIAL_ITEM_LEDGER
                --WHERE DATE <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                UNION ALL
                SELECT 'PROFIT & LOSS A/C.' AS [GROUP],
                C.AG_NAME AS [ACCOUNT],
                (
                SELECT ISNULL(SUM(DEBIT),'0') - ISNULL(SUM(CREDIT),'0') 
                FROM LEDGERS WHERE COA_ID = B.COA_ID
                AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) 
                AS [AMOUNT]
                FROM COA B
                INNER JOIN ACCOUNT_GROUP C ON B.AG_ID = C.AG_ID
                WHERE B.CA_ID IN (10,11,17,25,27)
                UNION ALL
                SELECT 'PROFIT & LOSS A/C.' AS [GROUP],
                B.COA_NAME AS [ACCOUNT],
                (
                SELECT ISNULL(SUM(DEBIT),'0') - ISNULL(SUM(CREDIT),'0') 
                FROM LEDGERS WHERE COA_ID = B.COA_ID
                AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) 
                AS [AMOUNT]
                FROM COA B
                WHERE B.CA_ID IN (9,12,13)
                UNION ALL
                --SELECT 'PROFIT & LOSS A/C.' AS [GROUP],'PURCHASES A/C' AS [ACCOUNT],
                --SUM(CASE WHEN C.MATERIAL_NAME = 'OLIEN/RBD' THEN (A.NET_WEIGHT * (A.MUAND_RATE / A.MUAND_VALUE)) ELSE
                --(A.NET_WEIGHT * A.KG_RATE) END) AS [AMOUNT]
                --FROM PURCHASES A
                --INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
                --INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID  
                --WHERE A.DATE <= '2020-08-03 00:00:00'
                SELECT 'PROFIT & LOSS A/C.' AS [GROUP],'PURCHASES A/C' AS [ACCOUNT],
                SUM(DEBIT) - SUM(CREDIT)  AS [AMOUNT] 
                FROM LEDGERS 
                WHERE COA_ID = 4012 AND [DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                UNION ALL
                SELECT 'PROFIT & LOSS A/C.' AS [GROUP],
                B.COA_NAME AS [ACCOUNT],
                (
                SELECT ISNULL(SUM(DEBIT),'0') - ISNULL(SUM(CREDIT),'0') 
                FROM LEDGERS WHERE COA_ID = B.COA_ID
                AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) 
                AS [AMOUNT]
                FROM COA B
                WHERE B.CA_ID IN (22,23) AND B.COA_ID <> '4012')

				SELECT A.[GROUP],A.[ACCOUNT NAME],SUM(A.AMOUNT) AS [AMOUNT]
				FROM A
				GROUP BY A.[GROUP],A.[ACCOUNT NAME]
                ORDER BY 
                CASE
	                WHEN A.[ACCOUNT NAME] LIKE '%OPENING STOCK AS ON%' THEN 1
	                WHEN A.[ACCOUNT NAME] LIKE '%CLOSING STOCK AS ON%' THEN 2
	                ELSE 3
                END ASC";
            }

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.nds.Tables["IncomeStatement"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["IncomeStatement"].NewRow();
                        classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date);
                        classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date);
                        classHelper.dataR["Group"] = classHelper.dr["GROUP"].ToString();
                        classHelper.dataR["AccountName"] = classHelper.dr["ACCOUNT NAME"].ToString();
                        if (classHelper.dr["ACCOUNT NAME"].ToString().Equals("CLOSING STOCK AS ON " + dtp_TO.Value.Date.ToString("dd-MM-yyyy") + @""))
                        {
                            classHelper.dataR["Credit"] =
                                classHelper.GetClosingStockValue(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                            //-
                            //    classHelper.GetAdjustmentInventoryValue(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                            classHelper.dataR["Debit"] = 0;

                            //decimal balance = -1 * (
                            //    Convert.ToDecimal(lblTotalCanola.Text)+ 
                            //    Convert.ToDecimal(lblTotalOlien.Text)+
                            //    Convert.ToDecimal(lblTotalSoya.Text) +
                            //    Convert.ToDecimal(lblTotalHard.Text) 
                            //);
                            //if (balance >= 0)
                            //{
                            //    classHelper.dataR["Debit"] = balance;
                            //    classHelper.dataR["Credit"] = 0;
                            //}
                            //else
                            //{
                            //    classHelper.dataR["Credit"] = Math.Abs(balance);
                            //    classHelper.dataR["Debit"] = 0;
                            //}
                        }
                        else if (classHelper.dr["ACCOUNT NAME"].ToString().Equals("OPENING STOCK AS ON " + dtp_FROM.Value.Date.ToString("dd-MM-yyyy") + @""))
                        {
                            classHelper.dataR["Credit"] = 0;
                            classHelper.dataR["Debit"] = classHelper.GetClosingStockValue(dtp_FROM.Value.Date.AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59));

                            //decimal balance = (
                            //    Convert.ToDecimal(lblOpenCanola.Text) +
                            //    Convert.ToDecimal(lblOpenOlien.Text) +
                            //    Convert.ToDecimal(lblOpenSoya.Text) +
                            //    Convert.ToDecimal(lblOpenHard.Text)
                            //);
                            //if (balance >= 0)
                            //{
                            //    classHelper.dataR["Debit"] = balance;
                            //    classHelper.dataR["Credit"] = 0;
                            //}
                            //else
                            //{
                            //    classHelper.dataR["Credit"] = Math.Abs(balance);
                            //    classHelper.dataR["Debit"] = 0;
                            //}
                        }
                        else {
                            decimal balance = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                            if (balance >= 0)
                            {
                                classHelper.dataR["Debit"] = balance;
                                classHelper.dataR["Credit"] = 0;
                            }
                            else
                            {
                                classHelper.dataR["Credit"] = Math.Abs(balance);
                                classHelper.dataR["Debit"] = 0;
                            }
                        }
                        classHelper.nds.Tables["IncomeStatement"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
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
            
            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("IncomeStatement", classHelper.nds);
                classHelper.rpt.ShowDialog();
            }
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            GenerateOpeningReport();
            GenerateReport();
            ShowReport();
        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
