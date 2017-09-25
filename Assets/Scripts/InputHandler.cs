using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : Singleton<InputHandler> {

    //List of keys for each input
    public List<string> jumpKeys, leftKeys, rightKeys;
    
    public float movement = 0f;
    public bool jump = false;
    public bool stopJump = false;
    bool wasJumping;

	void Update () {

        wasJumping = jump;
        //Reset variables
        movement = 0f;
        jump = false;
        stopJump = false;

        //Desktop controls
        if (CheckInput(jumpKeys))
        {
            jump = true;
        }
        if (CheckInput(leftKeys))
        {
            movement = -1f;
        }
        if (CheckInput(rightKeys))
        {
            movement = 1f;
        }

        //Mobile controls
        if (GameManager.instance)
        {
            if (GameManager.instance.mobileControls)
            {
                if (Input.GetButton("Fire1"))
                {
                    if (Input.mousePosition.x < Screen.width / 2)
                    {
                        movement = Input.mousePosition.x < Screen.width / 4 ? -1f : 1f;
                    }
                    else if (Input.mousePosition.x < Screen.width * .75)
                    {
                        movement = 1f;
                    }
                    else
                    {
                        jump = true;
                    }
                }
                foreach (var touch in Input.touches)
                {
                    if (touch.position.x < Screen.width / 2)
                    {
                        movement = touch.position.x < Screen.width / 4 ? -1f : 1f;
                    }
                    else if (touch.position.x < Screen.width * .75)
                    {
                        movement = 1f;
                    }
                    else
                    {
                        jump = true;
                    }
                }
            }
        }
        if(wasJumping && !jump)
        {
            stopJump = true;
        }
    }

    public bool CheckInput(List<string> keys)
    {
        foreach (var key in keys)
        {
            if (Input.GetKey(key)) return true;
        }
        return false;
    }

    public bool CheckInputDown(List<string> keys)
    {
        foreach (var key in keys)
        {
            if (Input.GetKeyDown(key)) return true;
        }
        return false;
    }

    public bool CheckInputUp(List<string> keys)
    {
        foreach (var key in keys)
        {
            if (Input.GetKeyUp(key)) return true;
        }
        return false;
    }
}
