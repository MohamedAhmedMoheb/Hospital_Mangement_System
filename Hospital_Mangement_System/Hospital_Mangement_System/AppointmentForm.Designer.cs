namespace Hospital_Mangement_System
{
    partial class AppointmentForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader          = new Panel();
            lblTitle             = new Label();
            lblSubtitle          = new Label();
            btnBack              = new Button();
            panelLeft            = new Panel();
            lblFormTitle         = new Label();
            lblDoctorID          = new Label();
            txtDoctorID          = new TextBox();
            lblDoctorHint        = new Label();
            lblPatientID         = new Label();
            txtPatientID         = new TextBox();
            lblPatientHint       = new Label();
            lblDate              = new Label();
            dtpDate              = new DateTimePicker();
            lblTime              = new Label();
            dtpTime              = new DateTimePicker();
            lblNote              = new Label();
            btnAdd               = new Button();
            btnUpdate            = new Button();
            btnDelete            = new Button();
            btnClear             = new Button();
            panelRight           = new Panel();
            panelSearch          = new Panel();
            lblSearchIcon        = new Label();
            txtSearch            = new TextBox();
            listViewAppointments = new ListView();
            colAppID             = new ColumnHeader();
            colDate              = new ColumnHeader();
            colTime              = new ColumnHeader();
            colDoctorID          = new ColumnHeader();
            colPatientID         = new ColumnHeader();

            panelHeader.SuspendLayout();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            panelSearch.SuspendLayout();
            SuspendLayout();

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(245, 247, 250);
            ClientSize          = new Size(1100, 650);
            Font                = new Font("Segoe UI", 9F);
            StartPosition       = FormStartPosition.CenterScreen;
            Text                = "Appointment Management";
            MinimumSize         = new Size(1100, 650);

            // Header
            panelHeader.BackColor = Color.FromArgb(90, 40, 120);
            panelHeader.Dock      = DockStyle.Top;
            panelHeader.Height    = 70;
            panelHeader.Controls.AddRange(new Control[] { lblTitle, lblSubtitle, btnBack });

            lblTitle.AutoSize  = true;
            lblTitle.Font      = new Font("Gill Sans Ultra Bold Condensed", 22F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(20, 10);
            lblTitle.Text      = "📅  Appointment Management";

            lblSubtitle.AutoSize  = true;
            lblSubtitle.Font      = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(200, 170, 230);
            lblSubtitle.Location  = new Point(25, 45);
            lblSubtitle.Text      = "Table: Appointment  —  Columns: APP_ID · Date · Time · DA_ID · PA_ID";

            btnBack.BackColor                 = Color.FromArgb(220, 53, 69);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle                 = FlatStyle.Flat;
            btnBack.Font                      = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBack.ForeColor                 = Color.White;
            btnBack.Location                  = new Point(990, 20);
            btnBack.Size                      = new Size(90, 32);
            btnBack.Text                      = "◀  Back";
            btnBack.Cursor                    = Cursors.Hand;
            btnBack.Click                    += btnBack_Click;

            // Left Panel
            panelLeft.BackColor = Color.White;
            panelLeft.Dock      = DockStyle.Left;
            panelLeft.Width     = 320;

            lblFormTitle.AutoSize  = true;
            lblFormTitle.Font      = new Font("Gill Sans Ultra Bold Condensed", 16F);
            lblFormTitle.ForeColor = Color.FromArgb(90, 40, 120);
            lblFormTitle.Location  = new Point(25, 15);
            lblFormTitle.Text      = "Appointment Details";

            void MkLbl(Label l, string t, int y)
            {
                l.AutoSize  = true;
                l.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
                l.ForeColor = Color.FromArgb(80, 80, 80);
                l.Location  = new Point(25, y);
                l.Text      = t;
            }
            void MkTxt(TextBox t, int y)
            {
                t.BorderStyle = BorderStyle.FixedSingle;
                t.Font        = new Font("Segoe UI", 10F);
                t.Location    = new Point(25, y);
                t.Size        = new Size(265, 28);
                t.BackColor   = Color.FromArgb(248, 249, 250);
            }
            void MkHint(Label l, string t, int y)
            {
                l.AutoSize  = true;
                l.Font      = new Font("Segoe UI", 8F, FontStyle.Italic);
                l.ForeColor = Color.SteelBlue;
                l.Location  = new Point(25, y);
                l.Text      = t;
            }

            MkLbl(lblDoctorID,  "DA_ID  (Doctor FK, required)", 55);
            MkTxt(txtDoctorID,  75);
            MkHint(lblDoctorHint, "Must match an existing DOC_ID in Doctor table", 108);

            MkLbl(lblPatientID,  "PA_ID  (Patient FK, required)", 130);
            MkTxt(txtPatientID,  150);
            MkHint(lblPatientHint, "Must match an existing P_ID in Patient table", 183);

            MkLbl(lblDate, "Date  (required)", 205);
            dtpDate.Format    = DateTimePickerFormat.Short;
            dtpDate.Font      = new Font("Segoe UI", 10F);
            dtpDate.Location  = new Point(25, 225);
            dtpDate.Size      = new Size(265, 28);

            MkLbl(lblTime, "Time  (required)", 263);
            dtpTime.Format    = DateTimePickerFormat.Time;
            dtpTime.ShowUpDown = true;
            dtpTime.Font      = new Font("Segoe UI", 10F);
            dtpTime.Location  = new Point(25, 283);
            dtpTime.Size      = new Size(265, 28);

            lblNote.AutoSize  = true;
            lblNote.Font      = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblNote.ForeColor = Color.Gray;
            lblNote.Location  = new Point(25, 322);
            lblNote.Text      = "APP_ID is auto-generated (IDENTITY)";

            void MkBtn(Button b, string t, int x, int y, Color bg)
            {
                b.BackColor                 = bg;
                b.FlatAppearance.BorderSize = 0;
                b.FlatStyle                 = FlatStyle.Flat;
                b.Font                      = new Font("Segoe UI", 9F, FontStyle.Bold);
                b.ForeColor                 = Color.White;
                b.Location                  = new Point(x, y);
                b.Size                      = new Size(125, 36);
                b.Text                      = t;
                b.Cursor                    = Cursors.Hand;
            }

            MkBtn(btnAdd,    "📅  Book",   25, 345, Color.FromArgb(90, 40, 120));
            MkBtn(btnUpdate, "✏️  Update", 160, 345, Color.FromArgb(0, 123, 255));
            MkBtn(btnDelete, "🗑️  Delete", 25, 390, Color.FromArgb(220, 53, 69));
            MkBtn(btnClear,  "🔄  Clear",  160, 390, Color.FromArgb(108, 117, 125));

            btnAdd.Click    += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click  += btnClear_Click;

            panelLeft.Controls.AddRange(new Control[] {
                lblFormTitle,
                lblDoctorID, txtDoctorID, lblDoctorHint,
                lblPatientID, txtPatientID, lblPatientHint,
                lblDate, dtpDate,
                lblTime, dtpTime,
                lblNote,
                btnAdd, btnUpdate, btnDelete, btnClear
            });

            // Right Panel
            panelRight.BackColor = Color.FromArgb(245, 247, 250);
            panelRight.Dock      = DockStyle.Fill;
            panelRight.Padding   = new Padding(20, 10, 20, 20);

            panelSearch.BackColor   = Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Location    = new Point(20, 10);
            panelSearch.Size        = new Size(740, 45);
            panelSearch.Anchor      = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblSearchIcon.AutoSize  = true;
            lblSearchIcon.Font      = new Font("Segoe UI", 10F);
            lblSearchIcon.ForeColor = Color.Gray;
            lblSearchIcon.Location  = new Point(10, 12);
            lblSearchIcon.Text      = "🔍";

            txtSearch.BorderStyle     = BorderStyle.None;
            txtSearch.Font            = new Font("Segoe UI", 10F);
            txtSearch.Location        = new Point(35, 12);
            txtSearch.Size            = new Size(680, 22);
            txtSearch.PlaceholderText = "Search by Date, DA_ID or PA_ID...";
            txtSearch.TextChanged    += txtSearch_TextChanged;

            panelSearch.Controls.Add(lblSearchIcon);
            panelSearch.Controls.Add(txtSearch);

            listViewAppointments.Anchor        = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewAppointments.BackColor     = Color.White;
            listViewAppointments.BorderStyle   = BorderStyle.FixedSingle;
            listViewAppointments.Font          = new Font("Segoe UI", 9F);
            listViewAppointments.FullRowSelect = true;
            listViewAppointments.GridLines     = true;
            listViewAppointments.Location      = new Point(20, 65);
            listViewAppointments.Size          = new Size(740, 520);
            listViewAppointments.View          = View.Details;
            listViewAppointments.HideSelection = false;
            listViewAppointments.SelectedIndexChanged += listViewAppointments_SelectedIndexChanged;

            colAppID.Text    = "APP_ID (auto)"; colAppID.Width    = 110;
            colDate.Text     = "Date";           colDate.Width     = 120;
            colTime.Text     = "Time";           colTime.Width     = 90;
            colDoctorID.Text = "DA_ID (Doctor)"; colDoctorID.Width = 120;
            colPatientID.Text= "PA_ID (Patient)";colPatientID.Width= 120;

            listViewAppointments.Columns.AddRange(new ColumnHeader[] {
                colAppID, colDate, colTime, colDoctorID, colPatientID
            });

            panelRight.Controls.Add(panelSearch);
            panelRight.Controls.Add(listViewAppointments);

            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelHeader);

            panelHeader.ResumeLayout(false); panelHeader.PerformLayout();
            panelLeft.ResumeLayout(false);   panelLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel        panelHeader, panelLeft, panelRight, panelSearch;
        private Label        lblTitle, lblSubtitle, lblFormTitle;
        private Label        lblDoctorID, lblDoctorHint, lblPatientID, lblPatientHint;
        private Label        lblDate, lblTime, lblNote, lblSearchIcon;
        private TextBox      txtDoctorID, txtPatientID, txtSearch;
        private DateTimePicker dtpDate, dtpTime;
        private Button       btnAdd, btnUpdate, btnDelete, btnClear, btnBack;
        private ListView     listViewAppointments;
        private ColumnHeader colAppID, colDate, colTime, colDoctorID, colPatientID;
    }
}
