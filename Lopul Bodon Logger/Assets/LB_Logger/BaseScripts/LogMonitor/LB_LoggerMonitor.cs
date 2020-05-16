
namespace Helpers.Logger
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using UnityEngine;

    //todo MVC

    [RequireComponent(typeof(LogFactory))]
    public class LB_LoggerMonitor : MonoBehaviour
    {
        [SerializeField]
        private Transform contentContainer;
        private LogFactory logFactory;
        private List<string> logList;

        private const int logsPerPage = 10;
        private int startIndexOfThePage;

        private int index;

        private void Start()
        {
            startIndexOfThePage = 0;

            logList = new List<string>();
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

        //todo refactor
        private void pushLog(string log, LogType logType)
        {
            //todo seperate id generation from log monitor
            index++;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            stringBuilder.Append(logType.ToString());
            stringBuilder.Append("] ");
            stringBuilder.Append(log);

            logList.Add(stringBuilder.ToString());

            var logItem = logFactory.createLogItem(new LogItemData(index.ToString(), log,logType));
            logItem.transform.SetParent(contentContainer);
            logItem.transform.localScale = Vector3.one;
        }
    }

}

