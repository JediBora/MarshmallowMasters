using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    public GM_Fishing gameManager;

    //Meter
    Transform meter_startPoint, meter_endPoint;
    public float activeDuration; // How long the meter remains active
    public bool isActive;
    public float rotX;

    //CatchZone
    public GameObject CatchZone;
    public float speed; //How fast the catchzone moves in units/second.
    float startTime;
    Vector3 targetPosition; //random value between 0 (start point) and 1 (end point) --- (Remember, I might make it smthn like btwn 0.2 and 0.8 so it doesn't go outside the meter)
    Vector3 initialPosition;

    //Hook
    public GameObject Hook;
    Gyroscope gyro;
    public float timeInCatchZone;
    public bool hit;
    public float magnitude;


    // Start is called before the first frame update
    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        meter_startPoint = transform.GetChild(0);
        meter_endPoint = transform.GetChild(1);
        //StartCoroutine("Move_CatchZone");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine("Move_CatchZone");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StopCoroutine("Move_CatchZone");
        }
        */

        if (isActive)
        {
            // Get device rotation
            rotX += gyro.rotationRateUnbiased.x;
                rotX = Mathf.Clamp(rotX, -50f, 0f); //Mathf.Clamp(rotX, 0f, 50f);

            //Move the hook based on device rotation
            float t = Mathf.Abs(rotX / 50);
            Hook.transform.position = Vector3.Lerp(meter_startPoint.position, meter_endPoint.position, t);

            Ray ray = new Ray(Hook.transform.position, transform.forward);
            RaycastHit hitInfo;

            int layerMask = 1 << LayerMask.NameToLayer("CatchZone");

            hit = Physics.Raycast(ray, out hitInfo, magnitude, layerMask);

            if (hit)
            {
                timeInCatchZone += Time.deltaTime;
                Debug.DrawLine(ray.origin, Hook.transform.position + transform.forward * magnitude, Color.red);
            }
            else
            {
                Debug.DrawLine(ray.origin, Hook.transform.position + transform.forward * magnitude, Color.red);
            }

        }
    }

    IEnumerator Move_CatchZone()
    {
        float activationTime = Time.time;

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
        gameManager.meterComplete = true;
        isActive = false;
    }

    public void Activate()
    {
        StartCoroutine("Move_CatchZone");
        isActive = true;
        timeInCatchZone = 0;
    }
}
