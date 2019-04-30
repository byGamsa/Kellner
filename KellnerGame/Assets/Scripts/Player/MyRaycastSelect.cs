using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRaycastSelect : RaycastSelect
{


    protected override void OnRaycastEnter(GameObject target)
    {
        if (target.tag == "Interactable")
        {
            Debug.Log(target);
        }
    }

    protected override void OnRaycastLeave(GameObject target)
    {

    }

}
