using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockGameManager : MonoBehaviour
{
    private static BlockGameManager instance = null;
    private int chocoCount = 10;
    public static BlockGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameObject = new GameObject("BlockGameManager");
                instance = gameObject.AddComponent<BlockGameManager>();
            }
            return instance;
        }
    }
    
    public void OnChocoDestroyed()
    {
        chocoCount--;
        if (chocoCount == 0)
        {
            Debug.Log("Success! All chocolates are destroyed.");
            
            int PLUS = 20;
            PlayerPrefs.SetInt("PLUS", PLUS);        
            
            SceneManager.LoadScene("Main");

        }
    }
    private bool is_GameOver = false;

    public bool Is_GameOver
    {
        set { is_GameOver = value; }
        get { return is_GameOver; }
    }
    
    private int ballCount = 0;
    public int BallCount
    {
        set { ballCount = value; }
        get { return ballCount; }
    }

    public void OnBallCountSub()
    {
        ballCount--;
        if (ballCount <= 0)
        {
            is_GameOver = true;
        }
    }

    
    private int point = 0;
    public int Point
    {
        set { point = value; }
        get { return point; }
    }
    

    private void Awake()
    {
        instance = this;
    }
}
