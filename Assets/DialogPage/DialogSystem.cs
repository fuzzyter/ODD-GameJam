using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public Image illustrationImage;
    public Image backgroundImage;
    public Image BlackImage;
    public Button Choice01;
    public Button Choice02;
    public TextMeshProUGUI ChoiceText01;
    public TextMeshProUGUI ChoiceText02;

    public static int currentLineIndex = 0;
    private string Name;

    int first_print;

    int favo;
    int day;

    void Start()
    {
        first_print = 0;
        Name = PlayerPrefs.GetString("PlayerName");
        favo = PlayerPrefs.GetInt("favorability");
        day = PlayerPrefs.GetInt("day");
        Debug.Log(Name);

        if (CSVRead.doubleChatList != null && CSVRead.doubleChatList.Length > 0)
        {
            DisplayLine();
        }

        Choice01.onClick.AddListener(OnChoice01Clicked);
        Choice02.onClick.AddListener(OnChoice02Clicked);
    }

    void Update()
    {
        if(first_print == 0) { currentLineIndex++; DisplayLine(); first_print++; }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(currentLineIndex);
            if (currentLineIndex < CSVRead.doubleChatList.GetLength(0) - 1 && currentLineIndex != 64 && currentLineIndex != 83 && currentLineIndex != 99 && currentLineIndex != 114 && currentLineIndex != 148 && currentLineIndex != 184 && currentLineIndex != 195 && currentLineIndex != 223)
            {
                /*Debug.Log("인덱스++전"+currentLineIndex);
                currentLineIndex++;
                Debug.Log("인덱스++후"+currentLineIndex);*/
                if (currentLineIndex == 38)
                {
                    currentLineIndex--;
                    SceneControl.Instance.LoadScene("Main");
                }
                if (currentLineIndex == 70)
                {
                    favo += 5;
                    PlayerPrefs.SetInt("favorability", favo);
                    //currentLineIndex--;
                    currentLineIndex = 80;
                }
                if (currentLineIndex == 80)
                {
                    currentLineIndex--;
                    SceneControl.Instance.LoadScene("Main");
                }
                if (currentLineIndex == 88)
                {
                    favo += 5;
                    PlayerPrefs.SetInt("favorability", favo);
                    currentLineIndex = 97;
                }
                if (currentLineIndex == 97)
                {
                    currentLineIndex--;
                    SceneControl.Instance.LoadScene("Main");
                }
                if (currentLineIndex == 101)
                {
                    favo += 5;
                    PlayerPrefs.SetInt("favorability", favo);
                    currentLineIndex = 111;
                }
                if (currentLineIndex == 111)
                {
                    currentLineIndex--;
                    SceneControl.Instance.LoadScene("Main");
                }
                if (currentLineIndex == 119)
                {
                    favo += 5;
                    PlayerPrefs.SetInt("favorability", favo);
                    currentLineIndex = 130;
                }
                if (currentLineIndex == 130)
                {
                    currentLineIndex--;
                    SceneControl.Instance.LoadScene("Main");
                }
                if (currentLineIndex == 179)
                {
                    currentLineIndex--;
                    SceneControl.Instance.LoadScene("Main");
                }
                if (currentLineIndex == 190)
                {
                    currentLineIndex--;
                    SceneControl.Instance.LoadScene("Main");
                }
                if (currentLineIndex == 213)
                {
                    currentLineIndex--;
                    SceneControl.Instance.LoadScene("Main");
                }
                if (currentLineIndex == 231)
                {
                    currentLineIndex--;
                    SceneControl.Instance.LoadScene("Main");
                }
                
                //해피엔딩 스크립트 출력
                if (currentLineIndex == 232 && favo >= 100)
                {
                    Debug.Log(favo);
                    currentLineIndex = 234;
                }
                //히든엔딩 스크립트 출력
                else if (currentLineIndex == 232 && favo == 0 && day >= 30)
                {
                    Debug.Log(favo);
                    currentLineIndex = 253;
                }
                //배드엔딩 스크립트 출력
                else if (currentLineIndex == 232 && favo < 100 && day >= 30)
                {
                    Debug.Log(favo);
                    currentLineIndex = 243;
                }
                
                if (currentLineIndex == 241 || currentLineIndex == 250 || currentLineIndex == 262)
                {
                    SceneControl.Instance.LoadScene("Background");
                }
                

                Debug.Log("인덱스++전" + currentLineIndex+" "+favo);
                currentLineIndex++;
                Debug.Log("인덱스++후" + currentLineIndex + " " + favo);
                DisplayLine();
            }
        }
    }

    void DisplayLine()
    {
        string speakerName = CSVRead.doubleChatList[currentLineIndex, 1];
        string illustrationName = CSVRead.doubleChatList[currentLineIndex, 2];
        string dialogueLine = CSVRead.doubleChatList[currentLineIndex, 3];
        string ChoiceT01 = CSVRead.doubleChatList[currentLineIndex, 4];
        string ChoiceT02 = CSVRead.doubleChatList[currentLineIndex, 5];
        string backgroundName = CSVRead.doubleChatList[currentLineIndex, 6];

        if (speakerName == "남주")
        {
            nameText.text = Name;
        }
        else
        {
            nameText.text = speakerName;
        }
        if (dialogueLine == ". 내 이름이야.")
        {
            dialogueText.text = Name + dialogueLine;
        }
        else
        {
            dialogueText.text = dialogueLine;

        }
        ChoiceText01.text = ChoiceT01;
        ChoiceText02.text = ChoiceT02;

        Choice01.gameObject.SetActive(false);
        Choice02.gameObject.SetActive(false);


        // �Ϸ���Ʈ �̹����� ������Ʈ
        if (!string.IsNullOrEmpty(illustrationName))
        {
            illustrationImage.gameObject.SetActive(true);
            illustrationImage.sprite = Resources.Load<Sprite>(illustrationName);
        }
        else
        {
            illustrationImage.gameObject.SetActive(false);
        }

        // ��� �̹����� ������Ʈ
        if (!string.IsNullOrEmpty(backgroundName))
        {
            BlackImage.gameObject.SetActive(false);
            Debug.Log($"Loading background: {backgroundName}"); // Debug.Log �߰�
            Sprite backgroundSprite = Resources.Load<Sprite>(backgroundName);
            if (backgroundSprite != null)
            {
                backgroundImage.sprite = backgroundSprite;
            }
            else
            {
                Debug.LogError($"Background sprite not found: {backgroundName}");
            }
        }
        else
        {
            BlackImage.gameObject.SetActive(true);
            backgroundImage.sprite = null;
        }
       
        //�������� �����Ѵٸ� ����â/������� ǥ��
        if (!string.IsNullOrEmpty(ChoiceT01))
        {
            Debug.Log(ChoiceT01);
            Choice01.gameObject.SetActive(true);
            Choice02.gameObject.SetActive(true);
            ChoiceText01.gameObject.SetActive(true);
            ChoiceText02.gameObject.SetActive(true);
            BlackImage.gameObject.SetActive(true);


        }

        else //�������� �����̸� ����âX
        {
            Choice01.gameObject.SetActive(false);
            Choice02.gameObject.SetActive(false);
            ChoiceText01.gameObject.SetActive(false);
            ChoiceText02.gameObject.SetActive(false);
        }

       
    }

    // Choice01 버튼 클릭 시 호출될 메서드
    public void OnChoice01Clicked()
    {
        // Choice01 클릭 시 처리할 로직
        Debug.Log("Choice01 clicked");

        if(currentLineIndex > 130)
        {
            favo += 15;
            PlayerPrefs.SetInt("favorability", favo);
        }
        currentLineIndex++;
        DisplayLine();
    }

    // Choice02 버튼 클릭 시 호출될 메서드
    public void OnChoice02Clicked()
    {
        // Choice02 클릭 시 처리할 로직
        Debug.Log("Choice02 clicked");

        // currentLineIndex 값에 따라 다른 동작 수행
        if (currentLineIndex == 64)
        {
            Debug.Log("Choice02 63번째줄");
            // Choice02 클릭 시의 동작
            favo += 10;
            PlayerPrefs.SetInt("favorability", favo);
            currentLineIndex = 71;
        }
        else if (currentLineIndex == 83)
        {
            // Choice02 클릭 시의 다른 동작
            favo += 15;
            PlayerPrefs.SetInt("favorability", favo);
            currentLineIndex = 89;
        }
        else if (currentLineIndex == 99)
        {
            // Choice02 클릭 시의 다른 동작
            favo += 15;
            PlayerPrefs.SetInt("favorability", favo);
            currentLineIndex = 102;
        }
        else if (currentLineIndex == 114)
        {
            // Choice02 클릭 시의 다른 동작
            favo += 15;
            PlayerPrefs.SetInt("favorability", favo);
            currentLineIndex = 120;
        }
        else
        {
            favo += 5;
            PlayerPrefs.SetInt("favorability", favo);
            // 기본 동작
            currentLineIndex++;
        }
        DisplayLine();
    }
}
