using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullSkill : Skill
{
    public override void Execute()
    {
        Debug.Log("Use Null");
        return;
    }
}
