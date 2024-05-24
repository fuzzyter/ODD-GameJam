using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameManager : MonoBehaviour
{
    private static BlockGameManager instance = null;

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
