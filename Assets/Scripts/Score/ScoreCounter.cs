using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static HitBeat;

public class ScoreCounter : MonoBehaviour
{
    public static int s_scale = 1;
    public int Score = 0;
    public int BaseScore = 100;

    [Header("Display Text")]
    public TextMeshProUGUI ScoreUI;
    public GameObject DynamicShadowScore;
    public Transform InitPlace;

    [Header("Combo Count")]
    public int Combo = 0;
    public GameObject ComboImage;

    private void OnEnable()
    {
        BeatCounter.OnAddBeat += AddScore;
        ComboImage.SetActive(false);
    }
    private void OnDisable()
    {
        BeatCounter.OnAddBeat -= AddScore;
    }
    private void AddScore(HitBeat.CorrectType correctType)
    {
        int adder = 0;
        if (correctType == HitBeat.CorrectType.Excellent)
            adder += BaseScore * 4 * s_scale;
        else if (correctType == HitBeat.CorrectType.Good)
            adder += BaseScore * 2 * s_scale;
        else if (correctType == HitBeat.CorrectType.Bad)
            adder += BaseScore * s_scale;
        Score += adder;
        if (adder != 0)
        {
            Combo++;
            ComboScale();
            if(Combo == 2)
                ComboImage.SetActive(true);
            InitDynamicScore(adder);
            UpdateSocreUI();
        }
        else
        {
            if(Combo != 0)
                s_scale = 1;
            Combo = 0;
            ComboImage.SetActive(false);
        }
    }
    private void InitDynamicScore(int adder)
    {
        GameObject temp = Instantiate(DynamicShadowScore, InitPlace);
        temp.GetComponent<FlowText>().SetText(adder);
    }
    private void UpdateSocreUI()
    {
        string sixbit = "";
        for (int i = 0; i < 6 - Score.ToString().Length; i++)
            sixbit += "0";
        sixbit += Score.ToString();
        ScoreUI.text = sixbit;
    }
    private void ComboScale()
    {
        if (Combo == 10)
            s_scale += 1;
        else if (Combo == 5)
            s_scale += 1;
    }
}
