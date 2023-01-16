using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class SpectrumMaker : MonoBehaviour
    {
        public SpectrumReader Spectrum;

        [System.Serializable]
        public class SpectrumChess {
            public float StartMovingTime;
            public float BeatTime;
            public PieceMovement PM;
            public Chessman.ChessType ChessMan = Chessman.ChessType.None;
            public SpectrumChess(float beat = 0f) {
                BeatTime = beat;
                StartMovingTime = beat;
                ChessMan = Chessman.ChessType.None;
                PM = null;
            }
        }

        public List<SpectrumChess> SpectrumWithChess = new List<SpectrumChess>();
        public List<GameObject> Chesses = new List<GameObject>();

        public Transform EnemyManager;

        private IEnumerator _coroutine;

        public void Start()
        {
            Initialize();
        }
        private void OnDisable()
        {
            //SpectrumWithChess.Clear();
        }
        public void Initialize()
        {
            SpectrumWithChess.Clear();
            for (int i = 0; i < Spectrum.SpectrumMusic.Notes.Count; i++)
            {
                SpectrumWithChess.Add(new SpectrumChess(Spectrum.SpectrumMusic.Notes[i].Timing));

                SpectrumWithChess[i].ChessMan = (Chessman.ChessType)(Random.Range(2, 7)); // No King
                GameObject temp = InstantiateChess(SpectrumWithChess[i].ChessMan);
                SpectrumWithChess[i].PM = temp.GetComponent<PieceMovement>();
                SpectrumWithChess[i].PM.InitializeData();
                SpectrumWithChess[i].StartMovingTime = SpectrumWithChess[i].BeatTime - SpectrumWithChess[i].PM.PerfectTime;
            }
            SpectrumWithChess.Sort(delegate (SpectrumChess sc1, SpectrumChess sc2) { return sc1.StartMovingTime.CompareTo(sc2.StartMovingTime); });
            foreach (SpectrumChess sc in SpectrumWithChess)
                sc.PM.gameObject.SetActive(false);
        }
        public void StartMove()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = InstantiateByBeat();
            StartCoroutine(_coroutine);
        }
        private GameObject InstantiateChess(Chessman.ChessType chess)
        {
           GameObject newChess = GameObject.Instantiate(Chesses[(int)chess], Vector3.zero, Quaternion.identity, EnemyManager);
            return newChess.gameObject;
        }
        public void StopGenerateEnemy()
        {
            StopCoroutine(_coroutine);
        }
        public IEnumerator InstantiateByBeat()
        {
            float startTime = (float)AudioSettings.dspTime;
            int currentIndex = 0;
            while (currentIndex + 1 < SpectrumWithChess.Count)
            {
                float musicTime = (float)AudioSettings.dspTime - startTime ;
                for (int i = currentIndex; i < SpectrumWithChess.Count; i++)
                {
                    if (musicTime >= SpectrumWithChess[i].StartMovingTime)
                    {
                        if (SpectrumWithChess[i].PM != null && !SpectrumWithChess[i].PM.gameObject.activeInHierarchy)
                        {
                            SpectrumWithChess[i].PM.gameObject.SetActive(true);
                            SpectrumWithChess[i].PM.Movement();
                        }
                        currentIndex = i;
                    }
                    else
                        yield return null;
                }
            }
        }
    }
}
