using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Option_Panel : MonoBehaviour
{
   // public GameObject optionPanel;
    // Start is called before the first frame update
    void Start()
    {
       // optionPanel = GameObject.FindWithTag("TitleOptionPanel");
       // optionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void OnClickMain()
    {
        Debug.Log("메인으로 돌아가기");

        // optionPanel.SetActive(false);
        SceneManager.LoadScene("background");
    }


}
