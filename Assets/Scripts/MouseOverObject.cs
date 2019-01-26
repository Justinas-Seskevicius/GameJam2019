using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverObject : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float transperancy = 0.7f;
    Renderer currentObjectRenderer;
    Color startColor;
    Renderer globalChildRenderer;


    private void Start()
    {
        startColor = getCurrentColor();
        currentObjectRenderer = gameObject.GetComponent<Renderer>();
    }

    void OnMouseOver()
    {
       
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeInHierarchy == true)
            {
                Renderer childRenderer = child.GetComponent<Renderer>();
                childRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, transperancy);
                globalChildRenderer = childRenderer;
            }
        }
    }

    void OnMouseExit()
    {
        if(globalChildRenderer != null)
        globalChildRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 1.0f);
    }

    Color getCurrentColor()
    {
        Color currentColor = gameObject.GetComponent<Renderer>().material.color;
        return currentColor;
    }



}
