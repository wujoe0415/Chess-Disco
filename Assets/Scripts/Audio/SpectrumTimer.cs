using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Audio {
    [RequireComponent(typeof(AudioSource))]
    public class SpectrumTimer : MonoBehaviour
    {
        public SpectrumReader Spectrum;
        private static Spectrum s_spectrum;
        public static float currentTime = 0f;
        private static int s_currentNote = 0;
        public static float CurrentNote{
            get { return s_spectrum.Notes[s_currentNote].Timing; }
        }
        public static float NextBeatGap {
            get {
                //if (s_spectrum.Notes.Count < s_currentNote)
                    return s_spectrum.Notes[s_currentNote + 1].Timing - s_spectrum.Notes[s_currentNote].Timing;
                //else
                    //return Mathf.Infinity;
            }
        }

        public double bpm = 140d;
        private double sampleRate;
        private double nextTick;
        private float _startTick = 0f;

        private Thread _audioThreading;
        private bool _audioThreadingGate = false;

        private void Start()
        {
            s_currentNote = 0;
            currentTime = 0f;
            s_currentNote = 0;
            _startTick = (float)AudioSettings.dspTime;
            currentTime = _startTick;
            sampleRate = AudioSettings.outputSampleRate;
            nextTick = _startTick * sampleRate;
            _audioThreading = new Thread(new ThreadStart(CalculateTimer));
            _audioThreadingGate = true;
            _audioThreading.Start();
        }
        void OnApplicationQuit()
        {
            if (_audioThreading != null)
            {
                _audioThreadingGate = false;
                _audioThreading.Abort();
            }
            
        }
        void CalculateTimer()
        {
            double samplesPerTick = sampleRate * 60.0F / bpm * 4.0F / 4;
            double sample = AudioSettings.dspTime * sampleRate;

            s_spectrum = Spectrum.SpectrumMusic;
            
            while (true)
            {
                try
                {
                    if (!_audioThreadingGate || s_currentNote > s_spectrum.Notes.Count)
                        break;

                    currentTime = (float)AudioSettings.dspTime - _startTick;
                    //Debug.Log(currentTime/* + " Beat Note = " + s_currentNote*/);
                    //Debug.Log(CurrentNote + " " + NextBeatGap);
                    if (currentTime > CurrentNote + NextBeatGap)
                    {
                        s_currentNote++;
                    }
                }
                catch (Exception err)
                {
                    Debug.LogWarning(err.ToString());
                }
            }
        }
    }
}
