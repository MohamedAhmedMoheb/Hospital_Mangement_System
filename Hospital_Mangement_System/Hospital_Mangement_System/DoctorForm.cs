using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class DoctorForm : Form
    {
        public DoctorForm()
        {
            InitializeComponent();
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            try
            {
                listViewDoctors.Items.Clear();
                DataTable dt = DBHelper.ExecuteQuery("SELECT DOC_ID, DOC_NAME, Specialty, DD_ID FROM Doctor");
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["DOC_ID"].ToString());
                    item.SubItems.Add(row["DOC_NAME"].ToString());
                    item.SubItems.Add(row["Specialty"].ToString());
                    item.SubItems.Add(row["DD_ID"].ToString());
                    listViewDoctors.Items.Add(item);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading doctors:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSpecialty.Text) || string.IsNullOrWhiteSpace(txtDeptID.Text))
            { MessageBox.Show("All fields are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(txtDeptID.Text, out int deptId))
            { MessageBox.Show("DD_ID must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                DBHelper.ExecuteNonQuery(
                    "INSERT INTO Doctor (DOC_NAME, Specialty, DD_ID) VALUES (@name, @spec, @dept)",
                    new SqlParameter[] {
                        new SqlParameter("@name", txtName.Text.Trim()),
                        new SqlParameter("@spec", txtSpecialty.Text.Trim()),
                        new SqlParameter("@dept", deptId)
                    });
                MessageBox.Show("Doctor added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); LoadDoctors();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewDoctors.SelectedItems.Count == 0)
            { MessageBox.Show("Select a doctor first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (!int.TryParse(txtDeptID.Text, out int deptId))
            { MessageBox.Show("DD_ID must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                int docId = int.Parse(listViewDoctors.SelectedItems[0].Text);
                DBHelper.ExecuteNonQuery(
                    "UPDATE Doctor SET DOC_NAME=@name, Specialty=@spec, DD_ID=@dept WHERE DOC_ID=@id",
                    new SqlParameter[] {
                        new SqlParameter("@name", txtName.Text.Trim()),
                        new SqlParameter("@spec", txtSpecialty.Text.Trim()),
                        new SqlParameter("@dept", deptId),
                        new SqlParameter("@id",   docId)
                    });
                MessageBox.Show("Doctor updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); LoadDoctors();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewDoctors.SelectedItems.Count == 0)
            { MessageBox.Show("Select a doctor first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show("Delete this doctor?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int docId = int.Parse(listViewDoctors.SelectedItems[0].Text);
                    DBHelper.ExecuteNonQuery("DELETE FROM Doctor WHERE DOC_ID=@id",
                        new[] { new SqlParameter("@id", docId) });
                    MessageBox.Show("Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); LoadDoctors();
                }
                catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void listViewDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDoctors.SelectedItems.Count > 0)
            {
                var item = listViewDoctors.SelectedItems[0];
                txtName.Text = item.SubItems[1].Text;
                txtSpecialty.Text = item.SubItems[2].Text;
                txtDeptID.Text = item.SubItems[3].Text;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearch.Text.ToLower();
            foreach (ListViewItem item in listViewDoctors.Items)
            {
                bool match = string.IsNullOrWhiteSpace(q) ||
                             item.SubItems[1].Text.ToLower().Contains(q) ||
                             item.SubItems[2].Text.ToLower().Contains(q);
                item.BackColor = (!string.IsNullOrWhiteSpace(q) && match) ? Color.LightYellow : Color.White;
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();
        private void btnBack_Click(object sender, EventArgs e) => this.Close();
        private void ClearFields() { txtName.Clear(); txtSpecialty.Clear(); txtDeptID.Clear(); listViewDoctors.SelectedItems.Clear(); }
    }
}