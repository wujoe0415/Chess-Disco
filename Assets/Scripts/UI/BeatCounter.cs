using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BeatCounter : MonoBehaviour
{
    public static event Action<HitBeat.CorrectType> OnAddBeat;

    public int Excellent = 0;
    public int Good = 0;
    public int Bad = 0;
    public int Miss = 0;
    public EnergyBar Blood;
    public EnergyBar Energy;

    public EndGame End;

    public void AddBeat(HitBeat.CorrectType correctType)
    {
        OnAddBeat?.Invoke(correctType);
        if (correctType == HitBeat.CorrectType.Excellent)
        {
            Energy.ChargeEnergy(0.5f);
            Blood.ChargeEnergy(0.5f);
            Excellent++;
        }
        else if (correctType == HitBeat.CorrectType.Good)
        {
            Energy.ChargeEnergy(0.25f);
            Blood.ChargeEnergy(0.25f);
            Good++;
        }
        else if (correctType == HitBeat.CorrectType.Bad)
        {
            Bad++;
        }
        else
        {
            Blood.LostEnergy(1f);
            Miss++;
            if (Blood.CurrentEnergy == 0)
                End.EndofGame();
        }
    }
}
