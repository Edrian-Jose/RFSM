using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    public static SingletonManager Instance { get; private set; }
    public static bool stopDefaultLocationUpdate = false;
    [SerializeField]
    public List<GameObject> singletons;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            for (int i = 0; i < Instance.singletons.Count; i++)
            {
                if (singletons.Count > i && !stopDefaultLocationUpdate)
                {
                    Instance.singletons[i].transform.position = singletons[i].transform.position;
                    Instance.singletons[i].transform.localScale = singletons[i].transform.localScale;
                }
            }
            SingletonManager.stopDefaultLocationUpdate = false;
            Destroy(gameObject);
        }
    }
}
