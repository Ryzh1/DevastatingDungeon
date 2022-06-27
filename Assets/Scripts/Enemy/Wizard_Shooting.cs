using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Shooting : MonoBehaviour
{

    public GameObject Fireball;
    public float FireRate = 0.8f;
    public bool IsShooting;
    public bool InCombat;


    void Update()
    {
        if (IsShooting == false && InCombat == false)
        {

            StartCoroutine("Delay", FireRate);

        }
    }


    IEnumerator Delay(float delay)
    {


        GameObject player = GameObject.Find("Player");
        IsShooting = true;
        Vector3 pos = player.transform.position;
        
        GameObject fireball = Instantiate(Fireball, transform.position, transform.rotation);
        
        fireball.GetComponent<WizardProjectile>().location = (pos - transform.position);
        fireball.GetComponent<WizardProjectile>().location.Normalize();
        yield return new WaitForSeconds(delay);
        IsShooting = false;
        
    }
}
