using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Audio
{
    public class SpectrumReader : MonoBehaviour
    {
        public TextAsset jsonFile;
        public Spectrum SpectrumMusic;

        // Start is called before the first frame update
        void Awake()
        {
            SpectrumMusic = JsonUtility.FromJson<Spectrum>(jsonFile.text);
        }
    }
}
