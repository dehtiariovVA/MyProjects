namespace Task_4
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
            this.tbForMessages = new System.Windows.Forms.TextBox();
            this.btnStartGeneration = new System.Windows.Forms.Button();
            this.btnStopGeneration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbForMessages
            // 
            this.tbForMessages.Location = new System.Drawing.Point(12, 12);
            this.tbForMessages.Multiline = true;
            this.tbForMessages.Name = "tbForMessages";
            this.tbForMessages.ReadOnly = true;
            this.tbForMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbForMessages.Size = new System.Drawing.Size(330, 187);
            this.tbForMessages.TabIndex = 0;
            // 
            // btnStartGeneration
            // 
            this.btnStartGeneration.Enabled = false;
            this.btnStartGeneration.Location = new System.Drawing.Point(12, 205);
            this.btnStartGeneration.Name = "btnStartGeneration";
            this.btnStartGeneration.Size = new System.Drawing.Size(153, 25);
            this.btnStartGeneration.TabIndex = 1;
            this.btnStartGeneration.Text = "start generating exceptions";
            this.btnStartGeneration.UseVisualStyleBackColor = true;
            this.btnStartGeneration.Click += new System.EventHandler(this.btnStartGeneration_Click);
            // 
            // btnStopGeneration
            // 
            this.btnStopGeneration.Location = new System.Drawing.Point(193, 205);
            this.btnStopGeneration.Name = "btnStopGeneration";
            this.btnStopGeneration.Size = new System.Drawing.Size(149, 25);
            this.btnStopGeneration.TabIndex = 3;
            this.btnStopGeneration.Text = "stop generating exceptions";
            this.btnStopGeneration.UseVisualStyleBackColor = true;
            this.btnStopGeneration.Click += new System.EventHandler(this.btnStopGeneration_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 262);
            this.Controls.Add(this.btnStopGeneration);
            this.Controls.Add(this.btnStartGeneration);
            this.Controls.Add(this.tbForMessages);
            this.Name = "Form1";
            this.Text = "Catching exceptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbForMessages;
        private System.Windows.Forms.Button btnStartGeneration;
        private System.Windows.Forms.Button btnStopGeneration;
    }
}

