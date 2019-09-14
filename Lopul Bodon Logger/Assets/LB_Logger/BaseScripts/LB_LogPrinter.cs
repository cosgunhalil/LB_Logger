
namespace Helpers.Logger
{
    using UnityEngine;

    public class LB_LogPrinter : MonoBehaviour
    {

        private void Awake()
        {
            DeleteOtherConsoleLoggers();
            LB_Logger.Instance.OnLogPrint += PrintLogToConsole;
        }

        private void OnDestroy()
        {
            LB_Logger.Instance.OnLogPrint -= PrintLogToConsole;
        }

        private void DeleteOtherConsoleLoggers()
        {
            var consoleLoggers = FindObjectsOfType<LB_LogPrinter>();
            if (consoleLoggers.Length > 1)
            {
                for (int i = 1; i < consoleLoggers.Length; i++)
                {
                    Destroy(consoleLoggers[i]);
                }
            }
        }

        private void PrintLogToConsole(string log, LogType logType)
        {
            Debug.Log(log);
        }

    }

}

