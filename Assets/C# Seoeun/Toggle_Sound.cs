using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle_Sound : MonoBehaviour
{
    public Button soundButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    void Start()
    {
        soundButton.image.sprite = soundOnSprite;  // ÃÊ±â ÀÌ¹ÌÁö ¼³Á¤
        soundButton.onClick.AddListener(ToggleSound);
    }

    void ToggleSound()
    {
        if (AudioListener.volume > 0)
        {
            Debug.Log("À½¾Ç ²¨Áü");
            AudioListener.volume = 0;
            soundButton.image.sprite = soundOffSprite;
        }
        else
        {
            Debug.Log("À½¾Ç ÄÑÁü");
            AudioListener.volume = 1;
            soundButton.image.sprite = soundOnSprite;
        }
    }
}
