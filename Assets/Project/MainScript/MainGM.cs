using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainGM : MonoBehaviour
{
    //����
    GameObject CharFace;

    // ��¥,  ��, �ɼ�
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI dayText;
    public int money;
    public int day;
    public int setting;
    public GameObject option;

    // ����
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

    // ��������, ����Ʈ ���� ���ȼ�ġ
    public int totStat;
    public int dateStatLimit;

    // ����Ʈ, �̴ϰ���, ȣ����
    public GameObject dateBtn;
    public GameObject miniGameBtn;
    public GameObject miniGameBtn2;
    public TextMeshProUGUI favorabilityText;
    public int favorability;
    public int miniGameCnt;

    // ������ ����, �ʱ�ȭ ����
    public int runOnlyOnce;

    // ���� ���� ��ġ �� ����
    private int ramdomNo;
    public GameObject gamblePanel;

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
        /*if (runOnlyOnce == 0) { SaveDistroy(); }
        else PlayerPrefs.SetInt("runOnlyOnce", 0);*/
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

        //�ʱⰪ ����
        if (setting == 0)
        {
            day = 1;
            dateStatLimit = 12;
            setting++;
        }

        option.SetActive(false);
        gamblePanel.SetActive(false);

        

        MiniGameCheck();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString() + "��";
        dayText.text = day.ToString() + "/30";

        hairText.text =hair.ToString();
        skinText.text = skin.ToString();
        weightText.text =  weight.ToString();
        talkText.text =  talk.ToString();
        styleText.text =  style.ToString();
        favorabilityText.text = favorability.ToString();

        totStat = hair + skin + weight + talk + style;
    }

    //�˹�
    public void PartTimeJob()
    {
        money += 30000;
        day += 1;

    }


    //����
    public void Gambling()
    {
        ramdomNo = Random.Range(0, 3);
        switch (ramdomNo)
        {
            case 0: break;
            case 1: money += 15000; break;
            case 2: money += 60000; break;
        }

        gamblePanel.SetActive(false);
        day += 1;
    }

    public void GamebleOpen()
    {
        if (money >= 10000)
        {
            money -= 10000;
            gamblePanel.SetActive(true);
        }
        else Debug.Log("���� �����մϴ�.");
    }

    //����

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
        StatUp(ref hair, "�� �������� �� �ٸ� �ѵ�?", "�Ӹ��� ���ع��Ⱦ�!", "hair stop");
    }
    public void Skin()
    {
        StatUp(ref skin, "�����ϰ� ���������", "����Ư ��ģ�Ǻ�.", "skin stop");
    }
    public void Weight()
    {
        StatUp(ref weight, "���� ������ ������", "�Ϸ����� ġ�õ��� ������!", "Weight stop");
    }
    public void Talk()
    {
        StatUp(ref talk, "������ å�� �о��", "��Ʃ�� ��ۺ��鼭 �帳�� �����", "Talk stop");
    }
    public void Style()
    {
        StatUp(ref style, "�̰� ���� �����ϴ� ��Ÿ��?", "������ ����� �� �̻ڴ�", "Style stop");
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
            Debug.Log("���� ������ " + dateStatLimit + "�� �̻��Ͻ� �����մϴ�.");
    }

    public void MiniGameCheck()
    {
        if (favorability >= 80 && miniGameCnt == 1)
        {
            dateBtn.SetActive(false);
            miniGameBtn.SetActive(false);
            miniGameBtn2.SetActive(true);
        }
        else if (favorability >= 40 && miniGameCnt == 0)
        {
            dateBtn.SetActive(false);
            miniGameBtn2.SetActive(false);
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

    // �ɼ� â
    public void OptionOpen()
    {
        option.SetActive(true);
    }
    public void OptionClose()
    {
        option.SetActive(false);
    }

    public void OptionSave()
    {
        int savePoint0 = PlayerPrefs.GetInt("Is_money");
        int savePoint1 = PlayerPrefs.GetInt("Is_day");
        int savePoint2 = PlayerPrefs.GetInt("Is_hair");
        int savePoint3 = PlayerPrefs.GetInt("Is_skin");
        int savePoint4 = PlayerPrefs.GetInt("Is_weight");
        int savePoint5 = PlayerPrefs.GetInt("Is_talk");
        int savePoint6 = PlayerPrefs.GetInt("Is_style");
        int savePoint7 = PlayerPrefs.GetInt("Is_dateStatLimit");
        int savePoint8 = PlayerPrefs.GetInt("Is_favorability");
        int savePoint9 = PlayerPrefs.GetInt("Is_miniGameCnt");
        int savePoint10 = PlayerPrefs.GetInt("Is_dateStatLimit");
        int savePoint11 = PlayerPrefs.GetInt("Is_setting");

        PlayerPrefs.SetInt("Is_money", money);
        PlayerPrefs.SetInt("Is_day", day);
        PlayerPrefs.SetInt("Is_hair", hair);
        PlayerPrefs.SetInt("Is_skin", skin);
        PlayerPrefs.SetInt("Is_weight", weight);
        PlayerPrefs.SetInt("Is_talk", talk);
        PlayerPrefs.SetInt("Is_style", style);
        PlayerPrefs.SetInt("Is_dateStatLimit", dateStatLimit);
        PlayerPrefs.SetInt("Is_favorability", favorability);
        PlayerPrefs.SetInt("Is_miniGameCnt", miniGameCnt);
        PlayerPrefs.SetInt("Is_dateStatLimit", dateStatLimit);
        PlayerPrefs.SetInt("Is_setting", setting);
    }

    public void OptionLoad()
    {
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("Is_money"));
        PlayerPrefs.SetInt("day", PlayerPrefs.GetInt("Is_day"));
        PlayerPrefs.SetInt("hair", PlayerPrefs.GetInt("Is_hair"));
        PlayerPrefs.SetInt("skin", PlayerPrefs.GetInt("Is_skin"));
        PlayerPrefs.SetInt("weight", PlayerPrefs.GetInt("Is_weight"));
        PlayerPrefs.SetInt("talk", PlayerPrefs.GetInt("Is_talk"));
        PlayerPrefs.SetInt("style", PlayerPrefs.GetInt("Is_style"));
        PlayerPrefs.SetInt("dateStatLimit", PlayerPrefs.GetInt("Is_dateStatLimit"));
        PlayerPrefs.SetInt("favorability", PlayerPrefs.GetInt("Is_favorability"));
        PlayerPrefs.SetInt("miniGameCnt", PlayerPrefs.GetInt("Is_miniGameCnt"));
        PlayerPrefs.SetInt("dateStatLimit", PlayerPrefs.GetInt("Is_dateStatLimit"));
        PlayerPrefs.SetInt("setting", PlayerPrefs.GetInt("Is_setting"));
        //Start();//lock (this) { }
        SceneManager.LoadScene("Main");
    }

    public void OptionTitle()
    {
        SceneManager.LoadScene("Background");
    }

    public void OptionQuit()
    {
        SaveDistroy();
        // �����Ϳ��� ���� ������ Ȯ�� (�����Ϳ��� ���� �׽�Ʈ�� ���� �ʿ�)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ����� ���ӿ��� ������ �����մϴ�.
        Application.Quit();
#endif
    }

    
}