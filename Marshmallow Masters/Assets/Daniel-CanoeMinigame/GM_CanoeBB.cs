using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_CanoeBB : MonoBehaviour
{
    //Wave
    public int waveStrength;
    int waveDirection;
    int waveSecondsAfterWarning;

    public GameObject waveWarningIndicator;
    public Canoe canoe;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaveGenerator");
    }

    IEnumerator WaveGenerator()
    {
        while (true)
        {
            //Set up the attributes of the next wave
            if (Random.Range(1, 11) > 5)
            {
                waveDirection = 1;
                waveWarningIndicator.transform.GetChild(0).localScale = new Vector3(2, 2, 1); //flip scale
            }
            else
            {
                waveDirection = -1;
                waveWarningIndicator.transform.GetChild(0).localScale = new Vector3(-2, 2, 1); //flip scale
            }

            waveSecondsAfterWarning = Random.Range(1, 5);
            waveWarningIndicator.transform.GetChild(1).GetComponent<Text>().text = waveSecondsAfterWarning + " sec";

            //Show warning
            yield return new WaitForSeconds(Random.Range(3f, 7f));
            waveWarningIndicator.SetActive(true);

            //Hide warning
            yield return new WaitForSeconds(2.0f);
            waveWarningIndicator.SetActive(false);

            //After the warning goes away, the wave hits a few seconds after.
            yield return new WaitForSeconds(waveSecondsAfterWarning);
            canoe.HitWithWave(waveStrength * waveDirection);


        }
        
    }
    public int CalculateMarshmallowsGained()
    {
        return 2;
    }
}
