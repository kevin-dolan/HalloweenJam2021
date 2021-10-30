using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovePattern { Straight, Zigzag, Sine, Stutter };
public enum ShootPattern { None, Straight, Bifurcated, Trifurcated };

public class EnemyBehavior : MonoBehaviour
{

    private int health;
    private float moveSpeed;
    private MovePattern movePattern;
    private ShootPattern shootPattern;

    private SpriteRenderer spriteRenderer;
    private Sprite sprite;



    public EnemyBehavior(int h, float s, MovePattern mp, ShootPattern sp, Sprite spr)
    {
        health = h;
        moveSpeed = s;
        movePattern = mp;
        shootPattern = sp;

        sprite = spr;
    }

    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer.sprite = sprite; //set the sprite of the 
    }

    // Update is called once per frame
    void Update()
    {
        //movement logic
        switch(movePattern)
        {
            case MovePattern.Zigzag:
                break;
            case MovePattern.Sine:
                break;
            case MovePattern.Stutter:
                break;
            case MovePattern.Straight:
            default: //in default case, do the same behavior as MovePattern.Straight

                break;
        }



        if(transform.position.x < -10) //if the enemy goes off screen to the left of the player, die
        {
            Die();
        }

    }

    public void FireBullet()
    {

    }

    public void Die()
    {
        //animation?

        Destroy(this);
    }
}
