
namespace Helpers.Logger
{
    using System;
    using System.IO;
    using System.Text;
    using UnityEngine;

    public class LB_LogSaver : MonoBehaviour
    {
        private StringBuilder logHistory;

        private void Start()
        {
            LoadLogHistory();
            LB_Logger.Instance.OnLogPrint += AddLog;
        }

        private void LoadLogHistory()
        {
            logHistory = new StringBuilder();

            using (FileStream fs = new FileStream(GetLogFilePath(), FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    logHistory.Append(reader.ReadToEnd());
                }
            }
        }

        private string GetLogFilePath()
        {
#if UNITY_EDITOR
            return Application.dataPath + "/LB_Logger_LogFile.txt";
#else
            return Application.persistentDataPath + "/LB_Logger_LogFile.txt";
#endif
        }

        private void AddLog(string log, LogType logType)
        {
            logHistory.Append(Environment.NewLine);

            logHistory.Append(System.DateTime.UtcNow.ToString() + " - ");
            logHistory.Append(logType.ToString() + " - ");
            logHistory.Append(log);
        }

        private void OnDestroy()
        {
            LB_Logger.Instance.OnLogPrint -= AddLog;

            SaveLogHistory();
        }

        private void SaveLogHistory()
        {
            using (FileStream fs = new FileStream(GetLogFilePath(), FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    logHistory.Append(Environment.NewLine + "----------------" + Environment.NewLine);
                    logHistory.Append(DateTime.UtcNow);
                    logHistory.Append(logHistory);
                    logHistory.Append(Environment.NewLine + "----------------" + Environment.NewLine);
                    writer.Write(logHistory);
                }

            }
        }
    }

}