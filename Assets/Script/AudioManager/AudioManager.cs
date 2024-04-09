using System.Collections.Generic;
using UnityEngine;

namespace Echo.Audio
{
    public enum AudioType
    {
        ItemPickup,
        FishPickup,
        WrongBookPlace,
        CorrectBookPlace,
        TaskComplete,
    }

    public enum BgmType
    {
        MainMenu,
        Cave,
        Chireiden,
        PostTask1,
        PostTask2,
    }

    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _backgroundMusicPlayer;
        [SerializeField] private AudioSource _audioPlayer;

        [Header("Bgm Clips")]
        [SerializeField] private AudioClip _mainMenuBgm;
        [SerializeField] private AudioClip _cave;
        [SerializeField] private AudioClip _postTask1;
        [SerializeField] private AudioClip _postTask2;
        [SerializeField] private AudioClip _somethingElse;
        [SerializeField] private AudioClip _chireiden;

        [Header("Sfx Clips")]
        [SerializeField] private AudioClip _pickupSound;
        [SerializeField] private AudioClip _fishPickupSound;
        [SerializeField] private AudioClip _bookPlaceSound;
        [SerializeField] private AudioClip _wrongBookPlaceSound;
        [SerializeField] private AudioClip _taskComplete;

        private Dictionary<AudioType, AudioClip> _clips;
        private Dictionary<BgmType, AudioClip> _bgmClips;

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
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _backgroundMusicPlayer.clip = _mainMenuBgm;
            _backgroundMusicPlayer.Play();

            _clips = new Dictionary<AudioType, AudioClip>
            {
                { AudioType.ItemPickup, _pickupSound },
                { AudioType.FishPickup, _fishPickupSound },
                { AudioType.WrongBookPlace, _wrongBookPlaceSound },
                { AudioType.CorrectBookPlace, _bookPlaceSound },
                { AudioType.TaskComplete, _taskComplete }
            };

            _bgmClips = new Dictionary<BgmType, AudioClip>
            {
                { BgmType.MainMenu, _mainMenuBgm },
                { BgmType.Cave, _cave },
                { BgmType.PostTask1, _postTask1 },
                { BgmType.PostTask2, _postTask2 },
                { BgmType.Chireiden, _chireiden }
            };
        }

        public void ChangeBgm(BgmType bgmType)
        {
            _backgroundMusicPlayer.clip = _bgmClips[bgmType];
            _backgroundMusicPlayer.Play();
        }

        public void Play(AudioType audioType)
        {
            _audioPlayer.clip = _clips[audioType];
            _audioPlayer.Play();
        }
    }
}