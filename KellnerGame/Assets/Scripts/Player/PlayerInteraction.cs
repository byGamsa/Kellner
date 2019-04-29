using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        {
            Vector3 playerPostion = transform.position;
            Vector3 forwardDirection = transform.forward;

            Ray interactionRay = new Ray(playerPostion, forwardDirection);
            RaycastHit interactionRayHit;
            float interactionRayLength = 5.0f;

            Vector3 interactionRayEndpoint = forwardDirection * interactionRayLength;
            Debug.DrawLine(playerPostion, interactionRayEndpoint);

            bool hitFound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength);
            if (hitFound)
            {
                GameObject hitGameObject = interactionRayHit.transform.gameObject;
                string hitFeedback = hitGameObject.name;
                Debug.Log(hitFeedback);
            }
            else
            {
                string nothingFeedback = "-";
                Debug.Log(nothingFeedback);
            }

        }
    }
}
