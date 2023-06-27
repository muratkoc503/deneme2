using System;
using System.Data;
using WebApplication5;
using System.Web.UI.WebControls;
using System.IO;

namespace WebForm1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        protected void ShowAllData()
        {
            string query = "Select * FROM Yazılım"; // Tablo adını buraya atayın veya parametre olarak alır
            SqlQuery sqlQuery = new SqlQuery();
            DataTable dataTable = sqlQuery.GetSQLData(query, "config.yaml");

            // Verileri GridView'e bağla
            gridView.DataSource = dataTable;
            gridView.DataBind();
        }

        protected void BindGridView()
        {
            string customerName = txtCustomerName.Text.Trim();
            string productionType = ddlProductionType.SelectedValue;
            string durum = ddlDurum.SelectedValue;
            string tamamlayanPersonel = txtTamamlayanPerson.Text.Trim();

            string query = "SELECT * FROM Yazılım WHERE 1=1";

            if (!string.IsNullOrEmpty(customerName))
            {
                query += " AND musteri_name LIKE '" + customerName + "%'";
            }

            if (!string.IsNullOrEmpty(productionType))
            {
                query += " AND type = '" + productionType + "'";
            }

            if (!string.IsNullOrEmpty(durum))
            {
                query += " AND durum = '" + durum + "'";
            }

            if (!string.IsNullOrEmpty(tamamlayanPersonel))
            {
                query += " AND Tamamlayan_Personel LIKE '%" + tamamlayanPersonel + "%'";
            }

            SqlQuery sqlQ = new SqlQuery();
            DataTable dataTable = sqlQ.GetSQLData(query, "config.yaml");

            gridView.DataSource = dataTable;
            gridView.DataBind();

            int rowCount = dataTable.Rows.Count;
            lblResults.Text = "Toplam " + rowCount + " kayıt bulundu.";
        }

        protected void ddlProductionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();
            //this.Page_Load(sender, e);
        }

        protected void ddlDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();
            //this.Page_Load(sender, e);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
             BindGridView();
            //this.Page_Load(sender, e);
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {

        }




    }
}
