using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectCounter : MonoBehaviour
{
    public StringVariable Pollution, Nature;
    public IntVariable TreeCount, FactoryCount, CutTreesCount, TrashCount, FireCount, TotalSpotCount;
    SpotController[] All;

    void Start()
    {
        All = GameObject.FindObjectsOfType<SpotController>();
        TotalSpotCount.Value = All.Length;
    }

    // Update is called once per frame
    void Update()
    {
        TreeCount.Value = 0;
        FactoryCount.Value = 0;
        CutTreesCount.Value = 0;
        TrashCount.Value = 0;
        FireCount.Value = 0;

        int total = All.Length;

        foreach (SpotController spot in All)
        {
            if (spot.CurrentlyEnabled != null)
            {
                if (spot.CurrentlyEnabled.name.Equals("Tree"))
                {
                    TreeCount.Value++;
                }
                else if(spot.CurrentlyEnabled.name.Equals("Factory"))
                {
                    FactoryCount.Value++;
                }
                else if (spot.CurrentlyEnabled.name.Equals("Fire"))
                {
                    FireCount.Value++;
                }
                else if (spot.CurrentlyEnabled.name.Equals("Cut Trees"))
                {
                    CutTreesCount.Value++;
                }
                else if (spot.CurrentlyEnabled.name.Equals("Trash"))
                {
                    TrashCount.Value++;
                }
            }
        }

        Pollution.Value = CalculatePollution() + "/" + total + " Pollution";
        Nature.Value = TreeCount.Value.ToString() + "/" + total + " Trees";
    }

    public int CalculatePollution()
    {
        return FactoryCount.Value + TrashCount.Value;
    }
}
