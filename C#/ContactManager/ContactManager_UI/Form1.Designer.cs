namespace ContactManager_UI
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbForFName = new System.Windows.Forms.TextBox();
            this.tbForLName = new System.Windows.Forms.TextBox();
            this.tbForGroup = new System.Windows.Forms.TextBox();
            this.tbForHomeNumber = new System.Windows.Forms.TextBox();
            this.tbForMobileNumber = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_RemoveContact = new System.Windows.Forms.Button();
            this.btn_AddContact = new System.Windows.Forms.Button();
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.cb_GroupOrNot = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tb_forFiltering = new System.Windows.Forms.TextBox();
            this.tb_forPhoto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbForFName
            // 
            this.tbForFName.Location = new System.Drawing.Point(292, 57);
            this.tbForFName.MaxLength = 15;
            this.tbForFName.Name = "tbForFName";
            this.tbForFName.Size = new System.Drawing.Size(141, 20);
            this.tbForFName.TabIndex = 0;
            // 
            // tbForLName
            // 
            this.tbForLName.Location = new System.Drawing.Point(292, 96);
            this.tbForLName.MaxLength = 15;
            this.tbForLName.Name = "tbForLName";
            this.tbForLName.Size = new System.Drawing.Size(141, 20);
            this.tbForLName.TabIndex = 1;
            // 
            // tbForGroup
            // 
            this.tbForGroup.Location = new System.Drawing.Point(292, 135);
            this.tbForGroup.MaxLength = 15;
            this.tbForGroup.Name = "tbForGroup";
            this.tbForGroup.Size = new System.Drawing.Size(141, 20);
            this.tbForGroup.TabIndex = 2;
            // 
            // tbForHomeNumber
            // 
            this.tbForHomeNumber.Location = new System.Drawing.Point(292, 177);
            this.tbForHomeNumber.MaxLength = 7;
            this.tbForHomeNumber.Name = "tbForHomeNumber";
            this.tbForHomeNumber.Size = new System.Drawing.Size(141, 20);
            this.tbForHomeNumber.TabIndex = 3;
            this.tbForHomeNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbForHomeNumber_KeyPress);
            // 
            // tbForMobileNumber
            // 
            this.tbForMobileNumber.Location = new System.Drawing.Point(292, 218);
            this.tbForMobileNumber.MaxLength = 13;
            this.tbForMobileNumber.Name = "tbForMobileNumber";
            this.tbForMobileNumber.Size = new System.Drawing.Size(141, 20);
            this.tbForMobileNumber.TabIndex = 4;
            this.tbForMobileNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbForMobileNumber_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(295, 283);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 119);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btn_RemoveContact
            // 
            this.btn_RemoveContact.Location = new System.Drawing.Point(189, 408);
            this.btn_RemoveContact.Name = "btn_RemoveContact";
            this.btn_RemoveContact.Size = new System.Drawing.Size(83, 23);
            this.btn_RemoveContact.TabIndex = 6;
            this.btn_RemoveContact.Text = "Delete";
            this.btn_RemoveContact.UseVisualStyleBackColor = true;
            this.btn_RemoveContact.Click += new System.EventHandler(this.btn_RemoveContact_Click);
            // 
            // btn_AddContact
            // 
            this.btn_AddContact.Location = new System.Drawing.Point(12, 408);
            this.btn_AddContact.Name = "btn_AddContact";
            this.btn_AddContact.Size = new System.Drawing.Size(75, 23);
            this.btn_AddContact.TabIndex = 7;
            this.btn_AddContact.Text = "Add";
            this.btn_AddContact.UseVisualStyleBackColor = true;
            this.btn_AddContact.Click += new System.EventHandler(this.btn_AddContact_Click);
            // 
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.Location = new System.Drawing.Point(339, 408);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Size = new System.Drawing.Size(97, 23);
            this.btn_SaveChanges.TabIndex = 8;
            this.btn_SaveChanges.Text = "Save canges";
            this.btn_SaveChanges.UseVisualStyleBackColor = true;
            this.btn_SaveChanges.Click += new System.EventHandler(this.btn_SaveChanges_Click);
            // 
            // cb_GroupOrNot
            // 
            this.cb_GroupOrNot.AutoSize = true;
            this.cb_GroupOrNot.Location = new System.Drawing.Point(13, 12);
            this.cb_GroupOrNot.Name = "cb_GroupOrNot";
            this.cb_GroupOrNot.Size = new System.Drawing.Size(123, 17);
            this.cb_GroupOrNot.TabIndex = 11;
            this.cb_GroupOrNot.Text = "grouping by \"Group\"";
            this.cb_GroupOrNot.UseVisualStyleBackColor = true;
            this.cb_GroupOrNot.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Group";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Home number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mobile number";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 38);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(259, 364);
            this.treeView1.TabIndex = 18;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tb_forFiltering
            // 
            this.tb_forFiltering.Location = new System.Drawing.Point(143, 12);
            this.tb_forFiltering.Name = "tb_forFiltering";
            this.tb_forFiltering.Size = new System.Drawing.Size(129, 20);
            this.tb_forFiltering.TabIndex = 19;
            this.tb_forFiltering.TextChanged += new System.EventHandler(this.tb_forFiltering_TextChanged);
            // 
            // tb_forPhoto
            // 
            this.tb_forPhoto.Location = new System.Drawing.Point(292, 257);
            this.tb_forPhoto.Name = "tb_forPhoto";
            this.tb_forPhoto.Size = new System.Drawing.Size(141, 20);
            this.tb_forPhoto.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Path to Photo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 435);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_forPhoto);
            this.Controls.Add(this.tb_forFiltering);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_GroupOrNot);
            this.Controls.Add(this.btn_SaveChanges);
            this.Controls.Add(this.btn_AddContact);
            this.Controls.Add(this.btn_RemoveContact);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbForMobileNumber);
            this.Controls.Add(this.tbForHomeNumber);
            this.Controls.Add(this.tbForGroup);
            this.Controls.Add(this.tbForLName);
            this.Controls.Add(this.tbForFName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbForFName;
        private System.Windows.Forms.TextBox tbForLName;
        private System.Windows.Forms.TextBox tbForGroup;
        private System.Windows.Forms.TextBox tbForHomeNumber;
        private System.Windows.Forms.TextBox tbForMobileNumber;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_RemoveContact;
        private System.Windows.Forms.Button btn_AddContact;
        private System.Windows.Forms.Button btn_SaveChanges;
        private System.Windows.Forms.CheckBox cb_GroupOrNot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox tb_forFiltering;
        private System.Windows.Forms.TextBox tb_forPhoto;
        private System.Windows.Forms.Label label6;
    }
}

