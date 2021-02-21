using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadAndSave : MonoBehaviour
{
    //Some of this stuff is from a previous project
    //I'm leaving garbage here for reminders. Once I have everything sorted, I'll clean up
    // - Ren

    public SavedData savedData;


    //public HighScores highScores = new HighScores();

    public GameObject namecreation;

    public GameObject scoreManger;

    //The text that the player inputs for their name
    //public Text inputField;

    //Used later to save the inputed name
    public string newName;


    public int marshmallows;
    public int roastedMarshmallows;
    void Start()
    {
        //Load scores
        //LoadSaveFile();


        /*
        //Sort the array from least to greatest score as well as connect the names with the scores
        if (SceneManager.GetActiveScene().name == "UITest")
        {
            Array.Sort(highScores.savedHighScores, highScores.savedNames);
            highScores.newHighScoreAchieved = false;
        }


        Debug.Log("Loaded Scores.");

        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //If in the scene UITest, run the SaveScores function
        if (SceneManager.GetActiveScene().name == "UITest")
            SaveScores();

        //If in the scene HighScoreScreen, run the InputName function 
        else if (SceneManager.GetActiveScene().name == "HighScoreScreen" && highScores.newHighScoreAchieved)
        {
            InputName();
           
        }
        */

    }
    /*
    public void SaveScores()
    {


        //If reached end of game or died
        if (Input.GetKey("s"))
        {
            for (int i = 0; i < highScores.savedHighScores.Length; i++)
            {
                //If the player's score is greater than any of the saved scores
                if (scoreManger.GetComponent<ScoreManager>().score > highScores.savedHighScores[i])
                {
                    Debug.Log("Good job mate, yeh beat a score!");
                    //Replace the lowest score with the player's new score
                    highScores.savedHighScores[0] = scoreManger.GetComponent<ScoreManager>().score;
                    highScores.newHighScoreAchieved = true;
                    //Save the new score
                    RewriteSaveFile();

                    //Load the next scene
                    SceneManager.LoadScene("HighScoreScreen");
                    Debug.Log("Saved Scores.");

                }
                //If the player's score is less than all the saved scores
                else if (scoreManger.GetComponent<ScoreManager>().score < highScores.savedHighScores[0])
                    Debug.Log("Hah you are a potato and cannot beat dah scores!");
                SceneManager.LoadScene("HighScoreScreen");
            }

        }
    }
    */

    //Function for inserting player name and saving name
    public void InputName()
    {
        //Replace the lowest score name with the new inputed name
        //newName = namecreation.GetComponent<NameCreation>().playerName;
        //highScores.savedNames[0] = newName;

    }

    //Specifically used to replace old name
    public void SaveName()
    {

            //Re-sort the array now that the player's name and score have been inputed
            //Array.Sort(highScores.savedHighScores, highScores.savedNames);

            //Save the newly sorted information/array
            RewriteSaveFile();
        

    }








    //Loads the save file
    public void LoadSaveFile()
    {

        savedData = JsonTools.DeserializeObject<SavedData>(Application.dataPath + "/Initial Folder" + "/SaveFiles" + "/" + "SaveFile");
        Debug.Log("Loaded information.");

    }

    //Saves over the previous save file
    public void RewriteSaveFile()
    {
        JsonTools.SaveSerializedObject(savedData, Application.dataPath + "/Initial Folder" + "/SaveFiles", "SaveFile");
        Debug.Log("Saved information.");
    }
}
