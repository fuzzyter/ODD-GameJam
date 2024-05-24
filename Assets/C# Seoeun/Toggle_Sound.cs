using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle_Sound : MonoBehaviour
{
    public Button soundButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    //public int soundCondition;

    void Start()
    {
       // soundCondition = PlayerPrefs.GetInt("soundCondition");
       // soundButton.image.sprite = soundOnSprite;  // ÃÊ±â ÀÌ¹ÌÁö ¼³Á¤
        soundButton.onClick.AddListener(ToggleSound);
        /*if(soundCondition == 0)
            soundButton.image.sprite = soundOnSprite;
        else
            soundButton.image.sprite = soundOffSprite;
        PlayerPrefs.SetInt("soundCondition", soundCondition);*/
    }

    void ToggleSound()
    {
        if (AudioListener.volume > 0)
        {
            Debug.Log("À½¾Ç ²¨Áü");
            AudioListener.volume = 0;
            soundButton.image.sprite = soundOffSprite;
            //soundCondition = 1;
           // PlayerPrefs.SetInt("soundCondition", soundCondition);
        }
        else
        {
            Debug.Log("À½¾Ç ÄÑÁü");
            AudioListener.volume = 1;
            soundButton.image.sprite = soundOnSprite;
            //soundCondition = 0;
           // PlayerPrefs.SetInt("soundCondition", soundCondition);
        }
    }
}
