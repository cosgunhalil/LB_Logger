using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LB_LogSaver : MonoBehaviour {

    private string logFilePath;

    private string logHistory;

    private void Start()
    {
        SetDataPath();
        LoadLogHistory();
    }

    private void SetDataPath()
    {
        #if UNITY_EDITOR
            logFilePath = Application.dataPath + "/LB_Logger_LogFile.txt";
        #else
            logFilePath = Application.persistentDataPath + "/LB_Logger_LogFile.txt";
        #endif
    }

    private void LoadLogHistory()
    {
        using (FileStream fs = new FileStream(logFilePath, FileMode.Open))
        {
            using (StreamReader reader = new StreamReader(fs))
            {
                logHistory = reader.ReadToEnd();
            }
        }
    }

    private void OnDestroy()
    {
        using (FileStream fs = new FileStream(logFilePath, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                logHistory += DateTime.Now;
                logHistory += Environment.NewLine + "----------------" + Environment.NewLine;
                logHistory += LB_Logger.Instance.GetLogString();
                logHistory += Environment.NewLine + "----------------" + Environment.NewLine;
                writer.Write(logHistory);
            }

        }
    }
}
