using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NameInput : MonoBehaviour
{
    public TMP_InputField nameInputField;  
    public Button checkButton;


    public void SubmitName()
    {
        //checkButton.onClick.AddListener(SubmitName);
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName); // 'PlayerName'이라는 키로 playerName 저장
        SceneManager.LoadScene("Main");// 나중에 메인 씬 연결 후 이름 바꾸기

    }
}
