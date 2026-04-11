using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class PrescriptionForm : Form
    {
        public PrescriptionForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedication.Text) ||
                string.IsNullOrWhiteSpace(txtAppID.Text))
            {
                MessageBox.Show("Medication and AP_ID are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtAppID.Text, out int apId))
            {
                MessageBox.Show("AP_ID must be a valid integer (Appointment ID).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem("Auto");   // Presc_ID is IDENTITY
            item.SubItems.Add(txtMedication.Text);
            item.SubItems.Add(apId.ToString());
            listViewPrescriptions.Items.Add(item);

            ClearFields();
            MessageBox.Show("Prescription added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewPrescriptions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a prescription to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!int.TryParse(txtAppID.Text, out int apId))
            {
                MessageBox.Show("AP_ID must be a valid integer.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = listViewPrescriptions.SelectedItems[0];
            item.SubItems[1].Text = txtMedication.Text;
            item.SubItems[2].Text = apId.ToString();

            MessageBox.Show("Prescription updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewPrescriptions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a prescription to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Delete this prescription?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                listViewPrescriptions.SelectedItems[0].Remove();
                ClearFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void listViewPrescriptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPrescriptions.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewPrescriptions.SelectedItems[0];
                txtMedication.Text = item.SubItems[1].Text;
                txtAppID.Text      = item.SubItems[2].Text;
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

        private void ClearFields()
        {
            txtMedication.Clear();
            txtAppID.Clear();
            listViewPrescriptions.SelectedItems.Clear();
        }
    }
}
