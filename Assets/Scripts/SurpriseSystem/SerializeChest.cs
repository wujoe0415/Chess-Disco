using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerializeChest : MonoBehaviour
{
    public float Duration = 2.5f;
    public Image _image;
    private void OnEnable()
    {
        StartCoroutine(Serialize());
        Invoke("DestroySelf", Duration);
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
    IEnumerator Serialize()
    {
        Color init = _image.color;
        init.a = 0f;
        _image.color = init;
        Color target = init;
        target.a = 1f;
        for (float f = 0f; f <= 0.5f; f += Time.deltaTime)
        {
            _image.color = Color.Lerp(init, target, f / 0.5f);
            yield return null;
        }
    }
}
