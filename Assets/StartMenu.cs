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
            OptionPanel.SetActive(true); // �ɼ� �г��� Ȱ��ȭ
        }
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ��ư�� ������ ������ ����ǵ���
#endif
    }

 
}
