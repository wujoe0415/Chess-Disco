using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ChargeBlood : Skill
{
    public EnergyBar blood;
    public EnergyBar energy;
    public override void Execute()
    {
        blood.ChargeMaxEnergy();
        energy.ChargeMaxEnergy();
    }
}
