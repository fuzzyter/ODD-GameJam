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
        PlayerPrefs.SetString("PlayerName", playerName); // 'PlayerName'�̶�� Ű�� playerName ����
        SceneManager.LoadScene("Main");// ���߿� ���� �� ���� �� �̸� �ٲٱ�

    }
}
