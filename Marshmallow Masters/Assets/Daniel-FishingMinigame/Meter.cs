using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    //Meter
    Transform meter_startPoint, meter_endPoint;
    //public bool isActive;
    public float activeDuration; // How long the meter remains active
    float activationTime; // When the meter began


    //CatchZone
    public GameObject CatchZone;
    public float speed; //How fast the catchzone moves in units/second.
    float startTime;
    Vector3 targetPosition; //random value between 0 (start point) and 1 (end point) --- (Remember, I might make it smthn like btwn 0.2 and 0.8 so it doesn't go outside the meter)
    Vector3 initialPosition;
    bool finished;


    // Start is called before the first frame update
    void Start()
    {
        meter_startPoint = transform.GetChild(0);
        meter_endPoint = transform.GetChild(1);

        StartCoroutine(Move_CatchZone());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Move_CatchZone()
    {
        activationTime = Time.time;

        while (Time.time - activationTime < activeDuration) //Move back and forth for a set time.
        {
            initialPosition = CatchZone.transform.position;
            targetPosition = Vector3.Lerp(meter_startPoint.position, meter_endPoint.position, Random.Range(0.1f, 0.9f));
            startTime = Time.time;

            while (CatchZone.transform.position != targetPosition)
            {
                if(targetPosition.x > initialPosition.x)
                {
                    CatchZone.transform.Translate(Vector3.right * speed * Time.deltaTime);
                    if(CatchZone.transform.position.x >= targetPosition.x)
                    {
                        CatchZone.transform.position = targetPosition;
                    }
                }
                else
                {
                    CatchZone.transform.Translate(Vector3.left * speed * Time.deltaTime);
                    if (CatchZone.transform.position.x <= targetPosition.x)
                    {
                        CatchZone.transform.position = targetPosition;
                    }
                }

                yield return null;
            }

            yield return null;
        }
    }
}
