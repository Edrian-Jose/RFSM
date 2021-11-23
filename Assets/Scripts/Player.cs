using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement movement;
    PlayerCombat combat;

    public PlayerGFX graphics;
    public Camera cam;
    public GameObject target;

    public int[] scene = { 0, 0 };

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        combat = GetComponent<PlayerCombat>();
        // Load();
        InvokeRepeating("Save", 15f, 15f);
    }


    public void Save()
    {
        PlayerData data = new PlayerData(this);
        Debug.Log("Data saved");
        StorageSystem.StorePlayerData(data);
    }

    public void Load()
    {
        PlayerData data = StorageSystem.FetchPlayerData();
        if (data != null)
        {
            LoadLocation(data.location);
        }
    }


    void LoadLocation(LocationState location)
    {
        SingletonManager.stopDefaultLocationUpdate = true;
        movement.Teleport(location.scene[0], location.scene[1]);
        transform.position = location.position.Convert();
        transform.localScale = location.localScale.Convert();
        target.transform.position = location.position.Convert();
        target.transform.localScale = location.localScale.Convert();
    }


}
