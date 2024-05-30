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
        private readonly object lockObject = new object();

        public void LogData(object data)
        {
            lock (lockObject)
            {
                string jsonString = JsonConvert.SerializeObject(data);
                Debug.WriteLine(jsonString);
                File.AppendAllText("log.log", jsonString + Environment.NewLine);
            }
        }
    }
}
