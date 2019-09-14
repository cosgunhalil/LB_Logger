
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

        public delegate void PrintLogDelegate(string log, LogType logType);
        public event PrintLogDelegate OnLogPrint;

        public void PrintLog(string log, LogType logType)
        {
            OnLogPrint?.Invoke(log, logType);
        }

    }

    public enum LogType
    {
        UserInterface,
        Gameplay,
        Server,
        Warning,
        Common
    }

}