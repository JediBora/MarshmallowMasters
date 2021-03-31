using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : MonoBehaviour
{
    public List<GameObject> waypoints;
    public int waypointIndex;
    public float speed;
    public float m_stoppingDistance;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        transform.LookAt(waypoints[waypointIndex].transform);


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == waypoints[waypointIndex])
        {
            if(other.gameObject == waypoints[5])
            {
                gameObject.transform.position = waypoints[0].transform.position;
            }
            waypointIndex = (waypointIndex + 1) % waypoints.Count;
        }
    }

}
