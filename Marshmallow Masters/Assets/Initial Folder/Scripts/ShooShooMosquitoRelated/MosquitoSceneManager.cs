using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MosquitoSceneManager : MonoBehaviour
{
    public string overworldName;

    public ShooShooMosquitoGameManger gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.timeToSurvive <= 0 || gameManager.lives <= 0)
        {
            SceneManager.LoadScene(overworldName);

        }
        

    }


}
