
namespace TrayAppWithMutex.Forms {
    partial class FrmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.CbSendTrayWhenClosed = new System.Windows.Forms.CheckBox();
            this.CbSendTrayWhenMinimized = new System.Windows.Forms.CheckBox();
            this.GbSettings = new System.Windows.Forms.GroupBox();
            this.CbShowNotifications = new System.Windows.Forms.CheckBox();
            this.TxtMain = new System.Windows.Forms.TextBox();
            this.GbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbSendTrayWhenClosed
            // 
            this.CbSendTrayWhenClosed.AutoSize = true;
            this.CbSendTrayWhenClosed.Location = new System.Drawing.Point(6, 44);
            this.CbSendTrayWhenClosed.Name = "CbSendTrayWhenClosed";
            this.CbSendTrayWhenClosed.Size = new System.Drawing.Size(202, 17);
            this.CbSendTrayWhenClosed.TabIndex = 0;
            this.CbSendTrayWhenClosed.Text = "Form kapatıldığında tray\'e gönder";
            this.CbSendTrayWhenClosed.UseVisualStyleBackColor = true;
            // 
            // CbSendTrayWhenMinimized
            // 
            this.CbSendTrayWhenMinimized.AutoSize = true;
            this.CbSendTrayWhenMinimized.Location = new System.Drawing.Point(6, 67);
            this.CbSendTrayWhenMinimized.Name = "CbSendTrayWhenMinimized";
            this.CbSendTrayWhenMinimized.Size = new System.Drawing.Size(307, 17);
            this.CbSendTrayWhenMinimized.TabIndex = 1;
            this.CbSendTrayWhenMinimized.Text = "Form simge durumuna küçültüldüğünde tray\'e gönder";
            this.CbSendTrayWhenMinimized.UseVisualStyleBackColor = true;
            // 
            // GbSettings
            // 
            this.GbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbSettings.Controls.Add(this.CbShowNotifications);
            this.GbSettings.Controls.Add(this.CbSendTrayWhenClosed);
            this.GbSettings.Controls.Add(this.CbSendTrayWhenMinimized);
            this.GbSettings.Location = new System.Drawing.Point(12, 61);
            this.GbSettings.Name = "GbSettings";
            this.GbSettings.Size = new System.Drawing.Size(426, 90);
            this.GbSettings.TabIndex = 2;
            this.GbSettings.TabStop = false;
            this.GbSettings.Text = "Seçenekler";
            // 
            // CbShowNotifications
            // 
            this.CbShowNotifications.AutoSize = true;
            this.CbShowNotifications.Location = new System.Drawing.Point(6, 21);
            this.CbShowNotifications.Name = "CbShowNotifications";
            this.CbShowNotifications.Size = new System.Drawing.Size(116, 17);
            this.CbShowNotifications.TabIndex = 2;
            this.CbShowNotifications.Text = "Bildirimleri göster";
            this.CbShowNotifications.UseVisualStyleBackColor = true;
            // 
            // TxtMain
            // 
            this.TxtMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtMain.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtMain.Location = new System.Drawing.Point(12, 12);
            this.TxtMain.Name = "TxtMain";
            this.TxtMain.ReadOnly = true;
            this.TxtMain.Size = new System.Drawing.Size(426, 43);
            this.TxtMain.TabIndex = 4;
            this.TxtMain.TabStop = false;
            this.TxtMain.Text = "Tray App With Mutex";
            this.TxtMain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(450, 163);
            this.Controls.Add(this.TxtMain);
            this.Controls.Add(this.GbSettings);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tray App With Mutex";
            this.GbSettings.ResumeLayout(false);
            this.GbSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CbSendTrayWhenClosed;
        private System.Windows.Forms.CheckBox CbSendTrayWhenMinimized;
        private System.Windows.Forms.GroupBox GbSettings;
        private System.Windows.Forms.TextBox TxtMain;
        private System.Windows.Forms.CheckBox CbShowNotifications;
    }
}