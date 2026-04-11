using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoctorID.Text) ||
                string.IsNullOrWhiteSpace(txtPatientID.Text))
            {
                MessageBox.Show("DA_ID (Doctor) and PA_ID (Patient) are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtDoctorID.Text, out int daId))
            {
                MessageBox.Show("DA_ID must be a valid integer (Doctor ID).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtPatientID.Text, out int paId))
            {
                MessageBox.Show("PA_ID must be a valid integer (Patient ID).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem("Auto");   // APP_ID is IDENTITY
            item.SubItems.Add(dtpDate.Value.ToShortDateString());
            item.SubItems.Add(dtpTime.Value.ToString("HH:mm"));
            item.SubItems.Add(daId.ToString());
            item.SubItems.Add(paId.ToString());
            listViewAppointments.Items.Add(item);

            ClearFields();
            MessageBox.Show("Appointment booked!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewAppointments.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select an appointment to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!int.TryParse(txtDoctorID.Text, out int daId) || !int.TryParse(txtPatientID.Text, out int paId))
            {
                MessageBox.Show("DA_ID and PA_ID must be valid integers.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = listViewAppointments.SelectedItems[0];
            item.SubItems[1].Text = dtpDate.Value.ToShortDateString();
            item.SubItems[2].Text = dtpTime.Value.ToString("HH:mm");
            item.SubItems[3].Text = daId.ToString();
            item.SubItems[4].Text = paId.ToString();

            MessageBox.Show("Appointment updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewAppointments.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select an appointment to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Delete this appointment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                listViewAppointments.SelectedItems[0].Remove();
                ClearFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void listViewAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAppointments.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewAppointments.SelectedItems[0];
                if (DateTime.TryParse(item.SubItems[1].Text, out DateTime d)) dtpDate.Value = d;
                if (DateTime.TryParse(item.SubItems[2].Text, out DateTime t)) dtpTime.Value = t;
                txtDoctorID.Text  = item.SubItems[3].Text;
                txtPatientID.Text = item.SubItems[4].Text;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearch.Text.ToLower();
            foreach (ListViewItem item in listViewAppointments.Items)
            {
                bool match = string.IsNullOrWhiteSpace(q) ||
                             item.SubItems[3].Text.ToLower().Contains(q) ||
                             item.SubItems[4].Text.ToLower().Contains(q) ||
                             item.SubItems[1].Text.ToLower().Contains(q);
                item.BackColor = (!string.IsNullOrWhiteSpace(q) && match) ? Color.LightYellow : Color.White;
            }
        }

        private void ClearFields()
        {
            txtDoctorID.Clear();
            txtPatientID.Clear();
            dtpDate.Value = DateTime.Today;
            dtpTime.Value = DateTime.Now;
            listViewAppointments.SelectedItems.Clear();
        }
    }
}
