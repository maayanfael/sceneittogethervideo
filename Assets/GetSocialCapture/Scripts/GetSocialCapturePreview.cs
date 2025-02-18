﻿using System;
using System.Collections.Generic;
using GetSocialSdk.Capture.Scripts.Internal.Recorder;
using UnityEngine;
using UnityEngine.UI;

namespace GetSocialSdk.Capture.Scripts
{
    public class GetSocialCapturePreview : MonoBehaviour
    {

        #region Public fields
        
        /// <summary>
        /// Number of displayed frames per second. Default is 30.
        /// </summary>
        public int playbackFrameRate = 30;

        /// <summary>
        /// Preview loops or played only once.
        /// </summary>
        public bool loopPlayback = true;

        #endregion

        #region Private fields

        private List<Texture2D> _framesToPlay;
        private RawImage _rawImage;
        private bool _play;
        private bool _myPlay;
        private float _playbackStartTime;
        private bool _previewInitialized;

        #endregion

        #region Public methods

        /// <summary>
        /// Starts preview playback.
        /// </summary>
        public void Play()
        {
            if (!_previewInitialized)
            {
                Init();
            }

            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }
            _play = true;
            _myPlay = true;
            Debug.Log("No Of Frames In Gif: " + _framesToPlay.Count);
        }

        /// <summary>
        /// Stops playback.
        /// </summary>
        public void Stop()
        {
            _play = false;
            _myPlay = false;

            _playbackStartTime = 0;
        }

        public void Clear()
        {
            if(_framesToPlay != null)
            {
                _framesToPlay.Clear();
                _framesToPlay = null;
                _framesToPlay = new List<Texture2D>();
            }
            
            _previewInitialized = false;
        }


        public void PlayByMovieFrame(int Frame, int FrameCount)
        {

            try
            {

                if (!_myPlay) return;
                if (_framesToPlay.Count <= 0) return;
                if (Frame < 0) return;

                int realFrame = (int)((double)((float)_framesToPlay.Count / (float)FrameCount) * Frame);

                if (realFrame >= _framesToPlay.Count)
                {
                    Stop();
                    return;
                }
                _rawImage.texture = _framesToPlay[realFrame];
            }
            catch {

                Debug.LogError("Error: "+Frame + ", _framesToPlay.Count: " + _framesToPlay.Count + ", FrameCount: " + FrameCount + ", realFrame:" + ((int)((double)((float)_framesToPlay.Count / (float)FrameCount) * Frame)));

            }

        }

        #endregion

        #region Private methods

        private void Init()
        {
            for (var i = 0; i < StoreWorker.Instance.StoredFrames.Count(); i++)
            {
                var frame = StoreWorker.Instance.StoredFrames.ElementAt(i);
                var texture2D = new Texture2D(frame.Width, frame.Height);
                texture2D.SetPixels32(frame.Data);
                texture2D.Apply();
                _framesToPlay.Add(texture2D);
            }

            _previewInitialized = true;
        }

        #endregion

        #region Unity methods

        private void Awake()
        {
            _rawImage = GetComponent<RawImage>();
            _framesToPlay = new List<Texture2D>();
            _play = false;
        }

        private void OnDestroy()
        {
            var listId = GC.GetGeneration(_framesToPlay);
            _framesToPlay.Clear();
            GC.Collect(listId, GCCollectionMode.Forced);
            _framesToPlay = null;
        }

        private void Start()
        {
            //Init();
            if (_framesToPlay.Count == 0)
            {
                _play = false;
            }
        }

        private void Update()
        {
            //if (!_play) return;
            //if (_framesToPlay.Count == 0) return;
            //if (Math.Abs(_playbackStartTime) < 0.0001f)
            //{
            //    _playbackStartTime = Time.realtimeSinceStartup;
            //    
            //}
            //var index = (int)((Time.realtimeSinceStartup - _playbackStartTime) * playbackFrameRate) % _framesToPlay.Count;
            //_rawImage.texture = _framesToPlay[index];
            //if (index == _framesToPlay.Count - 1 && !loopPlayback)
            //{
            //    Debug.LogWarning(" Stop playnig Capture," + Time.realtimeSinceStartup + " Took: " +(Time.realtimeSinceStartup - _playbackStartTime) );
            //    _play = false;
            //}
        }


        #endregion

    }
}