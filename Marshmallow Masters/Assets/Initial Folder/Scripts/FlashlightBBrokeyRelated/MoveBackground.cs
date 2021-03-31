using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{



    public Transform[] waypointArray;
    public Transform[] waypointArray2;
    float percentsPerSecond = 1.5f; // %2 of the path moved per second
    public float currentPathPercent = 0.0f; //min 0, max 1

    public bool pathFinished;

    public ShakeDetector shakeDetector;


    void Update()
    {
        if (!shakeDetector.deviceIsShaking)
        {
            currentPathPercent += percentsPerSecond * Time.deltaTime;

            if (currentPathPercent <= 1 && !pathFinished)
            {
                iTween.PutOnPath(gameObject, waypointArray, currentPathPercent);
            }
            if (currentPathPercent <= 1 && pathFinished)
            {
                iTween.PutOnPath(gameObject, waypointArray2, currentPathPercent);
            }

            if (currentPathPercent >= 1 && pathFinished)
            {
                currentPathPercent = 0;
                pathFinished = false;

            }
            if (currentPathPercent >= 1 && !pathFinished)
            {
                currentPathPercent = 0;
                pathFinished = true;

            }
        }
    }

    void OnDrawGizmos()
    {
        //Visual. Not used in movement
        iTween.DrawPath(waypointArray);



    }
}
