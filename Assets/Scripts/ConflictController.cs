using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConflictController : MonoBehaviour
{
    public int HP;
    private Ray ray;
    private RaycastHit hit;
    private Color startColor;

    public void Start()
    {
        HP = 100;
        startColor = GetComponent<Renderer>().material.color;
    }
    
    public void Update()
    { 
        if (Input.GetButtonDown("Fire1"))
        { 
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.name);
            }
        } 
    }

    public void setHP(int damage)
    {
        if (HP > 0)
        {
            HP = HP - damage;
        }
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public int getHP()
    {
        return HP;
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startColor;
    }
}


