using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarshmallowCount : MonoBehaviour
{
    //Accessing saved data to display
    public LoadAndSave loadAndSave;

    public TextMeshProUGUI shmellowCount;
    public TextMeshProUGUI roastedShmellowCount;



    // Update is called once per frame
    void Update()
    {
        shmellowCount.text = "Marshmallows: " + loadAndSave.savedData.marshmallows;
        roastedShmellowCount.text = " Roasted Marshmallows: " + loadAndSave.savedData.roastedMarshmallows;
    }
}
