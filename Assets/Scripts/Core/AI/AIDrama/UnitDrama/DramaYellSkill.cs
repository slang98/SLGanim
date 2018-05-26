using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DramaYellSkill : UnitDrama {
    public GameObject skillNamePF;
    public string skillName;
    public Unit unit; //current AI unit

    private Transform skillNamePanel;
    private static Vector3 displayPos; //the position of skill name text

    void Start() {
        skillNamePanel = GameObject.Find("Canvas/SkillNamePanel").transform;
        displayPos = new Vector3(Screen.width / 2, Screen.height / 6, 0);
    }

    public override IEnumerator Play()
    {
        yield return StartCoroutine(yellSkillName());
    }

    private IEnumerator yellSkillName()
    {
        GameObject snpf = Instantiate(skillNamePF);
        snpf.transform.SetParent(skillNamePanel);
        string unitName = unit.GetComponent<CharacterStatus>().roleCName;
        snpf.GetComponent<Text>().text = "["+unitName+ "] 使用了 <color=#00FF01FF>" + getSkillChName(skillName)+ "</color>";
        //the position of display should on the left top of unit
        snpf.GetComponent<TextFlyAboveAnim>().textPosition = displayPos;
        snpf.GetComponent<TextFlyAboveAnim>().DoAnim();
        yield return new WaitForSeconds(1);
        
    }

    private string getSkillChName(string skillEnName) {
        Skill skill = SkillManager.GetInstance().skillList.Find(s => s.EName == skillEnName);
        return skill.CName;
    } 
}
