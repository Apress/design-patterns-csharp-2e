namespace UsingWebClentWithWinForm
{
    partial class Form1
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
            this.StartDownload = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartDownload
            // 
            this.StartDownload.Location = new System.Drawing.Point(68, 245);
            this.StartDownload.Name = "StartDownload";
            this.StartDownload.Size = new System.Drawing.Size(215, 87);
            this.StartDownload.TabIndex = 0;
            this.StartDownload.Text = "StartDownload";
            this.StartDownload.UseVisualStyleBackColor = true;
            this.StartDownload.Click += new System.EventHandler(this.StartDownload_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(79, 129);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(484, 23);
            this.progressBar.TabIndex = 1;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(356, 245);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(123, 87);
            this.ResetButton.TabIndex = 2;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(521, 245);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(161, 87);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.StartDownload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartDownload;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

