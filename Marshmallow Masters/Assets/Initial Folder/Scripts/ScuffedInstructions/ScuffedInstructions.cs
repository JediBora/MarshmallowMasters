using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScuffedInstructions : MonoBehaviour
{
    public LoadAndSave loadNSave;

    public string overworldName;

    //0 = Save Your Sanwich
    //1 = Canoe Boo Boo
    //2 = Fishing Fishers
    //3 = Shoo Shoo Mosquito
    //4 = Flashlight B' Brokey
    //5 = Marshmallow Masters
    //6 = Overworld
    public int miniGameToLoad;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "SaveSamI")
        {
            //Add Save your Sandwich Scene
            miniGameToLoad = 0;
        }
        else if (scene.name == "CanoeBooBooI")
        {
            //Add Save your Sandwich Scene
            miniGameToLoad = 1;
        }
        else if (scene.name == "FishingFishersI")
        {
            //Add Save your Sandwich Scene
            miniGameToLoad = 2;
        }
        else if (scene.name == "ShooShooMosquitoTestI")
        {
            //Add Save your Sandwich Scene
            miniGameToLoad = 3;
        }
        else if (scene.name == "FlashlightBBrokeyI")
        {
            //Add Save your Sandwich Scene
            miniGameToLoad = 4;
        }
        else if (scene.name == "MarshmallowRoasting")
        {
            //Add Save your Sandwich Scene
            miniGameToLoad = 5;
        }
        else if (scene.name == "TitleScreen")
        {
            //Add Save your Sandwich Scene
            miniGameToLoad = 6;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void LoadCorrespondingScene()
    {


        if (miniGameToLoad == 0)
        {
            loadNSave.savedData.levelToLoadName = "SaveSam";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 1)
        {
            loadNSave.savedData.levelToLoadName = "CanoeBooBoo";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 2)
        {
            loadNSave.savedData.levelToLoadName = "FishingFishers";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 3)
        {
            loadNSave.savedData.levelToLoadName = "ShooShooMosquitoTest";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 4)
        {
            loadNSave.savedData.levelToLoadName = "FlashlightBBrokey";
            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 5)
        {
            loadNSave.savedData.levelToLoadName = "MarshmallowRoasting";
            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 6)
        {
            loadNSave.savedData.levelToLoadName = "UpdatedCampOverworld";
            loadNSave.RewriteSaveFile();
        }

        SceneManager.LoadScene("LoadingScreen");
    }
}
