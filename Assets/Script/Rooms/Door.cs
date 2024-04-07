using UnityEngine;

namespace Echo.Rooms
{
    [RequireComponent(typeof(Collider2D))]
    public class Door : MonoBehaviour
    {
        [SerializeField] private Room _room;

        private Collider2D _collider;
        private bool _canUse = true;

        public Room ConnectedRoom => _room;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Playercontrol _) && _canUse)
            {
                var roomManager = FindObjectOfType<RoomManager>();
                roomManager.Load(this);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _canUse = true;
        }

        public void UseDoor()
        {
            _canUse = false;
        }
    }
}