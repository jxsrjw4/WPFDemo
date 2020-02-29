﻿using Prism.Logging;
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace WPFDemo.Infrastructure
{
    public class Logger : ILoggerFacade, IDisposable
    {
        private readonly TextWriter _writer;
        private readonly FileStream _fileStream;
        private readonly string _savePath;

        private int _exceptionCount;


        public Logger()
        {
            _savePath = GenerateLoggingPath();
            _fileStream = new FileStream(_savePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            _writer = new StreamWriter(_fileStream, Encoding.UTF8) { AutoFlush = true };

            WriteBasicInfo();
        }


        public void Log(string message, Category category, Priority priority)
        {
            string messageToLog = string.Format(CultureInfo.InvariantCulture, "{1}: {2}. Priority: {3}. Timestamp:{0:u}.",
                DateTime.Now, category.ToString().ToUpper(CultureInfo.InvariantCulture), message, priority.ToString());

            _writer.WriteLine(messageToLog);

            if (category == Category.Exception || category == Category.Warn) _exceptionCount++;
        }

        private void WriteBasicInfo()
        {
            //_writer.WriteLine($"{SystemInfo.Caption}: [{SystemInfo.Version}] {SystemInfo.OSArchitecture}");
        }

        private static string GenerateLoggingPath()
        {
            return Path.Combine(AcceleriderFolders.Logs, $"Accelerider.Windows.{DateTime.Now:yyyyMMddHHmmssff}.log");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _writer?.Dispose();
                _fileStream?.Dispose();

                if (_exceptionCount == 0) File.Delete(_savePath);
            }
        }
    }
}
