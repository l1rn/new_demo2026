namespace demonewkakaxi
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            label3 = new Label();
            button3 = new Button();
            button4 = new Button();
            panel3 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(52, 83);
            button1.Name = "button1";
            button1.Size = new Size(109, 53);
            button1.TabIndex = 0;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(398, 83);
            button2.Name = "button2";
            button2.Size = new Size(109, 53);
            button2.TabIndex = 1;
            button2.Text = "Открыть";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(911, 100);
            panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Icon;
            pictureBox1.Location = new Point(405, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(609, 35);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(0, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(911, 396);
            panel2.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Controls.Add(button3);
            panel4.Controls.Add(button4);
            panel4.Location = new Point(183, 221);
            panel4.Name = "panel4";
            panel4.Size = new Size(566, 163);
            panel4.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(241, 29);
            label3.Name = "label3";
            label3.Size = new Size(55, 19);
            label3.TabIndex = 3;
            label3.Text = "Заказы";
            // 
            // button3
            // 
            button3.Location = new Point(52, 83);
            button3.Name = "button3";
            button3.Size = new Size(109, 53);
            button3.TabIndex = 0;
            button3.Text = "Добавить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(398, 83);
            button4.Name = "button4";
            button4.Size = new Size(109, 53);
            button4.TabIndex = 1;
            button4.Text = "Открыть";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(button2);
            panel3.Location = new Point(183, 34);
            panel3.Name = "panel3";
            panel3.Size = new Size(566, 163);
            panel3.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(241, 31);
            label2.Name = "label2";
            label2.Size = new Size(59, 19);
            label2.TabIndex = 2;
            label2.Text = "Товары";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 496);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Главная форма";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel4;
        private Label label3;
        private Button button3;
        private Button button4;
        private Panel panel3;
        private Label label2;
    }
}