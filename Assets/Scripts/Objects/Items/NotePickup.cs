using Player;
using TMPro;
using UnityEngine;
namespace Objects.Items
{
    public class NotePickup : Interactable
    {
        [TextArea(3,10)]
        public string text = "";
        public Transform NoteUI;
        public void Read()
        {
            NoteUI.gameObject.SetActive(true);
            var textUi = NoteUI.GetComponentInChildren<TextMeshProUGUI>();
            textUi.text = text;
        }

        protected override void Start()
        {
            base.Start();
            
            ContextMenu.Add(("Read", Read));
        }

    }
}
