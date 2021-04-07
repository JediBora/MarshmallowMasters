using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stick : MonoBehaviour
{
    //Components
    public Marshmallow marshmallow;
    public GameObject marshmallowPrefab;
    public GM_MarshmallowRoasting gameManager;

    //Controls
    Gyroscope gyro;
    float rotX, rotY, rotZ;
    float lastRotX, lastRotY, lastRotZ;
    public float shakeForce;

    public float stickTurnRateMultiplier; //So you don't have to rotate the device as much to spin the stick, fe, a full 180.


    /*
    //UI
    public Text rotXText, rotYText, rotZText;
    public Text mrotXText, mrotYText, mrotZText;
    public Text rotRate;
    public Text transForwardZ;

    //test
    public bool rotateX, rotateY;
    float deltaRotationX, deltaRotationY;
    */

    // Start is called before the first frame update
    void Start()
    {
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        gyro = Input.gyro;
        gyro.enabled = true;

        marshmallow = transform.Find("Marshmallow").gameObject.GetComponent<Marshmallow>();
    }

    void Update()
    {
        rotX += Input.gyro.rotationRateUnbiased.x;
            rotX = Mathf.Clamp(rotX, -70f, 0f); // Prev: -50f, 0f
        rotY += -Input.gyro.rotationRateUnbiased.y;
        rotZ += Input.gyro.rotationRateUnbiased.z;

        Raise_Lower();
        Turn();
        Shake();
        UpdateUIInfo();

        //Store current rotation
        lastRotX = rotX;
        lastRotY = rotY;
        lastRotZ = rotZ;
    }

    // Raises/lowers the stick
    void Raise_Lower()
    {
        //if(rotX < 0 && rotX > -50) // Limits how much you can raise/lower the stick (buggy).
        //{
            transform.RotateAround(transform.position, Vector3.forward, rotX - lastRotX);
        //}

    }

    // Turns the stick
    void Turn()
    {
        transform.RotateAround(transform.position, transform.right, (rotY - lastRotY) * stickTurnRateMultiplier);
    }

    // Shakes stick
    void Shake()
    {
        if (Mathf.Abs(gyro.rotationRateUnbiased.x) > shakeForce)
        {
            marshmallow.StopFire();




        }
    }

    /*
    // Touch the stick to...
    public void Add_Remove_Marshmallow()
    {
        // Add a marshmallow if there isn't one.
        if(marshmallow == null)
        {
            Debug.Log("Marshmallow Added");
            AddMarshmallow();
        }
        else // Destroy the current marshmallow
        {
            Debug.Log("Marshmallow Destroyed");
            Destroy(marshmallow.gameObject);
        }
    }
    */

    public void AddMarshmallow()
    {
        if (marshmallow == null && gameManager.marshmallowsRemaining > 0)
        {
            GameObject newMarshmallow = Instantiate(marshmallowPrefab, transform.Find("Marshmallow Spawnpoint").position, Quaternion.identity);
            newMarshmallow.transform.parent = transform;
            newMarshmallow.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -90)); //
            marshmallow = newMarshmallow.GetComponent<Marshmallow>();

            gameManager.MarshmallowAdded();
        }
    }

    public void RemoveMarshmallow()
    {
        if (marshmallow != null)
        {
            if (marshmallow.timeCooked >= 55 && marshmallow.timeCooked <= 70)
            {
                gameManager.MarshmallowRemoved(true, "Perfect!");

            }
            else if (marshmallow.timeCooked >= 30 && marshmallow.timeCooked <= 85)
            {

                gameManager.MarshmallowRemoved(true, "Nice.");
            }
            else if (marshmallow.timeCooked > 85)
            {

                gameManager.MarshmallowRemoved(false, "Whoops, too burnt :(");
            }
            else if (marshmallow.timeCooked < 30)
            {
                gameManager.MarshmallowRemoved(false, "Whoops, too raw :(");
            }

            Destroy(marshmallow.gameObject);
        }   
    }

    // Updates UI info related to stick.
    void UpdateUIInfo()
    {
        /*
        rotXText.text = "Rot X = " + rotX.ToString("F0");
        rotYText.text = "Rot Y = " + rotY.ToString("F0");
        rotZText.text = "Rot Z = " + rotZ.ToString("F0");

        mrotXText.text = "MRot X = " + transform.eulerAngles.x.ToString("F0");
        mrotYText.text = "MRot Y = " + transform.eulerAngles.y.ToString("F0");
        mrotZText.text = "MRot Z = " + transform.eulerAngles.z.ToString("F0");

        rotRate.text = "rotRateX = " + Mathf.Abs(gyro.rotationRateUnbiased.x);

        //transForwardZ.text = "rotZ = " + transform.up;
        */
    }

}
