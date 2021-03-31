using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySquishSound : MonoBehaviour
{

    AudioSource source;
    public List<AudioClip> sound;
    int randomSoundNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        randomSoundNumber = Random.Range(0, 3);
        StartCoroutine(PlaySquish());
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }


    private IEnumerator PlaySquish()
    {
        source.PlayOneShot(sound[randomSoundNumber]);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        yield return null;
    }


}
