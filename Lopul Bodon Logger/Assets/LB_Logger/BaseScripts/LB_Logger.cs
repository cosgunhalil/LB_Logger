using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_Logger {

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

    private string logString;

    public void PrintLog(string log)
    {
        logString += Environment.NewLine;
        logString += log;

        if (PrintLogEvent != null)
        {
            PrintLogEvent(logString);
        }
    }
}
