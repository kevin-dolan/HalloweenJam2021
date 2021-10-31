using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    public int dmg = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //damage enemy
            //collision.getComponent<EnemyBehavior().TakeDamage(dmg);
            Debug.Log("Bullet hitting enemy");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

    }


}
