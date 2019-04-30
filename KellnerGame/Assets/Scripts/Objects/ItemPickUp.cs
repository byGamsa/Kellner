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
    public GameObject Player;

    void Update()
    {
        distance = Vector3.Distance(this.transform.position, Dest.transform.position);

        if (distance <= 3f)
        {
            playerHold();

            if (isHolding == true)
            {
                if (distance >= 1f)
                {
                    this.transform.position = Dest.position;
                    this.transform.rotation = Dest.rotation;
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }

            }

            if (drag == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    isHolding = true;
                    this.GetComponent<Rigidbody>().useGravity = false;
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    this.GetComponent<Rigidbody>().freezeRotation = true;
                    this.transform.position = Dest.position;
                    this.transform.rotation = Dest.rotation;
                    this.transform.parent = Dest.transform;
                    drag = false;
                    StartCoroutine(Delay1());
                }
            }

            if (drop == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    this.transform.parent = null;
                    this.GetComponent<Rigidbody>().useGravity = true;
                    this.GetComponent<Rigidbody>().freezeRotation = false;
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
            this.transform.parent = null;
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Rigidbody>().freezeRotation = false;
            drop = false;
            isHolding = false;
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
