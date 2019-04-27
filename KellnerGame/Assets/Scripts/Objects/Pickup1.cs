using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup1 : MonoBehaviour
{
    float throwForce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public Transform Dest;
    public GameObject item;
    public bool isHolding = false;

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(item.transform.position, Dest.transform.position);
        Debug.Log(distance);

        if(isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.position = Dest.position;
            item.transform.parent = GameObject.Find("ItemDestination").transform;

        }
        else
        {
            objectPos = item.transform.position;
            item.transform.parent = null;
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    void OnMouseDown()
    {
        if (distance <= 3f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }

    void OnMouseUp()
    {
        isHolding = false;
    }
}
