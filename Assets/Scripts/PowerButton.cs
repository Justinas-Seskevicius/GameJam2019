using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
    [SerializeField] string powerName;

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<PowerButton>();
        foreach (PowerButton button in buttons)
        {
            button.GetComponent<MeshRenderer>().material.color = new Color32(89, 89, 89, 255);
        }
        GetComponent<MeshRenderer>().material.color = Color.white;
        FindObjectOfType<Power>().SetCurrentPower(powerName);
    }
}
