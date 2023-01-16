using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RevolveCombo : MonoBehaviour
{
    private bool isLeft = true;

    private float _growingTime = 0.1f;
    private Vector3 InitScale = new Vector3(1.85f, 1.15f, 1f);
    private Vector3 GrowScale = new Vector3(2.41f, 1.5f, 1f);
    private IEnumerator _coroutine;

    private void OnEnable()
    {
        //StartCoroutine(Revolve());
    }
    private void Update()
    {
        if (isLeft && transform.rotation.z > 10)
            isLeft = false;
        else if (!isLeft && transform.rotation.z < 10)
            isLeft = true;

        //if (isLeft)
        //    transform.Rotate(0f, 0f, 5f);
        //else
        //    transform.Rotate(0f, 0f, 5f);
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = Blow();
            StartCoroutine(_coroutine);
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
    IEnumerator Revolve()
    {
        transform.rotation = Quaternion.identity;
        while (true)
        {
            for (float f = 0f; f <= 1f; f += Time.deltaTime)
            {
                transform.Rotate(0f, 0f, 0.1f);
                yield return null;
            }
            for (float f = 0f; f <= 1f; f += Time.deltaTime)
            {
                transform.Rotate(0f, 0f, -0.1f);
                yield return null;
            }
        }
    }
}
