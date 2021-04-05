using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject GameOverScreen;
    public Button BackToCampButton;
    public Text marshmallowsGained_txt;
    public Text timeRemaining_txt;
    public Text timeRemainingShadow_txt;
    public int timeRemaining = 60; // minute by default


    public LoadAndSave loadAndSave;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Countdown");
    }


    IEnumerator Countdown()
    {
        while(timeRemaining > 0)
        {
            timeRemaining--;
            timeRemaining_txt.text = timeRemaining.ToString();
            timeRemainingShadow_txt.text = timeRemaining.ToString();
            yield return new WaitForSeconds(1.0f);
        }

        // When the timer ends, the game over screen appears
        GameOverScreen.SetActive(true);

        // Marshmallows gained are counted (3 seconds)
        int marshmallowsGained = GetMarshmallowsGained();

        for (int i = 0; i < marshmallowsGained + 1; i++)
        {
            marshmallowsGained_txt.text = "+" + i.ToString();
            //...pulse effect
            yield return new WaitForSeconds(3 / (float) marshmallowsGained);
        }

        // After marshmallows are counted, you can return to camp (button is greyed out while counting)
        BackToCampButton.interactable = true;
        
        // Save
    }


    // Called when you want to quit marshmallow roasting. It can also be used for minigames that you're able to 'die' before timer runs out.
    public void SkipToEndOfCountdown()
    {
        timeRemaining = 0;
    }


    // When the timer ends, retrieve the amount of marshmallows gained from the respective game manager (or whatever is tracking your score).
    int GetMarshmallowsGained()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "MarshmallowRoasting":
                return GameObject.Find("Game Manager").GetComponent<GM_MarshmallowRoasting>().CalculateMarshmallowsGained();

            case "CanoeBooBoo":
                return GameObject.Find("Game Manager").GetComponent<GM_CanoeBB>().CalculateMarshmallowsGained();

            case "FishingFishers":
                return GameObject.Find("Game Manager").GetComponent<GM_Fishing>().CalculateMarshmallowsGained();
                /*
            case "FlashlighBBrokey":
                //...

            case "SaveSam":
                //...

            case "ShooShooMosquiotoTest":
                //...
                break;
                */
            default:
                return 0;
        }
    }


    // Called when the "Back to Camp" button is pressed.
    public void ReturnToCamp()
    {
        //Debug.Log("Pressed");
        loadAndSave.savedData.levelToLoadName = "UpdatedCampOverworld";

        loadAndSave.RewriteSaveFile();

        SceneManager.LoadScene("LoadingScreen");
    }

}
