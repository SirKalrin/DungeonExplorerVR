using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class NpcInteractible : PointerInteraction
    {
        [SerializeField]
        private List<AudioClip> _dialogClips;
        [SerializeField]
        private AudioClip _negativeClip;
        private AudioSource _audioSource;
        private GameObject _player;
        private HeadGestures _gestures;
        private int index;

        void Start()
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
            index = 0;
        }

        void Update()
        {
            if (_player != null )
            {
                bool? reaction = _gestures.GetReaction();

                if (reaction != null && !_audioSource.isPlaying)
                {
                    if (reaction == true)
                    {
                        Debug.Log("good boy");
                        _audioSource.PlayOneShot(_dialogClips[index++]);                       
                    }
                    else
                    {
                        _audioSource.PlayOneShot(_negativeClip);
                    }
                }
            }
        }

        void OnTriggerEnter(Collider col)
        {
            Debug.Log(col.tag);
            if (col.gameObject.tag == "Player")
            {
                _player = col.gameObject;
                _gestures = _player.GetComponent<HeadGestures>();
            }
        }


        public new void PointerEntered()
        {
            base.PointerEntered();
        }

        public new void PointerExited()
        {
            base.PointerExited();
        }

    
    }
}
