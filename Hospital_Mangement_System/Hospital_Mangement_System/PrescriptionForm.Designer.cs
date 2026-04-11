namespace Hospital_Mangement_System
{
    partial class PrescriptionForm
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
            lblMedication        = new Label();
            txtMedication        = new TextBox();
            lblAppID             = new Label();
            txtAppID             = new TextBox();
            lblAppHint           = new Label();
            lblNote              = new Label();
            btnAdd               = new Button();
            btnUpdate            = new Button();
            btnDelete            = new Button();
            btnClear             = new Button();
            panelRight           = new Panel();
            panelSearch          = new Panel();
            lblSearchIcon        = new Label();
            txtSearch            = new TextBox();
            listViewPrescriptions= new ListView();
            colPrescID           = new ColumnHeader();
            colMedication        = new ColumnHeader();
            colAppID             = new ColumnHeader();

            panelHeader.SuspendLayout();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            panelSearch.SuspendLayout();
            SuspendLayout();

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(245, 247, 250);
            ClientSize          = new Size(1100, 620);
            Font                = new Font("Segoe UI", 9F);
            StartPosition       = FormStartPosition.CenterScreen;
            Text                = "Prescription Management";
            MinimumSize         = new Size(1100, 620);

            // Header
            panelHeader.BackColor = Color.FromArgb(180, 80, 20);
            panelHeader.Dock      = DockStyle.Top;
            panelHeader.Height    = 70;
            panelHeader.Controls.AddRange(new Control[] { lblTitle, lblSubtitle, btnBack });

            lblTitle.AutoSize  = true;
            lblTitle.Font      = new Font("Gill Sans Ultra Bold Condensed", 22F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(20, 10);
            lblTitle.Text      = "💊  Prescription Management";

            lblSubtitle.AutoSize  = true;
            lblSubtitle.Font      = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(255, 200, 160);
            lblSubtitle.Location  = new Point(25, 45);
            lblSubtitle.Text      = "Table: Prescription  —  Columns: Presc_ID · Medication · AP_ID";

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
            lblFormTitle.ForeColor = Color.FromArgb(180, 80, 20);
            lblFormTitle.Location  = new Point(25, 15);
            lblFormTitle.Text      = "Prescription Details";

            void MkLbl(Label l, string t, int y)
            {
                l.AutoSize  = true;
                l.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
                l.ForeColor = Color.FromArgb(80, 80, 80);
                l.Location  = new Point(25, y);
                l.Text      = t;
            }

            MkLbl(lblMedication, "Medication  (required)", 55);
            txtMedication.BorderStyle = BorderStyle.FixedSingle;
            txtMedication.Font        = new Font("Segoe UI", 10F);
            txtMedication.Location    = new Point(25, 75);
            txtMedication.Size        = new Size(265, 70);
            txtMedication.Multiline   = true;
            txtMedication.BackColor   = Color.FromArgb(248, 249, 250);

            MkLbl(lblAppID, "AP_ID  (Appointment FK, required)", 160);
            txtAppID.BorderStyle = BorderStyle.FixedSingle;
            txtAppID.Font        = new Font("Segoe UI", 10F);
            txtAppID.Location    = new Point(25, 180);
            txtAppID.Size        = new Size(265, 28);
            txtAppID.BackColor   = Color.FromArgb(248, 249, 250);

            lblAppHint.AutoSize  = true;
            lblAppHint.Font      = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblAppHint.ForeColor = Color.SteelBlue;
            lblAppHint.Location  = new Point(25, 213);
            lblAppHint.Text      = "Must match an existing APP_ID in Appointment table";

            lblNote.AutoSize  = true;
            lblNote.Font      = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblNote.ForeColor = Color.Gray;
            lblNote.Location  = new Point(25, 233);
            lblNote.Text      = "Presc_ID is auto-generated (IDENTITY)";

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

            MkBtn(btnAdd,    "➕  Add",    25, 260, Color.FromArgb(180, 80, 20));
            MkBtn(btnUpdate, "✏️  Update", 160, 260, Color.FromArgb(0, 123, 255));
            MkBtn(btnDelete, "🗑️  Delete", 25, 305, Color.FromArgb(220, 53, 69));
            MkBtn(btnClear,  "🔄  Clear",  160, 305, Color.FromArgb(108, 117, 125));

            btnAdd.Click    += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click  += btnClear_Click;

            panelLeft.Controls.AddRange(new Control[] {
                lblFormTitle,
                lblMedication, txtMedication,
                lblAppID, txtAppID, lblAppHint,
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
            txtSearch.PlaceholderText = "Search by Medication or AP_ID...";
            txtSearch.TextChanged    += txtSearch_TextChanged;

            panelSearch.Controls.Add(lblSearchIcon);
            panelSearch.Controls.Add(txtSearch);

            listViewPrescriptions.Anchor        = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewPrescriptions.BackColor     = Color.White;
            listViewPrescriptions.BorderStyle   = BorderStyle.FixedSingle;
            listViewPrescriptions.Font          = new Font("Segoe UI", 9F);
            listViewPrescriptions.FullRowSelect = true;
            listViewPrescriptions.GridLines     = true;
            listViewPrescriptions.Location      = new Point(20, 65);
            listViewPrescriptions.Size          = new Size(740, 490);
            listViewPrescriptions.View          = View.Details;
            listViewPrescriptions.HideSelection = false;
            listViewPrescriptions.SelectedIndexChanged += listViewPrescriptions_SelectedIndexChanged;

            colPrescID.Text   = "Presc_ID (auto)"; colPrescID.Width   = 120;
            colMedication.Text= "Medication";       colMedication.Width= 430;
            colAppID.Text     = "AP_ID (FK)";       colAppID.Width     = 110;

            listViewPrescriptions.Columns.AddRange(new ColumnHeader[] { colPrescID, colMedication, colAppID });

            panelRight.Controls.Add(panelSearch);
            panelRight.Controls.Add(listViewPrescriptions);

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
        private Label        lblMedication, lblAppID, lblAppHint, lblNote, lblSearchIcon;
        private TextBox      txtMedication, txtAppID, txtSearch;
        private Button       btnAdd, btnUpdate, btnDelete, btnClear, btnBack;
        private ListView     listViewPrescriptions;
        private ColumnHeader colPrescID, colMedication, colAppID;
    }
}
