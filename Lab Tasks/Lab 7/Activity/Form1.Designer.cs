namespace Activity
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
            dayyear = new ComboBox();
            combo = new ComboBox();
            button = new Button();
            Pizza = new ComboBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // dayyear
            // 
            dayyear.FormattingEnabled = true;
            dayyear.Location = new Point(80, 38);
            dayyear.Name = "dayyear";
            dayyear.Size = new Size(151, 28);
            dayyear.TabIndex = 0;
            dayyear.SelectedIndexChanged += dayyear_SelectedIndexChanged;
            // 
            // combo
            // 
            combo.FormattingEnabled = true;
            combo.Location = new Point(80, 135);
            combo.Name = "combo";
            combo.Size = new Size(151, 28);
            combo.TabIndex = 1;
            combo.SelectedIndexChanged += combo_SelectedIndexChanged;
            // 
            // button
            // 
            button.Location = new Point(126, 251);
            button.Name = "button";
            button.Size = new Size(94, 29);
            button.TabIndex = 2;
            button.Text = "Click";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // Pizza
            // 
            Pizza.FormattingEnabled = true;
            Pizza.Location = new Point(380, 38);
            Pizza.Name = "Pizza";
            Pizza.Size = new Size(151, 28);
            Pizza.TabIndex = 3;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(391, 95);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(78, 24);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Cheese";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(392, 125);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(77, 24);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "Paparo";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(392, 155);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(102, 24);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "Mushroom";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(338, 46);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 7;
            label1.Text = "Size";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(392, 201);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 8;
            button1.Text = "Click";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(391, 260);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(Pizza);
            Controls.Add(button);
            Controls.Add(combo);
            Controls.Add(dayyear);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox dayyear;
        private ComboBox combo;
        private Button button;
        private ComboBox Pizza;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Label label1;
        private Button button1;
        private Label label2;
    }
}
