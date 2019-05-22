using System.Windows.Forms;

namespace KerfuffleUI
{
    partial class KerfuffleUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Button encryptBtn;
        private TextBox encryptBox;
        private TextBox decryptBox;
        private Button decryptBtn;
        private TextBox outputBox;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KerfuffleUI));
            this.encryptBox = new System.Windows.Forms.TextBox();
            this.decryptBox = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // encryptBox
            // 
            this.encryptBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.encryptBox.Location = new System.Drawing.Point(24, 23);
            this.encryptBox.Margin = new System.Windows.Forms.Padding(6);
            this.encryptBox.Multiline = true;
            this.encryptBox.Name = "encryptBox";
            this.encryptBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.encryptBox.Size = new System.Drawing.Size(516, 123);
            this.encryptBox.TabIndex = 0;
            this.encryptBox.Text = "Message to encrypt";
            this.encryptBox.Enter += new System.EventHandler(this.encryptBox_Enter);
            this.encryptBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.encryptBox.Leave += new System.EventHandler(this.encryptBox_Leave);
            // 
            // decryptBox
            // 
            this.decryptBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.decryptBox.Location = new System.Drawing.Point(24, 217);
            this.decryptBox.Margin = new System.Windows.Forms.Padding(6);
            this.decryptBox.Multiline = true;
            this.decryptBox.Name = "decryptBox";
            this.decryptBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.decryptBox.Size = new System.Drawing.Size(516, 123);
            this.decryptBox.TabIndex = 2;
            this.decryptBox.Text = "Message to decrypt";
            this.decryptBox.Enter += new System.EventHandler(this.decryptBox_Enter);
            this.decryptBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.decryptBox.Leave += new System.EventHandler(this.decryptBox_Leave);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(26, 413);
            this.outputBox.Margin = new System.Windows.Forms.Padding(6);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(514, 219);
            this.outputBox.TabIndex = 5;
            this.outputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // decryptBtn
            // 
            this.decryptBtn.Image = global::KerfuffleUI.Properties.Resources.Decrypt;
            this.decryptBtn.Location = new System.Drawing.Point(204, 356);
            this.decryptBtn.Margin = new System.Windows.Forms.Padding(6);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(150, 44);
            this.decryptBtn.TabIndex = 3;
            this.decryptBtn.Text = "Decrypt";
            this.decryptBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // encryptBtn
            // 
            this.encryptBtn.Image = global::KerfuffleUI.Properties.Resources.Encrypt;
            this.encryptBtn.Location = new System.Drawing.Point(204, 161);
            this.encryptBtn.Margin = new System.Windows.Forms.Padding(6);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(150, 44);
            this.encryptBtn.TabIndex = 1;
            this.encryptBtn.Text = "Encrypt";
            this.encryptBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // KerfuffleUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 660);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.decryptBtn);
            this.Controls.Add(this.decryptBox);
            this.Controls.Add(this.encryptBox);
            this.Controls.Add(this.encryptBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "KerfuffleUI";
            this.Text = "KerfuffleUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

