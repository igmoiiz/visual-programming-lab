namespace Task1
{
    partial class Form1
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            add = new Button();
            Sub = new Button();
            mul = new Button();
            div = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 42);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 0;
            label1.Text = "Enter number 1: ";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(200, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(162, 27);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 137);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 2;
            label2.Text = "Enter number 2: ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(200, 130);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(162, 27);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 230);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 4;
            label3.Text = "Result: ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(139, 223);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(162, 27);
            textBox3.TabIndex = 5;
            // 
            // add
            // 
            add.Location = new Point(38, 322);
            add.Name = "add";
            add.Size = new Size(94, 29);
            add.TabIndex = 6;
            add.Text = "Add";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // Sub
            // 
            Sub.Location = new Point(157, 322);
            Sub.Name = "Sub";
            Sub.Size = new Size(94, 29);
            Sub.TabIndex = 7;
            Sub.Text = "Subtract";
            Sub.UseVisualStyleBackColor = true;
            Sub.Click += Sub_Click;
            // 
            // mul
            // 
            mul.Location = new Point(286, 322);
            mul.Name = "mul";
            mul.Size = new Size(94, 29);
            mul.TabIndex = 8;
            mul.Text = "Multiply";
            mul.UseVisualStyleBackColor = true;
            mul.Click += mul_Click;
            // 
            // div
            // 
            div.Location = new Point(420, 322);
            div.Name = "div";
            div.Size = new Size(94, 29);
            div.TabIndex = 9;
            div.Text = "Division";
            div.UseVisualStyleBackColor = true;
            div.Click += div_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(div);
            Controls.Add(mul);
            Controls.Add(Sub);
            Controls.Add(add);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Button add;
        private Button Sub;
        private Button mul;
        private Button div;
    }
}
