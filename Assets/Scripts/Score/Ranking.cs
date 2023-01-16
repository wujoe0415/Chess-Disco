using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class Ranking : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public AudioSource audio;

    public void Rank(int score)
    {
        if (score > 900000)
            Text.text = "S";
        else if (score > 800000)
            Text.text = "A";
        else if (score > 750000)
            Text.text = "B";
        else if (score > 500000)
            Text.text = "C";
        else if (score > 250000)
            Text.text = "D";
        else if (score > 100000)
            Text.text = "E";
        else
            Text.text = "F";
        StartCoroutine(Display());
    }
    private IEnumerator Display()
    {
        float target = Text.fontSize;
        Text.fontSize = 0f;
        for(float f = 0f; f<=0.5f;f+=Time.deltaTime)
        {
            Text.fontSize = Mathf.Lerp(0f, target, f / 0.5f);
            if(Text.fontSize > 5f)
                audio.Play();
            yield return null;
        }
        Text.fontSize = target;
    }
}
