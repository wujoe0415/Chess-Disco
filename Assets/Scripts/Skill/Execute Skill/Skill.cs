using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public abstract class Skill : MonoBehaviour
{
    public Light2D PointLight;
    public float Duration = 5f;
    public Color Glow = Color.white;

    public void OnEnable()
    {
        Execute();
        PointLight.color = Glow;
        Invoke("Recover", Duration);
    }
    public void OnDisable()
    {
        Recover();
    }
    public abstract void Execute();
    public virtual void Recover()
    {
        this.gameObject.SetActive(false);
        PointLight.color = Color.white;
    }
}
