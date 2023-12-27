namespace SmartDeliveryUI
{
    partial class Form7
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
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.adressCourier_textBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cityCourier_textBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.submitCourier_button = new System.Windows.Forms.Button();
            this.goBack_button = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.courierDate_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(7, 185);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 16);
            this.label17.TabIndex = 38;
            this.label17.Tag = "Delivery time:";
            this.label17.Text = "Сonvenient time:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(22, 148);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 16);
            this.label16.TabIndex = 36;
            this.label16.Text = "Delivery date:";
            // 
            // adressCourier_textBox
            // 
            this.adressCourier_textBox.Location = new System.Drawing.Point(118, 109);
            this.adressCourier_textBox.Name = "adressCourier_textBox";
            this.adressCourier_textBox.Size = new System.Drawing.Size(147, 20);
            this.adressCourier_textBox.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(7, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 16);
            this.label15.TabIndex = 34;
            this.label15.Text = "Delivery adress:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(98, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 18);
            this.label13.TabIndex = 33;
            this.label13.Text = "Request courier";
            // 
            // cityCourier_textBox
            // 
            this.cityCourier_textBox.Location = new System.Drawing.Point(118, 72);
            this.cityCourier_textBox.Name = "cityCourier_textBox";
            this.cityCourier_textBox.Size = new System.Drawing.Size(147, 20);
            this.cityCourier_textBox.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(48, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 16);
            this.label14.TabIndex = 31;
            this.label14.Text = "Enter city:";
            // 
            // submitCourier_button
            // 
            this.submitCourier_button.Location = new System.Drawing.Point(175, 232);
            this.submitCourier_button.Name = "submitCourier_button";
            this.submitCourier_button.Size = new System.Drawing.Size(90, 32);
            this.submitCourier_button.TabIndex = 55;
            this.submitCourier_button.Text = "Submit";
            this.submitCourier_button.UseVisualStyleBackColor = true;
            this.submitCourier_button.Click += new System.EventHandler(this.submitCourier_button_Click);
            // 
            // goBack_button
            // 
            this.goBack_button.Location = new System.Drawing.Point(60, 232);
            this.goBack_button.Name = "goBack_button";
            this.goBack_button.Size = new System.Drawing.Size(90, 32);
            this.goBack_button.TabIndex = 56;
            this.goBack_button.Text = "Go back";
            this.goBack_button.UseVisualStyleBackColor = true;
            this.goBack_button.Click += new System.EventHandler(this.goBack_button_Click);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "8:00",
            "10:00",
            "12:00",
            "14:00",
            "16:00"});
            this.comboBox.Location = new System.Drawing.Point(118, 184);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(147, 21);
            this.comboBox.TabIndex = 57;
            // 
            // courierDate_comboBox
            // 
            this.courierDate_comboBox.FormattingEnabled = true;
            this.courierDate_comboBox.Location = new System.Drawing.Point(119, 147);
            this.courierDate_comboBox.Name = "courierDate_comboBox";
            this.courierDate_comboBox.Size = new System.Drawing.Size(146, 21);
            this.courierDate_comboBox.TabIndex = 58;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 300);
            this.Controls.Add(this.courierDate_comboBox);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.goBack_button);
            this.Controls.Add(this.submitCourier_button);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.adressCourier_textBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cityCourier_textBox);
            this.Controls.Add(this.label14);
            this.Name = "Form7";
            this.Text = "Order courier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox adressCourier_textBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox cityCourier_textBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button submitCourier_button;
        private System.Windows.Forms.Button goBack_button;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.ComboBox courierDate_comboBox;
    }
}