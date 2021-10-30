using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{


    [SerializeField] private Sprite[] enemySprites = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        //spawn between y (3, -4.5)

        //EnemyBehavior enemy = new EnemyBehavior(10, 10.0f, MovePattern.Straight, ShootPattern.Straight, enemySprites[0]); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
