using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovePattern { Straight, Zigzag, Sine, Stutter };
public enum ShootPattern { None, Straight, Bifurcated, Trifurcated };

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private float moveSpeed;
    [SerializeField] private MovePattern movePattern;
    [SerializeField] private ShootPattern shootPattern;
    [SerializeField] private float bulletCooldown;

    private float incrementMove = 0.0f; //used in movement logic (Zigzag, Stutter)
    private float bulletCounter = 0.0f;

    [SerializeField] private GameObject bulletPrefab;
    private Vector3 angleHolder = Vector3.zero; //used in movement logic (Sine)
    private Quaternion fireQuaternion;

    //psuedo-constructor
    public void SetBehavior(int h = 1, float s = 1.1f, MovePattern mp = MovePattern.Straight, ShootPattern sp = ShootPattern.None, float bc = 2.0f)
    {
        health = h;
        moveSpeed = s;
        movePattern = mp;
        shootPattern = sp;
        bulletCooldown = bc;
    }

    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer.sprite = sprite; //set the sprite of the 
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movement logic
        switch(movePattern)
        {
            case MovePattern.Zigzag:
                if(incrementMove <= 0.0f) { incrementMove = 2.0f; } //if incrementMove goes to 0 or below, reset to 2.0f

                if(incrementMove > 1.0f) { transform.position += Vector3.up * moveSpeed * Time.deltaTime; } //if incrementMove is greater than 1, move up.
                else if( incrementMove > 0.0f) { transform.position += Vector3.down * moveSpeed * Time.deltaTime; } //if incrementMove is less than 1 but greater than 0, move down.

                transform.position += Vector3.left * moveSpeed * Time.deltaTime; //move left.

                incrementMove -= Time.deltaTime; //subtract deltaTime from incrementMove
                break;

            case MovePattern.Sine:
                angleHolder = new Vector3(-Mathf.Abs(Mathf.Cos(incrementMove)), 
                                          Mathf.Sin(incrementMove), 
                                          0.0f);

                transform.position += (angleHolder) * moveSpeed * Time.deltaTime;

                incrementMove += Time.deltaTime; //add deltaTime to incrementMove
                break;

            case MovePattern.Stutter:
                if (incrementMove <= 0.0f) { incrementMove = 2.0f; } //if incrementMove goes to 0 or below, reset to 2.0f

                if (incrementMove > 1.0f) { transform.position += Vector3.left * moveSpeed * Time.deltaTime * 0.5f; } //if incrementMove is greater than 1, move half speed.
                else if (incrementMove > 0.0f) { transform.position += Vector3.left * moveSpeed * Time.deltaTime * 2.0f; } //if incrementMove is less than 1 but greater than 0, move double speed.

                incrementMove -= Time.deltaTime; //subtract deltaTime from incrementMove
                break;

            case MovePattern.Straight:
            default: //in default case, do the same behavior as MovePattern.Straight
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                break;
        }

        if(bulletCounter <= 0) //if bulletCounter is less than or equal to 0, fire
        {
            switch (shootPattern)
            {
                case ShootPattern.Straight:
                    FireBullet(0.0f);
                    break;
                case ShootPattern.Bifurcated:
                    FireBullet(30.0f); //Mathf.PI/6 is about 30deg
                    FireBullet(-30.0f);
                    break;
                case ShootPattern.Trifurcated:
                    FireBullet(30.0f);
                    FireBullet(0.0f);
                    FireBullet(-30.0f);
                    break;
                case ShootPattern.None:
                default:
                    //don't shoot anything
                    break;
            }

            bulletCounter = bulletCooldown; //after firing, reset bulletCounter.
        }

        bulletCounter -= Time.deltaTime;



        if (transform.position.x < -10) //if the enemy goes far enough to the left (should be offscreen), die
        {
            Die();
        }

    }

    //fire a bullet from the enemy. ANGLE IS IS RADIANS!
    public void FireBullet(float fireAngle = 0.0f)
    {
        //fireQuaternion.Set(0.0f, 0.0f, Mathf.Sin(Mathf.Deg2Rad * 30.0f), 1);
        GameObject bulletHolder = Instantiate(bulletPrefab, transform.position, fireQuaternion);
        bulletHolder.transform.Rotate(0.0f, 0.0f, fireAngle); //this is stupid and inefficient
    }

    //public method to take damage.
    public void TakeDamage(int dmg)
    {
        health -= dmg;

        if(health <= 0) { Die(); }
    }

    //destroys self, possibly plays animation if we have time.
    public void Die()
    {
        //animation?

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            Debug.Log("Enemy hit a player!");
            //collision.gameObject.GetComponent<PlayerControl>().TakeDamage();
        }
    }
}
