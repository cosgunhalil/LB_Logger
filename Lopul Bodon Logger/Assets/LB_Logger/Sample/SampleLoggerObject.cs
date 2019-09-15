
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
            LB_Logger.Instance.PrintLog("Common log test", Helpers.Logger.LogType.Common);
            LB_Logger.Instance.PrintLog("Error log test", Helpers.Logger.LogType.Error);
            LB_Logger.Instance.PrintLog("GamePlay log test", Helpers.Logger.LogType.Gameplay);
            LB_Logger.Instance.PrintLog("Server log test", Helpers.Logger.LogType.Server);
            LB_Logger.Instance.PrintLog("UI log test", Helpers.Logger.LogType.UserInterface);
            LB_Logger.Instance.PrintLog("Warning log test", Helpers.Logger.LogType.Warning);
        }
	}
}
