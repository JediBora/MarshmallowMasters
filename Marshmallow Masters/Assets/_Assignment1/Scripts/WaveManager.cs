using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    #region Variables
    public static WaveManager instance;

    private AIManager aiManager;

    public List<GameObject> pooledAgents;

    [SerializeField] private GameObject agentParent; //Object to sort all agents under. Object should exist at Vector3.zero

    [SerializeField] private GameObject gunPotatoPrefab;
    [SerializeField] private GameObject chaserPrefab;

    public int WaveNumber { get; protected set; } //Current wave
    public int MaxSpawnedAgents { get; protected set; } //Max enemies on screen at any time
    public int WaveStrength { get; protected set; } //Max enemies per wave

    public bool waveComplete;
    #endregion

    private void Awake()
    {
        /////Singleton Initialization/////
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        /////Singleton Initialization/////

        aiManager = GetComponent<AIManager>();
        agentParent = GameObject.Find("PooledAgents");
        if (agentParent.transform.position != Vector3.zero)
        {
            agentParent.transform.position = Vector3.zero;
        }

        WaveNumber = 0;
    }

    void Start()
    {
        CreateWaveParameters();
    }

    /// <summary>
    /// Used to create a number of agents to be pooled. Spawns enemy agents when 
    /// specific conditions are met
    /// </summary>
    void Update()
    {
        if (pooledAgents.Count <= MaxSpawnedAgents)
        {
            int difference = MaxSpawnedAgents - pooledAgents.Count; //Checks the difference between the number of agents in the current wave to the actual number of pooled agents

            for (int i = 0; i < difference + 5; i++) //Adds any missing agents to the pool
            {
                int agentType = Random.Range(0, 2); //Used in determining which type of enemy to spawn

                if (agentType == 0)
                {
                    GameObject newAgent = Instantiate(gunPotatoPrefab, Vector3.zero, Quaternion.identity, agentParent.transform);
                    pooledAgents.Add(newAgent);
                    newAgent.SetActive(false);
                }
                else
                {
                    GameObject newAgent = Instantiate(chaserPrefab, Vector3.zero, Quaternion.identity, agentParent.transform);
                    pooledAgents.Add(newAgent);
                    newAgent.SetActive(false);
                }
            }
        }

        if (waveComplete) //Advances wave when current wave is complete
        {
            CreateWaveParameters();
            Debug.Log("ADVANCED WAVE WITH " + WaveNumber + " " + WaveStrength + " " + MaxSpawnedAgents);
        }
    }

    /// <summary>
    /// Used to dynamically calculate wave parameters based on the wave number
    /// </summary>
    void CreateWaveParameters()
    {
        WaveNumber++;
        WaveStrength = 15 + (WaveNumber * 8) + ((int)Mathf.Sqrt(WaveNumber * 8));
        MaxSpawnedAgents = 20 + (WaveNumber * 10);
        waveComplete = false;
    }
}
