using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace UsingWebClentWithWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartDownload_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            Uri myLocation = new Uri(@"C:\TestData\OriginalFile.txt");
            string targetLocation = @"C:\TestData\DownloadedFile.txt";
            webClient.DownloadFileAsync(myLocation, targetLocation);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);            
            MessageBox.Show("Executed download operation.");
        }
        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Successfully downloaded the file now.");
        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

    }
}
