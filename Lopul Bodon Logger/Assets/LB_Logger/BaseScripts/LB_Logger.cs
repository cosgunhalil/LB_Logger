using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LB_Logger
{
    private static readonly LB_Logger instance = new LB_Logger();

    static LB_Logger()
    {

    }

    private LB_Logger()
    {

    }

    public static LB_Logger Instance
    {
        get
        {
            return instance;
        }
    }

    public delegate void PrintLogDelegate(string log);
    public event PrintLogDelegate PrintLogEvent;

    private string logString = String.Empty;

    public void PrintLog(string log)
    {
        if (logString != string.Empty)
        {
            logString += Environment.NewLine;
        }
        logString += log;

        if (PrintLogEvent != null)
        {
            PrintLogEvent(logString);
        }
    }

    public string GetLogString()
    {
        return logString;
    }

}
