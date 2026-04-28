namespace DVLD___Presentation_Layer
{
    partial class frmManagePeople
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagePeople));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvColPersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColNationalNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColSecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColThirdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColDOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.msiShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.msiAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.msiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.msiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.msiSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.msiPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTotalNumberOfRecords = new System.Windows.Forms.Label();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSearchBox = new System.Windows.Forms.TextBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.plGender = new System.Windows.Forms.Panel();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.plGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(572, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 234);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(584, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage People";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColPersonID,
            this.dgvColNationalNum,
            this.dgvColFirstName,
            this.dgvColSecondName,
            this.dgvColThirdName,
            this.dgvColLastName,
            this.dgvColGender,
            this.dgvColDOB,
            this.dgvColNationality,
            this.dgvColPhone,
            this.dgvColEmail});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 368);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1440, 275);
            this.dataGridView1.TabIndex = 2;
            // 
            // dgvColPersonID
            // 
            this.dgvColPersonID.HeaderText = "Person ID";
            this.dgvColPersonID.MinimumWidth = 6;
            this.dgvColPersonID.Name = "dgvColPersonID";
            this.dgvColPersonID.ReadOnly = true;
            // 
            // dgvColNationalNum
            // 
            this.dgvColNationalNum.HeaderText = "National NO";
            this.dgvColNationalNum.MinimumWidth = 6;
            this.dgvColNationalNum.Name = "dgvColNationalNum";
            this.dgvColNationalNum.ReadOnly = true;
            // 
            // dgvColFirstName
            // 
            this.dgvColFirstName.HeaderText = "First Name";
            this.dgvColFirstName.MinimumWidth = 6;
            this.dgvColFirstName.Name = "dgvColFirstName";
            this.dgvColFirstName.ReadOnly = true;
            // 
            // dgvColSecondName
            // 
            this.dgvColSecondName.HeaderText = "Second Name";
            this.dgvColSecondName.MinimumWidth = 6;
            this.dgvColSecondName.Name = "dgvColSecondName";
            this.dgvColSecondName.ReadOnly = true;
            // 
            // dgvColThirdName
            // 
            this.dgvColThirdName.HeaderText = "Third Name";
            this.dgvColThirdName.MinimumWidth = 6;
            this.dgvColThirdName.Name = "dgvColThirdName";
            this.dgvColThirdName.ReadOnly = true;
            // 
            // dgvColLastName
            // 
            this.dgvColLastName.HeaderText = "Last Name";
            this.dgvColLastName.MinimumWidth = 6;
            this.dgvColLastName.Name = "dgvColLastName";
            this.dgvColLastName.ReadOnly = true;
            // 
            // dgvColGender
            // 
            this.dgvColGender.HeaderText = "Gender";
            this.dgvColGender.MinimumWidth = 6;
            this.dgvColGender.Name = "dgvColGender";
            this.dgvColGender.ReadOnly = true;
            // 
            // dgvColDOB
            // 
            this.dgvColDOB.HeaderText = "Date of Birth";
            this.dgvColDOB.MinimumWidth = 6;
            this.dgvColDOB.Name = "dgvColDOB";
            this.dgvColDOB.ReadOnly = true;
            // 
            // dgvColNationality
            // 
            this.dgvColNationality.HeaderText = "Nationality";
            this.dgvColNationality.MinimumWidth = 6;
            this.dgvColNationality.Name = "dgvColNationality";
            this.dgvColNationality.ReadOnly = true;
            // 
            // dgvColPhone
            // 
            this.dgvColPhone.HeaderText = "Phone";
            this.dgvColPhone.MinimumWidth = 6;
            this.dgvColPhone.Name = "dgvColPhone";
            this.dgvColPhone.ReadOnly = true;
            // 
            // dgvColEmail
            // 
            this.dgvColEmail.HeaderText = "Email";
            this.dgvColEmail.MinimumWidth = 6;
            this.dgvColEmail.Name = "dgvColEmail";
            this.dgvColEmail.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiShowDetails,
            this.toolStripSeparator1,
            this.msiAddNewPerson,
            this.msiEdit,
            this.msiDelete,
            this.toolStripSeparator2,
            this.msiSendEmail,
            this.msiPhoneCall});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 272);
            // 
            // msiShowDetails
            // 
            this.msiShowDetails.Image = ((System.Drawing.Image)(resources.GetObject("msiShowDetails.Image")));
            this.msiShowDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msiShowDetails.Name = "msiShowDetails";
            this.msiShowDetails.Size = new System.Drawing.Size(226, 38);
            this.msiShowDetails.Text = "Show Details";
            this.msiShowDetails.Click += new System.EventHandler(this.msiShowDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // msiAddNewPerson
            // 
            this.msiAddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("msiAddNewPerson.Image")));
            this.msiAddNewPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msiAddNewPerson.Name = "msiAddNewPerson";
            this.msiAddNewPerson.Size = new System.Drawing.Size(226, 38);
            this.msiAddNewPerson.Text = "Add New Person";
            this.msiAddNewPerson.Click += new System.EventHandler(this.msiAddNewPerson_Click);
            // 
            // msiEdit
            // 
            this.msiEdit.Image = ((System.Drawing.Image)(resources.GetObject("msiEdit.Image")));
            this.msiEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msiEdit.Name = "msiEdit";
            this.msiEdit.Size = new System.Drawing.Size(226, 38);
            this.msiEdit.Text = "Edit";
            this.msiEdit.Click += new System.EventHandler(this.msiEdit_Click);
            // 
            // msiDelete
            // 
            this.msiDelete.Image = ((System.Drawing.Image)(resources.GetObject("msiDelete.Image")));
            this.msiDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msiDelete.Name = "msiDelete";
            this.msiDelete.Size = new System.Drawing.Size(226, 38);
            this.msiDelete.Text = "Delete";
            this.msiDelete.Click += new System.EventHandler(this.msiDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // msiSendEmail
            // 
            this.msiSendEmail.Image = ((System.Drawing.Image)(resources.GetObject("msiSendEmail.Image")));
            this.msiSendEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msiSendEmail.Name = "msiSendEmail";
            this.msiSendEmail.Size = new System.Drawing.Size(226, 38);
            this.msiSendEmail.Text = "Send Email";
            this.msiSendEmail.Click += new System.EventHandler(this.msiSendEmail_Click);
            // 
            // msiPhoneCall
            // 
            this.msiPhoneCall.Image = ((System.Drawing.Image)(resources.GetObject("msiPhoneCall.Image")));
            this.msiPhoneCall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msiPhoneCall.Name = "msiPhoneCall";
            this.msiPhoneCall.Size = new System.Drawing.Size(226, 38);
            this.msiPhoneCall.Text = "Phone Call";
            this.msiPhoneCall.Click += new System.EventHandler(this.msiPhoneCall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 666);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "# Records:";
            // 
            // lbTotalNumberOfRecords
            // 
            this.lbTotalNumberOfRecords.AutoSize = true;
            this.lbTotalNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalNumberOfRecords.Location = new System.Drawing.Point(117, 666);
            this.lbTotalNumberOfRecords.Name = "lbTotalNumberOfRecords";
            this.lbTotalNumberOfRecords.Size = new System.Drawing.Size(18, 20);
            this.lbTotalNumberOfRecords.TabIndex = 3;
            this.lbTotalNumberOfRecords.Text = "0";
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National Number",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gender",
            "Phone",
            "Email"});
            this.cbFilters.Location = new System.Drawing.Point(105, 327);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(135, 24);
            this.cbFilters.TabIndex = 4;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Filter By:";
            // 
            // tbSearchBox
            // 
            this.tbSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearchBox.Location = new System.Drawing.Point(293, 329);
            this.tbSearchBox.Name = "tbSearchBox";
            this.tbSearchBox.Size = new System.Drawing.Size(135, 22);
            this.tbSearchBox.TabIndex = 6;
            this.tbSearchBox.Visible = false;
            this.tbSearchBox.TextChanged += new System.EventHandler(this.tbSearchBox_TextChanged);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.Image")));
            this.btnAddPerson.Location = new System.Drawing.Point(1372, 300);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(69, 47);
            this.btnAddPerson.TabIndex = 7;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // plGender
            // 
            this.plGender.Controls.Add(this.rbFemale);
            this.plGender.Controls.Add(this.rbMale);
            this.plGender.Location = new System.Drawing.Point(293, 327);
            this.plGender.Name = "plGender";
            this.plGender.Size = new System.Drawing.Size(150, 26);
            this.plGender.TabIndex = 8;
            this.plGender.Visible = false;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(72, 4);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(74, 20);
            this.rbFemale.TabIndex = 1;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(2, 4);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(58, 20);
            this.rbMale.TabIndex = 0;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1336, 657);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 50);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1477, 714);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.plGender);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.tbSearchBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilters);
            this.Controls.Add(this.lbTotalNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1355, 701);
            this.Name = "frmManagePeople";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.plGender.ResumeLayout(false);
            this.plGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTotalNumberOfRecords;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSearchBox;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColPersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColNationalNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColSecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColThirdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColEmail;
        private System.Windows.Forms.Panel plGender;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem msiShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem msiAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem msiEdit;
        private System.Windows.Forms.ToolStripMenuItem msiDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem msiSendEmail;
        private System.Windows.Forms.ToolStripMenuItem msiPhoneCall;
        private System.Windows.Forms.Button btnClose;
    }
}