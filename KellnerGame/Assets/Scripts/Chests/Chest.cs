using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Pickup pickup;

    public GameObject item;
    public Transform Dest;

    bool isPlayer = false;

    float distance;

    void Update()
    {

            distance = Vector3.Distance(item.transform.position, Dest.transform.position);
            if (distance > 1f)
            {
                item.transform.position = Dest.position;
            }

        if(isPlayer == true)
        {
            if(pickup.isHolding == false)
            {
                if(Input.GetKey(KeyCode.E))
                {
                    Debug.Log("ja");
                    SpawnItem();
                }
            } 
            else
            {
                if (Input.GetKey(KeyCode.E))
                {
                    DropItem();
                }
            }
        }
    }

    void SpawnItem()
    {
        pickup.isHolding = true;

        GameObject.Instantiate(item.gameObject);
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;

        item.transform.position = Dest.position;
        item.transform.parent = Dest.transform;

    }

    void DropItem()
    {
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayer = true;
        }
    }

}
