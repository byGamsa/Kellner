using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public Transform Dest;
    public GameObject Object;

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Object.GetComponent<Rigidbody>().useGravity = false;
            Object.transform.position = Dest.position;
            Object.transform.parent = GameObject.Find("ItemDestination").transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
        }
    }
}
