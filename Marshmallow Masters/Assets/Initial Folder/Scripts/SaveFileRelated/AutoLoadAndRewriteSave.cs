using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLoadAndRewriteSave : MonoBehaviour
{
    [Header("This Script Shouldn't Need Editing")]
    public LoadAndSave loadNSave;

    // Start is called before the first frame update
    void Awake()
    {
        loadNSave.LoadSaveFile();
    }

    public void RewriteMarshmallowCount(int newMarshmallows, int newRoastedMarshmallows)
    {
        loadNSave.savedData.marshmallows += newMarshmallows;
        loadNSave.savedData.roastedMarshmallows += newRoastedMarshmallows;

        loadNSave.RewriteSaveFile();


    }
}
