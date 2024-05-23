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
        soundButton.image.sprite = soundOnSprite;  // �ʱ� �̹��� ����
        soundButton.onClick.AddListener(ToggleSound);
    }

    void ToggleSound()
    {
        if (AudioListener.volume > 0)
        {
            Debug.Log("���� ����");
            AudioListener.volume = 0;
            soundButton.image.sprite = soundOffSprite;
        }
        else
        {
            Debug.Log("���� ����");
            AudioListener.volume = 1;
            soundButton.image.sprite = soundOnSprite;
        }
    }
}
