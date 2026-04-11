using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class DepartmentForm : Form
    {
        public DepartmentForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDName.Text))
            {
                MessageBox.Show("D_NAME is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem("Auto");   // D_ID is IDENTITY
            item.SubItems.Add(txtDName.Text);
            item.SubItems.Add(txtLocation.Text);
            listViewDepts.Items.Add(item);

            ClearFields();
            MessageBox.Show("Department added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewDepts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a department to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ListViewItem item = listViewDepts.SelectedItems[0];
            item.SubItems[1].Text = txtDName.Text;
            item.SubItems[2].Text = txtLocation.Text;
            MessageBox.Show("Department updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewDepts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a department to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Delete this department?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                listViewDepts.SelectedItems[0].Remove();
                ClearFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void listViewDepts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDepts.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewDepts.SelectedItems[0];
                txtDName.Text    = item.SubItems[1].Text;
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

        private void ClearFields()
        {
            txtDName.Clear();
            txtLocation.Clear();
            listViewDepts.SelectedItems.Clear();
        }
    }
}
