using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyGroup : ScriptableObject
{
    public Sprite enemySprite; //sprite sprite sprite!!!!
    public float spawnDelay; //how long to wait until spawning this group.
    public int numOfEnemies; //how many enemies to spawn in this group.
    public float initialHeight; //where to start placing enemies at the beginning of the pattern.
    public MovePattern movePattern; //which way to move based on the enum MovePattern.
    public ShootPattern shootPattern; //which way to shoot based on the enum ShootPattern.
    public int enemyHealth; //how many hitpoints enemy have
    public float enemySpeed; //move speed
    public float shootCooldown; //cooldown of enemy shooting
}
