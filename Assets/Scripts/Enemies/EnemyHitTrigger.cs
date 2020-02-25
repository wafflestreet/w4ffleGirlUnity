using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitTrigger : MonoBehaviour
{
    public Transform boomObj;
    public Transform blaster2;
    public Transform blaster3;
    public Transform extraLife;
    public GameObject snowBall2;



    //ForEnemyCounter
    public GameObject warp;
    public player countSystem;
    // Start is called before the first frame update
    void Start()
    {
        countSystem = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("bullet"))
        {
            countSystem.enemyCounter++;
            Destroy(gameObject);
            Instantiate(boomObj, transform.position, boomObj.rotation);
            snowBall2.SetActive(true);
            




        }
        if (countSystem.enemyCounter == 3)
        {
            //Instantiate(extraLife, transform.position, extraLife.rotation);
        }
    }
}
