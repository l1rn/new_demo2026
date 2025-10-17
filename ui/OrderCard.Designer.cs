namespace demonewkakaxi.ui
{
    partial class OrderCard
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(13, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(470, 137);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(312, 103);
            button2.Name = "button2";
            button2.Size = new Size(138, 23);
            button2.TabIndex = 5;
            button2.Text = "Редактировать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(200, 103);
            button1.Name = "button1";
            button1.Size = new Size(91, 23);
            button1.TabIndex = 4;
            button1.Text = "Удалить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 103);
            label4.Name = "label4";
            label4.Size = new Size(42, 17);
            label4.TabIndex = 3;
            label4.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 68);
            label3.Name = "label3";
            label3.Size = new Size(42, 17);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 40);
            label2.Name = "label2";
            label2.Size = new Size(42, 17);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(18, 14);
            label1.Name = "label1";
            label1.Size = new Size(47, 17);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label5);
            panel2.Location = new Point(489, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(136, 137);
            panel2.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 55);
            label5.Name = "label5";
            label5.Size = new Size(42, 17);
            label5.TabIndex = 4;
            label5.Text = "label5";
            // 
            // OrderCard
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "OrderCard";
            Size = new Size(629, 169);
            Load += OrderCard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Label label5;
        private Button button2;
        private Button button1;
    }
}
