using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

public class RecordDemo : MonoBehaviour
{
    public SpectrumRecorder Recorder;

    private float _growingTime = 0.1f;
    private Vector3 InitScale = new Vector3(.5f, .5f, .5f);
    private Vector3 GrowScale = new Vector3(1.8f, 1.8f, 1.8f);
    private IEnumerator _coroutine;

    private void Awake()
    {
        transform.localScale = InitScale;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = Blow();
            StartCoroutine(_coroutine);

            Recorder.Append();
        } 
    }
    IEnumerator Blow()
    {
        for (float f = 0f; f < _growingTime; f += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(InitScale, GrowScale, f / _growingTime);
            yield return null;
        }
        transform.localScale = GrowScale;
        for (float f = 0f; f < _growingTime; f += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(GrowScale, InitScale, f / _growingTime);
            yield return null;
        }
        transform.localScale = InitScale;
    }
}
