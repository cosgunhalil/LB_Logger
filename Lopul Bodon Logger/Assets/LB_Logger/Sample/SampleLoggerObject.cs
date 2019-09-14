
using Helpers.Logger;
using UnityEngine;

public class SampleLoggerObject : MonoBehaviour {

    private void Awake()
    {
        LB_Logger.Instance.PrintLog("Logger Object Awake", Helpers.Logger.LogType.Common);
    }

    private void OnEnable()
    {
        LB_Logger.Instance.PrintLog("Logger Object Enable", Helpers.Logger.LogType.Common);
    }

    private void Start()
    {
        LB_Logger.Instance.PrintLog("Logger Object Start", Helpers.Logger.LogType.Common);
    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            LB_Logger.Instance.PrintLog("Pressed key is A", Helpers.Logger.LogType.Common);
        }
	}
}
