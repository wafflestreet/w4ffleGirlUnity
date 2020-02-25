using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingTriggered : MonoBehaviour
{
    public GameObject bulletToRight;
    public GameObject bulletToLeft;
    Vector2 bulletPos;
    public float fireRate = 0.01f;
    float nextFire = 0f;
    public Transform blastPoint;
    public Transform smallMuzzleFlash;
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

            Instantiate(bulletToRight, blastPoint.position, Quaternion.identity);
            Instantiate(smallMuzzleFlash, blastPoint.position, smallMuzzleFlash.rotation);
        }

        if (coll.gameObject.tag.Equals("shootL"))
        {

            Instantiate(bulletToLeft, blastPoint.position, Quaternion.identity);
            Instantiate(smallMuzzleFlash, blastPoint.position, smallMuzzleFlash.rotation);
        }
    }
}
