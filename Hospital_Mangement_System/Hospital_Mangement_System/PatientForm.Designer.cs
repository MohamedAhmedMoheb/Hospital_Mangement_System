namespace Hospital_Mangement_System
{
    partial class PatientForm
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
            lblName          = new Label();
            txtName          = new TextBox();
            lblAge           = new Label();
            txtAge           = new TextBox();
            lblPhone         = new Label();
            txtPhone         = new TextBox();
            lblNote          = new Label();
            btnAdd           = new Button();
            btnUpdate        = new Button();
            btnDelete        = new Button();
            btnClear         = new Button();
            panelRight       = new Panel();
            panelSearch      = new Panel();
            lblSearchIcon    = new Label();
            txtSearch        = new TextBox();
            listViewPatients = new ListView();
            colID            = new ColumnHeader();
            colName          = new ColumnHeader();
            colAge           = new ColumnHeader();
            colPhone         = new ColumnHeader();

            panelHeader.SuspendLayout();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            panelSearch.SuspendLayout();
            SuspendLayout();

            // ── Form ──────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(245, 247, 250);
            ClientSize          = new Size(1100, 650);
            Font                = new Font("Segoe UI", 9F);
            StartPosition       = FormStartPosition.CenterScreen;
            Text                = "Patient Management";
            MinimumSize         = new Size(1100, 650);

            // ── Header ────────────────────────────────────────────────
            panelHeader.BackColor = Color.FromArgb(26, 60, 90);
            panelHeader.Dock      = DockStyle.Top;
            panelHeader.Height    = 70;
            panelHeader.Controls.AddRange(new Control[] { lblTitle, lblSubtitle, btnBack });

            lblTitle.AutoSize  = true;
            lblTitle.Font      = new Font("Gill Sans Ultra Bold Condensed", 22F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(20, 10);
            lblTitle.Text      = "🏥  Patient Management";

            lblSubtitle.AutoSize  = true;
            lblSubtitle.Font      = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(180, 210, 240);
            lblSubtitle.Location  = new Point(25, 45);
            lblSubtitle.Text      = "Table: Patient  —  Columns: P_ID · P_NAME · Age · P_NUM";

            btnBack.BackColor                  = Color.FromArgb(220, 53, 69);
            btnBack.FlatAppearance.BorderSize  = 0;
            btnBack.FlatStyle                  = FlatStyle.Flat;
            btnBack.Font                       = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBack.ForeColor                  = Color.White;
            btnBack.Location                   = new Point(990, 20);
            btnBack.Size                       = new Size(90, 32);
            btnBack.Text                       = "◀  Back";
            btnBack.Cursor                     = Cursors.Hand;
            btnBack.Click                     += btnBack_Click;

            // ── Left Panel ────────────────────────────────────────────
            panelLeft.BackColor = Color.White;
            panelLeft.Dock      = DockStyle.Left;
            panelLeft.Width     = 320;

            lblFormTitle.AutoSize  = true;
            lblFormTitle.Font      = new Font("Gill Sans Ultra Bold Condensed", 16F);
            lblFormTitle.ForeColor = Color.FromArgb(26, 60, 90);
            lblFormTitle.Location  = new Point(25, 15);
            lblFormTitle.Text      = "Patient Details";

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

            MkLbl(lblName,  "P_NAME  (required)",   55);  MkTxt(txtName,  75);
            MkLbl(lblAge,   "Age  (required, 0–255)", 115); MkTxt(txtAge,   135);
            MkLbl(lblPhone, "P_NUM  (phone, optional)", 175); MkTxt(txtPhone, 195);

            lblNote.AutoSize  = true;
            lblNote.Font      = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblNote.ForeColor = Color.Gray;
            lblNote.Location  = new Point(25, 235);
            lblNote.Text      = "P_ID is auto-generated (IDENTITY)";

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

            MkBtn(btnAdd,    "➕  Add",     25, 265, Color.FromArgb(40, 167, 69));
            MkBtn(btnUpdate, "✏️  Update",  160, 265, Color.FromArgb(0, 123, 255));
            MkBtn(btnDelete, "🗑️  Delete",  25, 310, Color.FromArgb(220, 53, 69));
            MkBtn(btnClear,  "🔄  Clear",  160, 310, Color.FromArgb(108, 117, 125));

            btnAdd.Click    += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click  += btnClear_Click;

            panelLeft.Controls.AddRange(new Control[] {
                lblFormTitle,
                lblName, txtName,
                lblAge, txtAge,
                lblPhone, txtPhone,
                lblNote,
                btnAdd, btnUpdate, btnDelete, btnClear
            });

            // ── Right Panel ───────────────────────────────────────────
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
            txtSearch.PlaceholderText = "Search by P_NAME or P_NUM...";
            txtSearch.TextChanged    += txtSearch_TextChanged;

            panelSearch.Controls.Add(lblSearchIcon);
            panelSearch.Controls.Add(txtSearch);

            listViewPatients.Anchor           = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewPatients.BackColor        = Color.White;
            listViewPatients.BorderStyle      = BorderStyle.FixedSingle;
            listViewPatients.Font             = new Font("Segoe UI", 9F);
            listViewPatients.FullRowSelect    = true;
            listViewPatients.GridLines        = true;
            listViewPatients.Location         = new Point(20, 65);
            listViewPatients.Size             = new Size(740, 520);
            listViewPatients.View             = View.Details;
            listViewPatients.HideSelection    = false;
            listViewPatients.SelectedIndexChanged += listViewPatients_SelectedIndexChanged;

            colID.Text    = "P_ID (auto)"; colID.Width    = 100;
            colName.Text  = "P_NAME";      colName.Width  = 220;
            colAge.Text   = "Age";         colAge.Width   = 80;
            colPhone.Text = "P_NUM";       colPhone.Width = 160;

            listViewPatients.Columns.AddRange(new ColumnHeader[] { colID, colName, colAge, colPhone });

            panelRight.Controls.Add(panelSearch);
            panelRight.Controls.Add(listViewPatients);

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
        private Label        lblName, lblAge, lblPhone, lblNote, lblSearchIcon;
        private TextBox      txtName, txtAge, txtPhone, txtSearch;
        private Button       btnAdd, btnUpdate, btnDelete, btnClear, btnBack;
        private ListView     listViewPatients;
        private ColumnHeader colID, colName, colAge, colPhone;
    }
}
