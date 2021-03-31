using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject GameOverScreen;
    public Button BackToCampButton;
    public Text marshmallowsGained_txt;
    public Text timeRemaining_txt;
    public Text timeRemainingShadow_txt;
    public int timeRemaining = 60; //seconds

    public Vector2 referenceToMarshmallowsGained;
    // Vector2 ...;
    

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
        int marshmallowsGained = (int)referenceToMarshmallowsGained.x;
        // I need to get marshmallows gained

        for (int i = 0; i < marshmallowsGained + 1; i++)
        {
            marshmallowsGained_txt.text = "+" + i.ToString();
            //...pulse effect
            yield return new WaitForSeconds(3 / (float) marshmallowsGained);
        }

        BackToCampButton.interactable = true;
        // Save.
    }


    public void SkipToEndOfCountdown()
    {
        timeRemaining = 0;
    }

    public void GetMarshmallowsGained(Vector2 v2)
    {
        referenceToMarshmallowsGained = v2;
    }

    public void ReturnToCamp()
    {
        Debug.Log("Pressed");
    }
}
