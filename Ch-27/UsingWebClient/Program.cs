using System;
// For AsyncCompletedEventHandler delegate
using System.ComponentModel;
using System.Net; // For WebClient
using System.Threading; // For Thread.Sleep() method

namespace UsingWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Event Based Asynchronous Program Demo.***");
            // Method1();
            #region The lenghty operation(download)
            Console.WriteLine("Starting a download operation.");
            WebClient webClient = new WebClient();
            // File location
            Uri myLocation = new Uri(@"C:\TestData\OriginalFile.txt");
            // Target location for download
            string targetLocation = @"C:\TestData\DownloadedFile.txt";
            webClient.DownloadFileAsync(myLocation, targetLocation);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
            #endregion
            ExecuteMethodTwo();
            Console.WriteLine("End Main()...");
            Console.ReadKey();
        }
        // ExecuteMethodTwo
        private static void ExecuteMethodTwo()
        {
            Console.WriteLine("MethodTwo has started.");
            // Some very small task
            Thread.Sleep(10);
            Console.WriteLine("MethodTwo has finished.");
        }

        private static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Successfully downloaded the file now.");
        }
    }
}
