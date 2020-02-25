using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public float velX = 5f;
    public float velY = 0;
    public player shootSystem;
    public Rigidbody2D brb;

    
    
    void Start()
    {
        
      brb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Update()

    {
        fire();
        

    }
   // && Input.GetKey(KeyCode.S)at the end of each if makes cool platform effect
    // Update is called once per frame
    void fire()
    {
        brb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 4f);
    }

    




}
