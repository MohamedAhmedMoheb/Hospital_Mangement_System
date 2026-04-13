using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            listViewAppointments.Columns.Add("Doctor Name", 140);
            listViewAppointments.Columns.Add("Patient Name", 140);
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            try
            {
                listViewAppointments.Items.Clear();
                DataTable dt = DBHelper.ExecuteQuery(@"
                    SELECT a.APP_ID, a.Date, a.Time, a.DA_ID, a.PA_ID,
                           d.DOC_NAME AS DoctorName, p.P_NAME AS PatientName
                    FROM Appointment a
                    LEFT JOIN Doctor d ON a.DA_ID = d.DOC_ID
                    LEFT JOIN Patient p ON a.PA_ID = p.P_ID");
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["APP_ID"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(row["Date"]).ToShortDateString());
                    item.SubItems.Add(row["Time"].ToString());
                    item.SubItems.Add(row["DA_ID"].ToString());
                    item.SubItems.Add(row["PA_ID"].ToString());
                    item.SubItems.Add(row["DoctorName"].ToString());
                    item.SubItems.Add(row["PatientName"].ToString());
                    listViewAppointments.Items.Add(item);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading appointments:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoctorID.Text) || string.IsNullOrWhiteSpace(txtPatientID.Text))
            { MessageBox.Show("DA_ID and PA_ID are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(txtDoctorID.Text, out int daId))
            { MessageBox.Show("DA_ID must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(txtPatientID.Text, out int paId))
            { MessageBox.Show("PA_ID must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                DBHelper.ExecuteNonQuery(
                    "INSERT INTO Appointment (Date, Time, DA_ID, PA_ID) VALUES (@date, @time, @da, @pa)",
                    new SqlParameter[] {
                        new SqlParameter("@date", dtpDate.Value.Date),
                        new SqlParameter("@time", dtpTime.Value.TimeOfDay),
                        new SqlParameter("@da",   daId),
                        new SqlParameter("@pa",   paId)
                    });
                MessageBox.Show("Appointment booked!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); LoadAppointments();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewAppointments.SelectedItems.Count == 0)
            { MessageBox.Show("Select an appointment first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (!int.TryParse(txtDoctorID.Text, out int daId) || !int.TryParse(txtPatientID.Text, out int paId))
            { MessageBox.Show("DA_ID and PA_ID must be numbers.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                int appId = int.Parse(listViewAppointments.SelectedItems[0].Text);
                DBHelper.ExecuteNonQuery(
                    "UPDATE Appointment SET Date=@date, Time=@time, DA_ID=@da, PA_ID=@pa WHERE APP_ID=@id",
                    new SqlParameter[] {
                        new SqlParameter("@date", dtpDate.Value.Date),
                        new SqlParameter("@time", dtpTime.Value.TimeOfDay),
                        new SqlParameter("@da",   daId),
                        new SqlParameter("@pa",   paId),
                        new SqlParameter("@id",   appId)
                    });
                MessageBox.Show("Appointment updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); LoadAppointments();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewAppointments.SelectedItems.Count == 0)
            { MessageBox.Show("Select an appointment first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show("Delete this appointment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int appId = int.Parse(listViewAppointments.SelectedItems[0].Text);
                    DBHelper.ExecuteNonQuery("DELETE FROM Appointment WHERE APP_ID=@id",
                        new[] { new SqlParameter("@id", appId) });
                    MessageBox.Show("Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); LoadAppointments();
                }
                catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void listViewAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAppointments.SelectedItems.Count > 0)
            {
                var item = listViewAppointments.SelectedItems[0];
                if (DateTime.TryParse(item.SubItems[1].Text, out DateTime d)) dtpDate.Value = d;
                if (TimeSpan.TryParse(item.SubItems[2].Text, out TimeSpan t)) dtpTime.Value = DateTime.Today.Add(t);
                txtDoctorID.Text = item.SubItems[3].Text;
                txtPatientID.Text = item.SubItems[4].Text;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearch.Text.ToLower();
            foreach (ListViewItem item in listViewAppointments.Items)
            {
                bool match = string.IsNullOrWhiteSpace(q) ||
                             item.SubItems[1].Text.ToLower().Contains(q) ||
                             item.SubItems[3].Text.ToLower().Contains(q) ||
                             item.SubItems[4].Text.ToLower().Contains(q) ||
                             item.SubItems[5].Text.ToLower().Contains(q) ||
                             item.SubItems[6].Text.ToLower().Contains(q);
                item.BackColor = (!string.IsNullOrWhiteSpace(q) && match) ? Color.LightYellow : Color.White;
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();
        private void btnBack_Click(object sender, EventArgs e) => this.Close();
        private void ClearFields() { txtDoctorID.Clear(); txtPatientID.Clear(); dtpDate.Value = DateTime.Today; dtpTime.Value = DateTime.Now; listViewAppointments.SelectedItems.Clear(); }
    }
}