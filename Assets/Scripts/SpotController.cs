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
            Trees.gameObject.SetActive(value);
            CurrentlyEnabled = Trees;
        }
    }

    public void DisableTrees()
    {
        if (CurrentlyEnabled == Trees)
        {
            Trees.gameObject.SetActive(false);
            CurrentlyEnabled = null;
        }
    }

    public void EnableFactory(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            Factory.gameObject.SetActive(value);
            CurrentlyEnabled = Factory;
        }
    }

    public void EnableFire(bool value)
    {
            Fire.gameObject.SetActive(value);
    }

    public void EnableCutTrees(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            CutTrees.gameObject.SetActive(value);
            CurrentlyEnabled = CutTrees;
        }
    }

    public void EnableTrash(bool value)
    {
        if (CurrentlyEnabled == null)
        {
            Trash.gameObject.SetActive(value);
            CurrentlyEnabled = Trash;
        }
    }

}
