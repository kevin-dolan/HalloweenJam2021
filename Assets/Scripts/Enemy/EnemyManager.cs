using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{


    [SerializeField] private Sprite[] enemySprites = new Sprite[4]; ////MUST BE SET IN INSPECTOR
    [SerializeField] private GameObject enemyPrefab; //MUST BE SET IN INSPECTOR
    [SerializeField] private List<EnemyGroup> eGroups = new List<EnemyGroup>(); //list of groups of enemies to spawn in the level this EnemyManager is currently in.

    private float spawnDelayCounter = 0;

    private Vector3 spawnPosition; //used while instantiating enemies. manipulated to spawn enemies in patterns.

    private EnemyGroup enemyGroupHolder;
    private GameObject enemyHolder;

    // Start is called before the first frame update
    void Start()
    {
        //spawn between y (3, -4.5)

        //EnemyBehavior enemy = new EnemyBehavior(10, 10.0f, MovePattern.Straight, ShootPattern.Straight, enemySprites[0]); 

        //GameObject enemy = Instantiate(enemyPrefab, new Vector3(10.0f, 0.0f, 0.0f), Quaternion.identity);
        //enemy.GetComponent<EnemyBehavior>().SetBehavior(2, 1.0f, MovePattern.Zigzag, ShootPattern.None);

        //GameObject enemy2 = Instantiate(enemyPrefab, new Vector3(10.0f, 2.0f, 0.0f), Quaternion.identity);
        //enemy2.GetComponent<SpriteRenderer>().sprite = enemySprites[1];
        //enemy2.GetComponent<EnemyBehavior>().SetBehavior(2, 2.5f, MovePattern.Sine);

        //GameObject enemy3 = Instantiate(enemyPrefab, new Vector3(10.0f, -2.0f, 0.0f), Quaternion.identity);
        //enemy3.GetComponent<EnemyBehavior>().SetBehavior(2, 2.0f, MovePattern.Stutter);

        //for(int i = 0; i < 5; i++)
        //{
        //    enemyHolder = Instantiate(enemyPrefab, new Vector3(10.0f, 0.0f + (i * 0.75f), 0.0f), Quaternion.identity);
        //    enemyHolder.GetComponent<EnemyBehavior>().SetBehavior(2, 1.0f, MovePattern.Zigzag);
        //}

        


        //enemy.GetComponent<EnemyBehavior>()

    }

    private void SpawnGroup(int numOfEnemies, Vector3 initialPosition, MovePattern mp, ShootPattern sp)
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnDelayCounter <= 0) //spawn the next wave when spawnDelayCounter is 0 or less
        {
            for (int i = 0; i < eGroups[0].numOfEnemies; i++)
            {
                enemyHolder = Instantiate(enemyPrefab, new Vector3(10.0f, eGroups[0].initialHeight + (0.75f * i), 0.0f), Quaternion.identity);
                enemyHolder.GetComponent<EnemyBehavior>().SetBehavior(eGroups[0].enemyHealth,
                                                                      eGroups[0].enemySpeed,
                                                                      eGroups[0].movePattern,
                                                                      eGroups[0].shootPattern,
                                                                      eGroups[0].shootCooldown);
            }

            spawnDelayCounter = eGroups[0].spawnDelay; //set the delay

        }
        spawnDelayCounter -= Time.deltaTime;
    }
}
