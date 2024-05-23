using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCONT : MonoBehaviour
{

    public Rigidbody myRigidbody;

    void Start()
    {
      // myRigidbody = GetComponent<Rigidbody>();
      // myRigidbody.AddForce(Vector3.up * 300.0f);
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameOverWall"))
        {
            BlockGameManager.Instance.OnBallCountSub();
            Destroy(this.gameObject);
        }
    }
}