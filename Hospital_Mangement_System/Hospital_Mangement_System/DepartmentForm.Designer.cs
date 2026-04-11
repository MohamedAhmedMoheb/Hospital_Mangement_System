namespace Hospital_Mangement_System
{
    partial class DepartmentForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader   = new Panel();
            lblTitle      = new Label();
            lblSubtitle   = new Label();
            btnBack       = new Button();
            panelLeft     = new Panel();
            lblFormTitle  = new Label();
            lblDName      = new Label();
            txtDName      = new TextBox();
            lblLocation   = new Label();
            txtLocation   = new TextBox();
            lblNote       = new Label();
            btnAdd        = new Button();
            btnUpdate     = new Button();
            btnDelete     = new Button();
            btnClear      = new Button();
            panelRight    = new Panel();
            panelSearch   = new Panel();
            lblSearchIcon = new Label();
            txtSearch     = new TextBox();
            listViewDepts = new ListView();
            colID         = new ColumnHeader();
            colDName      = new ColumnHeader();
            colLocation   = new ColumnHeader();

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
            Text                = "Department Management";
            MinimumSize         = new Size(1100, 620);

            // Header
            panelHeader.BackColor = Color.FromArgb(60, 60, 130);
            panelHeader.Dock      = DockStyle.Top;
            panelHeader.Height    = 70;
            panelHeader.Controls.AddRange(new Control[] { lblTitle, lblSubtitle, btnBack });

            lblTitle.AutoSize  = true;
            lblTitle.Font      = new Font("Gill Sans Ultra Bold Condensed", 22F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(20, 10);
            lblTitle.Text      = "🏢  Department Management";

            lblSubtitle.AutoSize  = true;
            lblSubtitle.Font      = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(180, 180, 240);
            lblSubtitle.Location  = new Point(25, 45);
            lblSubtitle.Text      = "Table: Department  —  Columns: D_ID · D_NAME · Location";

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
            lblFormTitle.ForeColor = Color.FromArgb(60, 60, 130);
            lblFormTitle.Location  = new Point(25, 15);
            lblFormTitle.Text      = "Department Details";

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

            MkLbl(lblDName,    "D_NAME  (required)", 55);  MkTxt(txtDName,    75);
            MkLbl(lblLocation, "Location  (optional)", 115); MkTxt(txtLocation, 135);

            lblNote.AutoSize  = true;
            lblNote.Font      = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblNote.ForeColor = Color.Gray;
            lblNote.Location  = new Point(25, 175);
            lblNote.Text      = "D_ID is auto-generated (IDENTITY)";

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

            MkBtn(btnAdd,    "➕  Add",    25, 200, Color.FromArgb(60, 60, 130));
            MkBtn(btnUpdate, "✏️  Update", 160, 200, Color.FromArgb(0, 123, 255));
            MkBtn(btnDelete, "🗑️  Delete", 25, 245, Color.FromArgb(220, 53, 69));
            MkBtn(btnClear,  "🔄  Clear",  160, 245, Color.FromArgb(108, 117, 125));

            btnAdd.Click    += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click  += btnClear_Click;

            panelLeft.Controls.AddRange(new Control[] {
                lblFormTitle,
                lblDName, txtDName,
                lblLocation, txtLocation,
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
            txtSearch.PlaceholderText = "Search by D_NAME or Location...";
            txtSearch.TextChanged    += txtSearch_TextChanged;

            panelSearch.Controls.Add(lblSearchIcon);
            panelSearch.Controls.Add(txtSearch);

            listViewDepts.Anchor        = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewDepts.BackColor     = Color.White;
            listViewDepts.BorderStyle   = BorderStyle.FixedSingle;
            listViewDepts.Font          = new Font("Segoe UI", 9F);
            listViewDepts.FullRowSelect = true;
            listViewDepts.GridLines     = true;
            listViewDepts.Location      = new Point(20, 65);
            listViewDepts.Size          = new Size(740, 490);
            listViewDepts.View          = View.Details;
            listViewDepts.HideSelection = false;
            listViewDepts.SelectedIndexChanged += listViewDepts_SelectedIndexChanged;

            colID.Text       = "D_ID (auto)"; colID.Width       = 100;
            colDName.Text    = "D_NAME";       colDName.Width    = 280;
            colLocation.Text = "Location";     colLocation.Width = 280;

            listViewDepts.Columns.AddRange(new ColumnHeader[] { colID, colDName, colLocation });

            panelRight.Controls.Add(panelSearch);
            panelRight.Controls.Add(listViewDepts);

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
        private Label        lblDName, lblLocation, lblNote, lblSearchIcon;
        private TextBox      txtDName, txtLocation, txtSearch;
        private Button       btnAdd, btnUpdate, btnDelete, btnClear, btnBack;
        private ListView     listViewDepts;
        private ColumnHeader colID, colDName, colLocation;
    }
}
