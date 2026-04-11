using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
            LoadPatients();
        }

        private void LoadPatients()
        {
            try
            {
                listViewPatients.Items.Clear();
                DataTable dt = DBHelper.ExecuteQuery("SELECT P_ID, P_NAME, Age, P_NUM FROM Patient");
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["P_ID"].ToString());
                    item.SubItems.Add(row["P_NAME"].ToString());
                    item.SubItems.Add(row["Age"].ToString());
                    item.SubItems.Add(row["P_NUM"] == DBNull.Value ? "" : row["P_NUM"].ToString());
                    listViewPatients.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patients:\n" + ex.Message, "DB Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAge.Text))
            { MessageBox.Show("P_NAME and Age are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!byte.TryParse(txtAge.Text, out byte age))
            { MessageBox.Show("Age must be 0–255.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                DBHelper.ExecuteNonQuery(
                    "INSERT INTO Patient (P_NAME, Age, P_NUM) VALUES (@name, @age, @phone)",
                    new SqlParameter[] {
                        new SqlParameter("@name",  txtName.Text.Trim()),
                        new SqlParameter("@age",   age),
                        new SqlParameter("@phone", string.IsNullOrWhiteSpace(txtPhone.Text)
                                                   ? (object)DBNull.Value : txtPhone.Text.Trim())
                    });
                MessageBox.Show("Patient added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); LoadPatients();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewPatients.SelectedItems.Count == 0)
            { MessageBox.Show("Select a patient first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (!byte.TryParse(txtAge.Text, out byte age))
            { MessageBox.Show("Age must be 0–255.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                int pid = int.Parse(listViewPatients.SelectedItems[0].Text);
                DBHelper.ExecuteNonQuery(
                    "UPDATE Patient SET P_NAME=@name, Age=@age, P_NUM=@phone WHERE P_ID=@id",
                    new SqlParameter[] {
                        new SqlParameter("@name",  txtName.Text.Trim()),
                        new SqlParameter("@age",   age),
                        new SqlParameter("@phone", string.IsNullOrWhiteSpace(txtPhone.Text)
                                                   ? (object)DBNull.Value : txtPhone.Text.Trim()),
                        new SqlParameter("@id",    pid)
                    });
                MessageBox.Show("Patient updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); LoadPatients();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewPatients.SelectedItems.Count == 0)
            { MessageBox.Show("Select a patient first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show("Delete this patient?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int pid = int.Parse(listViewPatients.SelectedItems[0].Text);
                    DBHelper.ExecuteNonQuery("DELETE FROM Patient WHERE P_ID=@id",
                        new[] { new SqlParameter("@id", pid) });
                    MessageBox.Show("Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); LoadPatients();
                }
                catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void listViewPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPatients.SelectedItems.Count > 0)
            {
                var item = listViewPatients.SelectedItems[0];
                txtName.Text = item.SubItems[1].Text;
                txtAge.Text = item.SubItems[2].Text;
                txtPhone.Text = item.SubItems[3].Text;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearch.Text.ToLower();
            foreach (ListViewItem item in listViewPatients.Items)
            {
                bool match = string.IsNullOrWhiteSpace(q) ||
                             item.SubItems[1].Text.ToLower().Contains(q) ||
                             item.SubItems[3].Text.ToLower().Contains(q);
                item.BackColor = (!string.IsNullOrWhiteSpace(q) && match) ? Color.LightYellow : Color.White;
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();
        private void btnBack_Click(object sender, EventArgs e) => this.Close();
        private void ClearFields() { txtName.Clear(); txtAge.Clear(); txtPhone.Clear(); listViewPatients.SelectedItems.Clear(); }
    }
}