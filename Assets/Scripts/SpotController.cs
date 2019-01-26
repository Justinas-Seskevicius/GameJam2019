using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour, OnRightClick, OnLeftClick
{

    public GameObject Trees;
    public GameObject Factory;
    public GameObject Fire;
    public GameObject CutTrees;
    public GameObject Trash;
    public GameObject Apartment;

    public GameObject CurrentlyEnabled;

    public void RightClick()
    {
        if (CurrentlyEnabled != null)
        {
            if(CurrentlyEnabled.GetComponent<OnRightClick>() != null)
            CurrentlyEnabled.GetComponent<OnRightClick>().RightClick();
        }
    }

    public void ClearCurrentlyEnabled()
    {
        CurrentlyEnabled = null;
    }

    public void LeftClick()
    {
        if (CurrentlyEnabled != null)
        {
            if (CurrentlyEnabled.GetComponent<OnLeftClick>() != null)
                CurrentlyEnabled.GetComponent<OnLeftClick>().LeftClick();
        }
    }

    public void EnableTrees(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            Trees.SetActive(value);
            CurrentlyEnabled = Trees;
        }
    }

    public void EnableApartments(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            Apartment.SetActive(value);
            CurrentlyEnabled = Apartment;
        }
    }

    public void EnableFactory(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            Factory.SetActive(value);
            CurrentlyEnabled = Factory;
        }
    }

    public void EnableFire(bool value)
    {
            Fire.SetActive(value);
    }

    public void EnableCutTrees(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            CutTrees.SetActive(value);
            CurrentlyEnabled = CutTrees;
        }
    }

    public void EnableTrash(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            Trash.SetActive(value);
            CurrentlyEnabled = Trash;
        }
    }

}
