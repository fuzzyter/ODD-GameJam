using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class MiniGM : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI timeTxt;
    public GameObject timeOverPanel;
    public GameObject gameStartPanel;
    public GameObject gameEndPanel;

    bool timeActive;


    //��
    public GameObject midRoom;
    public GameObject leftRoom;
    public GameObject rightRoom;

    public GameObject door;
    public GameObject character;

    //������
    public GameObject closedDrawer;
    public GameObject openedDrawer;

    //ã�� ����
    public GameObject item1; //�ڵ��� ����
    public GameObject item2; //����
    public GameObject item3; //mp3
    public GameObject item4; //���
    public GameObject item5; //����
    public GameObject item6; //����
    public GameObject item7; //å
    public GameObject item10;//����ƾ
    public GameObject item11;//ȭ��
    bool item_1;
    bool item_2;
    bool item_3;
    bool item_4;
    bool item_5;
    bool item_6;
    bool item_7;
    bool item_10;
    bool item_11;

    void Setting()
    {
        item_1 = false;
        item_2 = false;
        item_3 = false;
        item_4 = false;
        item_5 = false;
        item_6 = false;
        item_7 = false;
        item_10 = false;
        item_11 = false;

        timeActive = false;
        time = 10f;
        timeTxt.text = time.ToString("F2");
        timeOverPanel.SetActive(false);
        gameEndPanel.SetActive(false);
        leftRoom.SetActive(false);
        rightRoom.SetActive(false);
        character.SetActive(false);
        midRoom.SetActive(true);
        door.SetActive(true);
        gameStartPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Setting();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    public void GameStart()
    {
        gameStartPanel.SetActive(false);
        timeActive = true;
        
    }

    void Timer()
    {
        if (timeActive)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timeTxt.text = time.ToString("F2");
            } else { timeOverPanel.SetActive(true); }
        }
    }

    //�� �̵�
    public void LeftRoom()
    {
        midRoom.SetActive(false);
        rightRoom.SetActive(false);
        leftRoom.SetActive(true);
    }
    public void MidRoom()
    {
        midRoom.SetActive(true);
        rightRoom.SetActive(false);
        leftRoom.SetActive(false);
    }
    public void RightRoom()
    {
        midRoom.SetActive(false);
        rightRoom.SetActive(true);
        leftRoom.SetActive(false);
    }


    
    // ��� �� �� Ŭ���� ����
    public void DoorOpen()
    {
        if(item_1 == true && item_2 == true && item_3 == true && item_4 == true)
        {
            timeActive = false;
            door.SetActive(false);
            character.SetActive(true);
            gameEndPanel.SetActive(true);
        }
        else
            Debug.Log("������ �� ã������.");
    }

    //���� ã��
    void GetItem(ref GameObject item, ref bool getItem)
    {
        item.SetActive(false);
        getItem = true;
    }

    //������
    public void DrawerOpen()
    {
        closedDrawer.SetActive(false);
        openedDrawer.SetActive(true);
    }
    public void DrawerClose()
    {
        closedDrawer.SetActive(true);
        openedDrawer.SetActive(false);
    }
    public void Item1() { GetItem(ref item1, ref item_1); }
    public void Item2() { GetItem(ref item2, ref item_2); }
    public void Item3() { GetItem(ref item3, ref item_3); }
    public void Item4() { GetItem(ref item4, ref item_4); }


    public void RePlay()
    {
        SceneManager.LoadScene("MiniGame2");
    }

    public void GoMain()
    {
        SceneManager.LoadScene("Main");
    }

}
