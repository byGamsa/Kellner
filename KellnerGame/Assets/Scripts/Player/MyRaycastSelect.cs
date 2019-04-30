using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRaycastSelect : RaycastSelect
{

    Interactable Interactable;

    protected override void OnRaycastEnter(GameObject target)
    {
        if (target.tag == "Interactable")
        {
            Debug.Log("...");
        }
    }

    protected override void OnRaycastLeave(GameObject target)
    {

    }

}
