using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marshmallow : MonoBehaviour
{
    bool isCooking;
    public float timeCooked = 0;
    float burnTime = 100;
    float cookSpeed = 0.66f;
    bool onFire;
    public Color rawColour, goodColour, burntColour;
    Material marshmallowMaterial;
    GameObject FireEffect;
    
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        marshmallowMaterial = GetComponent<MeshRenderer>().material;
        FireEffect = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Cook()
    {
        while (isCooking)
        {
            // Cook // Turning the marshmallow speeds up cooking
            timeCooked += cookSpeed + (cookSpeed * Mathf.Abs(Input.gyro.rotationRateUnbiased.y));
            // Cooks 3x faster when on fire
            if (onFire)
            {
                timeCooked += cookSpeed * 2;
            }
            
            // Change colour
            if (timeCooked < burnTime / 2) //Half-way cooked
            {
                marshmallowMaterial.color = Color.Lerp(rawColour, goodColour, timeCooked / (burnTime / 2));
            }
            else
            {
                marshmallowMaterial.color = Color.Lerp(goodColour, burntColour, (timeCooked - 50) / (burnTime / 2));
            }

            // Chance to catch on fire
            if(Random.Range(1, 101) < 3) //2% chance (every 1/5 second)
            {
                onFire = true;
                FireEffect.SetActive(true);
            }

            // Repeat (if still cooking)
            yield return new WaitForSeconds(0.2f);
        }

        yield return null;
    }

    public void StopFire()
    {
        //onFire = false;
        FireEffect.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Fire")
        {
            isCooking = true;
            StartCoroutine("Cook");
            //Debug.Log("Cooking");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Fire")
        {
            isCooking = false;
            StopCoroutine("Cook");
            //Debug.Log("Not Cooking");
        }
    }
}
