
using Helpers.Logger;
using UnityEngine;

public class SampleLoggerObject : MonoBehaviour {

    private void Awake()
    {
        LB_Logger.Instance.PrintLog("Logger Object Awake");
    }

    private void OnEnable()
    {
        LB_Logger.Instance.PrintLog("Logger Object Enable");
    }

    private void Start()
    {
        LB_Logger.Instance.PrintLog("Logger Object Start");
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            LB_Logger.Instance.PrintLog("Pressed key is A");
        }
	}
}
