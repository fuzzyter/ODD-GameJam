using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverControl : MonoBehaviour
{
   
    public Image overImg;

    void Start()
    {
        //overImg = GetComponent<Image>();
        //overImg.enabled =false;
    }

    void Update()
    {
        if (BlockGameManager.Instance.Is_GameOver && !overImg.enabled)
        {
            overImg.enabled = true; 
        }
    }
}

