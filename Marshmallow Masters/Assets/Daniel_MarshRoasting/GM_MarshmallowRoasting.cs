using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_MarshmallowRoasting : MonoBehaviour
{
    int score = 0;
    public int marshmallowsRemaining;
    public Text scoreDisplay, marshmallowsRemainingDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MarshmallowAdded()
    {
        marshmallowsRemaining--;
        marshmallowsRemainingDisplay.text = marshmallowsRemaining.ToString();
    }

    public void MarshmallowRemoved(int score)
    {
        this.score += score;
        scoreDisplay.text = this.score.ToString();
    }
}
