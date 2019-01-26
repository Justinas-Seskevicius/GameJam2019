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
    public List<SpotController> populatedGoodSpotList;
    public float badSpawnTimeInterval = 1f;
    public float badSpawnSpeed;
    public float LevelInterval = 2f;
    public int TreesOnStart;

    private float badSpawnInterval = 0;
    private float LevelTimer;
    private int random;

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

        InitialSpawn();
    }

    public List<SpotController> getEmptySpots()
    {
        foreach (SpotController ctrl in GameObject.FindObjectsOfType<SpotController>())
        {
            if (ctrl.CurrentlyEnabled)
            {
                Spots.Remove(ctrl);
            }
            else if (!Spots.Contains(ctrl) && !ctrl.CurrentlyEnabled)
            {
                Spots.Add(ctrl);
            }
        }
        return Spots;
    }

    public List<SpotController> getPopulatedGoodSpots()
    {
        foreach (SpotController ctrl in GameObject.FindObjectsOfType<SpotController>())
        {
            if (ctrl.Trees)
            {
                populatedGoodSpotList.Add(ctrl);
            }
        }
        return populatedGoodSpotList;
    }

    void InitialSpawn()
    {
        List<SpotController> emptySpotList = getEmptySpots();

        for (int i = 0; i < TreesOnStart; i++)  
        {
            random = Random.Range(0, emptySpotList.Count);
            if (emptySpotList[random].CurrentlyEnabled == null)
            {
                emptySpotList[random].EnableTrees(true);
                emptySpotList.RemoveAt(random);
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
        getEmptySpots();

        badSpawnInterval += Time.deltaTime * badSpawnSpeed;
        LevelTimer += Time.deltaTime;

        if (badSpawnTimeInterval <= badSpawnInterval)
        {
            spawnBadThing();
            badSpawnInterval = 0;
        }

        if (LevelTimer >= LevelInterval) 
        {
            badSpawnSpeed += Time.deltaTime * 25f;
            LevelTimer = 0;
        }

        if (getEmptySpots().Count <= 20)
        {
            disableRandomGoodSpot();
        }
    }

    void disableRandomGoodSpot()
    {
        List<SpotController> treesEnabled = getPopulatedGoodSpots();
        treesEnabled[Random.Range(0, treesEnabled.Count)].DisableTrees();
    }

    void spawnBadThing()
    {
        ShuffleList(SpotsInTriggerReference.SpotsInRange);

        foreach (SpotController ctrl in SpotsInTriggerReference.SpotsInRange)
        {
            if (ctrl.CurrentlyEnabled == null)
            {
                int r = Random.Range(0, 3);

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

                    default:
                        ctrl.EnableFactory(true);
                        break;
                }
                break;
            }
        }

    }

}
