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

public enum ItemType
{
    Weapon,
    Armor,
    Consumable
}

public enum GearSlot
{
    Head,
    Chest,
    Weapon,
    Hands,
    Ring,
    Feet,
    Trinket,
    HealingPotion,
    ManaPotion
}


public class Item
{
    public ItemGrade grade;
}
public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Unique,

}

public struct ItemGrade
{
    public ItemType type;
    public ItemRarity rarity;
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
public class PlayerData
{
    public EntityStats stats;
    public LocationState location;

    public PlayerData(Player player)
    {
        this.location = new LocationState(player.scene, player.transform);
    }

}

public class Weapon
{
    public string Name;
    public float Damage;
    public string Handed;
    public float AtkSpd;
    public string WeaponType;
    public string AtkType;
    public int LevelReq;
    public float Range;
}
