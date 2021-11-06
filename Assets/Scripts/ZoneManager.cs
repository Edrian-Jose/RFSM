
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneManager : MonoBehaviour
{
    public static void GoTo(int level, int zone)
    {
        Debug.Log("Going to " + "L" + level + "Z" + zone);
        SceneManager.LoadScene("L" + level + "Z" + zone);
    }

    public static bool isCurrentScene(int level, int zone)
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneTarget = "L" + level + "Z" + zone;
        return scene.name == sceneTarget;
    }
}
