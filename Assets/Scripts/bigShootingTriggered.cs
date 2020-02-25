using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigShootingTriggered : MonoBehaviour
{
    public GameObject bigBulletToRight;
    public GameObject bigBulletToLeft;
    Vector2 bulletPos;
    public float fireRate = 0.01f;
    float nextFire = 0f;
    public Transform blastPoint;
    public Transform bigMuzzleFlash;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("shootR"))
        {

            Instantiate(bigBulletToRight, blastPoint.position, Quaternion.identity);
            Instantiate(bigMuzzleFlash, blastPoint.position, bigMuzzleFlash.rotation);
            Destroy(bigMuzzleFlash, 1f);
        }

        if (coll.gameObject.tag.Equals("shootL"))
        {

            Instantiate(bigBulletToLeft, blastPoint.position, Quaternion.identity);
            Instantiate(bigMuzzleFlash, blastPoint.position, bigMuzzleFlash.rotation);
            Destroy(bigMuzzleFlash, 1f);
        }
    }
}

