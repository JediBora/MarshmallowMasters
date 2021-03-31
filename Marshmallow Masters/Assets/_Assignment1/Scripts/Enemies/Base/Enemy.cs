using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour, IKillable, IDamageable<float>
{
    public abstract float Health { get; protected set; }

    public AIManager aiManager;
    public GameObject target;
    public Health healthScript;

    private void Awake()
    {
        aiManager = GameObject.Find("Singletons").GetComponent<AIManager>();
        healthScript = GetComponent<Health>();
    }

    private void Start()
    {
        aiManager = GameObject.Find("Singletons").GetComponent<AIManager>();
        healthScript = GetComponent<Health>();
    }

    private void OnEnable()
    {
        Debug.Log("Spawned");
        aiManager.AddToList(this.gameObject);
    }

    private void OnDisable()
    {
        Debug.Log("Despawned");
        aiManager.RemoveFromList(this.gameObject);
    }

    public virtual void Kill()
    {
        if (aiManager.CheckisInList(this.gameObject))
        {
            aiManager.RemoveFromList(this.gameObject);
        }
        gameObject.SetActive(false);
    }

    public virtual void ApplyDamage(float damageValue)
    {
        Health -= damageValue;
    }


}
