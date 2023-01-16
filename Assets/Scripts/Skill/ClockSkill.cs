using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSkill : MonoBehaviour
{
    public UseSkill Clock;
    public int CurrentSkillNum = 0;
    public int maxSkillNum;

    private void Start()
    {
        maxSkillNum = Clock.Skills.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CurrentSkillNum = CurrentSkillNum - 1 >= 0 ? CurrentSkillNum - 1 : maxSkillNum - 1;
            Clock.CurrentSkill = CurrentSkillNum;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CurrentSkillNum = CurrentSkillNum + 1 < maxSkillNum ? CurrentSkillNum + 1 : 0;
            Clock.CurrentSkill = CurrentSkillNum;
        }
    }
}
