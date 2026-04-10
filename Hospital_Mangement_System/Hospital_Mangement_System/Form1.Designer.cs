namespace Hospital_Mangement_System
{
    partial class menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            button1 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            button4 = new Button();
            dateTimePicker1 = new DateTimePicker();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Gill Sans Ultra Bold Condensed", 15.75F);
            button1.ForeColor = Color.DarkRed;
            button1.Location = new Point(40, 245);
            button1.Name = "button1";
            button1.Size = new Size(193, 49);
            button1.TabIndex = 0;
            button1.Text = "Patient";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Cornsilk;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Britannic Bold", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.DarkRed;
            textBox1.HideSelection = false;
            textBox1.Location = new Point(497, 325);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(437, 98);
            textBox1.TabIndex = 2;
            textBox1.Text = "Hospital of The British University in Egypt";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button3
            // 
            button3.Font = new Font("Gill Sans Ultra Bold Condensed", 15.75F);
            button3.ForeColor = Color.DarkRed;
            button3.Location = new Point(30, 69);
            button3.Name = "button3";
            button3.Size = new Size(193, 49);
            button3.TabIndex = 4;
            button3.Text = "Doctor";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Gill Sans Ultra Bold Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DarkRed;
            button2.Location = new Point(265, 69);
            button2.Name = "button2";
            button2.Size = new Size(193, 49);
            button2.TabIndex = 5;
            button2.Text = "Appointment";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Gill Sans Ultra Bold Condensed", 15.75F);
            button4.ForeColor = Color.DarkRed;
            button4.Location = new Point(265, 245);
            button4.Name = "button4";
            button4.Size = new Size(193, 49);
            button4.TabIndex = 6;
            button4.Text = "Medical Records";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(146, 363);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(225, 23);
            dateTimePicker1.TabIndex = 7;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gemini_Generated_Image_x2uz7nx2uz7nx2uz;
            pictureBox1.Location = new Point(-2348, 78);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(434, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_2;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(487, 35);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(412, 273);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(1011, 487);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "menu";
            Text = "Menu";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Button button3;
        private Button button2;
        private Button button4;
        private DateTimePicker dateTimePicker1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
