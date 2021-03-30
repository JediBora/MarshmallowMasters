using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySetter : MonoBehaviour
{
    public LoadAndSave loadAndSave;

    public void DifficultyOne()
    {
        loadAndSave.savedData.setMinigameDifficulty = 1;
        loadAndSave.RewriteSaveFile();

    }

    public void DifficultyTwo()
    {
        loadAndSave.savedData.setMinigameDifficulty = 2;
        loadAndSave.RewriteSaveFile();

    }

    public void DifficultyThree()
    {
        loadAndSave.savedData.setMinigameDifficulty = 3;
        loadAndSave.RewriteSaveFile();

    }
}
