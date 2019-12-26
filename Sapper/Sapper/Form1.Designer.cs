namespace Sapper
{
    partial class Form1
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
            this.bombsleft = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bombsleft
            // 
            this.bombsleft.AutoSize = true;
            this.bombsleft.BackColor = System.Drawing.SystemColors.Window;
            this.bombsleft.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bombsleft.Location = new System.Drawing.Point(323, 9);
            this.bombsleft.Name = "bombsleft";
            this.bombsleft.Size = new System.Drawing.Size(62, 20);
            this.bombsleft.TabIndex = 0;
            this.bombsleft.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sapper.Properties.Resources.empty;
            this.ClientSize = new System.Drawing.Size(684, 711);
            this.Controls.Add(this.bombsleft);
            this.Name = "Form1";
            this.Text = "Sapper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bombsleft;
    }
}

