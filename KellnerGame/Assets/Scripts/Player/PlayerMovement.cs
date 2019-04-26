using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed = 5f;
    public float RotateSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        transform.Translate(0f , 0f, MoveSpeed * Time.deltaTime * ver);
        transform.Rotate(0, RotateSpeed * Input.GetAxis("Horizontal"), 0);
    }
}
