using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Objects
{
    public class ContextUI : MonoBehaviour
    {
        public GameObject buttonPrefab;
        public Transform contextPanel;
        private Transform _actionPanel;
        private void Start()
        {
            GameInstance.Instance.playerController.OnInteractionCallback += UpdateUI;

            _actionPanel = contextPanel.GetChild(0);
        }

        private void Clear()
        {
            foreach (Transform child in _actionPanel.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void UpdateUI()
        {
            Debug.Log("Updating");
            Clear();
            Interactable focused = GameInstance.Instance.playerController.focus;

            if (!focused)
            {
                contextPanel.gameObject.SetActive(false);
                return;
            }

            foreach ((string, Action) action in focused.ContextMenu)
            {
                GameObject btn = Instantiate(buttonPrefab);
                btn.transform.SetParent(_actionPanel, false);

                var button = btn.GetComponent<Button>();
                button.onClick.AddListener(() => action.Item2());

                var btnText = btn.GetComponentInChildren<TextMeshProUGUI>();
                btnText.text = action.Item1;
            }
            contextPanel.gameObject.SetActive(true);

        }
    }
}
