using Objects;
using System;
using UnityEngine;
namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public delegate void OnInteraction();

        public OnInteraction OnInteractionCallback;

        private Camera _cam;
        private PlayerMovement _motor;

        public Interactable focus;

        private void Start()
        {
            _cam = Camera.main;
            _motor = transform.GetComponent<PlayerMovement>();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 ray = _cam.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
                if (hit)
                {
                    Debug.Log(hit.transform.name);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                Vector3 ray = _cam.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
                if (hit)
                {
                    
                    Interactable interactable = hit.collider.GetComponent<Interactable>();

                    if (interactable != null)
                    {
                        float distance = (transform.position - interactable.interactionTransform.position).magnitude;
                        if (distance <= interactable.radius)
                            SetFocus(interactable);
                        else
                            RemoveFocus();
                    }
                    else
                        RemoveFocus();

                }
                else
                    RemoveFocus();

            }

            if (_motor.IsMoving())
            {
                RemoveFocus();
            }
        }

        public void SetFocus(Interactable newFocus)
        {
            if (newFocus != focus)
            {
                if (focus != null)
                {
                    focus.OnDefocused();
                }

                focus = newFocus;
                _motor.SetAndLockRotation(newFocus);
            }
            newFocus.OnFocused(transform);

            Debug.Log("focused: " + newFocus.name);
        }

        public void RemoveFocus()
        {
            if (focus == null)
                return;

            focus.OnDefocused();
            _motor.FreeRotation();
            focus = null;
            
            OnInteractionCallback?.Invoke();
        }

    }
}
