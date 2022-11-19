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
            this.Controls.SetChildIndex(this.addressComboBox, 0);
            this.Controls.SetChildIndex(this.loadAddressLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label address1Lbl;
        private System.Windows.Forms.Label cityLbl;
        private System.Windows.Forms.Label stateLbl;
        private System.Windows.Forms.Label zipLbl;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.TextBox address1Txt;
        private System.Windows.Forms.TextBox address2Txt;
        private System.Windows.Forms.TextBox cityTxt;
        private System.Windows.Forms.ComboBox stateCbo;
        private System.Windows.Forms.TextBox zipTxt;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox addressComboBox;
        private System.Windows.Forms.Label loadAddressLabel;
    }
}