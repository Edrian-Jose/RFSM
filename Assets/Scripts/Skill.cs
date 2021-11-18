using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Skill : ScriptableObject
{
    public string Name;
    public float cooldown;
    public float duration;
    
    public virtual void Activate()
    {
        Debug.Log("SKILL!!");
    }
}
