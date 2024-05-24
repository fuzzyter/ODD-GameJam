using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public GameObject OptionPanel;

    void Start()
    {
        DataSend();
        OptionPanel.SetActive(false);
    }

    void Update()
    {
    }

    public void DataSend()
    {
       
    }
    public void SaveDistroy()
    {
        PlayerPrefs.DeleteKey("money");
        PlayerPrefs.DeleteKey("day");
        PlayerPrefs.DeleteKey("hair");
        PlayerPrefs.DeleteKey("skin");
        PlayerPrefs.DeleteKey("weight");
        PlayerPrefs.DeleteKey("talk");
        PlayerPrefs.DeleteKey("style");
        PlayerPrefs.DeleteKey("dateStatLimit");
        PlayerPrefs.DeleteKey("favorability");
        PlayerPrefs.DeleteKey("dateStatLimit");
        PlayerPrefs.DeleteKey("miniGameCnt");
        PlayerPrefs.DeleteKey("setting");
        PlayerPrefs.DeleteKey("PlayerName");
    }
    public void OnClickNewGame()
    {

        Debug.Log("Start New Game");
        SaveDistroy();
        SceneManager.LoadScene("NameInput");

    }

    public void OnClickLoad()
    {
        Debug.Log("Continue Game");
        SceneManager.LoadScene("Main");
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
