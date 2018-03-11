namespace HomeWork_4
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
            this.lbMain = new System.Windows.Forms.Label();
            this.lbFrom = new System.Windows.Forms.Label();
            this.lbWhere = new System.Windows.Forms.Label();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.tbWhere = new System.Windows.Forms.TextBox();
            this.btnFrom1 = new System.Windows.Forms.Button();
            this.pbCopy = new System.Windows.Forms.ProgressBar();
            this.btnFrom2 = new System.Windows.Forms.Button();
            this.btnWhere = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.Location = new System.Drawing.Point(74, 24);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(169, 13);
            this.lbMain.TabIndex = 0;
            this.lbMain.Text = "Копирование файлов или папок";
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(27, 60);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(43, 13);
            this.lbFrom.TabIndex = 1;
            this.lbFrom.Text = "Откуда";
            // 
            // lbWhere
            // 
            this.lbWhere.AutoSize = true;
            this.lbWhere.Location = new System.Drawing.Point(27, 100);
            this.lbWhere.Name = "lbWhere";
            this.lbWhere.Size = new System.Drawing.Size(31, 13);
            this.lbWhere.TabIndex = 2;
            this.lbWhere.Text = "Куда";
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(77, 60);
            this.tbFrom.Multiline = true;
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(257, 20);
            this.tbFrom.TabIndex = 3;
            // 
            // tbWhere
            // 
            this.tbWhere.Location = new System.Drawing.Point(77, 97);
            this.tbWhere.Name = "tbWhere";
            this.tbWhere.Size = new System.Drawing.Size(257, 20);
            this.tbWhere.TabIndex = 4;
            this.tbWhere.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWhere_KeyDown);
            // 
            // btnFrom1
            // 
            this.btnFrom1.Location = new System.Drawing.Point(367, 60);
            this.btnFrom1.Name = "btnFrom1";
            this.btnFrom1.Size = new System.Drawing.Size(75, 23);
            this.btnFrom1.TabIndex = 5;
            this.btnFrom1.Text = "Файл";
            this.btnFrom1.UseVisualStyleBackColor = true;
            this.btnFrom1.Click += new System.EventHandler(this.btnFrom1_Click);
            // 
            // pbCopy
            // 
            this.pbCopy.Location = new System.Drawing.Point(77, 141);
            this.pbCopy.Name = "pbCopy";
            this.pbCopy.Size = new System.Drawing.Size(257, 23);
            this.pbCopy.TabIndex = 6;
            // 
            // btnFrom2
            // 
            this.btnFrom2.Location = new System.Drawing.Point(448, 60);
            this.btnFrom2.Name = "btnFrom2";
            this.btnFrom2.Size = new System.Drawing.Size(75, 23);
            this.btnFrom2.TabIndex = 7;
            this.btnFrom2.Text = "Папка";
            this.btnFrom2.UseVisualStyleBackColor = true;
            this.btnFrom2.Click += new System.EventHandler(this.btnFrom2_Click);
            // 
            // btnWhere
            // 
            this.btnWhere.Location = new System.Drawing.Point(367, 95);
            this.btnWhere.Name = "btnWhere";
            this.btnWhere.Size = new System.Drawing.Size(75, 23);
            this.btnWhere.TabIndex = 8;
            this.btnWhere.Text = "Папка";
            this.btnWhere.UseVisualStyleBackColor = true;
            this.btnWhere.Click += new System.EventHandler(this.btnWhere_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(367, 141);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 9;
            this.btnCopy.Text = "Копировать";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(448, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 224);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnWhere);
            this.Controls.Add(this.btnFrom2);
            this.Controls.Add(this.pbCopy);
            this.Controls.Add(this.btnFrom1);
            this.Controls.Add(this.tbWhere);
            this.Controls.Add(this.tbFrom);
            this.Controls.Add(this.lbWhere);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.lbMain);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label lbWhere;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.TextBox tbWhere;
        private System.Windows.Forms.Button btnFrom1;
        private System.Windows.Forms.ProgressBar pbCopy;
        private System.Windows.Forms.Button btnFrom2;
        private System.Windows.Forms.Button btnWhere;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCancel;
    }
}

