using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : MonoBehaviour
{
    PlayerControl myPlayer;
    BulletScript myBullet = new BulletScript();
    private SpriteRenderer rend;
    //private Sprite foot;
    //[SerializeField] private GameObject sacrificeObject1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeFoot()
    {

        myPlayer.PlayerSpeed -= 0.01f;
        myBullet.BulletSize = 3;
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = 
    }

    void TakeEye()
    {
        myPlayer.BulletCoolDown -= 0.2f;
        //loses accuracy
    }

    void TakeHand()
    {
        myPlayer.BulletNumber += 5;
        myPlayer.BulletCoolDown += 0.2f;
    }

    void TakeHeart()
    {
        myBullet.BulletSpeed += 2;
        myBullet.bulletSize = 2;
        myPlayer.PlayerHealth = 1;
    }
}
