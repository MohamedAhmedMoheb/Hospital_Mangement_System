using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class MedicalRecordsForm : Form
    {
        public MedicalRecordsForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecordID.Text) ||
                string.IsNullOrWhiteSpace(txtPatientID.Text) ||
                string.IsNullOrWhiteSpace(txtDoctorID.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem(txtRecordID.Text);
            item.SubItems.Add(txtPatientID.Text);
            item.SubItems.Add(txtDoctorID.Text);
            item.SubItems.Add(dtpDate.Value.ToShortDateString());
            item.SubItems.Add(txtDiagnosis.Text);
            item.SubItems.Add(txtTreatment.Text);
            item.SubItems.Add(txtMedications.Text);
            item.SubItems.Add(cmbRecordType.Text);
            listViewRecords.Items.Add(item);

            ClearFields();
            MessageBox.Show("Medical record added successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewRecords.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a record to update.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ListViewItem item = listViewRecords.SelectedItems[0];
            item.Text = txtRecordID.Text;
            item.SubItems[1].Text = txtPatientID.Text;
            item.SubItems[2].Text = txtDoctorID.Text;
            item.SubItems[3].Text = dtpDate.Value.ToShortDateString();
            item.SubItems[4].Text = txtDiagnosis.Text;
            item.SubItems[5].Text = txtTreatment.Text;
            item.SubItems[6].Text = txtMedications.Text;
            item.SubItems[7].Text = cmbRecordType.Text;

            MessageBox.Show("Record updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewRecords.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this record?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                listViewRecords.SelectedItems[0].Remove();
                ClearFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void listViewRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRecords.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewRecords.SelectedItems[0];
                txtRecordID.Text    = item.Text;
                txtPatientID.Text   = item.SubItems[1].Text;
                txtDoctorID.Text    = item.SubItems[2].Text;
                if (DateTime.TryParse(item.SubItems[3].Text, out DateTime d)) dtpDate.Value = d;
                txtDiagnosis.Text   = item.SubItems[4].Text;
                txtTreatment.Text   = item.SubItems[5].Text;
                txtMedications.Text = item.SubItems[6].Text;
                cmbRecordType.Text  = item.SubItems[7].Text;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.ToLower();
            foreach (ListViewItem item in listViewRecords.Items)
            {
                item.BackColor = Color.White;
                if (!string.IsNullOrWhiteSpace(query))
                {
                    bool match = item.Text.ToLower().Contains(query) ||
                                 item.SubItems[1].Text.ToLower().Contains(query) ||
                                 item.SubItems[4].Text.ToLower().Contains(query);
                    item.BackColor = match ? Color.LightCyan : Color.White;
                }
            }
        }

        private void ClearFields()
        {
            txtRecordID.Clear();
            txtPatientID.Clear();
            txtDoctorID.Clear();
            txtDiagnosis.Clear();
            txtTreatment.Clear();
            txtMedications.Clear();
            cmbRecordType.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today;
            listViewRecords.SelectedItems.Clear();
        }
    }
}
