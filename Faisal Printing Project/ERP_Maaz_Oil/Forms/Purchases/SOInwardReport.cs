using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Purchases
{
    class SOInwardReport
    {
        Classes.Helper classHelper = new Classes.Helper();
        public void SOInward_Report(int soId) {
        classHelper.query = @"SELECT B.INVOICE_NO AS PO_NUMBER,B.[DATE] AS [PO DATE],B.CREDIT_DAYS AS [CONDITION],C.COA_NAME AS [SUPPLIER],B.TOTAL_KGS AS [WEIGHT],
        CASE WHEN D.MATERIAL_NAME = 'CANOLA' THEN B.RATE ELSE ROUND(B.RATE * 37.324,0) END AS[RATE],
        A.[DATE],A.INVOICE_NO,E.VEHICLE_NO,A.sales_weight AS KORANGI_WEIGHT,A.sales_weight AS NET_WEIGHT,(A.sales_weight - A.sales_weight) AS[DIFFERENCE],
        CASE WHEN D.MATERIAL_NAME = 'CANOLA' THEN '40' ELSE '37.324' END AS MUAND_VALUE,D.MATERIAL_NAME
        FROM purchases_sales_transfer A
        INNER JOIN SALES_ORDER_DIRECT B ON A.so_id = B.SOD_ID
        INNER JOIN COA C ON B.CUSTOMER_ID = C.COA_ID
        INNER JOIN MATERIALS D ON B.MATERIAL_ID = D.MATERIAL_ID
        INNER JOIN PURCHASES E ON A.purchases_id = E.PI_ID
        WHERE B.SOD_ID = '" + soId+"'";
            char hasRows = 'N';
            try
            {
                
                decimal balance = 0;
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.mds.Tables["PO_Inward"].Clear();
                    while (classHelper.dr.Read())
                    {
                        if (balance == 0) { balance = Convert.ToDecimal(classHelper.dr["WEIGHT"].ToString()); }
                        classHelper.dataR = classHelper.mds.Tables["PO_Inward"].NewRow();
                        classHelper.dataR["poNumber"] = classHelper.dr["PO_NUMBER"].ToString();
                        classHelper.dataR["poDate"] = Convert.ToDateTime(classHelper.dr["PO DATE"].ToString());
                        classHelper.dataR["condition"] = classHelper.dr["CONDITION"].ToString()+" DAYS";
                        classHelper.dataR["supplier"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["material"] = classHelper.dr["MATERIAL_NAME"].ToString();
                        classHelper.dataR["weight"] = Convert.ToDecimal(classHelper.dr["WEIGHT"].ToString());
                        classHelper.dataR["rate"] = Convert.ToDecimal(classHelper.dr["RATE"].ToString());
                        classHelper.dataR["piDate"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["invoiceNo"] = classHelper.dr["INVOICE_NO"].ToString();
                        classHelper.dataR["vehicleNo"] = classHelper.dr["VEHICLE_NO"].ToString();
                        classHelper.dataR["korangiWeight"] = Convert.ToDecimal(classHelper.dr["KORANGI_WEIGHT"].ToString());
                        classHelper.dataR["netWeight"] = Convert.ToDecimal(classHelper.dr["NET_WEIGHT"].ToString());
                        classHelper.dataR["difference"] = Convert.ToDecimal(classHelper.dr["DIFFERENCE"].ToString());
                        if (classHelper.dr["MATERIAL_NAME"].ToString().Equals("CANOLA"))
                        {
                            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["NET_WEIGHT"].ToString()) * Convert.ToDecimal(classHelper.dr["RATE"].ToString());
                        }
                        else {
                            classHelper.dataR["amount"] = (Convert.ToDecimal(classHelper.dr["NET_WEIGHT"].ToString()) / Convert.ToDecimal(classHelper.dr["MUAND_VALUE"].ToString())) * Convert.ToDecimal(classHelper.dr["RATE"].ToString());
                        }
                        classHelper.dataR["balance"] = balance - Convert.ToDecimal(classHelper.dr["NET_WEIGHT"].ToString());
                        balance = balance - Convert.ToDecimal(classHelper.dr["NET_WEIGHT"].ToString());
                        classHelper.mds.Tables["PO_Inward"].Rows.Add(classHelper.dataR);
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
            if (hasRows == 'Y') {
                classHelper.rpt = new Reporting.frmReports();
                classHelper.rpt.GenerateReport("rptSI_InwardReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
    }
}
