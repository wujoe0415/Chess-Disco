using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DarkNight : Skill
{
    public Light2D light;
    public override void Execute()
    {
        light.gameObject.SetActive(false);
        // Turn EnemyLight;
    }
    public override void Recover()
    {
        light.gameObject.SetActive(true);
        base.Recover();
    }
}
