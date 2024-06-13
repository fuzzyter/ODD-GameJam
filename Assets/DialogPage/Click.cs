using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioClip clickSound; // 재생할 오디오 클립
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource 컴포넌트를 찾을 수 없습니다.");
        }
        else
        {
            audioSource.clip = clickSound;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();

        }
    }
}
