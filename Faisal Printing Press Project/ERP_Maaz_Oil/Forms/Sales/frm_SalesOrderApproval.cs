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
    public partial class frm_SalesOrderApproval : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_SalesOrderApproval()
        {
            InitializeComponent();
        }


        private void load_sales_person()
        {
            classHelper.query = @"SELECT 0 as [id], '--SELECT SALES PERSON--' as [name]
					union all
					SELECT sales_per_id as [id], name from SALES_PERSONS";
            classHelper.LoadComboData(cmbSalesPerson, classHelper.query);
        }
        //load COMBO BOXES
        private void LoadCustomers()
        {
            classHelper.LoadCustomersWithAll(cmbCustomer);
        }

        private void UpdateDiscardSO() {
            try
            {
                if (grdSOList.Rows.Count > 0)
                {
                    string soIds = "";
                    string sopIds = "";
                    foreach (DataGridViewRow dgvr in grdSOList.Rows)
                    {
                        if (dgvr.Cells["discard"].Value.ToString().Equals("True")) {
                            if(dgvr.Cells["TYPE"].Value.ToString().Equals("SOD"))
                                soIds += "'" + dgvr.Cells["soID"].Value.ToString() + "',";
                            else
                                sopIds += "'" + dgvr.Cells["soID"].Value.ToString() + "',";
                        }
                    }
                    if (!soIds.Equals(""))
                    {
                        soIds = soIds.TrimEnd(',');
                        classHelper.query = @"UPDATE SALES_ORDER_DIRECT SET STATUS = '0' WHERE SOD_ID IN ("+soIds+")";
                        if (classHelper.InsertUpdateDelete(classHelper.query) > 0) {
                            LoadSO();
                        }
                    }
                    if(!sopIds.Equals(""))
                    {
                        sopIds = sopIds.TrimEnd(',');
                        classHelper.query = @"UPDATE SALES_ORDER_PRODUCT_MASTER SET STATUS = '0' WHERE SOPM_ID IN (" + sopIds + ")";
                        if (classHelper.InsertUpdateDelete(classHelper.query) > 0)
                        {
                            LoadSO();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadSO() {
            if (cmbCustomer.SelectedValue.ToString().Equals("0"))
            {
                classHelper.query = @"SELECT A.SOD_ID,A.DATE AS [SALES ORDER DATE],A.INVOICE_NO AS [S.O #],B.COA_NAME AS [CUSTOMER NAME],
                C.MATERIAL_NAME AS [RAW MATERIAL],A.TOTAL_KGS AS [S.O WEIGHT],A.TOTAL_KGS - A.REMAINING_WEIGHT AS [DELIVERED WEIGHT],
                ROUND(A.REMAINING_WEIGHT,2) AS [BALANCE WEIGHT],convert(varchar(max),A.RATE) as RATE,A.DESCRIPTION,A.CREDIT_DAYS,'SOD' as [TYPE]
                FROM SALES_ORDER_DIRECT A
                INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                INNER JOIN MATERIALS C ON A.MATERIAL_ID = C.MATERIAL_ID
                INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
                INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
                WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND A.STATUS = '1'";

                if (cmbSalesPerson.SelectedIndex > 0)
                    classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";

                classHelper.query+= @"
                UNION ALL

                SELECT A.SOPM_ID,A.DATE AS[SALES ORDER DATE], A.INVOICE_NO AS[S.O #],B.COA_NAME AS [CUSTOMER NAME],
                (SELECT STUFF((SELECT  DISTINCT ',' + C.MATERIAL_NAME FROM SALES_ORDER_PRODUCT_DETAILS Z
                 INNER JOIN PRODUCT_DETAILS P ON Z.PRODUCT_ID = P.PD_ID
                 INNER JOIN MATERIALS C ON P.MATERIAL_ID = C.MATERIAL_ID
                 WHERE Z.SOPM_ID = A.SOPM_ID FOR XML PATH('')), 1, 1, '')
				) AS[RAW MATERIAL], 
				A.TOTAL_WEIGHT AS[S.O WEIGHT], A.TOTAL_WEIGHT - A.REMAINING_WEIGHT AS[DELIVERED WEIGHT],
                ROUND(A.REMAINING_WEIGHT,2) AS[BALANCE WEIGHT],
				(SELECT STUFF(
                    (SELECT ',' + COnvert(varchar(max), X.RATE) FROM SALES_ORDER_PRODUCT_DETAILS X where X.SOPM_ID = A.SOPM_ID FOR XML PATH(''))
                , 1, 1, '') 
				) as [RATE],
				A.DESCRIPTION, A.CREDIT_DAYS,'SOP' as [TYPE]
                FROM SALES_ORDER_PRODUCT_MASTER A
                LEFT JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
                INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
                WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND A.STATUS = '1'
                ";
                if (cmbSalesPerson.SelectedIndex > 0)
                    classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";
            }
            else {
                classHelper.query = @"SELECT A.SOD_ID,A.DATE AS [SALES ORDER DATE],A.INVOICE_NO AS [S.O #],B.COA_NAME AS [CUSTOMER NAME],
                C.MATERIAL_NAME AS [RAW MATERIAL],A.TOTAL_KGS AS [S.O WEIGHT],A.TOTAL_KGS - A.REMAINING_WEIGHT AS [DELIVERED WEIGHT],
                ROUND(A.REMAINING_WEIGHT,2) AS [BALANCE WEIGHT],convert(varchar(max),A.RATE) as RATE,A.DESCRIPTION,A.CREDIT_DAYS,'SOD' as [TYPE]
                FROM SALES_ORDER_DIRECT A
                INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                INNER JOIN MATERIALS C ON A.MATERIAL_ID = C.MATERIAL_ID
                INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
                INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
                WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND A.STATUS = '1' 
                AND B.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"'";


                if (cmbSalesPerson.SelectedIndex > 0)
                    classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";

                classHelper.query +=@"
                UNION ALL

                SELECT A.SOPM_ID,A.DATE AS[SALES ORDER DATE], A.INVOICE_NO AS[S.O #],B.COA_NAME AS [CUSTOMER NAME],
                (SELECT STUFF((SELECT  DISTINCT ',' + C.MATERIAL_NAME FROM SALES_ORDER_PRODUCT_DETAILS Z
				INNER JOIN PRODUCT_DETAILS P ON Z.PRODUCT_ID = P.PD_ID
				INNER JOIN MATERIALS C ON P.MATERIAL_ID = C.MATERIAL_ID
				WHERE Z.SOPM_ID = A.SOPM_ID FOR XML PATH('')),1,1,'')
				) AS[RAW MATERIAL], 
				A.TOTAL_WEIGHT AS[S.O WEIGHT], A.TOTAL_WEIGHT - A.REMAINING_WEIGHT AS[DELIVERED WEIGHT],
                ROUND(A.REMAINING_WEIGHT,2) AS[BALANCE WEIGHT], 
				(SELECT STUFF(
					(SELECT ',' + COnvert(varchar(max),X.RATE) FROM SALES_ORDER_PRODUCT_DETAILS X where X.SOPM_ID = A.SOPM_ID FOR XML PATH(''))
				,1,1,'') 
				) as [RATE],
				A.DESCRIPTION, A.CREDIT_DAYS,'SOP' as [TYPE]
                FROM SALES_ORDER_PRODUCT_MASTER A
                LEFT JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                LEFT JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
                LEFT JOIN SALES_PERSONS I ON C.SALE_PER_ID = I.SALES_PER_ID
                WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND A.STATUS = '1'
                AND B.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"'
                ";

                if (cmbSalesPerson.SelectedIndex > 0)
                    classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";
            }

          
            classHelper.query += " ORDER BY [SALES ORDER DATE] ";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                grdSOList.Rows.Clear();
                if (classHelper.dr.HasRows == true)
                {
                    while (classHelper.dr.Read())
                    {
                        if (classHelper.dr["RATE"].ToString().Equals("0"))
                        {
                            grdSOList.Rows.Add(false, classHelper.dr["SOD_ID"].ToString(), classHelper.dr["SALES ORDER DATE"].ToString(),
                            classHelper.dr["S.O #"].ToString(), classHelper.dr["CUSTOMER NAME"].ToString(),
                            classHelper.dr["RAW MATERIAL"].ToString(), Math.Round(Convert.ToDecimal(classHelper.dr["S.O WEIGHT"].ToString())),
                            Math.Round(Convert.ToDecimal(classHelper.dr["DELIVERED WEIGHT"].ToString())), Math.Round(Convert.ToDecimal(classHelper.dr["BALANCE WEIGHT"].ToString())),
                            classHelper.dr["DESCRIPTION"].ToString(), classHelper.dr["DESCRIPTION"].ToString(), classHelper.dr["CREDIT_DAYS"].ToString(),classHelper.dr["TYPE"].ToString());
                        }
                        else
                        {
                            grdSOList.Rows.Add(false, classHelper.dr["SOD_ID"].ToString(), classHelper.dr["SALES ORDER DATE"].ToString(),
                            classHelper.dr["S.O #"].ToString(), classHelper.dr["CUSTOMER NAME"].ToString(),
                            classHelper.dr["RAW MATERIAL"].ToString(), Math.Round(Convert.ToDecimal(classHelper.dr["S.O WEIGHT"].ToString())),
                            Math.Round(Convert.ToDecimal(classHelper.dr["DELIVERED WEIGHT"].ToString())), Math.Round(Convert.ToDecimal(classHelper.dr["BALANCE WEIGHT"].ToString())),
                            classHelper.dr["RATE"].ToString(), classHelper.dr["DESCRIPTION"].ToString(), classHelper.dr["CREDIT_DAYS"].ToString(), classHelper.dr["TYPE"].ToString());
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
                if (cmbCustomer.SelectedValue.ToString().Equals("0"))
                {
                    classHelper.query = @"SELECT A.DATE AS [SALES ORDER DATE],A.INVOICE_NO AS [S.O #],B.COA_NAME AS [CUSTOMER NAME],
                    C.MATERIAL_NAME AS [RAW MATERIAL],A.TOTAL_KGS AS [S.O WEIGHT],A.TOTAL_KGS - A.REMAINING_WEIGHT AS [DELIVERED WEIGHT],
                    ROUND(A.REMAINING_WEIGHT,2) AS [BALANCE WEIGHT],
                    convert(varchar(max),CASE WHEN C.MATERIAL_ID = '5005' THEN A.RATE ELSE ROUND(A.RATE * 37.324,0) END) AS [RATE],A.DESCRIPTION,A.CREDIT_DAYS
                    FROM SALES_ORDER_DIRECT A
                    INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                    INNER JOIN MATERIALS C ON A.MATERIAL_ID = C.MATERIAL_ID
                    INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
                    INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
                    WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'";

                if (cmbSalesPerson.SelectedIndex > 0)
                        classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";

                    classHelper.query += @"
                UNION ALL
                SELECT A.DATE AS[SALES ORDER DATE], A.INVOICE_NO AS[S.O #],B.COA_NAME AS [CUSTOMER NAME],
                (SELECT STUFF((SELECT  DISTINCT ', ' + C.MATERIAL_NAME FROM SALES_ORDER_PRODUCT_DETAILS Z
				INNER JOIN PRODUCT_DETAILS P ON Z.PRODUCT_ID = P.PD_ID
				INNER JOIN MATERIALS C ON P.MATERIAL_ID = C.MATERIAL_ID
				WHERE Z.SOPM_ID = A.SOPM_ID FOR XML PATH('')),1,1,'')
				) AS[RAW MATERIAL], 
				A.TOTAL_WEIGHT AS[S.O WEIGHT], A.TOTAL_WEIGHT - A.REMAINING_WEIGHT AS[DELIVERED WEIGHT],
                ROUND(A.REMAINING_WEIGHT,2) AS[BALANCE WEIGHT], 
				(SELECT STUFF(
					(SELECT ', ' + COnvert(varchar(max),X.RATE) FROM SALES_ORDER_PRODUCT_DETAILS X where X.SOPM_ID = A.SOPM_ID FOR XML PATH(''))
				,1,1,'') 
				) as [RATE],
				A.DESCRIPTION, A.CREDIT_DAYS
                FROM SALES_ORDER_PRODUCT_MASTER A
                LEFT JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
                INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
                    
                WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND A.STATUS = '1'
                ";
                    if (cmbSalesPerson.SelectedIndex > 0)
                        classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";
                }
                else {
                    classHelper.query = @"SELECT A.DATE AS [SALES ORDER DATE],A.INVOICE_NO AS [S.O #],B.COA_NAME AS [CUSTOMER NAME],
                    C.MATERIAL_NAME AS [RAW MATERIAL],A.TOTAL_KGS AS [S.O WEIGHT],A.TOTAL_KGS - A.REMAINING_WEIGHT AS [DELIVERED WEIGHT],
                    ROUND(A.REMAINING_WEIGHT,2) AS [BALANCE WEIGHT],
                    convert(varchar(max),CASE WHEN C.MATERIAL_ID = '5005' THEN A.RATE ELSE ROUND(A.RATE * 37.324,0) END) AS [RATE],A.DESCRIPTION,A.CREDIT_DAYS
                    FROM SALES_ORDER_DIRECT A
                    INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                    INNER JOIN MATERIALS C ON A.MATERIAL_ID = C.MATERIAL_ID
                INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
                INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
                    WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                    AND B.COA_ID = '"+cmbCustomer.SelectedValue.ToString()+ @"'
                    
";

                    if (cmbSalesPerson.SelectedIndex > 0)
                        classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";

                    classHelper.query += @"
                UNION ALL

                SELECT A.DATE AS[SALES ORDER DATE], A.INVOICE_NO AS[S.O #],B.COA_NAME AS [CUSTOMER NAME],
                (SELECT STUFF((SELECT  DISTINCT ', ' + C.MATERIAL_NAME FROM SALES_ORDER_PRODUCT_DETAILS Z
				INNER JOIN PRODUCT_DETAILS P ON Z.PRODUCT_ID = P.PD_ID
				INNER JOIN MATERIALS C ON P.MATERIAL_ID = C.MATERIAL_ID
				WHERE Z.SOPM_ID = A.SOPM_ID FOR XML PATH('')),1,1,'')
				) AS[RAW MATERIAL], 
				A.TOTAL_WEIGHT AS[S.O WEIGHT], A.TOTAL_WEIGHT - A.REMAINING_WEIGHT AS[DELIVERED WEIGHT],
                ROUND(A.REMAINING_WEIGHT,2) AS[BALANCE WEIGHT], 
				(SELECT STUFF(
					(SELECT ', ' + COnvert(varchar(max),X.RATE) FROM SALES_ORDER_PRODUCT_DETAILS X where X.SOPM_ID = A.SOPM_ID FOR XML PATH(''))
				,1,1,'') 
				) as [RATE],
				A.DESCRIPTION, A.CREDIT_DAYS
                FROM SALES_ORDER_PRODUCT_MASTER A
                LEFT JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
                INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
                WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND A.STATUS = '1'
                AND B.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"'
              ";
                    if (cmbSalesPerson.SelectedIndex > 0)
                        classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";
                }
                
            }
            else {
                if (cmbCustomer.SelectedValue.ToString().Equals("0"))
                {
                    classHelper.query = @"SELECT A.DATE AS [SALES ORDER DATE],A.INVOICE_NO AS [S.O #],B.COA_NAME AS [CUSTOMER NAME],
                    C.MATERIAL_NAME AS [RAW MATERIAL],A.TOTAL_KGS AS [S.O WEIGHT],A.TOTAL_KGS - A.REMAINING_WEIGHT AS [DELIVERED WEIGHT],
                    ROUND(A.REMAINING_WEIGHT,2) AS [BALANCE WEIGHT],
                    convert(varchar(max),CASE WHEN C.MATERIAL_ID = '5005' THEN A.RATE ELSE ROUND(A.RATE * 37.324,0) END) AS [RATE],A.DESCRIPTION,A.CREDIT_DAYS
                    FROM SALES_ORDER_DIRECT A
                    INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                    INNER JOIN MATERIALS C ON A.MATERIAL_ID = C.MATERIAL_ID
                INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
                INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
                    WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND A.STATUS = '1'
                   ";

                    if (cmbSalesPerson.SelectedIndex > 0)
                        classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";

                    classHelper.query += @"
                UNION ALL
                SELECT A.DATE AS[SALES ORDER DATE], A.INVOICE_NO AS[S.O #],B.COA_NAME AS [CUSTOMER NAME],
                (SELECT STUFF((SELECT  DISTINCT ', ' + C.MATERIAL_NAME FROM SALES_ORDER_PRODUCT_DETAILS Z
				INNER JOIN PRODUCT_DETAILS P ON Z.PRODUCT_ID = P.PD_ID
				INNER JOIN MATERIALS C ON P.MATERIAL_ID = C.MATERIAL_ID
				WHERE Z.SOPM_ID = A.SOPM_ID FOR XML PATH('')),1,1,'')
				) AS[RAW MATERIAL], 
				A.TOTAL_WEIGHT AS[S.O WEIGHT], A.TOTAL_WEIGHT - A.REMAINING_WEIGHT AS[DELIVERED WEIGHT],
                ROUND(A.REMAINING_WEIGHT,2) AS[BALANCE WEIGHT], 
				(SELECT STUFF(
					(SELECT ', ' + COnvert(varchar(max),X.RATE) FROM SALES_ORDER_PRODUCT_DETAILS X where X.SOPM_ID = A.SOPM_ID FOR XML PATH(''))
				,1,1,'') 
				) as [RATE],
				A.DESCRIPTION, A.CREDIT_DAYS
                FROM SALES_ORDER_PRODUCT_MASTER A
                LEFT JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
                INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
                WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND A.STATUS = '1'
                ";
                    if (cmbSalesPerson.SelectedIndex > 0)
                        classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";
                }
                else {
                    classHelper.query = @"SELECT A.DATE AS [SALES ORDER DATE],A.INVOICE_NO AS [S.O #],B.COA_NAME AS [CUSTOMER NAME],
                    C.MATERIAL_NAME AS [RAW MATERIAL],A.TOTAL_KGS AS [S.O WEIGHT],A.TOTAL_KGS - A.REMAINING_WEIGHT AS [DELIVERED WEIGHT],
                    ROUND(A.REMAINING_WEIGHT,2) AS [BALANCE WEIGHT],
                    convert(varchar(max),CASE WHEN C.MATERIAL_ID = '5005' THEN A.RATE ELSE ROUND(A.RATE * 37.324,0) END) AS [RATE],A.DESCRIPTION,A.CREDIT_DAYS
                    FROM SALES_ORDER_DIRECT A
                    INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                    INNER JOIN MATERIALS C ON A.MATERIAL_ID = C.MATERIAL_ID
                INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
                INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
                    WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND A.STATUS = '1'
                    AND B.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"'";

                    if (cmbSalesPerson.SelectedIndex > 0)
                        classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";

                    classHelper.query += @"
                UNION ALL

                SELECT A.DATE AS[SALES ORDER DATE], A.INVOICE_NO AS[S.O #],B.COA_NAME AS [CUSTOMER NAME],
                (SELECT STUFF((SELECT  DISTINCT ', ' + C.MATERIAL_NAME FROM SALES_ORDER_PRODUCT_DETAILS Z
				INNER JOIN PRODUCT_DETAILS P ON Z.PRODUCT_ID = P.PD_ID
				INNER JOIN MATERIALS C ON P.MATERIAL_ID = C.MATERIAL_ID
				WHERE Z.SOPM_ID = A.SOPM_ID FOR XML PATH('')),1,1,'')
				) AS[RAW MATERIAL], 
				A.TOTAL_WEIGHT AS[S.O WEIGHT], A.TOTAL_WEIGHT - A.REMAINING_WEIGHT AS[DELIVERED WEIGHT],
                ROUND(A.REMAINING_WEIGHT,2) AS[BALANCE WEIGHT], 
				(SELECT STUFF(
					(SELECT ', ' + COnvert(varchar(max),X.RATE) FROM SALES_ORDER_PRODUCT_DETAILS X where X.SOPM_ID = A.SOPM_ID FOR XML PATH(''))
				,1,1,'') 
				) as [RATE],
				A.DESCRIPTION, A.CREDIT_DAYS
                FROM SALES_ORDER_PRODUCT_MASTER A
                LEFT JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
                INNER JOIN CUSTOMER_PROFILE P ON B.COA_ID = P.COA_ID
                INNER JOIN SALES_PERSONS I ON P.SALE_PER_ID = I.SALES_PER_ID
                WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND A.STATUS = '1'
                AND B.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"'
               ";
                    if (cmbSalesPerson.SelectedIndex > 0)
                        classHelper.query += " AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + "'";
                }
                
            }

            classHelper.query += "  ORDER BY [SALES ORDER DATE]";

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.nds.Tables["SO_Report"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["SO_Report"].NewRow();
                        classHelper.dataR["DATE"] = Convert.ToDateTime(classHelper.dr["SALES ORDER DATE"].ToString());
                        classHelper.dataR["S.O #"] = classHelper.dr["S.O #"].ToString();
                        classHelper.dataR["CUSTOMER"] = classHelper.dr["CUSTOMER NAME"].ToString();
                        classHelper.dataR["RAW MATERIAL"] = classHelper.dr["RAW MATERIAL"].ToString();
                        classHelper.dataR["BALANCE_WEIGHT"] = Convert.ToDecimal(classHelper.dr["BALANCE WEIGHT"].ToString());
                        //if (classHelper.dr["RATE"].ToString().Equals("0")) {
                        //    classHelper.dataR["RATE"] = classHelper.dr["DESCRIPTION"].ToString();
                        //}
                        //else
                        //{
                        //    classHelper.dataR["RATE"] = classHelper.dr["RATE"].ToString();
                        //}
                        classHelper.dataR["RATE"] = classHelper.dr["RATE"].ToString();
                        classHelper.dataR["SO WEIGHT"] = Convert.ToDecimal(classHelper.dr["S.O WEIGHT"].ToString());
                        classHelper.dataR["DELIVERED WEIGHT"] = Convert.ToDecimal(classHelper.dr["DELIVERED WEIGHT"].ToString());
                        classHelper.dataR["CONDITION"] = classHelper.dr["CREDIT_DAYS"].ToString()+" DAYS";
                        classHelper.dataR["DESCRIPTION"] = classHelper.dr["DESCRIPTION"].ToString();
                        classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date);
                        classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                        classHelper.nds.Tables["SO_Report"].Rows.Add(classHelper.dataR);
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
                if (cmbCustomer.SelectedValue.ToString().Equals("0"))
                {
                    classHelper.query = @"DECLARE @FROM DATETIME;
                DECLARE @TO DATETIME;

                SET @FROM = '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"';
                SET @TO = '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"';

                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [TOTAL WEIGHT],
                ISNULL(D.[OLIEN WEIGHT],0) AS [OLIEN WEIGHT],ISNULL(E.[CANOLA WEIGHT],0) AS [CANOLA WEIGHT],
				ISNULL(F.[SINDH WEIGHT],0) AS [SINDH WEIGHT],ISNULL(I.[PUNJAB WEIGHT],0) AS [PUNJAB WEIGHT],
				ISNULL(G.[KPK WEIGHT],0) AS [KPK WEIGHT],ISNULL(H.[BALOCHISTAN WEIGHT],0) AS [BALOCHISTAN WEIGHT]
                FROM SALES_PERSONS A
                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [OLIEN WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN MATERIALS D ON C.MATERIAL_ID = D.MATERIAL_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO
	                AND D.MATERIAL_ID IN ('5003','3002')
	                GROUP BY A.NAME
                ) D ON A.NAME = D.[SALES PERSON]
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [CANOLA WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN MATERIALS D ON C.MATERIAL_ID = D.MATERIAL_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO
	                AND D.MATERIAL_ID = '5005'
	                GROUP BY A.NAME
                ) E ON A.NAME = E.[SALES PERSON]
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [SINDH WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO
	                AND E.REGION_ID = '1'
	                GROUP BY A.NAME
                ) F ON A.NAME = F.[SALES PERSON]
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [KPK WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO
	                AND E.REGION_ID = '2'
	                GROUP BY A.NAME
                ) G ON A.NAME = G.[SALES PERSON]
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [BALOCHISTAN WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO
	                AND E.REGION_ID = '3'
	                GROUP BY A.NAME
                ) H ON A.NAME = H.[SALES PERSON]
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [PUNJAB WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO
	                AND E.REGION_ID = '1002'
	                GROUP BY A.NAME
                ) I ON A.NAME = I.[SALES PERSON]
                WHERE C.DATE BETWEEN @FROM AND @TO
                GROUP BY A.NAME,D.[OLIEN WEIGHT],E.[CANOLA WEIGHT],F.[SINDH WEIGHT],I.[PUNJAB WEIGHT],G.[KPK WEIGHT],H.[BALOCHISTAN WEIGHT]";
                }
                else {
                    classHelper.query = @"DECLARE @FROM DATETIME;
                DECLARE @TO DATETIME;
                DECLARE @CUST_ID INT;

                SET @FROM = '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"';
                SET @TO = '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"';
                SET @CUST_ID = '"+ cmbCustomer.SelectedValue.ToString() + @"';

                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [TOTAL WEIGHT],
                ISNULL(D.[OLIEN WEIGHT],0) AS [OLIEN WEIGHT],ISNULL(E.[CANOLA WEIGHT],0) AS [CANOLA WEIGHT],
				ISNULL(F.[SINDH WEIGHT],0) AS [SINDH WEIGHT],ISNULL(I.[PUNJAB WEIGHT],0) AS [PUNJAB WEIGHT],
				ISNULL(G.[KPK WEIGHT],0) AS [KPK WEIGHT],ISNULL(H.[BALOCHISTAN WEIGHT],0) AS [BALOCHISTAN WEIGHT]
                FROM SALES_PERSONS A
                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [OLIEN WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN MATERIALS D ON C.MATERIAL_ID = D.MATERIAL_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO AND B.COA_ID = @CUST_ID
	                AND D.MATERIAL_ID IN ('5003','3002')
	                GROUP BY A.NAME
                ) D ON A.NAME = D.[SALES PERSON]
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [CANOLA WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN MATERIALS D ON C.MATERIAL_ID = D.MATERIAL_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO AND B.COA_ID = @CUST_ID
	                AND D.MATERIAL_ID = '5005'
	                GROUP BY A.NAME
                ) E ON A.NAME = E.[SALES PERSON]
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [SINDH WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO AND B.COA_ID = @CUST_ID
	                AND E.REGION_ID = '1'
	                GROUP BY A.NAME
                ) F ON A.NAME = F.[SALES PERSON]
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [KPK WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO AND B.COA_ID = @CUST_ID
	                AND E.REGION_ID = '2'
	                GROUP BY A.NAME
                ) G ON A.NAME = G.[SALES PERSON]
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [BALOCHISTAN WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO AND B.COA_ID = @CUST_ID
	                AND E.REGION_ID = '3'
	                GROUP BY A.NAME
                ) H ON A.NAME = H.[SALES PERSON]
                LEFT JOIN (
	                SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [PUNJAB WEIGHT] 
	                FROM SALES_PERSONS A
	                LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                WHERE C.DATE BETWEEN @FROM AND @TO AND B.COA_ID = @CUST_ID
	                AND E.REGION_ID = '1002'
	                GROUP BY A.NAME
                ) I ON A.NAME = I.[SALES PERSON]
                WHERE C.DATE BETWEEN @FROM AND @TO AND B.COA_ID = @CUST_ID
                GROUP BY A.NAME,D.[OLIEN WEIGHT],E.[CANOLA WEIGHT],F.[SINDH WEIGHT],I.[PUNJAB WEIGHT],G.[KPK WEIGHT],H.[BALOCHISTAN WEIGHT]";
                }
                
            }
            else {
                if (cmbCustomer.SelectedValue.ToString().Equals("0"))
                {
                    classHelper.query = @"DECLARE @FROM DATETIME;
                    DECLARE @TO DATETIME;

                    SET @FROM = '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"';
                    SET @TO = '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"';

                    SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [TOTAL WEIGHT],
                    ISNULL(D.[OLIEN WEIGHT],0) AS [OLIEN WEIGHT],ISNULL(E.[CANOLA WEIGHT],0) AS [CANOLA WEIGHT],
				    ISNULL(F.[SINDH WEIGHT],0) AS [SINDH WEIGHT],ISNULL(I.[PUNJAB WEIGHT],0) AS [PUNJAB WEIGHT],
				    ISNULL(G.[KPK WEIGHT],0) AS [KPK WEIGHT],ISNULL(H.[BALOCHISTAN WEIGHT],0) AS [BALOCHISTAN WEIGHT]
                    FROM SALES_PERSONS A
                    LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
                    LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
                    LEFT JOIN (
	                    SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [OLIEN WEIGHT] 
	                    FROM SALES_PERSONS A
	                    LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                    LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                    LEFT JOIN MATERIALS D ON C.MATERIAL_ID = D.MATERIAL_ID
	                    WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1
	                    AND D.MATERIAL_ID IN ('5003','3002')
	                    GROUP BY A.NAME
                    ) D ON A.NAME = D.[SALES PERSON]
                    LEFT JOIN (
	                    SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [CANOLA WEIGHT] 
	                    FROM SALES_PERSONS A
	                    LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                    LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                    LEFT JOIN MATERIALS D ON C.MATERIAL_ID = D.MATERIAL_ID
	                    WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1
	                    AND D.MATERIAL_ID = '5005'
	                    GROUP BY A.NAME
                    ) E ON A.NAME = E.[SALES PERSON]
                    LEFT JOIN (
	                    SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [SINDH WEIGHT] 
	                    FROM SALES_PERSONS A
	                    LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                    LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                    LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                    LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                    WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1
	                    AND E.REGION_ID = '1'
	                    GROUP BY A.NAME
                    ) F ON A.NAME = F.[SALES PERSON]
                    LEFT JOIN (
	                    SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [KPK WEIGHT] 
	                    FROM SALES_PERSONS A
	                    LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                    LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                    LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                    LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                    WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1
	                    AND E.REGION_ID = '2'
	                    GROUP BY A.NAME
                    ) G ON A.NAME = G.[SALES PERSON]
                    LEFT JOIN (
	                    SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [BALOCHISTAN WEIGHT] 
	                    FROM SALES_PERSONS A
	                    LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                    LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                    LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                    LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                    WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1
	                    AND E.REGION_ID = '3'
	                    GROUP BY A.NAME
                    ) H ON A.NAME = H.[SALES PERSON]
                    LEFT JOIN (
	                    SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [PUNJAB WEIGHT] 
	                    FROM SALES_PERSONS A
	                    LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                    LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                    LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                    LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                    WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1
	                    AND E.REGION_ID = '1002'
	                    GROUP BY A.NAME
                    ) I ON A.NAME = I.[SALES PERSON]
                    WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1
                    GROUP BY A.NAME,D.[OLIEN WEIGHT],E.[CANOLA WEIGHT],F.[SINDH WEIGHT],I.[PUNJAB WEIGHT],G.[KPK WEIGHT],H.[BALOCHISTAN WEIGHT]";
                }
                else {
                        classHelper.query = @"DECLARE @FROM DATETIME;
                        DECLARE @TO DATETIME;
                        DECLARE @CUST_ID INT;

                        SET @FROM = '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"';
                        SET @TO = '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"';
                        SET @CUST_ID = '" + cmbCustomer.SelectedValue.ToString() + @"';

                        SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [TOTAL WEIGHT],
                        ISNULL(D.[OLIEN WEIGHT],0) AS [OLIEN WEIGHT],ISNULL(E.[CANOLA WEIGHT],0) AS [CANOLA WEIGHT],
				        ISNULL(F.[SINDH WEIGHT],0) AS [SINDH WEIGHT],ISNULL(I.[PUNJAB WEIGHT],0) AS [PUNJAB WEIGHT],
				        ISNULL(G.[KPK WEIGHT],0) AS [KPK WEIGHT],ISNULL(H.[BALOCHISTAN WEIGHT],0) AS [BALOCHISTAN WEIGHT]
                        FROM SALES_PERSONS A
                        LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
                        LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
                        LEFT JOIN (
	                        SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [OLIEN WEIGHT] 
	                        FROM SALES_PERSONS A
	                        LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                        LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                        LEFT JOIN MATERIALS D ON C.MATERIAL_ID = D.MATERIAL_ID
	                        WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1 AND B.COA_ID = @CUST_ID
	                        AND D.MATERIAL_ID IN ('5003','3002')
	                        GROUP BY A.NAME
                        ) D ON A.NAME = D.[SALES PERSON]
                        LEFT JOIN (
	                        SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [CANOLA WEIGHT] 
	                        FROM SALES_PERSONS A
	                        LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                        LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                        LEFT JOIN MATERIALS D ON C.MATERIAL_ID = D.MATERIAL_ID
	                        WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1 AND B.COA_ID = @CUST_ID
	                        AND D.MATERIAL_ID = '5005'
	                        GROUP BY A.NAME
                        ) E ON A.NAME = E.[SALES PERSON]
                        LEFT JOIN (
	                        SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [SINDH WEIGHT] 
	                        FROM SALES_PERSONS A
	                        LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                        LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                        LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                        LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                        WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1 AND B.COA_ID = @CUST_ID
	                        AND E.REGION_ID = '1'
	                        GROUP BY A.NAME
                        ) F ON A.NAME = F.[SALES PERSON]
                        LEFT JOIN (
	                        SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [KPK WEIGHT] 
	                        FROM SALES_PERSONS A
	                        LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                        LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                        LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                        LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                        WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1 AND B.COA_ID = @CUST_ID
	                        AND E.REGION_ID = '2'
	                        GROUP BY A.NAME
                        ) G ON A.NAME = G.[SALES PERSON]
                        LEFT JOIN (
	                        SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [BALOCHISTAN WEIGHT] 
	                        FROM SALES_PERSONS A
	                        LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                        LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                        LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                        LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                        WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1 AND B.COA_ID = @CUST_ID
	                        AND E.REGION_ID = '3'
	                        GROUP BY A.NAME
                        ) H ON A.NAME = H.[SALES PERSON]
                        LEFT JOIN (
	                        SELECT A.NAME AS [SALES PERSON],ISNULL(SUM(C.TOTAL_KGS) - (SUM(C.TOTAL_KGS) - SUM(C.REMAINING_WEIGHT)),0) AS [PUNJAB WEIGHT] 
	                        FROM SALES_PERSONS A
	                        LEFT JOIN CUSTOMER_PROFILE B ON A.SALES_PER_ID = B.SALE_PER_ID
	                        LEFT JOIN SALES_ORDER_DIRECT C ON C.CUSTOMER_ID = B.COA_ID
	                        LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
	                        LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
	                        WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1 AND B.COA_ID = @CUST_ID
	                        AND E.REGION_ID = '1002'
	                        GROUP BY A.NAME
                        ) I ON A.NAME = I.[SALES PERSON]
                        WHERE C.DATE BETWEEN @FROM AND @TO AND C.STATUS = 1 AND B.COA_ID = @CUST_ID
                        GROUP BY A.NAME,D.[OLIEN WEIGHT],E.[CANOLA WEIGHT],F.[SINDH WEIGHT],I.[PUNJAB WEIGHT],G.[KPK WEIGHT],H.[BALOCHISTAN WEIGHT]";
                }
                
            }
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["SO_Summary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["SO_Summary"].NewRow();
                        classHelper.dataR["SALES PERSON"] = classHelper.dr["SALES PERSON"].ToString();
                        classHelper.dataR["TOTAL"] = Convert.ToDecimal(classHelper.dr["TOTAL WEIGHT"].ToString());
                        classHelper.dataR["OLIEN"] = Convert.ToDecimal(classHelper.dr["OLIEN WEIGHT"].ToString());
                        classHelper.dataR["CANOLA"] = Convert.ToDecimal(classHelper.dr["CANOLA WEIGHT"].ToString());
                        classHelper.dataR["SINDH"] = Convert.ToDecimal(classHelper.dr["SINDH WEIGHT"].ToString());
                        classHelper.dataR["PUNJAB"] = Convert.ToDecimal(classHelper.dr["PUNJAB WEIGHT"].ToString());
                        classHelper.dataR["BALOCHISTAN"] = Convert.ToDecimal(classHelper.dr["BALOCHISTAN WEIGHT"].ToString());
                        classHelper.dataR["KPK"] = Convert.ToDecimal(classHelper.dr["KPK WEIGHT"].ToString());
                        classHelper.nds.Tables["SO_Summary"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                   // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Reports.POSummary rptPOS = new Reports.POSummary();
                //rptPOS.SetDataSource(classHelper.nds.Tables["PO_Summary"]);
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
                classHelper.rpt.GenerateReport("SO_Approval_Report", classHelper.nds);
                classHelper.rpt.ShowDialog();
            }
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            LoadSO();
        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            load_sales_person();
            LoadCustomers();
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
            if (grdSOList.Rows.Count > 0 && e.RowIndex > -1) {
                if (grdSOList.Rows[e.RowIndex].Cells["discard"].Value.ToString().Equals("True"))
                {
                    grdSOList.Rows[e.RowIndex].Cells["discard"].Value = false;
                }
                else {
                    grdSOList.Rows[e.RowIndex].Cells["discard"].Value = true;
                }
            }
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            UpdateDiscardSO();
        }
    }
}
