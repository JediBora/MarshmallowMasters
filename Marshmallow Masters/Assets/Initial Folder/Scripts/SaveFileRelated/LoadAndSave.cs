﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadAndSave : MonoBehaviour
{
    [Header("Do not touch.")]
    [Header("Other scripts should set the following.")]
    //Accessing saved data
    public SavedData savedData;

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