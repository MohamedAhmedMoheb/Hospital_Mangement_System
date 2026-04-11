namespace Hospital_Mangement_System
{
    partial class DoctorForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader    = new Panel();
            lblTitle       = new Label();
            lblSubtitle    = new Label();
            btnBack        = new Button();
            panelLeft      = new Panel();
            lblFormTitle   = new Label();
            lblName        = new Label();
            txtName        = new TextBox();
            lblSpecialty   = new Label();
            txtSpecialty   = new TextBox();
            lblDeptID      = new Label();
            txtDeptID      = new TextBox();
            lblDeptHint    = new Label();
            lblNote        = new Label();
            btnAdd         = new Button();
            btnUpdate      = new Button();
            btnDelete      = new Button();
            btnClear       = new Button();
            panelRight     = new Panel();
            panelSearch    = new Panel();
            lblSearchIcon  = new Label();
            txtSearch      = new TextBox();
            listViewDoctors = new ListView();
            colID          = new ColumnHeader();
            colName        = new ColumnHeader();
            colSpecialty   = new ColumnHeader();
            colDeptID      = new ColumnHeader();

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
            Text                = "Doctor Management";
            MinimumSize         = new Size(1100, 650);

            // Header
            panelHeader.BackColor = Color.FromArgb(20, 80, 60);
            panelHeader.Dock      = DockStyle.Top;
            panelHeader.Height    = 70;
            panelHeader.Controls.AddRange(new Control[] { lblTitle, lblSubtitle, btnBack });

            lblTitle.AutoSize  = true;
            lblTitle.Font      = new Font("Gill Sans Ultra Bold Condensed", 22F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(20, 10);
            lblTitle.Text      = "👨‍⚕️  Doctor Management";

            lblSubtitle.AutoSize  = true;
            lblSubtitle.Font      = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(160, 220, 190);
            lblSubtitle.Location  = new Point(25, 45);
            lblSubtitle.Text      = "Table: Doctor  —  Columns: DOC_ID · DOC_NAME · Specialty · DD_ID";

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
            lblFormTitle.ForeColor = Color.FromArgb(20, 80, 60);
            lblFormTitle.Location  = new Point(25, 15);
            lblFormTitle.Text      = "Doctor Details";

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

            MkLbl(lblName,     "DOC_NAME  (required)", 55);  MkTxt(txtName,     75);
            MkLbl(lblSpecialty,"Specialty  (required)", 115); MkTxt(txtSpecialty,135);
            MkLbl(lblDeptID,   "DD_ID  (Department FK, required)", 175); MkTxt(txtDeptID, 195);

            lblDeptHint.AutoSize  = true;
            lblDeptHint.Font      = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblDeptHint.ForeColor = Color.SteelBlue;
            lblDeptHint.Location  = new Point(25, 228);
            lblDeptHint.Text      = "Must match an existing D_ID in the Department table";

            lblNote.AutoSize  = true;
            lblNote.Font      = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblNote.ForeColor = Color.Gray;
            lblNote.Location  = new Point(25, 248);
            lblNote.Text      = "DOC_ID is auto-generated (IDENTITY)";

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

            MkBtn(btnAdd,    "➕  Add",    25, 275, Color.FromArgb(20, 80, 60));
            MkBtn(btnUpdate, "✏️  Update", 160, 275, Color.FromArgb(0, 123, 255));
            MkBtn(btnDelete, "🗑️  Delete", 25, 320, Color.FromArgb(220, 53, 69));
            MkBtn(btnClear,  "🔄  Clear",  160, 320, Color.FromArgb(108, 117, 125));

            btnAdd.Click    += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click  += btnClear_Click;

            panelLeft.Controls.AddRange(new Control[] {
                lblFormTitle,
                lblName, txtName,
                lblSpecialty, txtSpecialty,
                lblDeptID, txtDeptID,
                lblDeptHint, lblNote,
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
            txtSearch.PlaceholderText = "Search by DOC_NAME or Specialty...";
            txtSearch.TextChanged    += txtSearch_TextChanged;

            panelSearch.Controls.Add(lblSearchIcon);
            panelSearch.Controls.Add(txtSearch);

            listViewDoctors.Anchor        = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewDoctors.BackColor     = Color.White;
            listViewDoctors.BorderStyle   = BorderStyle.FixedSingle;
            listViewDoctors.Font          = new Font("Segoe UI", 9F);
            listViewDoctors.FullRowSelect = true;
            listViewDoctors.GridLines     = true;
            listViewDoctors.Location      = new Point(20, 65);
            listViewDoctors.Size          = new Size(740, 520);
            listViewDoctors.View          = View.Details;
            listViewDoctors.HideSelection = false;
            listViewDoctors.SelectedIndexChanged += listViewDoctors_SelectedIndexChanged;

            colID.Text       = "DOC_ID (auto)"; colID.Width       = 110;
            colName.Text     = "DOC_NAME";       colName.Width     = 220;
            colSpecialty.Text= "Specialty";      colSpecialty.Width= 200;
            colDeptID.Text   = "DD_ID (FK)";     colDeptID.Width   = 100;

            listViewDoctors.Columns.AddRange(new ColumnHeader[] { colID, colName, colSpecialty, colDeptID });

            panelRight.Controls.Add(panelSearch);
            panelRight.Controls.Add(listViewDoctors);

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
        private Label        lblName, lblSpecialty, lblDeptID, lblDeptHint, lblNote, lblSearchIcon;
        private TextBox      txtName, txtSpecialty, txtDeptID, txtSearch;
        private Button       btnAdd, btnUpdate, btnDelete, btnClear, btnBack;
        private ListView     listViewDoctors;
        private ColumnHeader colID, colName, colSpecialty, colDeptID;
    }
}
