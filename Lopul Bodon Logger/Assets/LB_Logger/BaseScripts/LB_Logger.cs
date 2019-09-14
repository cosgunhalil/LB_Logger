
namespace Helpers.Logger
{
    using System;
    using System.Collections.Generic;

    public class LB_Logger
    {
        private static readonly LB_Logger instance = new LB_Logger();

        static LB_Logger()
        {

        }

        private LB_Logger()
        {

        }

        public static LB_Logger Instance
        {
            get
            {
                return instance;
            }
        }

        public delegate void PrintLogDelegate(string log);
        public event PrintLogDelegate OnLogPrint;

        private string logString = String.Empty;
        private Queue<string> logQueue = new Queue<string>();

        public void PrintLog(string log)
        {
            logQueue.Enqueue(log);

            if (OnLogPrint != null)
            {
                OnLogPrint(log);
            }
        }

        public string GetLogString()
        {
            return logString;
        }

    }

}