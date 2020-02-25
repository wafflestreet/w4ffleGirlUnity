﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformHorizontal2 : MonoBehaviour
{
    float dirX, moveSpeed = 3f;
    bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 18f)
            moveRight = false;
        if (transform.position.x < 9)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);


    }
}
