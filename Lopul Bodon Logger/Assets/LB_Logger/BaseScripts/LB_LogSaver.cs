
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
            using (FileStream fs = new FileStream(GetLogFilePath(), FileMode.Open))
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

        private void AddLog(string log)
        {
            //todo add log to logHistory - use queue!
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
                    logHistory.Append(DateTime.Now);
                    logHistory.Append(Environment.NewLine + "----------------" + Environment.NewLine);
                    logHistory.Append(LB_Logger.Instance.GetLogString());
                    logHistory.Append(Environment.NewLine + "----------------" + Environment.NewLine);
                    writer.Write(logHistory);
                }

            }
        }
    }

}