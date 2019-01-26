using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Stichija { Nothing = 0, Audra = 1, Zaibas = 2, Kometos = 3, Viesulas = 4 }

public class GameController : MonoBehaviour
{
    public GameController Instance { get; private set; }
    public SpotsInTrigger SpotsInTriggerReference;
    public List<SpotController> Spots;
    public float BadSpawnTimeInterval = 1f;
    public int TreesOnStart = 5;

    private float BadSpawnInterval = 0;

    public static Stichija CurrentlySelectedStichija = Stichija.Nothing;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
            return;
        }

        // Get all spots in the game that can be used
        foreach (SpotController ctrl in GameObject.FindObjectsOfType<SpotController>())
        {
            if (!Spots.Contains(ctrl))
            {
                Spots.Add(ctrl);
            }
        }

        // Spawn initial objects at the start of the game
        SpawnInitial();
    }

    void SpawnInitial()
    {

        SpotController[] a = GameObject.FindObjectsOfType<SpotController>();
        List<SpotController> spots = new List<SpotController>();

        foreach (SpotController spt in a)
        {
            spots.Add(spt);
        }

        for (int i = 0; i < TreesOnStart; i++)
        {
            if (spots.Count > 0)
            {
                ShuffleList(spots);
                if (spots[0].CurrentlyEnabled == null)
                {
                    spots[0].EnableTrees(true);
                    spots.Remove(spots[0]);
                }
            }
        }

    }

    /// <summary>
    /// Generic list shuffling method
    /// </summary>
    /// <param name="list">List to be shuffled</param>
    public static void ShuffleList<T>(List<T> list)
    {

        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, list.Count);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;

        }
    }

    void Update()
    {
        BadSpawnInterval += Time.deltaTime;

        if (BadSpawnTimeInterval <= BadSpawnInterval)
        {
            SpawnBadThing();
            BadSpawnInterval = 0;
        }
    }

    void SpawnBadThing()
    {
        ShuffleList(SpotsInTriggerReference.SpotsInRange);

        foreach (SpotController ctrl in SpotsInTriggerReference.SpotsInRange)
        {
            if (ctrl.CurrentlyEnabled == null)
            {
                int r = Random.Range(0, 4);

                switch (r)
                {
                    case 1:
                        ctrl.EnableFactory(true);
                        break;

                    case 2:
                        ctrl.EnableTrash(true);
                        break;

                    case 3:
                        ctrl.EnableCutTrees(true);
                        break;

                    case 0:
                        ctrl.EnableApartments(true);
                        break;

                    default:
                        ctrl.EnableFactory(true);
                        break;
                }
                break;
            }
        }

    }

}
