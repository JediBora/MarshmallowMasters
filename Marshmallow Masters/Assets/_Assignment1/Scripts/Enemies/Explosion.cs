using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explosion : MonoBehaviour
{
    #region Variables
    public ExplosionEvent m_onExploded = new ExplosionEvent();

    private ObjectPooler objectPool;

    float timer;
    #endregion

    void Start()
    {
        timer = 0f;
        objectPool = GameObject.Find("ObjectPooler").GetComponent<ObjectPooler>();
    }

    private void OnEnable()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 0.25f)
        {
            objectPool.ReturnToPool(this.gameObject);
        }
    }
}
