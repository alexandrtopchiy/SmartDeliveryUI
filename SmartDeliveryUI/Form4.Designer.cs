namespace SmartDeliveryUI
{
    partial class Form4
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
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bankEDIT_textBox = new System.Windows.Forms.TextBox();
            this.cvvEDIT_textBox = new System.Windows.Forms.TextBox();
            this.expDateEDIT_textBox = new System.Windows.Forms.TextBox();
            this.cardNumberEDIT_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.saveCardData_button = new System.Windows.Forms.Button();
            this.returnToMenu_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(117, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 18);
            this.label12.TabIndex = 31;
            this.label12.Text = "Credit card data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(63, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "Bank:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(67, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "CVV:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(16, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "Expiring date:";
            // 
            // bankEDIT_textBox
            // 
            this.bankEDIT_textBox.Location = new System.Drawing.Point(120, 163);
            this.bankEDIT_textBox.Name = "bankEDIT_textBox";
            this.bankEDIT_textBox.Size = new System.Drawing.Size(147, 20);
            this.bankEDIT_textBox.TabIndex = 27;
            // 
            // cvvEDIT_textBox
            // 
            this.cvvEDIT_textBox.Location = new System.Drawing.Point(120, 130);
            this.cvvEDIT_textBox.Name = "cvvEDIT_textBox";
            this.cvvEDIT_textBox.Size = new System.Drawing.Size(147, 20);
            this.cvvEDIT_textBox.TabIndex = 26;
            // 
            // expDateEDIT_textBox
            // 
            this.expDateEDIT_textBox.Location = new System.Drawing.Point(120, 97);
            this.expDateEDIT_textBox.Name = "expDateEDIT_textBox";
            this.expDateEDIT_textBox.Size = new System.Drawing.Size(147, 20);
            this.expDateEDIT_textBox.TabIndex = 25;
            // 
            // cardNumberEDIT_textBox
            // 
            this.cardNumberEDIT_textBox.Location = new System.Drawing.Point(120, 64);
            this.cardNumberEDIT_textBox.Name = "cardNumberEDIT_textBox";
            this.cardNumberEDIT_textBox.Size = new System.Drawing.Size(147, 20);
            this.cardNumberEDIT_textBox.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(17, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "Card number:";
            // 
            // saveCardData_button
            // 
            this.saveCardData_button.Location = new System.Drawing.Point(120, 209);
            this.saveCardData_button.Name = "saveCardData_button";
            this.saveCardData_button.Size = new System.Drawing.Size(147, 28);
            this.saveCardData_button.TabIndex = 32;
            this.saveCardData_button.Text = "Save Changes";
            this.saveCardData_button.UseVisualStyleBackColor = true;
            this.saveCardData_button.Click += new System.EventHandler(this.saveCardData_button_Click);
            // 
            // returnToMenu_button
            // 
            this.returnToMenu_button.Location = new System.Drawing.Point(120, 258);
            this.returnToMenu_button.Name = "returnToMenu_button";
            this.returnToMenu_button.Size = new System.Drawing.Size(147, 28);
            this.returnToMenu_button.TabIndex = 33;
            this.returnToMenu_button.Text = "Return to Menu";
            this.returnToMenu_button.UseVisualStyleBackColor = true;
            this.returnToMenu_button.Click += new System.EventHandler(this.returnToMenu_button_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 316);
            this.Controls.Add(this.returnToMenu_button);
            this.Controls.Add(this.saveCardData_button);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bankEDIT_textBox);
            this.Controls.Add(this.cvvEDIT_textBox);
            this.Controls.Add(this.expDateEDIT_textBox);
            this.Controls.Add(this.cardNumberEDIT_textBox);
            this.Controls.Add(this.label7);
            this.Name = "Form4";
            this.Text = "Change credit card";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox bankEDIT_textBox;
        private System.Windows.Forms.TextBox cvvEDIT_textBox;
        private System.Windows.Forms.TextBox expDateEDIT_textBox;
        private System.Windows.Forms.TextBox cardNumberEDIT_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button saveCardData_button;
        private System.Windows.Forms.Button returnToMenu_button;
    }
}