using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    public List<Skill> Skills;
    public EnergyBar EnergySystem;
    public int CurrentSkill { get; set; }

    private void OnEnable()
    {
        foreach(Skill s in Skills)
            s.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ExecuteSkill();
    }
    public void AddSkill(Skill skill)
    {
        Skills.Add(skill);
    }
    public void RemoveSkill(Skill skill)
    {
        Skills.Remove(skill);
    }
    public void ExecuteSkill()
    {
        if(EnergySystem.LostEnergy(CurrentSkill))
            Skills[CurrentSkill].Execute();
    }
    public void UseRandomSkill()
    {
        int cur = Random.Range(0, Skills.Count);
        if (EnergySystem.LostEnergy(cur))
        {
            Skills[cur].gameObject.SetActive(true);
            Skills[cur].Execute();
        }
    }
}
