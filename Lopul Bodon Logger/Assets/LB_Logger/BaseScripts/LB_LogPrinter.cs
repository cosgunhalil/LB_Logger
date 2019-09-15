
namespace Helpers.Logger
{
    using System;
    using System.Text;
    using UnityEngine;

    public class LB_LogPrinter : MonoBehaviour
    {
        private StringBuilder stringBuilder = new StringBuilder();

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
            stringBuilder.Clear();
            stringBuilder.Append(GetHeader(logType));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(log);

            Debug.Log(stringBuilder);
        }

        private string GetHeader(LogType logType)
        {
            switch (logType)
            {
                case LogType.UserInterface:
                    return "<color=" + LB_Colors.Green + "> [USER INTERFACE] </color>";
                case LogType.Gameplay:
                    return "<color=" + LB_Colors.Orange + "> [GAMEPLAY] </color>";
                case LogType.Server:
                    return "<color=" + LB_Colors.DeapSkyBlue + "> [SERVER] </color>";
                case LogType.Warning:
                    return "<color=" + LB_Colors.Yellow + "> [WARNING] </color>";
                case LogType.Common:
                    return "<color=" + LB_Colors.Purple + "> [COMMON] </color>";
                case LogType.Error:
                    return "<color=" + LB_Colors.Red + "> [ERROR] </color>";
                default:
                    return "<color=blue> [DEFAULT] </color>";
            }
        }
    }

}

