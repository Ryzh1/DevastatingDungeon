using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardPowerUp : MonoBehaviour
{

    public int PowerUpChance;
    public int WhichPowerUp;

    public GameObject HealthPower;
    public GameObject SpeedPower;
    public GameObject FireRatePower;
    public GameObject DamagePower;

    private Wizard_Controller wizard;




    // Start is called before the first frame update
    void Start()
    {
        wizard = gameObject.GetComponent<Wizard_Controller>();

    }

    // If wizard is dead creates a random number if below 20 then it is a power up.
    //Then creates another random number which decides which powerup to place.
    void Update()
    {
        if (wizard.WizardCurrentHealth <= 0)
        {
            PowerUpChance = Random.Range(0, 100);



            if (PowerUpChance <= 100)
            {
                GameObject Player = GameObject.FindWithTag("Player");

                WhichPowerUp = Random.Range(0, 100);


                if (WhichPowerUp <= 25)
                {
                    GameObject healthPower = Instantiate(HealthPower, transform.position, transform.rotation);
                    healthPower.GetComponent<HealthPowerUp_Controller>().location = transform.position;
                }

                else if (WhichPowerUp <= 50 && WhichPowerUp >= 26)
                {
                    GameObject speedPower = Instantiate(SpeedPower, transform.position, transform.rotation);
                    speedPower.GetComponent<SpeedPowerUp_Controller>().location = transform.position;
                    speedPower.GetComponent<SpeedPowerUp_Controller>().Player = Player;
                }

                else if (WhichPowerUp <= 75 && WhichPowerUp >= 51)
                {
                    GameObject fireRatePower = Instantiate(FireRatePower, transform.position, transform.rotation);
                    fireRatePower.GetComponent<FireRatePowerUp_Controller>().location = transform.position;
                    fireRatePower.GetComponent<FireRatePowerUp_Controller>().Player = Player;
                }

                else if (WhichPowerUp <= 100 && WhichPowerUp >= 76)
                {
                    GameObject damagePower = Instantiate(DamagePower, transform.position, transform.rotation);
                    damagePower.GetComponent<DamagePowerUp_Controller>().location = transform.position;
                    damagePower.GetComponent<DamagePowerUp_Controller>().Player = Player;
                }

            }
        }



    }
}


