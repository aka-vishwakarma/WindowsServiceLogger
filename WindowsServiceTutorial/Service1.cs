using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace WindowsServiceTutorial
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer;

        public Service1()
        {
            InitializeComponent();
            _timer = new Timer();
        }

        protected override void OnStart(string[] args)
        {
            WriteToLog($"Service started at {DateTime.Now}");
            _timer.Elapsed += OnElapsedTime;
            _timer.Interval = 5000; // 5 seconds
            _timer.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteToLog($"Service stopped at {DateTime.Now}");
            _timer.Enabled = false; // Disable the timer when service stops
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToLog($"Service is recalling at {DateTime.Now}");
        }

        private void WriteToLog(string message)
        {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            // Ensure the log directory exists
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Create log file with today's date
            string fileName = $"ServiceLog_{DateTime.Now:yyyy_MM_dd}.txt";
            string filePath = Path.Combine(logDirectory, fileName);

            // Write log to file
            using (StreamWriter sw = new StreamWriter(filePath, append: true))
            {
                sw.WriteLine(message);
            }
        }
    }
}
