using System.Collections.Generic;
using UnityEngine;

namespace Echo.Audio
{
    public enum AudioType
    {
        Pickup,
    }

    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _backgroundMusicPlayer;
        [SerializeField] private AudioSource _audioPlayer;
        [SerializeField] private AudioClip _backgroundMusic;
        [SerializeField] private AudioClip _pickupSound;

        private Dictionary<AudioType, AudioClip> _clips;

        private static AudioManager _instance;

        public static AudioManager Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _backgroundMusicPlayer.clip = _backgroundMusic;
            _backgroundMusicPlayer.Play();

            _clips = new Dictionary<AudioType, AudioClip>
            {
                {AudioType.Pickup, _pickupSound}
            };
        }

        public void Play(AudioType audioType)
        {
            _audioPlayer.clip = _clips[audioType];
            _audioPlayer.Play();
        }
    }
}