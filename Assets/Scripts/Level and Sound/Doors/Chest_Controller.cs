using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Controller : MonoBehaviour
{
    public Animator OpenChest;
    public bool HasOpened = false;
    public AudioSource loot;


    void Start()
    {
        OpenChest = GetComponent<Animator>();
        OpenChest.SetBool("IsTouching", false);
    }

        
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (HasOpened != true)
        {
            if (other.tag == "Player")
            {
                loot.Play();

                OpenChest.SetBool("IsTouching", true);
                Key_Script.KeyValue += 1;
                HasOpened = true;
            }
        }
            
    }

}
