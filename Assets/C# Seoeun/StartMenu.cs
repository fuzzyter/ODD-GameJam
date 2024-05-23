using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public GameObject OptionPanel;


    void Start()
    {
        OptionPanel.SetActive(false);
    }

    void Update()
    {
    }
    public void OnClickNewGame()
    {
        Debug.Log("Start New Game");
        SceneManager.LoadScene("NameInput");

    }

    public void OnClickLoad()
    {
        Debug.Log("Continue Game");
    }

    public void OnClickOption()
    {
        Debug.Log("Open Settings");
        if (OptionPanel != null)
        {
            OptionPanel.SetActive(true); // 옵션 패널을 활성화
        }
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 버튼을 누르면 게임이 종료되도록
#endif
    }

 
}
