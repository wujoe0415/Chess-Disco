using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : Skill
{
    public Camera camera;
    private IEnumerator _coroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = Shake(0.2f, 0.1f);
            StartCoroutine(_coroutine);
        }
    }
    public override void Execute()
    {
        Debug.Log("Noise");
        StartCoroutine(Shake(0.2f, 0.5f));
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = camera.transform.localPosition;
        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            camera.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        camera.transform.localPosition = originalPos;
    }
}
