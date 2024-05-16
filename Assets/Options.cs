using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Options : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 이 메소드를 UI 버튼에 연결
    public void ToggleAudio()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            Debug.Log("음악 켜짐");  // 볼륨이 0에서 1로 바뀌면 "음악 켜짐" 로그 출력
        }
        else
        {
            AudioListener.volume = 0;
            Debug.Log("음악 꺼짐");  // 볼륨이 1에서 0으로 바뀌면 "음악 꺼짐" 로그 출력
        }
    }

    public void OnClickMain()
    {
        Debug.Log("메인으로 돌아가기");
        SceneManager.LoadScene("Background");
    }
}
