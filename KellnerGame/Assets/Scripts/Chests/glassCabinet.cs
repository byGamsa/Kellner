using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassCabinet : MonoBehaviour
{
    Vector3 objectPos;
    bool isPlayer = false;
    bool hasItem = false;
    float distance;

    GameObject myInstance;
         
    public Transform Dest;
    public GameObject item;
    public GameObject chest;

    private void Update()
    {
        if (hasItem == true)
        {
            distance = Vector3.Distance(item.transform.position, Dest.transform.position);
            if (distance > 1f)
            {
                item.transform.position = Dest.position;
            }
        }

        if (isPlayer == true)
        {
            if(Input.GetKey(KeyCode.E))
            {
                if(hasItem == false)
                {
                    SpawnItem();
                }
                    
            }
        }

    }

    void SpawnItem()
    {
        hasItem = true;
        myInstance = GameObject.Instantiate(item.gameObject); 
        myInstance.GetComponent<Rigidbody>().useGravity = false;
        myInstance.GetComponent<Rigidbody>().detectCollisions = true;
        myInstance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        myInstance.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        myInstance.transform.position = Dest.position;
        myInstance.transform.parent = Dest.transform;

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }
    }
}
