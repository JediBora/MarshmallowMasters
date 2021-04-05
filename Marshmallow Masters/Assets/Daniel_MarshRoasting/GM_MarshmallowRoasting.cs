using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_MarshmallowRoasting : MonoBehaviour
{
    public int successfullyRoastedMarshmallows;
    public int marshmallowsUsed;
    public int marshmallowsRemaining;
    public Text roastedMarshmallowsGained_txt, marshmallowsRemainingDisplay;
    public Text message;

    
    // Start is called before the first frame update
    void Start()
    {
        //Load marshmallow count.
    }

    public void MarshmallowAdded()
    {
        marshmallowsUsed++;
        marshmallowsRemaining--;
        marshmallowsRemainingDisplay.text = marshmallowsRemaining.ToString();
    }

    public void MarshmallowRemoved(bool success, string msg)
    {
        if (success)
        {
            successfullyRoastedMarshmallows++;
            
            if (msg == "Perfect!")
            {
                successfullyRoastedMarshmallows++; //You get 2 roasted marshmallows if you cook it perfectly.
            }

            roastedMarshmallowsGained_txt.text = successfullyRoastedMarshmallows.ToString();
        }
        message.text = msg;
        Invoke("RemoveMessage", 2.0f);

    }

    public int CalculateMarshmallowsGained()
    {
        // Or in this case, 'roasted' marshmallows
        return (successfullyRoastedMarshmallows);
    }

    public void RemoveMessage()
    {
        message.text = "";
    }
}
