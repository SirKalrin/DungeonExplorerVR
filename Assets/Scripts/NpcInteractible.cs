using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class NpcInteractible : PointerInteraction
    {
        [SerializeField]
        private List<AudioClip> _dialogClips;
        private AudioSource _audioSource;
        private GameObject _player;
        private HeadGestures _gestures;
        private int index;
        private bool? _reaction;
        private bool _hasNextDialogOption;

        void Start()
        {
            _reaction = null;
            _hasNextDialogOption = true;
            _audioSource = gameObject.GetComponent<AudioSource>();
            index = 0;
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                _player = col.gameObject;
                _gestures = _player.GetComponent<HeadGestures>();
                StartCoroutine(RunDialog());         
            }
        }

        private IEnumerator RunDialog()
        {
            _audioSource.PlayOneShot(_dialogClips[0]);            
            while (_hasNextDialogOption)
            {
                while (_reaction == null)
                {
                    _reaction = _gestures.GetReaction();
                    yield return new WaitForSeconds(0.3f);
                }
                PlayNextDialogClip();
            }
            Debug.Log("Dialog over");
        }

        private void PlayNextDialogClip()
        {
            if (!_audioSource.isPlaying)
            {
                if (_reaction == true)
                    _audioSource.PlayOneShot(_dialogClips[GetPositiveIndex()]);

                else
                {
                    _audioSource.PlayOneShot(_dialogClips[GetNegativeIndex()]);
                }    
                Debug.Log(index);           
            }
            _reaction = null;
        }

        private int GetPositiveIndex()
        {
            index = index * 2 + 2;
            if (_dialogClips.Count < index*2+2)
                _hasNextDialogOption = false;
            return index;
        }

        private int GetNegativeIndex()
        {
            index = index * 2 + 1;
            if (_dialogClips.Count < index * 2 + 2)
                _hasNextDialogOption = false;
            return index;
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
