using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Slider_Controller : MonoBehaviour
{

    public void ChangeSound()
    {
        float sound = GetComponent<Slider>().value;
        GameObject.FindGameObjectsWithTag("Music")[0].GetComponent<SoundController>().UpdateSound(sound);
    }
}
