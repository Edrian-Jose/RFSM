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
    public float AttackRange;
    public float MovementSpeed;
    public float AttackSpeed;
}


[System.Serializable]
public struct Coords
{
    public float x, y, z;
    public Coords(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }
    public Vector3 Convert()
    {
        return new Vector3(this.x, this.y, this.z);
    }
}
[System.Serializable]
public struct LocationState
{
    public Coords position;
    public Coords localScale;

    public int[] scene;

    public LocationState(int[] scene, Transform t)
    {
        this.scene = scene;
        position = new Coords(t.position);
        localScale = new Coords(t.localScale);
    }
}


[System.Serializable]
public class PlayerData{
    public EntityStats stats;
    public LocationState location;

    public PlayerData(Player player)
    {
        this.location = new LocationState(player.scene, player.transform);
    }

}