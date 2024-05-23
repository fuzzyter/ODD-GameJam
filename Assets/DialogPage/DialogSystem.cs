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

    private int currentLineIndex = 0;

    void Start()
    {/*
        // 이전 진행 상황이 저장되어 있으면 불러오기
        if (PlayerPrefs.HasKey("CurrentLineIndex"))
        {
            currentLineIndex = PlayerPrefs.GetInt("CurrentLineIndex");
        }
        */
        if (CSVRead.doubleChatList != null && CSVRead.doubleChatList.Length > 0)
        {
            DisplayLine();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentLineIndex < CSVRead.doubleChatList.GetLength(0) - 1)
            {
                currentLineIndex++;
                DisplayLine();
            }
        }
    }
    /*
    void OnDisable()
    {
        // 진행 상황 저장
        PlayerPrefs.SetInt("CurrentLineIndex", currentLineIndex);
        PlayerPrefs.Save();
    }*/

    void DisplayLine()
    {
        string speakerName = CSVRead.doubleChatList[currentLineIndex, 1];
        string illustrationName = CSVRead.doubleChatList[currentLineIndex, 2];
        string dialogueLine = CSVRead.doubleChatList[currentLineIndex, 3];
        string ChoiceT01 = CSVRead.doubleChatList[currentLineIndex, 4];
        string ChoiceT02 = CSVRead.doubleChatList[currentLineIndex, 5];
        string backgroundName = CSVRead.doubleChatList[currentLineIndex, 6];

        nameText.text = speakerName;
        dialogueText.text = dialogueLine;
        ChoiceText01.text = ChoiceT01;
        ChoiceText02.text = ChoiceT02;

        Choice01.gameObject.SetActive(false);
        Choice02.gameObject.SetActive(false);

        // 일러스트 이미지를 업데이트
        if (!string.IsNullOrEmpty(illustrationName))
        {
            illustrationImage.gameObject.SetActive(true);
            illustrationImage.sprite = Resources.Load<Sprite>(illustrationName);
        }
        else
        {
            illustrationImage.gameObject.SetActive(false);
        }

        // 배경 이미지를 업데이트
        if (!string.IsNullOrEmpty(backgroundName))
        {
            BlackImage.gameObject.SetActive(false);
            Debug.Log($"Loading background: {backgroundName}"); // Debug.Log 추가
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
       
        //선택지가 존재한다면 선택창/검은배경 표시
        if (!string.IsNullOrEmpty(ChoiceT01))
        {
            Debug.Log(ChoiceT01);
            Choice01.gameObject.SetActive(true);
            Choice02.gameObject.SetActive(true);
            ChoiceText01.gameObject.SetActive(true);
            ChoiceText02.gameObject.SetActive(true);
            BlackImage.gameObject.SetActive(true);


        }

        else //선택지가 공란이면 선택창X
        {
            Choice01.gameObject.SetActive(false);
            Choice02.gameObject.SetActive(false);
            ChoiceText01.gameObject.SetActive(false);
            ChoiceText02.gameObject.SetActive(false);
        }

        //선택지내용넣는코드ㅡㅡ
        //선택지따라코드건너뛰기(인덱스번호 이용)(이 코드에 클릭이벤트 추가)

        //변수따라 다른csv실행(이거는 dialogsystem, csvread수정) 
        //선택지 고르면 호감도 리턴(이건근데 코드끝나고 해도 되려나?)
     
    }
}