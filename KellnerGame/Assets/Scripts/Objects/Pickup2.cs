using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public Transform Dest;
    public GameObject Object;

    void OnMouseDown()
    {
        Object.GetComponent<BoxCollider>().enabled = false;
        Object.GetComponent<Rigidbody>().useGravity = false;
        Object.transform.position = Dest.position;
        Object.transform.parent = GameObject.Find("ItemDestination").transform;
    }

    void OnMouseUp()
    {
        Object.transform.parent = null;
        Object.GetComponent<Rigidbody>().useGravity = true;
        Object.GetComponent<BoxCollider>().enabled = true;
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
        }
    }
}
