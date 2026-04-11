namespace Hospital_Mangement_System
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        // button1 → Patient
        private void button1_Click(object sender, EventArgs e)
        {
            new PatientForm().Show();
        }

        // button2 → Appointment
        private void button2_Click(object sender, EventArgs e)
        {
            new AppointmentForm().Show();
        }

        // button3 → Doctor
        private void button3_Click(object sender, EventArgs e)
        {
            new DoctorForm().Show();
        }

        // button4 → Medical Records  →  now Prescription (matches your DB)
        private void button4_Click(object sender, EventArgs e)
        {
            new PrescriptionForm().Show();
        }

        // ── Tip: add a 5th button on the menu for Department ──────────
        // When you add button5 on the designer, hook it up like this:
        // private void button5_Click(object sender, EventArgs e)
        // {
        //     new DepartmentForm().Show();
        // }

        // ── Unused stubs ──────────────────────────────────────────────
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void pictureBox1_Click_1(object sender, EventArgs e) { }
        private void pictureBox1_Click_2(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
    }
}
