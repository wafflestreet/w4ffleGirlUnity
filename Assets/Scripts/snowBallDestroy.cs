﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowBallDestroy : MonoBehaviour
{
    public Transform snowSplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag.Equals("snowBall"))
        {
            Instantiate(snowSplosion, transform.position, snowSplosion.rotation);
            Destroy(col.gameObject);
        }

    }
}
