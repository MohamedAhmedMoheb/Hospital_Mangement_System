using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class DepartmentForm : Form
    {
        public DepartmentForm()
        {
            InitializeComponent();
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            try
            {
                listViewDepts.Items.Clear();
                DataTable dt = DBHelper.ExecuteQuery("SELECT D_ID, D_NAME, Location FROM Department");
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["D_ID"].ToString());
                    item.SubItems.Add(row["D_NAME"].ToString());
                    item.SubItems.Add(row["Location"] == DBNull.Value ? "" : row["Location"].ToString());
                    listViewDepts.Items.Add(item);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading departments:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDName.Text))
            { MessageBox.Show("D_NAME is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                DBHelper.ExecuteNonQuery(
                    "INSERT INTO Department (D_NAME, Location) VALUES (@name, @loc)",
                    new SqlParameter[] {
                        new SqlParameter("@name", txtDName.Text.Trim()),
                        new SqlParameter("@loc",  string.IsNullOrWhiteSpace(txtLocation.Text)
                                                  ? (object)DBNull.Value : txtLocation.Text.Trim())
                    });
                MessageBox.Show("Department added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); LoadDepartments();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewDepts.SelectedItems.Count == 0)
            { MessageBox.Show("Select a department first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            try
            {
                int did = int.Parse(listViewDepts.SelectedItems[0].Text);
                DBHelper.ExecuteNonQuery(
                    "UPDATE Department SET D_NAME=@name, Location=@loc WHERE D_ID=@id",
                    new SqlParameter[] {
                        new SqlParameter("@name", txtDName.Text.Trim()),
                        new SqlParameter("@loc",  string.IsNullOrWhiteSpace(txtLocation.Text)
                                                  ? (object)DBNull.Value : txtLocation.Text.Trim()),
                        new SqlParameter("@id",   did)
                    });
                MessageBox.Show("Department updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); LoadDepartments();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewDepts.SelectedItems.Count == 0)
            { MessageBox.Show("Select a department first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show("Delete this department?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int did = int.Parse(listViewDepts.SelectedItems[0].Text);
                    DBHelper.ExecuteNonQuery("DELETE FROM Department WHERE D_ID=@id",
                        new[] { new SqlParameter("@id", did) });
                    MessageBox.Show("Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); LoadDepartments();
                }
                catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void listViewDepts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDepts.SelectedItems.Count > 0)
            {
                var item = listViewDepts.SelectedItems[0];
                txtDName.Text = item.SubItems[1].Text;
                txtLocation.Text = item.SubItems[2].Text;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearch.Text.ToLower();
            foreach (ListViewItem item in listViewDepts.Items)
            {
                bool match = string.IsNullOrWhiteSpace(q) ||
                             item.SubItems[1].Text.ToLower().Contains(q) ||
                             item.SubItems[2].Text.ToLower().Contains(q);
                item.BackColor = (!string.IsNullOrWhiteSpace(q) && match) ? Color.LightYellow : Color.White;
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();
        private void btnBack_Click(object sender, EventArgs e) => this.Close();
        private void ClearFields() { txtDName.Clear(); txtLocation.Clear(); listViewDepts.SelectedItems.Clear(); }
    }
}