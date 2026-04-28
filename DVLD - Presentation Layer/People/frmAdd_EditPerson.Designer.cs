namespace DVLD___Presentation_Layer
{
    partial class frmAdd_EditPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdd_EditPerson));
            this.lbFormHeader = new System.Windows.Forms.Label();
            this.ctrlAdd_EditPersonInfo1 = new DVLD___Presentation_Layer.ctrlAdd_EditPersonInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPersonId = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbFormHeader
            // 
            this.lbFormHeader.AutoSize = true;
            this.lbFormHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFormHeader.ForeColor = System.Drawing.Color.Firebrick;
            this.lbFormHeader.Location = new System.Drawing.Point(272, 19);
            this.lbFormHeader.Name = "lbFormHeader";
            this.lbFormHeader.Size = new System.Drawing.Size(255, 36);
            this.lbFormHeader.TabIndex = 1;
            this.lbFormHeader.Text = "Add New Person";
            // 
            // ctrlAdd_EditPersonInfo1
            // 
            this.ctrlAdd_EditPersonInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlAdd_EditPersonInfo1.Location = new System.Drawing.Point(12, 90);
            this.ctrlAdd_EditPersonInfo1.Name = "ctrlAdd_EditPersonInfo1";
            this.ctrlAdd_EditPersonInfo1.Size = new System.Drawing.Size(820, 353);
            this.ctrlAdd_EditPersonInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Person ID:";
            // 
            // lbPersonId
            // 
            this.lbPersonId.AutoSize = true;
            this.lbPersonId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonId.Location = new System.Drawing.Point(131, 68);
            this.lbPersonId.Name = "lbPersonId";
            this.lbPersonId.Size = new System.Drawing.Size(32, 16);
            this.lbPersonId.TabIndex = 3;
            this.lbPersonId.Text = "1-23";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(393, 385);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 38);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAdd_EditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(848, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbPersonId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFormHeader);
            this.Controls.Add(this.ctrlAdd_EditPersonInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdd_EditPerson";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Person";
            this.Load += new System.EventHandler(this.frmAdd_EditPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlAdd_EditPersonInfo ctrlAdd_EditPersonInfo1;
        private System.Windows.Forms.Label lbFormHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPersonId;
        private System.Windows.Forms.Button btnClose;
    }
}