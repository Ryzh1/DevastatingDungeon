using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource sound;




    void Awake()
    {
        sound = GetComponent<AudioSource>();
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);


    }

    public void UpdateSound(float volume)
    {
        sound.volume = volume;
        
    }
}
