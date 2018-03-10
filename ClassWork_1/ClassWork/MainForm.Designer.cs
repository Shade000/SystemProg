namespace ClassWork
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Thread_1 = new System.Windows.Forms.Button();
            this.Thread_2 = new System.Windows.Forms.Button();
            this.Thread_3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Thread_1
            // 
            this.Thread_1.Location = new System.Drawing.Point(51, 55);
            this.Thread_1.Name = "Thread_1";
            this.Thread_1.Size = new System.Drawing.Size(75, 23);
            this.Thread_1.TabIndex = 0;
            this.Thread_1.Text = "Thread_1";
            this.Thread_1.UseVisualStyleBackColor = true;
            this.Thread_1.Click += new System.EventHandler(this.Thread_1_Click);
            // 
            // Thread_2
            // 
            this.Thread_2.Location = new System.Drawing.Point(163, 55);
            this.Thread_2.Name = "Thread_2";
            this.Thread_2.Size = new System.Drawing.Size(75, 23);
            this.Thread_2.TabIndex = 1;
            this.Thread_2.Text = "Thread_2";
            this.Thread_2.UseVisualStyleBackColor = true;
            this.Thread_2.Click += new System.EventHandler(this.Thread_2_Click);
            // 
            // Thread_3
            // 
            this.Thread_3.Location = new System.Drawing.Point(270, 55);
            this.Thread_3.Name = "Thread_3";
            this.Thread_3.Size = new System.Drawing.Size(75, 23);
            this.Thread_3.TabIndex = 2;
            this.Thread_3.Text = "Thread_3";
            this.Thread_3.UseVisualStyleBackColor = true;
            this.Thread_3.Click += new System.EventHandler(this.Thread_3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 315);
            this.Controls.Add(this.Thread_3);
            this.Controls.Add(this.Thread_2);
            this.Controls.Add(this.Thread_1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Thread_1;
        private System.Windows.Forms.Button Thread_2;
        private System.Windows.Forms.Button Thread_3;
    }
}

