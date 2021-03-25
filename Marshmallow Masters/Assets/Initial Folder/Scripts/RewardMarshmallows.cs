using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Minigames
{
    CanoeBooBoo,
    FishingFishers,
    FlashlightBBrokey,
    SaveYourSandwich,
    ShooShooMosquito,
    MarshmallowRoasting
};

public class RewardMarshmallows : MonoBehaviour
{
    [Header("PLEASE SET ME TO THE CORRESPONDING GAME")]
    public Minigames currentMinigame;

    [Space]

    public AutoLoadAndRewriteSave autoLoadAndRewriteSave;

    //Used to determine if marshmallows have already been added and limits the amount of added marshmallow
    public bool updatedMarshmallowCount;

    [Header("Flashlight B Brokey Related")]

    public GameController gameController;
    public FlashlightDifficultyController flashlightDifficultyController;
    
    [Space]

    [Header("Shoo Shoo Mosquito Related")]

    public ShooShooMosquitoGameManger mosquitoGameManager;


    public void Awake()
    {
        updatedMarshmallowCount = false;
    }

    public void Update()
    {
        //Automatically updates marshmallow count based on specifications within Switch cases
        UpdatePlayerMarshmallowCount();

    }


    public void UpdatePlayerMarshmallowCount()
    {
        switch (currentMinigame)
        {
            case Minigames.CanoeBooBoo:
                {
                    if (!updatedMarshmallowCount)
                    {
                        Debug.Log("CanoeBooBoo has ended.");

                        //Sets how many marshmallows to add. The first integer is Marshmallows, the second is Roasted Marshmallows.
                        //To subtract marshmallows from the player, simply use negative values
                        //Use the below commented code to add/subtract marshmallows from the player
                        //autoLoadAndRewriteSave.RewriteMarshmallowCount(0, 0);


                        updatedMarshmallowCount = true;
                    }
                }
                break;

            case Minigames.FishingFishers:
                {
                    if (!updatedMarshmallowCount)
                    {
                        Debug.Log("FishingFishers has ended.");

                        //Sets how many marshmallows to add. The first integer is Marshmallows, the second is Roasted Marshmallows.
                        //To subtract marshmallows from the player, simply use negative values
                        //Use the below commented code to add/subtract marshmallows from the player
                        //autoLoadAndRewriteSave.RewriteMarshmallowCount(0, 0);


                        updatedMarshmallowCount = true;
                    }
                }
                break;

            case Minigames.FlashlightBBrokey:
                {


                    if (!updatedMarshmallowCount)
                    {
                        //If the player is successful at mini game
                        if (gameController.outOfForest)
                        {
                            //This game currently awards based on the difficulty of the game
                            if (flashlightDifficultyController.difficultyTwo)
                                //Sets how many marshmallows to add. The first integer is Marshmallows, the second is Roasted Marshmallows.
                                //To subtract marshmallows from the player, simply use negative values
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(2, 0);


                            Debug.Log("FlashlightBBrokey has ended.");
                            updatedMarshmallowCount = true;
                        }

                    }

                }
                break;


            case Minigames.SaveYourSandwich:
                {
                    if (!updatedMarshmallowCount)
                    {
                        Debug.Log("SaveYourSandwich has ended.");


                        //Sets how many marshmallows to add. The first integer is Marshmallows, the second is Roasted Marshmallows.
                        //To subtract marshmallows from the player, simply use negative values
                        //Use the below commented code to add/subtract marshmallows from the player
                        //autoLoadAndRewriteSave.RewriteMarshmallowCount(0, 0);


                        updatedMarshmallowCount = true;
                    }
                }
                break;

            case Minigames.ShooShooMosquito:
                {
                    if (!updatedMarshmallowCount)
                    {
                        //If the player has made it to the end and lives with 4 lives remaining
                        if (mosquitoGameManager.timeToSurvive <= 0 && mosquitoGameManager.lives == 4)
                        {
                            //Sets how many marshmallows to add. The first integer is Marshmallows, the second is Roasted Marshmallows.
                            //To subtract marshmallows from the player, simply use negative values
                            autoLoadAndRewriteSave.RewriteMarshmallowCount(3, 0);

                            updatedMarshmallowCount = true;
                        }
                        //If the player has made it to the end and lives with 3 lives remaining
                        else if (mosquitoGameManager.timeToSurvive <= 0 && mosquitoGameManager.lives == 3)
                        {
                            autoLoadAndRewriteSave.RewriteMarshmallowCount(2, 0);

                            updatedMarshmallowCount = true;
                        }
                        //If the player has made it to the end and lives with 2 lives remaining
                        else if (mosquitoGameManager.timeToSurvive <= 0 && mosquitoGameManager.lives == 2)
                        {
                            autoLoadAndRewriteSave.RewriteMarshmallowCount(2, 0);

                            updatedMarshmallowCount = true;
                        }
                        //If the player has made it to the end and lives with 1 lives remaining
                        else if (mosquitoGameManager.timeToSurvive <= 0 && mosquitoGameManager.lives == 1)
                        {
                            autoLoadAndRewriteSave.RewriteMarshmallowCount(1, 0);

                            updatedMarshmallowCount = true;
                        }

                        Debug.Log("ShooShooMosquito has ended.");

                        
                    }
                }
                break;


            case Minigames.MarshmallowRoasting:
                {
                    if (!updatedMarshmallowCount)
                    {
                        Debug.Log("SaveYourSandwich has ended.");

                        updatedMarshmallowCount = true;
                    }
                }
                break;
        }




    }

}
