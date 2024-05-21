using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CharChange : MonoBehaviour
{
    //ø©¡÷
    public Sprite[] face;
    GameObject fov;
    int favorability;
    public void Start()
    {
        fov = GameObject.Find("GameManager");
        favorability = fov.GetComponent<MainGM>().favorability;
        ChangeFace();
    }
    public void ChangeFace()
    {
        if (60 < favorability)
            GetComponent<Image>().sprite = face[3];
        else if (40 < favorability)
            GetComponent<Image>().sprite = face[2];
        else if (20 < favorability)
            GetComponent<Image>().sprite = face[1];
        else
            GetComponent<Image>().sprite = face[0];

    }
}
