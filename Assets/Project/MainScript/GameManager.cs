using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;


using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI dayText;
    public int money;
    public int day;
    public int setting;

    public int hair;
    public int skin;
    public int weight;
    public int talk;
    public int style;
    public TextMeshProUGUI hairText;
    public TextMeshProUGUI skinText;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI talkText;
    public TextMeshProUGUI styleText;

    public int totStat;
    public int dateStatLimit;

    public GameObject dateBtn;
    public GameObject miniGameBtn;
    public GameObject miniGameBtn2;
    public TextMeshProUGUI favorabilityText;
    public int favorability;
    public int miniGameCnt;


    public int runOnlyOnce;

    private int ramdomNo;

    public void Save()
    {
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("day", day);
        PlayerPrefs.SetInt("hair", hair);
        PlayerPrefs.SetInt("skin", skin);
        PlayerPrefs.SetInt("weight", weight);
        PlayerPrefs.SetInt("talk", talk);
        PlayerPrefs.SetInt("style", style);
        PlayerPrefs.SetInt("dateStatLimit", dateStatLimit);
        PlayerPrefs.SetInt("favorability", favorability);
        PlayerPrefs.SetInt("miniGameCnt", miniGameCnt);
        PlayerPrefs.SetInt("dateStatLimit", dateStatLimit);
        PlayerPrefs.SetInt("setting", setting);
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
    }

    // Start is called before the first frame update
    void Start()
    {
        runOnlyOnce = PlayerPrefs.GetInt("runOnlyOnce");
        if (runOnlyOnce == 0) { SaveDistroy(); }
        else PlayerPrefs.SetInt("runOnlyOnce", 0);
        money = PlayerPrefs.GetInt("money");
        day = PlayerPrefs.GetInt("day");
        setting = PlayerPrefs.GetInt("setting");

        hair = PlayerPrefs.GetInt("hair");
        skin = PlayerPrefs.GetInt("skin");
        weight = PlayerPrefs.GetInt("weight");
        talk = PlayerPrefs.GetInt("talk");
        style = PlayerPrefs.GetInt("style");
        dateStatLimit = PlayerPrefs.GetInt("dateStatLimit");
        favorability = PlayerPrefs.GetInt("favorability");
        miniGameCnt = PlayerPrefs.GetInt("miniGameCnt");

        //초기값 설정
        if (setting == 0)
        {
            day = 1;
            dateStatLimit = 12;
            setting++;
        }

        MiniGameCheck();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString() + "￦";
        dayText.text = "Day " + day.ToString() + "/30";

        hairText.text = "헤어 : " + hair.ToString();
        skinText.text = "피부 : " + skin.ToString();
        weightText.text = "체중 : " + weight.ToString();
        talkText.text = "대화 : " + talk.ToString();
        styleText.text = "스타일 : " + style.ToString();
        favorabilityText.text = "호감도 " + favorability.ToString() + "/100";

        totStat = hair + skin + weight + talk + style;
    }

    //알바
    public void PartTimeJob()
    {
        money += 30000;
        day += 1;

    }

    //도박
    public void Gambling()
    {
        if (money >= 10000)
        {
            money -= 10000;

            ramdomNo = Random.Range(0, 3);
            switch (ramdomNo)
            {
                case 0: break;
                case 1: money += 15000; break;
                case 2: money += 60000; break;
            }

            day += 1;
        }
    }

    //스탯

    public void StatUp(ref int stat, string goodMsg, string badMsg, string stopMsg)
    {
        if (money >= 10000 && stat < 20)
        {
            money -= 10000;

            ramdomNo = Random.Range(0, 5);
            stat += ramdomNo;

            if (ramdomNo >= 2)
                Debug.Log(goodMsg);
            else
                Debug.Log(badMsg);
            if (stat > 20)
                stat = 20;
        }
        else
        {
            Debug.Log(stopMsg);
        }
    }



    public void Hair()
    {
        StatUp(ref hair, "나 이정도면 봐 줄만 한데?", "머리가 망해버렸어!", "hair stop");
    }
    public void Skin()
    {
        StatUp(ref skin, "촉촉하게 만들어주지", "상남자특 거친피부.", "skin stop");
    }
    public void Weight()
    {
        StatUp(ref weight, "오늘 저녁은 샐러드", "하루정돈 치팅데이 괜찮아!", "Weight stop");
    }
    public void Talk()
    {
        StatUp(ref talk, "오늘은 책을 읽어볼까", "유튜브 댓글보면서 드립을 배우자", "Talk stop");
    }
    public void Style()
    {
        StatUp(ref style, "이게 요즘 유행하는 스타일?", "엄마가 골라준 옷 이쁘당", "Style stop");
    }

    public void SelectDateScenes()
    {
        if (totStat >= dateStatLimit)
        {
            PlayerPrefs.SetInt("runOnlyOnce", 1);
            dateStatLimit += 12;
            Save();
            SceneManager.LoadScene("Date");
        }
        else
            Debug.Log("스탯 총합이 " + dateStatLimit + "점 이상일시 가능합니다.");
    }

    public void MiniGameCheck()
    {
        if (favorability >= 80 && miniGameCnt == 1)
        {
            dateBtn.SetActive(false);
            miniGameBtn2.SetActive(true);
        }
        else if (favorability >= 40 && miniGameCnt == 0)
        {
            dateBtn.SetActive(false);
            miniGameBtn.SetActive(true);
        }
        else
        {
            dateBtn.SetActive(true);
            miniGameBtn.SetActive(false);
            miniGameBtn2.SetActive(false);
        }
    }

    public void SelectMiniGameScence()
    {
        miniGameCnt++;
        Save();
        SceneManager.LoadScene("MiniGame");
        MiniGameCheck();
    }
    public void SelectMiniGameScence2()
    {
        miniGameCnt++;
        Save();
        SceneManager.LoadScene("MiniGame2");
        MiniGameCheck();
    }



}