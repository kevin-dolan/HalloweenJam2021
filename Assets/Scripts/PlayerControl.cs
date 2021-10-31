using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float bulletCoolDown;
    [SerializeField] private int damage;
    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletNumber;
    [SerializeField] private float invincibilityCoolDOwn;
    [SerializeField] private Sprite heart1;
    [SerializeField] private Sprite heart2;
    [SerializeField] private Sprite heart3;
    [SerializeField] private Sprite heart4;

    private Vector3 v3zero = Vector3.zero;
    private float cooldownCounter;
    private float damageCooldownCounter;
    [SerializeField] private int playerHealth;
    private GameObject playerObject;
    private Canvas canvas;

    public float PlayerSpeed
    {
        get
        {
            return playerSpeed;
        }
        set
        {
            playerSpeed = value;
        }
    }

    public float BulletCoolDown
    {
        get
        {
            return bulletCoolDown;
        }
        set
        {
            bulletCoolDown = value;
        }
    }
    
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    

    public int PlayerHealth
    {
        get
        {
            return playerHealth;
        }
        set
        {
            playerHealth = value;
        }
    }
    public int BulletNumber
    {
        get
        {
            return bulletNumber;
        }
        set
        {
            bulletNumber = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
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
            for(int i = 0; i < bulletNumber; i++)
            {
                Debug.Log("Shoot");
                Shoot();
            }
            
            cooldownCounter = bulletCoolDown;
        }

        if (damageCooldownCounter > 0)
        {
            damageCooldownCounter -= Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //cooling down based on real time
        

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
                playerHealth -= 1;
                damageCooldownCounter = invincibilityCoolDOwn;
            }
            
            //game over when the player's health is 0
            if (playerHealth == 0)
            {
                Debug.Log("You died.");
                //game over code
                SceneManager.LoadScene(0);
            }

            if(playerHealth == 4)
            {
                canvas.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = heart1;
                canvas.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>().sprite = heart1;
                canvas.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = heart1;
                canvas.transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Image>().sprite = heart1;
            }
            else if(playerHealth == 3)
            {
                canvas.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = heart1;
                canvas.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>().sprite = heart1;
                canvas.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = heart1;
                canvas.transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Image>().sprite = heart2;
            }
            else if (playerHealth == 2)
            {
                canvas.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = heart1;
                canvas.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>().sprite = heart1;
                canvas.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = heart2;
                canvas.transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Image>().sprite = heart2;
            }
            else if (playerHealth == 1)
            {
                canvas.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = heart1;
                canvas.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>().sprite = heart2;
                canvas.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = heart2;
                canvas.transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Image>().sprite = heart2;
            }
            else if (playerHealth == 0)
            {
                canvas.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = heart2;
                canvas.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>().sprite = heart2;
                canvas.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = heart2;
                canvas.transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Image>().sprite = heart2;
            }

             
        }
    }

    void Shoot()
    {
        GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.transform.localScale = Vector3.one * bulletClone.GetComponent<BulletScript>().bulletSize;
        bulletClone.GetComponent<BulletScript>().dmg = damage;
    }   

    void TakeFoot()
    {
        playerSpeed -= 0.02f;
        damage += 3;
    }

    void TakeEye()
    {
        bulletCoolDown = 0.3f;
    }

    void TakeHand()
    {
        playerHealth += 1;
        bulletCoolDown = 1;
    }

    void TakeHeart()
    {
        playerHealth = 1;
        bulletCoolDown = 0.05f;
    }
}
