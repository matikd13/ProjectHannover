using System;
using System.Collections.Generic;
using UnityEngine;
namespace Objects
{
    public class Interactable : MonoBehaviour
    {
        public float radius = 7f;
        public Transform interactionTransform;

        private bool _isFocus;
        private bool _hasInteracted;

        public List<(string, Action)> ContextMenu;

        protected virtual void Interact()
        {
            GameInstance.Instance.playerController.OnInteractionCallback?.Invoke();
        }

        protected virtual void Start()
        {
            if (interactionTransform == null) interactionTransform = transform;

            ContextMenu = new List<(string, Action)>
            {
                ("exit", GameInstance.Instance.playerController.RemoveFocus)
            };
        }

        private void Update()
        {
            if (!_isFocus || _hasInteracted)
                return;

            Interact();
            _hasInteracted = true;
        }

        public void OnFocused(Transform player)
        {
            _isFocus = true;
        }

        public void OnDefocused()
        {
            _isFocus = false;
            _hasInteracted = false;
        }

        private void OnDrawGizmosSelected()
        {
            if (interactionTransform == null)
                interactionTransform = transform;

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(interactionTransform.position, radius);
        }
    }
}
