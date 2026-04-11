namespace Hospital_Mangement_System
{
    partial class MedicalRecordsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader      = new Panel();
            lblTitle         = new Label();
            lblSubtitle      = new Label();
            btnBack          = new Button();
            panelLeft        = new Panel();
            lblFormTitle     = new Label();
            lblRecordID      = new Label();
            txtRecordID      = new TextBox();
            lblPatientID     = new Label();
            txtPatientID     = new TextBox();
            lblDoctorID      = new Label();
            txtDoctorID      = new TextBox();
            lblDate          = new Label();
            dtpDate          = new DateTimePicker();
            lblRecordType    = new Label();
            cmbRecordType    = new ComboBox();
            lblDiagnosis     = new Label();
            txtDiagnosis     = new TextBox();
            lblTreatment     = new Label();
            txtTreatment     = new TextBox();
            lblMedications   = new Label();
            txtMedications   = new TextBox();
            btnAdd           = new Button();
            btnUpdate        = new Button();
            btnDelete        = new Button();
            btnClear         = new Button();
            panelRight       = new Panel();
            panelSearch      = new Panel();
            lblSearch        = new Label();
            txtSearch        = new TextBox();
            listViewRecords  = new ListView();
            colRecordID      = new ColumnHeader();
            colPatient       = new ColumnHeader();
            colDoctor        = new ColumnHeader();
            colDate          = new ColumnHeader();
            colDiagnosis     = new ColumnHeader();
            colTreatment     = new ColumnHeader();
            colMeds          = new ColumnHeader();
            colType          = new ColumnHeader();

            panelHeader.SuspendLayout();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            panelSearch.SuspendLayout();
            SuspendLayout();

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1200, 700);
            Font = new Font("Segoe UI", 9F);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Medical Records";
            MinimumSize = new Size(1200, 700);

            // Header
            panelHeader.BackColor = Color.FromArgb(180, 80, 20);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 70;
            panelHeader.Controls.AddRange(new Control[] { lblTitle, lblSubtitle, btnBack });

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Gill Sans Ultra Bold Condensed", 22F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 10);
            lblTitle.Text = "📋  Medical Records";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(255, 200, 160);
            lblSubtitle.Location = new Point(25, 45);
            lblSubtitle.Text = "Add · Update · Delete · Search medical records";

            btnBack.BackColor = Color.FromArgb(220, 53, 69);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(1090, 20);
            btnBack.Size = new Size(90, 32);
            btnBack.Text = "◀  Back";
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += btnBack_Click;

            // Left Panel
            panelLeft.BackColor = Color.White;
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Width = 370;

            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Gill Sans Ultra Bold Condensed", 16F);
            lblFormTitle.ForeColor = Color.FromArgb(180, 80, 20);
            lblFormTitle.Location = new Point(25, 15);
            lblFormTitle.Text = "Record Details";

            void MakeLabel(Label lbl, string text, int y)
            {
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(80, 80, 80);
                lbl.Location = new Point(25, y);
                lbl.Text = text;
            }

            void MakeTextBox(TextBox txt, int y, int width = 310, int height = 28, bool multi = false)
            {
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 10F);
                txt.Location = new Point(25, y);
                txt.Size = new Size(width, height);
                txt.Multiline = multi;
                txt.BackColor = Color.FromArgb(248, 249, 250);
            }

            MakeLabel(lblRecordID,  "Record ID *",  55);
            MakeTextBox(txtRecordID, 75);

            MakeLabel(lblPatientID,  "Patient ID *", 115);
            MakeTextBox(txtPatientID, 135);

            MakeLabel(lblDoctorID,  "Doctor ID *",  175);
            MakeTextBox(txtDoctorID, 195);

            MakeLabel(lblDate, "Date", 235);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Font = new Font("Segoe UI", 10F);
            dtpDate.Location = new Point(25, 255);
            dtpDate.Size = new Size(145, 28);

            MakeLabel(lblRecordType, "Record Type", 235);
            lblRecordType.Location = new Point(185, 235);
            cmbRecordType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRecordType.Font = new Font("Segoe UI", 10F);
            cmbRecordType.Items.AddRange(new object[] {
                "Diagnosis", "Lab Result", "Prescription",
                "Surgery Report", "Discharge Summary", "Referral", "Imaging"
            });
            cmbRecordType.Location = new Point(185, 255);
            cmbRecordType.Size = new Size(150, 28);
            cmbRecordType.BackColor = Color.FromArgb(248, 249, 250);
            cmbRecordType.FlatStyle = FlatStyle.Flat;

            MakeLabel(lblDiagnosis,  "Diagnosis",   295);
            MakeTextBox(txtDiagnosis, 315, 310, 50, true);

            MakeLabel(lblTreatment,  "Treatment",   375);
            MakeTextBox(txtTreatment, 395, 310, 50, true);

            MakeLabel(lblMedications,  "Medications", 455);
            MakeTextBox(txtMedications, 475, 310, 40, true);

            void StyleBtn(Button btn, string text, int x, int y, Color bg)
            {
                btn.BackColor = bg;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                btn.ForeColor = Color.White;
                btn.Location = new Point(x, y);
                btn.Size = new Size(145, 36);
                btn.Text = text;
                btn.Cursor = Cursors.Hand;
            }

            StyleBtn(btnAdd,    "➕  Add Record",  25, 530, Color.FromArgb(180, 80, 20));
            StyleBtn(btnUpdate, "✏️  Update",      185, 530, Color.FromArgb(0, 123, 255));
            StyleBtn(btnDelete, "🗑️  Delete",      25, 575, Color.FromArgb(220, 53, 69));
            StyleBtn(btnClear,  "🔄  Clear",       185, 575, Color.FromArgb(108, 117, 125));

            btnAdd.Click    += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click  += btnClear_Click;

            panelLeft.Controls.AddRange(new Control[] {
                lblFormTitle,
                lblRecordID, txtRecordID,
                lblPatientID, txtPatientID,
                lblDoctorID, txtDoctorID,
                lblDate, dtpDate,
                lblRecordType, cmbRecordType,
                lblDiagnosis, txtDiagnosis,
                lblTreatment, txtTreatment,
                lblMedications, txtMedications,
                btnAdd, btnUpdate, btnDelete, btnClear
            });

            // Right Panel
            panelRight.BackColor = Color.FromArgb(245, 247, 250);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Padding = new Padding(20, 10, 20, 20);

            panelSearch.BackColor = Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Location = new Point(20, 10);
            panelSearch.Size = new Size(780, 45);
            panelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.ForeColor = Color.Gray;
            lblSearch.Location = new Point(10, 12);
            lblSearch.Text = "🔍";

            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(35, 12);
            txtSearch.Size = new Size(720, 22);
            txtSearch.PlaceholderText = "Search by record ID, patient ID or diagnosis...";
            txtSearch.TextChanged += txtSearch_TextChanged;

            panelSearch.Controls.Add(lblSearch);
            panelSearch.Controls.Add(txtSearch);

            listViewRecords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewRecords.BackColor = Color.White;
            listViewRecords.BorderStyle = BorderStyle.FixedSingle;
            listViewRecords.Font = new Font("Segoe UI", 9F);
            listViewRecords.FullRowSelect = true;
            listViewRecords.GridLines = true;
            listViewRecords.Location = new Point(20, 65);
            listViewRecords.Size = new Size(780, 555);
            listViewRecords.View = View.Details;
            listViewRecords.HideSelection = false;
            listViewRecords.SelectedIndexChanged += listViewRecords_SelectedIndexChanged;

            colRecordID.Text  = "Record ID";  colRecordID.Width  = 80;
            colPatient.Text   = "Patient ID"; colPatient.Width   = 90;
            colDoctor.Text    = "Doctor ID";  colDoctor.Width    = 90;
            colDate.Text      = "Date";       colDate.Width      = 90;
            colDiagnosis.Text = "Diagnosis";  colDiagnosis.Width = 150;
            colTreatment.Text = "Treatment";  colTreatment.Width = 150;
            colMeds.Text      = "Medications"; colMeds.Width     = 130;
            colType.Text      = "Type";       colType.Width      = 100;

            listViewRecords.Columns.AddRange(new ColumnHeader[] {
                colRecordID, colPatient, colDoctor, colDate,
                colDiagnosis, colTreatment, colMeds, colType
            });

            panelRight.Controls.Add(panelSearch);
            panelRight.Controls.Add(listViewRecords);

            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelHeader);

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel        panelHeader, panelLeft, panelRight, panelSearch;
        private Label        lblTitle, lblSubtitle, lblFormTitle;
        private Label        lblRecordID, lblPatientID, lblDoctorID, lblDate;
        private Label        lblRecordType, lblDiagnosis, lblTreatment, lblMedications, lblSearch;
        private TextBox      txtRecordID, txtPatientID, txtDoctorID;
        private TextBox      txtDiagnosis, txtTreatment, txtMedications, txtSearch;
        private ComboBox     cmbRecordType;
        private DateTimePicker dtpDate;
        private Button       btnAdd, btnUpdate, btnDelete, btnClear, btnBack;
        private ListView     listViewRecords;
        private ColumnHeader colRecordID, colPatient, colDoctor, colDate;
        private ColumnHeader colDiagnosis, colTreatment, colMeds, colType;
    }
}
