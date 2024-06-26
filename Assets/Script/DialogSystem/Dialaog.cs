using System.Collections.Generic;
using UnityEngine;

namespace Echo.Dialog
{
    [CreateAssetMenu(fileName = "Dialog", menuName = "ScriptableObjects/Dialog")]
    public class Dialog : ScriptableObject
    {
        [SerializeField] private List<string> _lines;
        public List<string> Lines => _lines;
    }
}