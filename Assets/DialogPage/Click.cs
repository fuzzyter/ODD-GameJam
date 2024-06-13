using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioClip clickSound; // ����� ����� Ŭ��
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource ������Ʈ�� ã�� �� �����ϴ�.");
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
