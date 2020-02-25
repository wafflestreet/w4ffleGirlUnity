using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackingBullet : MonoBehaviour
{
    
    public float moveSpeed = 7f;
    public Rigidbody2D brb;
   public GameObject waffleBall5;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        brb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }
    public void fire()
    {
        moveDirection = (waffleBall5.transform.position - transform.position).normalized * moveSpeed;
        brb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 4f);
    }
}
