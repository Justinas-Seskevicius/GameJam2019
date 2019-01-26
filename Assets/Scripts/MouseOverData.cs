using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverData : MonoBehaviour
{
    public Camera Main;
    public GameEvent DeselectAllStichijos;

    void Update()
    {
        Ray ray = Main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);

        if(hits.Length > 0) { 

            // Right click disables objects on SpotController tiles
            if (Input.GetMouseButtonDown(1))
            {

                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit hit = hits[i];

                    if (hit.collider != null && hit.collider.gameObject.tag.Equals("Spot"))
                    {
                        if (hit.collider.gameObject.GetComponent<SpotController>().CurrentlyEnabled != null)
                        {
                            if (hit.collider.gameObject.GetComponent<OnRightClick>() != null)
                            {
                                hit.collider.gameObject.GetComponent<OnRightClick>().RightClick();
                                break;
                            }
                        }
                    }

                    if (hit.collider != null && hit.collider.gameObject.tag.Equals("Earth"))
                    {
                            print("Earth was hit with right click");
                            break;
                    }
                }
            }

            // Left click spawns natural disasters (stichijas)
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit hit = hits[i];

                    if (hit.collider != null && hit.collider.gameObject.tag.Equals("Spot"))
                    {
                        if (hit.collider.gameObject.GetComponent<OnLeftClick>() != null)
                        {
                            if (hit.collider.gameObject.GetComponent<SpotController>().CurrentlyEnabled != null)
                            {
                                hit.collider.gameObject.GetComponent<OnLeftClick>().LeftClick();
                                break;
                            }
                        }
                    }

                    if (hit.collider != null && hit.collider.gameObject.tag.Equals("Earth"))
                    {
                            print("Earth was hit with left click");
                            DeselectAllStichijos.Raise();
                            break;
                    }
                }
            }
        }
    }
}
