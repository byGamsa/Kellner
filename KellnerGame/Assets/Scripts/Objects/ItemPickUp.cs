using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    float distance;

    bool drag = false;
    bool drop = false;
    bool isHolding = false;

    public bool canHold = true;

    public Transform Dest;
    public GameObject item;
    public GameObject Player;

    void Update()
    {

        distance = Vector3.Distance(item.transform.position, Dest.transform.position);

        if (distance <= 3f)
        {
            playerHold();

            if (isHolding == true)
            {
                if (distance >= 1f)
                {
                    item.transform.position = Dest.position;
                    item.transform.rotation = Dest.rotation;
                    item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }

            }

            if (drag == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    isHolding = true;
                    item.GetComponent<Rigidbody>().useGravity = false;
                    item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    item.GetComponent<Rigidbody>().freezeRotation = true;
                    item.transform.position = Dest.position;
                    item.transform.rotation = Dest.rotation;
                    item.transform.parent = Dest.transform;
                    drag = false;
                    StartCoroutine(Delay1());
                }
            }

            if (drop == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    item.transform.parent = null;
                    item.GetComponent<Rigidbody>().useGravity = true;
                    item.GetComponent<Rigidbody>().freezeRotation = false;
                    drop = false;
                    StartCoroutine(Delay2());
                }
            }
        }
    }
    void playerHold()
    {
        if (isHolding == false)
        {
            if (canHold == true)
            {
                drag = true;
            }
        }
        else
        {
            item.transform.parent = null;
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().freezeRotation = false;
            drop = false;
            StartCoroutine(Delay2());
        }
    }

    IEnumerator Delay1()
    {
        yield return new WaitForSeconds(2);
        drop = true;
        yield return null;
    }

    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(2);
        isHolding = false;
        yield return null;
    }
}
