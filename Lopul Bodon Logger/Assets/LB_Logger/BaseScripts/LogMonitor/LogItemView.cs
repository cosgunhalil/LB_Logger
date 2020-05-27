namespace Helpers.Logger
{
    using UnityEngine;
    using TMPro;
    using UnityEngine.UI;

    [RequireComponent(typeof(Image))]
    public class LogItemView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI idContainer;
        [SerializeField]
        private TextMeshProUGUI logContainer;
        private Image backgroundImage;

        public void Setup(ref LogItemData data)
        {
            backgroundImage = GetComponent<Image>();
            idContainer.text = data.Id;
            logContainer.text = data.Log;
        }

        private void SetColor(LogType logType)
        {
            //todo think: where is the correct place for set color routine? 
        }
    }

    public struct LogItemData
    {
        public readonly string Id;
        public readonly string Log;
        public readonly LogType Type;

        public LogItemData(string id, string log, LogType logType)
        {
            Id = id;
            Log = log;
            Type = logType;
        }
    }

}

