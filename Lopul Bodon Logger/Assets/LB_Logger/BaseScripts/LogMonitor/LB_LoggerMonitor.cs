
namespace Helpers.Logger
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using UnityEngine;

    [RequireComponent(typeof(LogFactory))]
    public class LB_LoggerMonitor : MonoBehaviour
    {
        private LogFactory logFactory;
        private Queue<string> logList;

        private const int logsPerPage = 10;
        private int startIndexOfThePage;

        private void Start()
        {
            startIndexOfThePage = 0;

            logList = new Queue<string>();
            logFactory = GetComponent<LogFactory>();

            LB_Logger.Instance.OnLogPrint += MonitorLog;
        }

        private void OnDestroy()
        {
            LB_Logger.Instance.OnLogPrint -= MonitorLog;
        }

        private void MonitorLog(string log, LogType logType)
        {
            pushLog(log, logType);
        }

        private void pushLog(string log, LogType logType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            stringBuilder.Append(logType.ToString());
            stringBuilder.Append("] ");
            stringBuilder.Append(log);

            logList.Enqueue(stringBuilder.ToString());
        }
    }

}

