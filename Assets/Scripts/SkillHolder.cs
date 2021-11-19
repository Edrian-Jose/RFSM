using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHolder : MonoBehaviour
{
    private PlayerController controller;
    public Skill[] skills;
    private SkillState[] skillStates;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        controller.QButtonUp += QButtonUpHandler;
        controller.WButtonUp += WButtonUpHandler;
        controller.EButtonUp += EButtonUpHandler;
        controller.RButtonUp += RButtonUpHandler;

        skillStates = new SkillState[skills.Length];
        for(int i = 0; i < skills.Length; i++)
        {
            skillStates[i] = SkillState.Ready;
        }
    }

    public enum SkillState{
        Ready,
        Active,
        Cooldown
    }

    void QButtonUpHandler()
    {
        TryCastSkill(0);
    }
    void WButtonUpHandler()
    {
        // StartCoroutine(StartSkillSequence(skills[1]));
        TryCastSkill(1);
    }
    void EButtonUpHandler()
    {
        // StartCoroutine(StartSkillSequence(skills[2]));
        TryCastSkill(2);
    }
    void RButtonUpHandler()
    {
        // StartCoroutine(StartSkillSequence(skills[3]));
        TryCastSkill(3);
    }
    void TryCastSkill(int index)
    {
        if(index >= skills.Length)
        {
            return;
        }
        if (skillStates[index] == SkillState.Ready)
        {
            StartCoroutine(StartSkillSequence(index));
        }
    }

    IEnumerator StartSkillSequence(int index) 
    {
        yield return StartCoroutine(SkillReadyCoroutine(index));
        yield return StartCoroutine(SkillActiveCoroutine(index));
    }

    IEnumerator SkillReadyCoroutine(int index)
    {
        Debug.Log("Skill ACTIVATE!");
        skills[index].Activate();
        skillStates[index] = SkillState.Active;
        yield return new WaitForSeconds(skills[index].duration);
    }

    IEnumerator SkillActiveCoroutine(int index)
    {
        Debug.Log("Skill COOLINGDOWN");
        skillStates[index] = SkillState.Cooldown;
        yield return new WaitForSeconds(skills[index].cooldown);
        skillStates[index] = SkillState.Ready;
        Debug.Log("Skill READY");
    }

}
