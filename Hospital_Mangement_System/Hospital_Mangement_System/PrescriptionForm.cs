using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class PrescriptionForm : Form
    {
        public PrescriptionForm()
        {
            InitializeComponent();
            LoadPrescriptions();
        }

        private void LoadPrescriptions()
        {
            try
            {
                listViewPrescriptions.Items.Clear();
                DataTable dt = DBHelper.ExecuteQuery("SELECT Presc_ID, Medication, AP_ID FROM Prescription");
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["Presc_ID"].ToString());
                    item.SubItems.Add(row["Medication"].ToString());
                    item.SubItems.Add(row["AP_ID"].ToString());
                    listViewPrescriptions.Items.Add(item);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading prescriptions:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedication.Text) || string.IsNullOrWhiteSpace(txtAppID.Text))
            { MessageBox.Show("Medication and AP_ID are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(txtAppID.Text, out int apId))
            { MessageBox.Show("AP_ID must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                DBHelper.ExecuteNonQuery(
                    "INSERT INTO Prescription (Medication, AP_ID) VALUES (@med, @ap)",
                    new SqlParameter[] {
                        new SqlParameter("@med", txtMedication.Text.Trim()),
                        new SqlParameter("@ap",  apId)
                    });
                MessageBox.Show("Prescription added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); LoadPrescriptions();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewPrescriptions.SelectedItems.Count == 0)
            { MessageBox.Show("Select a prescription first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (!int.TryParse(txtAppID.Text, out int apId))
            { MessageBox.Show("AP_ID must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                int prescId = int.Parse(listViewPrescriptions.SelectedItems[0].Text);
                DBHelper.ExecuteNonQuery(
                    "UPDATE Prescription SET Medication=@med, AP_ID=@ap WHERE Presc_ID=@id",
                    new SqlParameter[] {
                        new SqlParameter("@med", txtMedication.Text.Trim()),
                        new SqlParameter("@ap",  apId),
                        new SqlParameter("@id",  prescId)
                    });
                MessageBox.Show("Prescription updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); LoadPrescriptions();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewPrescriptions.SelectedItems.Count == 0)
            { MessageBox.Show("Select a prescription first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show("Delete this prescription?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int prescId = int.Parse(listViewPrescriptions.SelectedItems[0].Text);
                    DBHelper.ExecuteNonQuery("DELETE FROM Prescription WHERE Presc_ID=@id",
                        new[] { new SqlParameter("@id", prescId) });
                    MessageBox.Show("Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); LoadPrescriptions();
                }
                catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void listViewPrescriptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPrescriptions.SelectedItems.Count > 0)
            {
                var item = listViewPrescriptions.SelectedItems[0];
                txtMedication.Text = item.SubItems[1].Text;
                txtAppID.Text = item.SubItems[2].Text;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearch.Text.ToLower();
            foreach (ListViewItem item in listViewPrescriptions.Items)
            {
                bool match = string.IsNullOrWhiteSpace(q) ||
                             item.SubItems[1].Text.ToLower().Contains(q) ||
                             item.SubItems[2].Text.ToLower().Contains(q);
                item.BackColor = (!string.IsNullOrWhiteSpace(q) && match) ? Color.LightYellow : Color.White;
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();
        private void btnBack_Click(object sender, EventArgs e) => this.Close();
        private void ClearFields() { txtMedication.Clear(); txtAppID.Clear(); listViewPrescriptions.SelectedItems.Clear(); }
    }
}