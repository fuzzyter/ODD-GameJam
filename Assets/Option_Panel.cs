using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log("�������� ���ư���");
        SceneManager.LoadScene("Background");
    }

    // �� �޼ҵ带 UI ��ư�� ����
    public void ToggleAudio()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            Debug.Log("���� ����");  // ������ 0���� 1�� �ٲ�� "���� ����" �α� ���
        }
        else
        {
            AudioListener.volume = 0;
            Debug.Log("���� ����");  // ������ 1���� 0���� �ٲ�� "���� ����" �α� ���
        }
    }
}
