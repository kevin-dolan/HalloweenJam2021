using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float bulletCoolDown;
    //[SerializeField] private float bulletSpeed;
    [SerializeField] private int damage;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float invincibilityCoolDOwn;
    private float cooldownCounter;
    private float damageCooldownCounter;
    [SerializeField] private int playerHealth;
    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        //playerSpeed = gameObject.GetComponent<>
    }

    // Update is called once per frame
    void Update()
    {
        //if the player presses W or Up key
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 playerPosition = transform.position;
            playerPosition.y += playerSpeed;
            transform.position = playerPosition;
        }

        //if the player presses S or Down key
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 playerPosition = transform.position;
            playerPosition.y -= playerSpeed;
            transform.position = playerPosition;
        }

        ////if the player presses W or Up key
        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    Vector3 playerPosition = transform.position;
        //    playerPosition.x += playerSpeed;
        //    transform.position = playerPosition;
        //}

        ////if the player presses A or Left key
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //{
        //    Vector3 playerPosition = transform.position;
        //    playerPosition.x -= playerSpeed;
        //    transform.position = playerPosition;
        //}

        //cooling down based on real time
        if (cooldownCounter > 0)
        {
            cooldownCounter -= Time.deltaTime;

        }

        //pressing space to shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cooldownCounter > 0)
            {
                return;
            }
            Debug.Log("Shoot");
            Shoot();
            cooldownCounter = bulletCoolDown;
        }

        //takeDamage();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //cooling down based on real time
        if (damageCooldownCounter > 0)
        {
            damageCooldownCounter -= Time.deltaTime;

        }

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            Debug.Log(playerHealth);
            if (damageCooldownCounter > 0)
            {
                Debug.Log("im not hurt");
                return;
            }
            else
            {
                Debug.Log("im hurt");
                Shoot();
                playerHealth -= 1;
            }
            damageCooldownCounter = invincibilityCoolDOwn;
            //game over when the player's health is 0
            if (playerHealth == 0)
            {
                Debug.Log("You died.");
            }
        }
    }

    void Shoot()
    {
        GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.GetComponent<BulletScript>().dmg = damage;
    }
        
}
