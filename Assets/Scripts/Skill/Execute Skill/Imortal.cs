using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imortal : Skill
{
    public static bool isImortal = false;
    public override void Execute()
    {
        isImortal = true;
    }
    public override void Recover()
    {
        isImortal= false;
        base.Recover();
    }
}
