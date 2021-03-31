using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
        Application.Quit(); // quits the application

    }

    public void Play()
    {
        SceneManager.LoadScene("ForestScene"); // loads game scene

    }
    public void Restart()
    {
        SceneManager.LoadScene("ForestScene"); // loads game scene

    }
    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu"); // loads main menu

    }
    public void Instructions()
    {

        SceneManager.LoadScene("Instructions");  // loads instructions menu

    }
}

