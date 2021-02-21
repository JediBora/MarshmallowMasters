using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveFileTest : MonoBehaviour
{
    public GameObject nameField;

    //Accessing saved data
    public LoadAndSave loadAndSave;

    public TextMeshProUGUI shmellowCount;
    public TextMeshProUGUI nameDisplay;

    //Saves the inputed name in the namefield as the player name
    public void SetName()
    {
        loadAndSave.savedData.playerName = nameField.GetComponent<TMP_Text>().text;
        nameDisplay.GetComponent<TMP_Text>().text = "Name: " + loadAndSave.savedData.playerName;
    }

    public void AddOneMarshmellow()
    {
        loadAndSave.savedData.marshmallows += 1;
        shmellowCount.text = "Shmellows: " + loadAndSave.savedData.marshmallows;
    }

    public void SubtractOneMarshmellow()
    {
        loadAndSave.savedData.marshmallows -= 1;
        shmellowCount.text = "Shmellows: " + loadAndSave.savedData.marshmallows;
    }

    public void Update()
    {



    }

    public void LoadSavedFile()
    {
        shmellowCount.text = "Shmellows: " + loadAndSave.savedData.marshmallows;
        nameDisplay.text = "Name: " + loadAndSave.savedData.playerName;



    }

}
