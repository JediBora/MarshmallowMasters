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
    public int timeRemaining = 60; //seconds
    

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

        GameOverScreen.SetActive(true);
        int marshmallowsGained = GetMarshmallowsGained();

        for (int i = 0; i < marshmallowsGained + 1; i++)
        {
            marshmallowsGained_txt.text = "+" + i.ToString();
            //...pulse effect
            yield return new WaitForSeconds(3 / (float) marshmallowsGained);
        }

        BackToCampButton.interactable = true;
        // >>>Save<<<
    }

    public void SkipToEndOfCountdown()
    {
        timeRemaining = 0;
    }

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

    public void ReturnToCamp()
    {
        //Debug.Log("Pressed");
        SceneManager.LoadScene("CampOverworld");
    }
}
