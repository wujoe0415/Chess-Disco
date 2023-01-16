using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
namespace Audio
{
    [System.Serializable]
    [SerializeField]
    public class BeatNote
    {
        public float Timing;
        public BeatNote(double timing)
        {
            Timing = (float)timing;
        }
    }
    [System.Serializable]
    [SerializeField]
    public class Spectrum
    {
        public List<BeatNote> Notes;
    }

    [RequireComponent(typeof(AudioSource))]
    public class SpectrumRecorder : MonoBehaviour
    {
        [SerializeField]
        public List<BeatNote> _notes = new List<BeatNote>();
        
        private AudioSource _backGrouond;
        double _sdpSongTime;
        double _songPosition;

        private void OnEnable()
        {
            _backGrouond = GetComponent<AudioSource>();
            _sdpSongTime = AudioSettings.dspTime;
            _backGrouond.Play();
        }
        public void Append()
        {
            _songPosition = AudioSettings.dspTime - _sdpSongTime/* * AudioSettings.outputSampleRate*/;
            _notes.Add(new BeatNote(_songPosition));
        }
        public void OnDisable()
        {
            Spectrum spectrum = new Spectrum();
            spectrum.Notes = _notes;
            string json = JsonUtility.ToJson(spectrum, true);
            Debug.Log(json);
            File.WriteAllText("D:/Game Project/ChessDisco/Assets/Scripts/Audio/SpectrumJson/Music_1.json", json);
        }
    }
}