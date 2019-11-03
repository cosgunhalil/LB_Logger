
namespace Helpers.Logger
{
    using System.Collections.Generic;
    using System.Text;
    using UnityEngine;

    [RequireComponent(typeof(LogFactory))]
    public class LB_LoggerMonitor : MonoBehaviour
    {
        private LogFactory logFactory;
        private List<string> logList;

        private const int logsPerPage = 10;
        private int startIndexOfThePage;

        private void Start()
        {
            startIndexOfThePage = 0;

            logList = new List<string>();
            logFactory = GetComponent<LogFactory>();
        }

        void OnEnable()
        {
            LB_Logger.Instance.OnLogPrint += MonitorLog;
        }

        private void OnDisable()
        {
            LB_Logger.Instance.OnLogPrint -= MonitorLog;
        }

        private void MonitorLog(string log, LogType logType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            stringBuilder.Append(logType.ToString());
            stringBuilder.Append("] ");
            stringBuilder.Append(log);

            logList.Add(stringBuilder.ToString());
        }
    }

}

