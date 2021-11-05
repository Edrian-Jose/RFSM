
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneManager : MonoBehaviour
{
    public static void GoTo(int level, int zone)
    {
        SceneManager.LoadScene("L" + level + "Z" + zone);
    }
}
