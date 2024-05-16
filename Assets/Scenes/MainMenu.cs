using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickNewGame()
    {
        Debug.Log("Start");// 현재는 다음 씬이 없어서 
    }
    public void OnClickLoad()
    {
        Debug.Log("Continue");
    }
    public void OnClickOption()
    {
        Debug.Log("Settings");
    }
    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 버튼을 누르면 게임이 종료되도록
#endif
    }
}
