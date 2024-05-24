using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public static SceneControl Instance;

    public void LoadScene(string sceneName)
    {
        /*
        if (sceneName == "Script"&& DialogSystem.currentLineIndex!=0)
        {
            DialogSystem.currentLineIndex++;
        }*/

        // ¾À ÀüÈ¯
        SceneManager.LoadScene(sceneName);

    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
}
