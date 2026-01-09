using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Purchases
{
    class POInwardReport
    {
        Classes.Helper classHelper = new Classes.Helper();
        public void POInward_Report(int poId) {
            classHelper.query = @"SELECT B.PO_NUMBER,B.[DATE] AS [PO DATE],B.CREDIT_DAYS AS [CONDITION],C.COA_NAME AS [SUPPLIER],B.[WEIGHT],
            CASE WHEN D.MATERIAL_NAME = 'CANOLA' THEN B.KG_RATE ELSE B.MUAND_RATE END AS[RATE],
            A.[DATE],A.INVOICE_NO,A.VEHICLE_NO,A.KORANGI_WEIGHT,A.NET_WEIGHT,(A.NET_WEIGHT - A.KORANGI_WEIGHT) AS[DIFFERENCE],B.MUAND_VALUE,D.MATERIAL_NAME
            FROM PURCHASES A
            INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
            INNER JOIN COA C ON B.SUPPLIER_ID = C.COA_ID
            INNER JOIN MATERIALS D ON B.MATERIAL_ID = D.MATERIAL_ID
            WHERE B.PO_ID = '" + poId+"'";
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
                classHelper.rpt.GenerateReport("rptPI_InwardReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
    }
}
