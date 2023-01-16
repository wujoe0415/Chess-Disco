using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FlowText : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Awake()
    {
        Vector3 offset = new Vector3(0f, Random.Range(-2f, 2f), 0f);
        transform.localPosition = offset;
        transform.localRotation = Quaternion.identity;
        StartCoroutine(Flow());
    }
    public void SetText(int adder)
    {
        text.text = "+" + adder.ToString();
    }
    private IEnumerator Flow()
    {
        
        Vector3 target = transform.localPosition + new Vector3(0f, 30f, 0f);
        Color initColor = text.color;
        Color targetColor = text.color;
        targetColor.a = 0f;
        for(float f = 0f; f < 1f; f += Time.deltaTime)
        {
            transform.localPosition = Vector3.Slerp(Vector3.zero, target, f / 1f);
            text.color = Color.Lerp(initColor, targetColor, f / 1f);
            yield return null;
        }
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
    }
}
