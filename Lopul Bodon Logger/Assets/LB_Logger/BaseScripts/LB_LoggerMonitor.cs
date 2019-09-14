
namespace Helpers.Logger
{
    using UnityEngine;

    public class LB_LoggerMonitor : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI LogTextContainer;

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
            LogTextContainer.text = log;
        }
    }

}

