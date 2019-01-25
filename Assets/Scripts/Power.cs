using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] string currentPower = "Tornado";

    public void SetCurrentPower(string setPower)
    {
        currentPower = setPower;
    }

    public string GetSelectedPower()
    {
        return currentPower;
    }

    private void Update()
    {
        UsePower();
    }

    private void UsePower()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(Input.mousePosition + "  === Current power -> " + currentPower);
        }
    }
}
