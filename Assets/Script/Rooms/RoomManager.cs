using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Echo.Rooms
{
    public class RoomManager : MonoBehaviour
    {
        [SerializeField] private Room _currentRoom;
        [SerializeField] private Playercontrol _playerController;
        [SerializeField] private GameObject _rightCurtain;
        [SerializeField] private GameObject _leftCurtain;
        [SerializeField] private float _transitionTime;

        private string _previousRoomName;
        private Door _previousDoorUsed;

        private static RoomManager _instance;
        public static RoomManager Instance => _instance;

        private void Awake()
        {
            _previousRoomName = _currentRoom.RoomName;

            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public void Load(Door doorUsed)
        {
            _previousDoorUsed = doorUsed;
            StartCoroutine(StartLoading());
        }

        public IEnumerator StartLoading()
        {
            _rightCurtain.SetActive(true);
            _leftCurtain.SetActive(true);
            yield return StartCoroutine(TransitionCurtains(true));

            var operation = SceneManager.LoadSceneAsync(_previousDoorUsed.ConnectedRoom.RoomName);
            while (!operation.isDone)
            {
                yield return null;
            }

            var doorsInRoom = FindObjectsByType<Door>(FindObjectsSortMode.None);
            var doorToSpawnAt = doorsInRoom.Where(door => door.ConnectedRoom.RoomName == _previousRoomName).FirstOrDefault();


            _currentRoom = _previousDoorUsed.ConnectedRoom;
            _previousRoomName = _currentRoom.RoomName;
            doorToSpawnAt.UseDoor();
            _playerController = FindObjectOfType<Playercontrol>();
            _playerController.transform.position = doorToSpawnAt.transform.position;
            yield return StartCoroutine(TransitionCurtains(false));
            _rightCurtain.SetActive(false);
            _leftCurtain.SetActive(false);
        }

        private IEnumerator TransitionCurtains(bool opens)
        {
            float timeElapsed = 0;
            while (timeElapsed < _transitionTime)
            {
                var x = opens ? timeElapsed / _transitionTime : 1 - timeElapsed / _transitionTime;
                var scale = new Vector3(x, 1, 1);
                _rightCurtain.transform.localScale = scale;
                _leftCurtain.transform.localScale = scale;

                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}