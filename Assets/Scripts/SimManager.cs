using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Monobehaviour script used to create Sim entities.
public class SimManager : MonoBehaviour
{
    public List<SimData> sims = new List<SimData>();

    [Header("Variables 'n stuff")]
    public GameObject simPrefab;
    public Transform simsHolder;
    [Range(0, 10)] public float myNumber;


    //On initialization, the SimManager will create Sim entities for each instance of SimData it has stored.
    void Start()
    {
        foreach (SimData simData in sims)
        {
            CreateSimEntity(simData);
        }
    }

    //Given data about a Sim, it creates the entity associated with that data
    /// <summary>
    /// this is a function
    /// </summary>
    /// <param name="simData"></param>
    public void CreateSimEntity(SimData simData)
    { 
        GameObject simObject = Instantiate(simPrefab, simsHolder);
        Sim sim = simObject.GetComponent<Sim>();
        sim.Initialize(simData);
    }

    [ContextMenu("Say Hi")]
    public void PrintHello()
    {
        Debug.Log("Hi!");
    }

}
