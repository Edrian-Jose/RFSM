using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EntityStats 
{
    public float HealthPoints;
    public float Strength;
    public float Dexterity;
    public float Intelligence;
    public float Wisdom;
}


[System.Serializable]
public class PlayerData{
    EntityStats stats;
}