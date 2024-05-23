using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anime : MonoBehaviour
{
    public Sprite[] PartTimeJobs;
    public Sprite[] Gambles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMotion()
    {
        gameObject.SetActive(true);
        StartCoroutine(JobMotion());
    }

    IEnumerator JobMotion()
    {
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < PartTimeJobs.Length; i++)
            {
                GetComponent<Image>().sprite = PartTimeJobs[i];
                yield return new WaitForSeconds(0.2f);
            }
        }
        gameObject.SetActive(false);
    }

    public void StartMotion2()
    {
        gameObject.SetActive(true);
        StartCoroutine(GambleMotion());
    }

    IEnumerator GambleMotion()
    {
            for (int i = 0; i < Gambles.Length; i++)
            {
                GetComponent<Image>().sprite = Gambles[i];
                yield return new WaitForSeconds(0.2f);
            }
        gameObject.SetActive(false);
    }
}
