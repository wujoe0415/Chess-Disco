using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTreasure : MonoBehaviour
{
    public AudioSource m_Source;
    public void UseSkill()
    {
        m_Source.Play();
        GameObject.Find("SkillSystem").GetComponent<UseSkill>().UseRandomSkill();
    }
    public void DisableSelf()
    {
        Destroy(gameObject);
    }
}
