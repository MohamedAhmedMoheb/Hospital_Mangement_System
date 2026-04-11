using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class DoctorForm : Form
    {
        public DoctorForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSpecialty.Text) ||
                string.IsNullOrWhiteSpace(txtDeptID.Text))
            {
                MessageBox.Show("DOC_NAME, Specialty and DD_ID are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtDeptID.Text, out int deptId))
            {
                MessageBox.Show("DD_ID must be a valid integer (Department ID).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem("Auto");   // DOC_ID is IDENTITY
            item.SubItems.Add(txtName.Text);
            item.SubItems.Add(txtSpecialty.Text);
            item.SubItems.Add(deptId.ToString());
            listViewDoctors.Items.Add(item);

            ClearFields();
            MessageBox.Show("Doctor added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewDoctors.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a doctor to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!int.TryParse(txtDeptID.Text, out int deptId))
            {
                MessageBox.Show("DD_ID must be a valid integer.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = listViewDoctors.SelectedItems[0];
            item.SubItems[1].Text = txtName.Text;
            item.SubItems[2].Text = txtSpecialty.Text;
            item.SubItems[3].Text = deptId.ToString();

            MessageBox.Show("Doctor updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewDoctors.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a doctor to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Delete this doctor?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                listViewDoctors.SelectedItems[0].Remove();
                ClearFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void listViewDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDoctors.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewDoctors.SelectedItems[0];
                txtName.Text      = item.SubItems[1].Text;
                txtSpecialty.Text = item.SubItems[2].Text;
                txtDeptID.Text    = item.SubItems[3].Text;
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

        private void ClearFields()
        {
            txtName.Clear();
            txtSpecialty.Clear();
            txtDeptID.Clear();
            listViewDoctors.SelectedItems.Clear();
        }
    }
}
