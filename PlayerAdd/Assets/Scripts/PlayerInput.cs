using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;

    private string horizontalAxis;
    private string verticalAxis;
    private string aButton;
    private string bButton;
    private string triggerAxis;
    private int controllerNumber;

    public float Horizontal { get; set; }
    public float Thrust { get; set; }

    public bool OverrideA { get; set; }
    public bool OverrideB { get; set; }

    private bool IsBot {  get { return controllerNumber < 1; } }

    public enum Button
    {
        A,
        B,
    }

    internal bool ButtonIsDown(Button button)
    {
        switch(button)
        {
            case Button.A:
                return IsBot ? OverrideA : Input.GetButton(aButton);
            case Button.B:
                return IsBot ? OverrideB : Input.GetButton(bButton);
        }

        return false;
    }

    internal void SetControllerNumber(int number)
    {
        controllerNumber = number;
        horizontalAxis = "J" + controllerNumber + "Horizontal";
        verticalAxis = "J" + controllerNumber + "Vertical";
        aButton = "J" + controllerNumber + "A";
        bButton = "J" + controllerNumber + "B";
        triggerAxis = "J" + controllerNumber + "Trigger";
    }

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (controllerNumber > 0)
        {
            Horizontal = Input.GetAxis(horizontalAxis);
            Thrust = Input.GetAxis(verticalAxis);
        }
    }
}
