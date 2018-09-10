using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_LoggerMonitor : MonoBehaviour {

    public TMPro.TextMeshProUGUI LogTextContainer;

	void OnEnable ()
    {
        LB_Logger.Instance.PrintLogEvent += MonitorLog;
	}

    private void OnDisable()
    {
        LB_Logger.Instance.PrintLogEvent -= MonitorLog;
    }

    private void MonitorLog(string log)
    {
        LogTextContainer.text = log;
    }
}
