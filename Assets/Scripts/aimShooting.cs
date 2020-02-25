using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimShooting : MonoBehaviour
{
    public GameObject bulletToRight;
    public GameObject bulletToLeft;
    Vector2 bulletPos;
    public float fireRate = 0.01f;
    float nextFire = 0f;
    public Transform blastPoint;
    public Transform smallMuzzleFlash;
    public float waitTime = 500;
    public float counter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter++;

        if (counter >= waitTime)
        {
            Instantiate(bulletToRight, blastPoint.position, Quaternion.identity);
            Instantiate(smallMuzzleFlash, blastPoint.position, smallMuzzleFlash.rotation);
            Destroy(bulletToRight, 3f);
            counter = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("shootR"))
        {

           
        }

        if (coll.gameObject.tag.Equals("shootL"))
        {

            //Instantiate(bulletToLeft, blastPoint.position, Quaternion.identity);
            //Instantiate(smallMuzzleFlash, blastPoint.position, smallMuzzleFlash.rotation);
        }
    }
}

