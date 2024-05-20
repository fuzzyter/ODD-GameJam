using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DateGM : MonoBehaviour
{
    public int favo;
    public void Start()
    {
        favo = PlayerPrefs.GetInt("favorability");
    }
    public void SelectMainScenes()
    {
        favo += 40;
        PlayerPrefs.SetInt("favorability", favo);
        SceneManager.LoadScene("Main");
    }
}
