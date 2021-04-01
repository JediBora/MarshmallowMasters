using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_Fishing : MonoBehaviour
{
    public GUIStyle guiStyle;
    public GameObject Rod;
    public GameObject meter;
    public float reactionTimeNeeded;
    public int fishCaught;
    bool restartLoop;
    public bool meterComplete;
    public int percentNeededToCatch;
    public Text message;
    Gyroscope gyro;
    public float rotX, lastRotX;
    

    // Start is called before the first frame update
    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        StartCoroutine("GameLoop");
    }

    void Update()
    {
        if (meterComplete)
        {
            rotX += gyro.rotationRateUnbiased.x;
                rotX = Mathf.Clamp(rotX, -50f, 0f);

            Rod.transform.RotateAround(Rod.transform.position, Vector3.left, rotX - lastRotX);
            //Rod.transform.Rotate(new Vector3(0, 0, rotX - lastRotX));

            lastRotX = rotX;
        }
    }

    IEnumerator GameLoop()
    {
        print("Entered 'Idling' ");
        yield return StartCoroutine("Idling");

        print("Entered stage 1");
        yield return StartCoroutine("Stage_1");
        
        if (restartLoop)
        {
            StartCoroutine("GameLoop");
        }
        else
        {
            print("Entered stage 2");
            yield return StartCoroutine("Stage_2");
            
            meter.gameObject.SetActive(false);
            Rod.gameObject.SetActive(true);
            StartCoroutine("GameLoop");
        }
    }

    // Waiting for you to lower the rod.
    IEnumerator Idling()
    {
        while (Rod.transform.eulerAngles.z > 20)
        {
            message.text = "Lower Rod";
            yield return null;
        }
    }


    // Stage 1 is waiting for a fish to bite and pulling back on the rod.
    IEnumerator Stage_1()
    {
        message.text = ". . .";
        restartLoop = false;
        float timeRodEnteredWater = Time.time;
        float timeUntilNextBite = Random.Range(3, 5); //Once your rod is lowered a fish will come in 3-5 seconds

        // Waiting for a fish to bite.
        while (Time.time - timeRodEnteredWater < timeUntilNextBite)
        {
            // Pulling the rod out of the 'water' will restart the timer.
            if (Rod.transform.eulerAngles.z > 20)
            {
                restartLoop = true;
                yield break;
            }
            yield return null;
        }

        // When a fish bites, you have some time to react (pull back the rod).
        message.text = "!";
        float timeFishBit = Time.time;

        while (Time.time - timeFishBit < reactionTimeNeeded)
        {
            if (Rod.transform.eulerAngles.z > 45)
            {
                yield break;

            }
            yield return null;
        }

        // If execution reaches here, it means a fish bit but you didn't pull back fast enough.
        restartLoop = true;
        message.text = "Late.";
    }


    // If you react to the bite in-time in stage 1, stage 2 begins where you reel in the fish.
    IEnumerator Stage_2()
    {
        // The rod disappears and the meter is activated.
        meterComplete = false;
        meter.SetActive(true);
        Rod.gameObject.SetActive(false);
        yield return new WaitForSeconds(Time.deltaTime); // For some reason without this delay I get an error. I guess the meter needs some time to activate..?
        meter.GetComponent<Meter>().Activate();
        message.text = "Reel 'im in!";

        // The meter stays active for a few seconds.
        while (!meterComplete)
        {
            yield return null;
        }

        // To successfully catch the fish, you must keep the hook in the catchzone for at least 'percentNeededToCatch' % of the time.
        if ((meter.GetComponent<Meter>().timeInCatchZone / meter.GetComponent<Meter>().activeDuration) * 100 >= percentNeededToCatch)
        {
            fishCaught++;
            message.text = "Good Catch!";
            yield return new WaitForSeconds(2.0f);
        }
        else
        {
            message.text = "The fish got away...";
            yield return new WaitForSeconds(2.0f);
        }
    }

    public int CalculateMarshmallowsGained()
    {
        return (fishCaught * 3);
    }

    /*
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Fish Caught: " + fishCaught, guiStyle);
        GUI.Label(new Rect(10, 600, 100, 20), "RotX = " + rotX, guiStyle);
    }
    */
}
