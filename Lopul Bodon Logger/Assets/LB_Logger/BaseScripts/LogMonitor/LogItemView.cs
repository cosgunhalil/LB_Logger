namespace Helpers.Logger
{
    using UnityEngine;
    using TMPro;
    using UnityEngine.UI;

    public class LogItemView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI idContainer;
        [SerializeField]
        private TextMeshProUGUI logContainer;
        [SerializeField]
        private Image backgroundImage;

        public void Setup(ref LogItemData data)
        {
            idContainer.text = data.Id;
            logContainer.text = data.log;
        }

        private void SetColor(LogType logType)
        {
            //todo think: where is the correct place for set color routine? 
        }
    }

    public struct LogItemData
    {
        public readonly string Id;
        public readonly string log;
        public readonly LogType logType;
    }

}

