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
        Debug.Log("Start");// ����� ���� ���� ��� 
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
        Application.Quit(); // ��ư�� ������ ������ ����ǵ���
#endif
    }
}
