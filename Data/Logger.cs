using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Data
{
    public class Logger : ILogger
    {
        private readonly List<LoggerData> buffer = new List<LoggerData>();
        private readonly object lockObject = new object();

        public void LogData(LoggerData data)
        {
            lock (lockObject)
            {
                buffer.Add(data);
                TryWriteFile();
            }
        }

        private void TryWriteFile()
        {
            try
            {
                if (buffer.Count > 0)
                {
                    string jsonString = JsonConvert.SerializeObject(buffer);
                    File.AppendAllText("log.log", jsonString + Environment.NewLine);
                    buffer.Clear();
                }
            }
            catch (IOException) 
            {
                Debug.WriteLine(DateTime.Now);
                Debug.WriteLine("Nie udalo sie otworzyc pliku podczas loggowania, dane zostana zapisane w nastepnej probie.");
            }
        }
    }
}
