using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayChess : Skill
{
    public Image Background;
    public float EffectTime = 5f;
    private bool isBlink = true;
    
    public override void Execute()
    {
        isBlink = true;
        StartCoroutine(Blink());
        Invoke("CloseBlink", EffectTime);
    }
    public override void Recover()
    {
        base.Recover();
        isBlink = false;
    }
    IEnumerator Blink()
    {
        Color init = Background.color;
        while (isBlink)
        {
            float speed = 0.01f;
            Color temp = Background.color;
            while(Background.color.a + speed < 0.5f)
            {
                temp = Background.color;
                temp.a += speed;
                Background.color = temp;
                yield return null;
            }
            temp = Background.color;
            temp.a = 0.5f;
            Background.color = temp;
            while (Background.color.a - speed > 0)
            {
                temp = Background.color;
                temp.a -= speed;
                Background.color = temp;
                yield return null;
            }
            temp = Background.color;
            temp.a = 0f;
            Background.color = temp;
        }
        Color end = Background.color;
        for (float f = 0f; f < 0.5f; f += Time.deltaTime)
        {
            Background.color = Color.Lerp(end, init, f / 0.5f);
            yield return null;
        }
        Background.color = init;
    }
}
