using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Transform tr;
    public float speed = 5.0f;

    public GameObject ballPrefab;

    public Transform newBallTr;

    public bool is_Shoot = false;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        OnNewBall();
    }
    
    public void OnNewBall()
    {
        Vector3 initPos = tr.position + Vector3.up * 1.2f;
        Quaternion initRot = Quaternion.identity;
        GameObject newBall = (GameObject)Instantiate(ballPrefab, initPos, initRot);
        newBallTr = newBall.GetComponent<Transform>();

        BlockGameManager.Instance.BallCount += 1;
    }
    
    // Update is called once per frame
    void Update()
    {

        if (BlockGameManager.Instance.Is_GameOver) return;
        OnMove();
        OnShoot();
    }
    public void OnMove()
    {
        // 왼쪽으로 이동
        if (Input.GetKey(KeyCode.A))
        {
            tr.Translate(Vector3.left * speed * Time.deltaTime);
        }
        // 오른쪽으로 이동
        if (Input.GetKey(KeyCode.D))
        {
            tr.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    // 스페이스 바로 발사
    public void OnShoot()
    {
        if (!is_Shoot)
        {
            newBallTr.position = tr.position + Vector3.up * 1.2f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rigidbody ballRigidbody = newBallTr.GetComponent<Rigidbody>();
                if (ballRigidbody != null)
                {
                    is_Shoot = true;
                    ballRigidbody.AddForce(Vector3.up * 150.0f);
                }
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // 반사각 계산
        if (collision.gameObject.CompareTag("BALL"))
        {
            Vector3 reflect = collision.transform.position - tr.position;
            float result = 0.0f;

            if (reflect.x > 0)
            {
                result = 1.0f;
            }
            else if (reflect.x < 0)
            {
                result = -1.0f;
            }

            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(75.0f * result, 50.0f, 0.0f));
        }
    }
}
