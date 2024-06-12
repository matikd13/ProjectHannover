using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;

        private Rigidbody2D _rb;
        private Camera _cam;

        private Vector2 _movement;
        private float _angle;
        private Vector2 _lockedVector2 = Vector2.zero;

        private void Start()
        {
            _cam = Camera.main;
            _rb = GetComponent<Rigidbody2D>();
        }

        public bool IsMoving()
        {
            return _movement != Vector2.zero;
        }

        public void SetAndLockRotation(Component objectToLock)
        {
            Debug.Log("Locket to: " + objectToLock.transform);
            _lockedVector2 = objectToLock.transform.position;
        }

        public void FreeRotation()
        {
            _lockedVector2 = Vector2.zero;
        }

        void Update()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");

            Vector2 lookLocation = _lockedVector2 == Vector2.zero
                ? _cam.ScreenToWorldPoint(Input.mousePosition)
                : _lockedVector2;

            Vector2 lookDir = lookLocation - _rb.position;
            _angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        }

        private void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
            _rb.rotation = _angle;
        }
    }
}
