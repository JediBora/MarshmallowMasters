using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenShake : MonoBehaviour
{

    public GameObject camera;
   
    // Start is called before the first frame update
   public void shakeScreen(Vector3 cameraShakeIntensity, float cameraShakeDuration) {


        iTween.ShakePosition(camera, cameraShakeIntensity, cameraShakeDuration);
    }
}
