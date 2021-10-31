using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10.0f;
    public float bulletSize;

    public int dmg = 1;

    public float BulletSpeed
    {
        get
        {
            return bulletSpeed;
        }
        set
        {
            bulletSpeed = value;
        }
    }
    public float BulletSize
    {
        get
        {
            return bulletSize;
        }
        set
        {
            bulletSize = value;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //damage enemy
            //collision.getComponent<EnemyBehavior().TakeDamage(dmg);
            Debug.Log("Bullet hitting enemy");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

    }


}
