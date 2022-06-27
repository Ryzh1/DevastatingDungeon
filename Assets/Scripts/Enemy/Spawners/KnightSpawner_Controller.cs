using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSpawner_Controller : MonoBehaviour
{

    public int KnightSpawnerMaxHealth = 900;
    public bool IsInvincible;


    public int KnightSpawnerCurrentHealth;
    private SpriteRenderer spriterenderer;
    private Rigidbody2D rb;

    public float SpawnRate = 5f;
    public GameObject Knight;

    public bool IsSpawning;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();

        KnightSpawnerCurrentHealth = KnightSpawnerMaxHealth;



    }

    // Update is called once per frame
    void Update()
    {

        if (KnightSpawnerCurrentHealth <= 0)
        {
            ScoreScript.ScoreValue += 5;
            Destroy(gameObject);

        }


        if (IsSpawning == false)
        {
            StartCoroutine("Delay", SpawnRate);
        }

    }

    //Health
    public void ChangeHealth(int amount)
    {

        KnightSpawnerCurrentHealth = Mathf.Clamp(KnightSpawnerCurrentHealth + amount, 0, KnightSpawnerMaxHealth);



    }


    // SPawner
    IEnumerator Delay(float delay)
    {

        // Spawn knight every few seconds.
        IsSpawning = true;

        Instantiate(Knight, transform.position, transform.rotation);
        yield return new WaitForSeconds(delay);

        IsSpawning = false;



    }
}
