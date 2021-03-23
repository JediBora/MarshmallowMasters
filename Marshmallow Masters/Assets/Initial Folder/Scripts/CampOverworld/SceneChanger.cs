using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ////Minigames
       
        if (other.tag == "SandwichC")
        {
            //Add Save your Sandwich Scene
            // SceneManager.LoadScene(1);
            print("Save your Sandwich interaction");
        }

        if (other.tag == "CanoeC")
        {
            //Add Canoe Boo Boo Scene
            SceneManager.LoadScene("CanoeBooBoo");
            print("Canoe Boo Boo interaction");
        }

        if (other.tag == "FishingC")
        {
            //Add Fishing Fishers Scene
            SceneManager.LoadScene("FishingFishers");
            print("Fishing Fishers interaction");
        }

        if (other.tag == "MosquitoC")
        {
            //Add Shoo Shoo Mosquito Scene
            SceneManager.LoadScene("ShooShooMosquitoTest");
            print("Shoo Shoo Mosquito interaction");
        }

        if (other.tag == "FlashlightC")
        {
            //Add Flashlight B'Brokey Scene
            SceneManager.LoadScene("FlashlightBBrokey");
            print("Flashlight B'Brokey interaction");
        }

        if (other.tag == "MarshmallowC")
        {
            //Add Marshmallow Masters Scene
            SceneManager.LoadScene("MarshmallowRoasting");
            print("Marshmallow Masters interaction");
        }

    }
}
