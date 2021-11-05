
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
