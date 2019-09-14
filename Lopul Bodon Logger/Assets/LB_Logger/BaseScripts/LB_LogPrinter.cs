
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
            switch (logType)
            {
                case LogType.UserInterface:
                    Debug.Log("<color=#fe2d00>"+ log +"</color>");//todo move color codes to another container
                    break;
                case LogType.Gameplay:
                    Debug.Log("<color=#fe2d00>" + log + "</color>");
                    break;
                case LogType.Server:
                    Debug.Log("<color=#fe2d00>" + log + "</color>");
                    break;
                case LogType.Warning:
                    Debug.Log("<color=#fe2d00>" + log + "</color>");
                    break;
                case LogType.Common:
                    Debug.Log("<color=#fe2d00>" + log + "</color>");
                    break;
                default:
                    break;
            }
        }

    }

}

