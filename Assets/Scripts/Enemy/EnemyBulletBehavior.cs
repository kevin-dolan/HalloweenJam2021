using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position += Vector3.left * speed * Time.deltaTime; //old way of moving left
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);

        //if bullet goes too far away, destroy it
        if(transform.position.x <= -10.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Enemy Bullet hit player!");

            //collision.gameObject.GetComponent<PlayerControl>().TakeDamage();
            Destroy(this.gameObject); //destroy bullet
        }
    }

    //public property for speed
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
}
