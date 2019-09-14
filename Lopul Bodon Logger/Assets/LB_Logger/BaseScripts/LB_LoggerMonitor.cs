
namespace Helpers.Logger
{
    using UnityEngine;

    public class LB_LoggerMonitor : MonoBehaviour
    {

        public TMPro.TextMeshProUGUI LogTextContainer;

        private static LB_LoggerMonitor instance;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            DontDestroyOnLoad(this.gameObject);

            instance = this;
        }

        void OnEnable()
        {
            LB_Logger.Instance.OnLogPrint += MonitorLog;
        }

        private void OnDisable()
        {
            LB_Logger.Instance.OnLogPrint -= MonitorLog;
        }

        private void MonitorLog(string log)
        {
            LogTextContainer.text = log;
        }
    }

}

