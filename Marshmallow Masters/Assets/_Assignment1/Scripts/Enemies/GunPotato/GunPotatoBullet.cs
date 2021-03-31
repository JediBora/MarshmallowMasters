using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ExplosionEvent : UnityEvent { }

public class GunPotatoBullet : MonoBehaviour
{
    public ExplosionEvent m_onImpact = new ExplosionEvent();

    private ObjectPooler objectPool;

    private GameObject playerTarget;
    private GameObject explosionPrefab;

    public Vector3 startPos;
    public Vector3 endPos;

    public float arcHeight;

    private float timer;

    private bool canExplode;

    private void OnEnable()
    {
        objectPool = ObjectPooler.instance;
        explosionPrefab = Resources.Load("Explosion") as GameObject;
        timer = 0;
        canExplode = true;

        Debug.DrawLine(transform.position, transform.position + Vector3.up * 50, Color.blue, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime / (Mathf.Sqrt(arcHeight) / 3);

        timer = timer % 5f;

        transform.position = MathParabola.Parabola(startPos, endPos, arcHeight, timer);
        Debug.DrawLine(startPos, endPos, Color.green);

        if (timer >= 1f && canExplode)
        {
            objectPool.NewObject(explosionPrefab, transform.position, Quaternion.identity);
            m_onImpact.Invoke();
            objectPool.ReturnToPool(this.gameObject);
        }
    }

    public void InitializeValues(Vector3 start, Vector3 end, float height, GameObject target)
    {
        startPos = start;
        endPos = end;
        arcHeight = height;
        playerTarget = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerTarget)
        {
            Debug.Log("CONTACT PLAYER");
        }
        objectPool.NewObject(explosionPrefab, transform.position, Quaternion.identity);
        m_onImpact.Invoke();
        objectPool.ReturnToPool(this.gameObject);
    }
}
