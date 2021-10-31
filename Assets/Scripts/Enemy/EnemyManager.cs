using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab; //MUST BE SET IN INSPECTOR
    [SerializeField] private List<EnemyGroup> eGroupsList = new List<EnemyGroup>(); //list of groups of enemies to spawn in the level this EnemyManager is currently in.
    [SerializeField] private Queue<EnemyGroup> eGroups = new Queue<EnemyGroup>(); //QUEUE of groups of enemies

    private float spawnDelayCounter = 3.0f; //used to delay between spawns of enemy groups in FixedUpdate()

    private Vector3 spawnPosition; //used while instantiating enemies. manipulated to spawn enemies in patterns.

    private EnemyGroup enemyGroupHolder;
    private GameObject enemyHolder;

    // Start is called before the first frame update
    void Start()
    {
        foreach(EnemyGroup group in eGroupsList) //at the start of the scene, add all the enemy groups from eGroupsList to the queue eGroups.
        {
            eGroups.Enqueue(group);
        }
    }

    private void SpawnGroup(int numOfEnemies, Vector3 initialPosition, MovePattern mp, ShootPattern sp)
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnDelayCounter <= 0) //spawn the next wave when spawnDelayCounter is 0 or less
        {
            //THIS IS BASICALLY THE LEVEL COMPLETE CONDITION!
            if(eGroups.Count <= 0) //if eGroups is empty, just do nothing FOR NOW
            {
                Debug.Log("No more groups to spawn!");
                spawnDelayCounter = 999.0f;
                return;
            }

            enemyGroupHolder = eGroups.Dequeue(); //take the next enemyGroup from eGroups and spawn it.
            for (int i = 0; i < enemyGroupHolder.numOfEnemies; i++)
            {
                enemyHolder = Instantiate(enemyPrefab, new Vector3(10.0f, enemyGroupHolder.initialHeight + (0.75f * i), 0.0f), Quaternion.identity);
                enemyHolder.GetComponent<EnemyBehavior>().SetBehavior(enemyGroupHolder.enemyHealth,
                                                                      enemyGroupHolder.enemySpeed,
                                                                      enemyGroupHolder.movePattern,
                                                                      enemyGroupHolder.shootPattern,
                                                                      enemyGroupHolder.shootCooldown);
            }

            spawnDelayCounter = enemyGroupHolder.spawnDelay; //set the delay until the next group is spawned.
        }
        spawnDelayCounter -= Time.deltaTime;
    }
}
