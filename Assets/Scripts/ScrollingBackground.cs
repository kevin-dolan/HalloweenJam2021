using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private GameObject bg1;
    private GameObject bg2;

    [SerializeField] private float scrollSpeed = 0.05f; //speed at which the background scrolls to the left

    private Vector3 resetPosition = new Vector3(32.0f, -0.5f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        bg1 = transform.GetChild(0).gameObject;
        bg2 = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bg1.transform.position -= Vector3.right * scrollSpeed;
        bg2.transform.position -= Vector3.right * scrollSpeed;

        if(bg1.transform.position.x < -31.0f) { bg1.transform.position = resetPosition; }
        if(bg2.transform.position.x < -31.0f) { bg2.transform.position = resetPosition; }
    }
}
