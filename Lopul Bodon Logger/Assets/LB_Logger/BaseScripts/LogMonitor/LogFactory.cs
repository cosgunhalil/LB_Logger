
namespace Helpers.Logger
{
    using UnityEngine;

    public class LogFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject logPrefab;

        public LogItemView createLogItem(ref LogItemData data)
        {
            var logItem = Instantiate(logPrefab).GetComponent<LogItemView>();
            logItem.Setup(ref data);

            return logItem;
        }
    }
}


