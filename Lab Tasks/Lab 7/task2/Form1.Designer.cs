namespace task2
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
            textBox1 = new TextBox();
            add = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(36, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(723, 27);
            textBox1.TabIndex = 0;
            // 
            // add
            // 
            add.Location = new Point(558, 100);
            add.Name = "add";
            add.Size = new Size(98, 63);
            add.TabIndex = 1;
            add.Text = "+";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // button1
            // 
            button1.Location = new Point(662, 100);
            button1.Name = "button1";
            button1.Size = new Size(97, 66);
            button1.TabIndex = 2;
            button1.Text = "-";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(558, 169);
            button2.Name = "button2";
            button2.Size = new Size(98, 80);
            button2.TabIndex = 4;
            button2.Text = "*";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(662, 172);
            button3.Name = "button3";
            button3.Size = new Size(97, 74);
            button3.TabIndex = 5;
            button3.Text = "/";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(587, 264);
            button4.Name = "button4";
            button4.Size = new Size(154, 110);
            button4.TabIndex = 6;
            button4.Text = "=";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(add);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button butt;
        private Button add;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
