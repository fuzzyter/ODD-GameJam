using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    public GameObject itemPrefab;
    //���ݸ� ���� ����
    //public int choco;
    /*
    private void Start()
    {
        choco = 5;

    }
    */
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            Vector3 initPos = transform.position;
            Quaternion initRot = Quaternion.identity;

            if (itemPrefab != null)
            {
                GameObject newItem = (GameObject)Instantiate(itemPrefab, initPos, initRot);
                newItem.GetComponent<Item_Control>().Point = Random.Range(0,100);
            }
            BlockGameManager.Instance.OnChocoDestroyed();
            Destroy(this.gameObject);
        }
      
    }
}
