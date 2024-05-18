using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Option_Panel : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void OnClickMain()
    {
        Debug.Log("메인으로 돌아가기");
        SceneManager.LoadScene("Background");
    }


}
