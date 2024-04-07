using System.Collections.Generic;
using UnityEngine;

namespace Echo.Rooms
{
    [CreateAssetMenu(fileName = "New Room", menuName = "ScriptableObjects/Room")]
    public class Room : ScriptableObject
    {
        [SerializeField] private string _roomName;
        [SerializeField] private List<Room> _connectedRooms;

        public string RoomName => _roomName;
        public List<Room> ConnectedRooms => _connectedRooms;
    }
}