using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    #region Variables
    public static AIManager instance = null;

    [Header("Wave Manager and Agent List")]
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private List<GameObject> agentList;

    [Space]
    [Header("Wave integers")]
    public int waveNumber;
    public int maxSpawnedAgents; //Maximum agents that can be spawned at any time, independent from the wave limit
    public int agentsPerWave; //Max agents that can be spawned in a single wave
    [SerializeField] private int agentsSpawnedInWave = 0; //Keeps track of all agents spawned during a wave
    [SerializeField] private int waveCooldown = 10;

    [Space]
    [Header("Wave bools")]
    public bool spawnAgents = true;
    public bool disableSpawnTemp = false;
    #endregion

    private void Awake()
    {
        /////Singleton initialization/////
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        /////Singleton initialization/////

        waveManager = GetComponent<WaveManager>();
        agentList = new List<GameObject>();
    }

    private void Start()
    {
        Debug.Log("Game start");
        StartCoroutine(WaveCooldown(waveCooldown));
    }

    /// <summary>
    /// If agents can be spawned, their spawn position will be validated and
    /// they will be spawned. Otherwise, the script will check for agents that 
    /// have died
    /// </summary>
    private void Update()
    {
        if (spawnAgents)
        {
            if (!disableSpawnTemp)
            {
                ValidateSpawn();
            }
            else
            {
                CheckForAgentDeath();
            }
        }
    }

    /// <summary>
    /// Method that spawns AI agents. Will only spawn if valid conditionals.
    /// </summary>
    void ValidateSpawn()
    {
        if (agentsSpawnedInWave >= agentsPerWave)
        {
            if (agentList.Count <= 0)
            {
                StartCoroutine(WaveCooldown(waveCooldown));
                spawnAgents = false;
                waveManager.waveComplete = true;

            }
        }

        else if (agentsSpawnedInWave < agentsPerWave) //If number of agents spawned exceeds the wave limit
        {
            foreach (GameObject agent in waveManager.pooledAgents)
            {
                if (agentList.Count >= maxSpawnedAgents) //If the spawn list exceeds max amount of enemies existing at any one time, exit loop
                {
                    disableSpawnTemp = true;
                    Debug.Log("Spawning temporarily disabled");
                    break;
                }

                if (agentsSpawnedInWave >= agentsPerWave) //If spawned agents exceeds wave limit, exit loop
                {
                    spawnAgents = false;
                    break;
                }

                if (!agentList.Contains(agent)) //Sees if object in question is on the agent list. If not, it is added, enabled, and spawned according to the spawn algorithm
                {
                    agentList.Add(agent);
                    SetAgentSpawnPosition(agent);
                    agent.SetActive(true);
                    agentsSpawnedInWave++;
                }
            }
        }
    }

    /// <summary>
    /// Checks if agent dies. If yes, re-enables spawning if it was disabled
    /// </summary>
    void CheckForAgentDeath()
    {
        if (agentList.Count < maxSpawnedAgents)
        {
            disableSpawnTemp = false;
        }
    }

    void SetAgentSpawnPosition(GameObject agent) //Sets spawn position
    {
        agent.transform.position = GenerateSpawnPoint();
    }

    /// <summary>
    /// Generates a random spawn position on the navmesh. If a position is unable to be found on
    /// the navmesh, script will continue trying to find a point
    /// </summary>
    private Vector3 GenerateSpawnPoint()
    {
        bool hasSpawnPoint = false;

        NavMeshHit hit;
        while (!hasSpawnPoint)
        {
            if (NavMesh.SamplePosition(new Vector3(Random.Range(-3f, -242f), 0, Random.Range(-110f, 100f)), out hit, 10f, NavMesh.AllAreas))
            {
                hasSpawnPoint = true;
                return hit.position;
            }
        }
        return Vector3.zero;
    }

    #region ListMethods
    public void AddToList(GameObject agent) //Adds the agent in question to the list of active agents
    {
        if (!agentList.Contains(agent))
        {
            agentList.Add(agent);
        }
    }

    public void RemoveFromList(GameObject agent) //Adds the agent in question to the list of active agents
    {
        if (agentList.Contains(agent))
        {
            agentList.Remove(agent);
        }
    }

    public bool CheckisInList(GameObject agent)
    {
        if (agentList.Contains(agent))
        {
            return true;
        }
        else
            return false;
    }
    #endregion

    #region WaveMethods
    public void StartWave()
    {
        GetWaveParameters();
        spawnAgents = true;
        agentsSpawnedInWave = 0;
    }

    public IEnumerator WaveCooldown(int waitTime)
    {
        Debug.Log("Wave Ended");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Cooldown over");
        StartWave();
    }

    private void GetWaveParameters()
    {
        waveNumber = waveManager.WaveNumber;
        maxSpawnedAgents = waveManager.MaxSpawnedAgents;
        agentsPerWave = waveManager.WaveStrength;
    }
    #endregion

}
