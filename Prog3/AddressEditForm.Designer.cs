namespace UPVApp
{
    partial class AddressEditForm
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
            this.addressComboBox = new System.Windows.Forms.ComboBox();
            this.loadAddressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // addressComboBox
            // 
            this.addressComboBox.FormattingEnabled = true;
            this.addressComboBox.Location = new System.Drawing.Point(90, 190);
            this.addressComboBox.Name = "addressComboBox";
            this.addressComboBox.Size = new System.Drawing.Size(109, 21);
            this.addressComboBox.TabIndex = 13;
            this.addressComboBox.SelectedIndexChanged += new System.EventHandler(this.addressComboBox_SelectedIndexChanged);
            // 
            // loadAddressLabel
            // 
            this.loadAddressLabel.AutoSize = true;
            this.loadAddressLabel.Location = new System.Drawing.Point(12, 193);
            this.loadAddressLabel.Name = "loadAddressLabel";
            this.loadAddressLabel.Size = new System.Drawing.Size(72, 13);
            this.loadAddressLabel.TabIndex = 14;
            this.loadAddressLabel.Text = "Load Address";
            // 
            // AddressEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(211, 224);
            this.Controls.Add(this.loadAddressLabel);
            this.Controls.Add(this.addressComboBox);
            this.Name = "AddressEditForm";
            this.Text = "Edit Address";
            this.Controls.SetChildIndex(this.nameLbl, 0);
            this.Controls.SetChildIndex(this.address1Lbl, 0);
            this.Controls.SetChildIndex(this.cityLbl, 0);
            this.Controls.SetChildIndex(this.stateLbl, 0);
            this.Controls.SetChildIndex(this.zipLbl, 0);
            this.Controls.SetChildIndex(this.nameTxt, 0);
            this.Controls.SetChildIndex(this.address1Txt, 0);
            this.Controls.SetChildIndex(this.address2Txt, 0);
            this.Controls.SetChildIndex(this.cityTxt, 0);
            this.Controls.SetChildIndex(this.stateCbo, 0);
            this.Controls.SetChildIndex(this.zipTxt, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.cancelBtn, 0);
            this.Controls.SetChildIndex(this.addressComboBox, 0);
            this.Controls.SetChildIndex(this.loadAddressLabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox addressComboBox;
        private System.Windows.Forms.Label loadAddressLabel;
    }
}