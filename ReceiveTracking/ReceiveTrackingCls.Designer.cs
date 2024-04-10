namespace ReceiveTracking
{
    partial class ReceiveTrackingCls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiveTrackingCls));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbx_cyt = new System.Windows.Forms.CheckBox();
            this.cbx_pap = new System.Windows.Forms.CheckBox();
            this.lblBoxMsg = new System.Windows.Forms.Label();
            this.lblEntMsg = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEntName = new System.Windows.Forms.TextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblBoxMsg);
            this.panel1.Controls.Add(this.lblEntMsg);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtEntName);
            this.panel1.Controls.Add(this.txtBoxName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(53, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 408);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbx_cyt);
            this.panel3.Controls.Add(this.cbx_pap);
            this.panel3.Location = new System.Drawing.Point(191, 170);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 28);
            this.panel3.TabIndex = 21;
            // 
            // cbx_cyt
            // 
            this.cbx_cyt.AutoSize = true;
            this.cbx_cyt.Location = new System.Drawing.Point(32, 10);
            this.cbx_cyt.Name = "cbx_cyt";
            this.cbx_cyt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbx_cyt.Size = new System.Drawing.Size(119, 17);
            this.cbx_cyt.TabIndex = 19;
            this.cbx_cyt.Text = "צנצנות ציטולוגיה";
            this.cbx_cyt.UseVisualStyleBackColor = true;
            this.cbx_cyt.CheckedChanged += new System.EventHandler(this.cbx_cyt_CheckedChanged);
            // 
            // cbx_pap
            // 
            this.cbx_pap.AutoSize = true;
            this.cbx_pap.Location = new System.Drawing.Point(176, 10);
            this.cbx_pap.Name = "cbx_pap";
            this.cbx_pap.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbx_pap.Size = new System.Drawing.Size(87, 17);
            this.cbx_pap.TabIndex = 18;
            this.cbx_pap.Text = "צנצנות פאפ";
            this.cbx_pap.UseVisualStyleBackColor = true;
            this.cbx_pap.CheckedChanged += new System.EventHandler(this.cbx_cyt_CheckedChanged);
            // 
            // lblBoxMsg
            // 
            this.lblBoxMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBoxMsg.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblBoxMsg.ForeColor = System.Drawing.Color.Blue;
            this.lblBoxMsg.Location = new System.Drawing.Point(196, 125);
            this.lblBoxMsg.Name = "lblBoxMsg";
            this.lblBoxMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBoxMsg.Size = new System.Drawing.Size(332, 16);
            this.lblBoxMsg.TabIndex = 12;
            // 
            // lblEntMsg
            // 
            this.lblEntMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEntMsg.AutoSize = true;
            this.lblEntMsg.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblEntMsg.ForeColor = System.Drawing.Color.Blue;
            this.lblEntMsg.Location = new System.Drawing.Point(194, 249);
            this.lblEntMsg.Name = "lblEntMsg";
            this.lblEntMsg.Size = new System.Drawing.Size(0, 17);
            this.lblEntMsg.TabIndex = 11;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnClose.Location = new System.Drawing.Point(276, 279);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 58);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "יציאה";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnClear.Location = new System.Drawing.Point(376, 279);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(82, 58);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "נקה";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(562, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "הכנס יישות";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(563, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "הכנס ארגז";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtEntName
            // 
            this.txtEntName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntName.Enabled = false;
            this.txtEntName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtEntName.Location = new System.Drawing.Point(189, 214);
            this.txtEntName.Name = "txtEntName";
            this.txtEntName.Size = new System.Drawing.Size(333, 29);
            this.txtEntName.TabIndex = 3;
            this.txtEntName.TextChanged += new System.EventHandler(this.txtEntName_TextChanged);
            this.txtEntName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEntity_KeyPress);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtBoxName.Location = new System.Drawing.Point(196, 92);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(333, 29);
            this.txtBoxName.TabIndex = 2;
            this.txtBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.Location = new System.Drawing.Point(337, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "8.4.24";
            // 
            // ReceiveTrackingCls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReceiveTrackingCls";
            this.Size = new System.Drawing.Size(904, 468);
            this.Resize += new System.EventHandler(this.ReceiveTrackingCls_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEntName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblBoxMsg;
        private System.Windows.Forms.Label lblEntMsg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cbx_cyt;
        private System.Windows.Forms.CheckBox cbx_pap;
    }
}
