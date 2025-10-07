namespace demonewkakaxi.ui
{
    partial class ShowForm
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
            panel1 = new Panel();
            textBox1 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(891, 111);
            panel1.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(226, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(186, 25);
            textBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(418, 80);
            button1.Name = "button1";
            button1.Size = new Size(87, 25);
            button1.TabIndex = 3;
            button1.Text = "Поиск";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(599, 37);
            label1.Name = "label1";
            label1.Size = new Size(42, 17);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 111);
            panel2.Name = "panel2";
            panel2.Size = new Size(891, 375);
            panel2.TabIndex = 4;
            panel2.Paint += panel2_Paint;
            // 
            // ShowForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 486);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "ShowForm";
            Text = "ShowForm";
            Load += ShowForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
    }
}