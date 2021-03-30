using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SavedData
{
    [Header ("Player Name")]
    public string playerName;

    [Space(10)]

    [Header("Shmellows in Inventory")]
    public int marshmallows;
    public int roastedMarshmallows;

    [Space(10)]

    [Header("High Scores")]

    public int shooShooMosquitoHighScore;
    public int saveYourSandwichHighScore;
    public int canoeBooBooHighScore;
    public int flashlightBBrokeyHighScore;
    public int fishingFishersHighScore;

    [Space(10)]

    public int endlessModeHighScore;

    [Space(10)]

    [Header("High Scores")]

    // 1 = 1, 2 = 2, 3 = 3
    public int setMinigameDifficulty;
}
