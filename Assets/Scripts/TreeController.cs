using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour, OnRightClick, OnLeftClick
{
    public GameEvent DeselectAllStichijos;

    public void RightClick()
    {
        this.gameObject.SetActive(false);
        this.SendMessageUpwards("ClearCurrentlyEnabled");
    }

    public void LeftClick()
    {
        switch (GameController.CurrentlySelectedStichija)
        {
            case Stichija.Audra:
                throw new System.NotImplementedException();

            case Stichija.Kometos:
                throw new System.NotImplementedException();

            case Stichija.Viesulas:
                throw new System.NotImplementedException();

            case Stichija.Zaibas:
                throw new System.NotImplementedException();

            default:
                break;

        }

        DeselectAllStichijos.Raise();
    }

}
