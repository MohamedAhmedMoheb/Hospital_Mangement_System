using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAge.Text))
            {
                MessageBox.Show("P_NAME and Age are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!byte.TryParse(txtAge.Text, out byte age))
            {
                MessageBox.Show("Age must be a valid number (0–255).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem("Auto");  // P_ID is IDENTITY
            item.SubItems.Add(txtName.Text);
            item.SubItems.Add(age.ToString());
            item.SubItems.Add(txtPhone.Text);
            listViewPatients.Items.Add(item);

            ClearFields();
            MessageBox.Show("Patient added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewPatients.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a patient to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!byte.TryParse(txtAge.Text, out byte age))
            {
                MessageBox.Show("Age must be a valid number (0–255).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = listViewPatients.SelectedItems[0];
            item.SubItems[1].Text = txtName.Text;
            item.SubItems[2].Text = age.ToString();
            item.SubItems[3].Text = txtPhone.Text;

            MessageBox.Show("Patient updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewPatients.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a patient to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Delete this patient?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                listViewPatients.SelectedItems[0].Remove();
                ClearFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void listViewPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPatients.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewPatients.SelectedItems[0];
                txtName.Text  = item.SubItems[1].Text;
                txtAge.Text   = item.SubItems[2].Text;
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

        private void ClearFields()
        {
            txtName.Clear();
            txtAge.Clear();
            txtPhone.Clear();
            listViewPatients.SelectedItems.Clear();
        }
    }
}
