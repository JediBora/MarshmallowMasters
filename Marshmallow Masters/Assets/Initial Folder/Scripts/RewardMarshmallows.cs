using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Minigames
{
    NotMiniGame,
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
    public MosquitoSpawnerManager mosquitoSpawnerManager;

    [Space]

    [Header("Fishing Fishers Related")]

    public GM_Fishing Fishing_GM;

    [Space]

    [Header("Canoe Boo Boo Related")]

    public GM_CanoeBB Canoe_GM;

    [Space]

    [Header("Marshmallow Roastin' Related")]

    public GM_MarshmallowRoasting MRoastin_GM;



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

                        // For now you get a fixed amount if you survive until the end.
                        if (true)
                        {
                            autoLoadAndRewriteSave.RewriteMarshmallowCount(10, 0);
                        }
                        else
                        {
                            autoLoadAndRewriteSave.RewriteMarshmallowCount(1, 0);
                        }

                        updatedMarshmallowCount = true;
                    }
                }
                break;

            case Minigames.FishingFishers:
                {
                    if (!updatedMarshmallowCount)
                    {
                        Debug.Log("FishingFishers has ended.");

                        // For now you get 3 marshamllows per fish
                        autoLoadAndRewriteSave.RewriteMarshmallowCount(Fishing_GM.fishCaught * 3, 0);

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
                            if (flashlightDifficultyController.difficultyOne)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(2, 0);
                            //This game currently awards based on the difficulty of the game
                            else if (flashlightDifficultyController.difficultyTwo)
                                //Sets how many marshmallows to add. The first integer is Marshmallows, the second is Roasted Marshmallows.
                                //To subtract marshmallows from the player, simply use negative values
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(4, 0);

                            else if (flashlightDifficultyController.difficultyTwo)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(6, 0);

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
                            if (mosquitoSpawnerManager.levelOne)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(3, 0);
                            else if (mosquitoSpawnerManager.levelTwo)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(5, 0);
                            else if (mosquitoSpawnerManager.levelThree)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(7, 0);

                            updatedMarshmallowCount = true;
                        }
                        //If the player has made it to the end and lives with 3 lives remaining
                        else if (mosquitoGameManager.timeToSurvive <= 0 && mosquitoGameManager.lives == 3)
                        {
                            if (mosquitoSpawnerManager.levelOne)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(2, 0);
                            else if (mosquitoSpawnerManager.levelTwo)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(3, 0);
                            else if (mosquitoSpawnerManager.levelThree)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(5, 0);

                            updatedMarshmallowCount = true;
                        }
                        //If the player has made it to the end and lives with 2 lives remaining
                        else if (mosquitoGameManager.timeToSurvive <= 0 && mosquitoGameManager.lives == 2)
                        {
                            if (mosquitoSpawnerManager.levelOne)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(2, 0);
                            else if (mosquitoSpawnerManager.levelTwo)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(3, 0);
                            else if (mosquitoSpawnerManager.levelThree)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(5, 0);

                            updatedMarshmallowCount = true;
                        }
                        //If the player has made it to the end and lives with 1 lives remaining
                        else if (mosquitoGameManager.timeToSurvive <= 0 && mosquitoGameManager.lives == 1)
                        {
                            if (mosquitoSpawnerManager.levelOne)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(1, 0);
                            else if (mosquitoSpawnerManager.levelTwo)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(2, 0);
                            else if (mosquitoSpawnerManager.levelThree)
                                autoLoadAndRewriteSave.RewriteMarshmallowCount(4, 0);

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
                        autoLoadAndRewriteSave.RewriteMarshmallowCount(-MRoastin_GM.marshmallowsUsed, MRoastin_GM.successfullyRoastedMarshmallows);

                        updatedMarshmallowCount = true;
                    }
                }
                break;
        }




    }

}
