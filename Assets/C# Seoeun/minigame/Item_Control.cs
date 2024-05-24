using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Control : MonoBehaviour
{

    private float rotSpeed = 180.0f;
    private Transform myTr;
    private Collider myColor;
    private int point = 0;
    public int Point
    {
        set { point = value; }
        get { return point; }
    }

    // Use this for initialization
    void Start()
    {
        myTr = GetComponent<Transform>();
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 150.0f);

        //���� ���� ����
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            float r = Random.Range(0f, 1f); // 0�� 1 ������ ���� ��
            float g = Random.Range(0f, 1f); // 0�� 1 ������ ���� ��
            float b = Random.Range(0f, 1f); // 0�� 1 ������ ���� ��
            renderer.material.color = new Color(r, g, b); // RGB ���� ����Ͽ� ���� ����
        }

    }

    // Update is called once per frame
    void Update()
    {
        myTr.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BlockGameManager.Instance.Point += point;
            Destroy(this.gameObject);
        }
    }
}
