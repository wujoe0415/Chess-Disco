using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScore : Skill
{
    public override void Execute()
    {
        ScoreCounter.s_scale = 5;
    }
}
