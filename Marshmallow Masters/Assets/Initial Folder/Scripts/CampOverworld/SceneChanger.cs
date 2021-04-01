using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    //Used to check on marshmallow count, allowing or denying access to the marshmallow roasting mini game
    public LoadAndSave loadNSave;

    public GameObject difficultyCanvas;

    //0 = Save Your Sanwich
    //1 = Canoe Boo Boo
    //2 = Fishing Fishers
    //3 = Shoo Shoo Mosquito
    //4 = Flashlight B' Brokey
    //5 = Marshmallow Masters
    public int miniGameToLoad;


    private void OnTriggerEnter(Collider other)
    {
        ////Minigames

        if (other.tag == "SandwichC")
        {
            //Add Save your Sandwich Scene
            loadNSave.savedData.levelToLoadName = "SaveSamI";

            loadNSave.RewriteSaveFile();

            SceneManager.LoadScene("LoadingScreen");
            print("Save your Sandwich interaction");
        }

        if (other.tag == "CanoeC")
        {
            //Add Canoe Boo Boo Scene
            loadNSave.savedData.levelToLoadName = "CanoeBooBooI";

            loadNSave.RewriteSaveFile();

            SceneManager.LoadScene("LoadingScreen");
            print("Canoe Boo Boo interaction");
        }

        if (other.tag == "FishingC")
        {
            //Add Fishing Fishers Scene
            loadNSave.savedData.levelToLoadName = "FishingFishersI";

            loadNSave.RewriteSaveFile();

            SceneManager.LoadScene("LoadingScreen");
            print("Fishing Fishers interaction");
        }

        if (other.tag == "MosquitoC")
        {
            loadNSave.savedData.levelToLoadName = "FishingFishersI";

            loadNSave.RewriteSaveFile();
            miniGameToLoad = 3;
            difficultyCanvas.SetActive(true);

            //Add Shoo Shoo Mosquito Scene
            //SceneManager.LoadScene("ShooShooMosquitoTest");
            print("Shoo Shoo Mosquito interaction");
        }

        if (other.tag == "FlashlightC")
        {
            miniGameToLoad = 4;
            difficultyCanvas.SetActive(true);

            //Add Flashlight B'Brokey Scene
            //SceneManager.LoadScene("FlashlightBBrokey");
            print("Flashlight B'Brokey interaction");
        }

        if (other.tag == "MarshmallowC" && loadNSave.savedData.marshmallows > 0)
        {
            //Add Marshmallow Masters Scene
            loadNSave.savedData.levelToLoadName = "MarshmallowRoastingI";

            loadNSave.RewriteSaveFile();

            SceneManager.LoadScene("LoadingScreen");
            print("Marshmallow Masters interaction");
        }

        else if (other.tag == "MarshmallowC" && loadNSave.savedData.marshmallows <= 0)
        {
            Debug.Log("You don't have neough shmellows scrub.");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SandwichC" || other.tag == "CanoeC" || other.tag == "FlashlightC" || other.tag == "FishingC" || other.tag == "MosquitoC")

            difficultyCanvas.SetActive(false);


    }

    //0 = Save Your Sanwich
    //1 = Canoe Boo Boo
    //2 = Fishing Fishers
    //3 = Shoo Shoo Mosquito
    //4 = Flashlight B' Brokey
    //5 = Marshmallow Masters
    public void LoadCorrespondingScene()
    {


        if (miniGameToLoad == 0)
        {
            loadNSave.savedData.levelToLoadName = "SaveSamI";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 1)
        {
            loadNSave.savedData.levelToLoadName = "CanoeBooBooI";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 2)
        {
            loadNSave.savedData.levelToLoadName = "FishingFishersI";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 3)
        {
            loadNSave.savedData.levelToLoadName = "ShooShooMosquitoTestI";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 4)
        {
            loadNSave.savedData.levelToLoadName = "FlashlightBBrokeyI";
            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 5)
        {
            loadNSave.savedData.levelToLoadName = "MarshmallowRoastingI";
            loadNSave.RewriteSaveFile();
        }

        SceneManager.LoadScene("LoadingScreen");
    }

}
