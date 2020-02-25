using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockReset2 : MonoBehaviour
{
    public Vector3 originalPos;
    public GameObject rock;
    public Transform snowSplosion;
    public float counter;
    public float waitTime1;
    public float waitTime2;
    public float waitTime3;
    public float waitTime4;
    public float waitTime5;
    public float waitTime6;
    public float waitTime7;
    public float waitTime8;
    public float waitTime9;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = rock.transform.position;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter++;

        if (counter >= waitTime1)
        {
            transform.localScale = new Vector3(.3f, .3f, .3f);
        }
        if (counter >= waitTime2)
        {
            transform.localScale = new Vector3(.4f, .4f, .4f);
        }
        if (counter >= waitTime3)
        {
            transform.localScale = new Vector3(.4f, .4f, .4f);
        }
        if (counter >= waitTime4)
        {
            transform.localScale = new Vector3(.5f, .5f, .5f);
        }
        if (counter >= waitTime5)
        {
            transform.localScale = new Vector3(.6f, .6f, .6f);
        }
        if (counter >= waitTime6)
        {
            transform.localScale = new Vector3(.7f, .7f, .7f);
        }

        //transform.localScale += new Vector3(.0001f, .0001f, 0f);
    }
    public void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag.Equals("Player"))
        {
            Instantiate(snowSplosion, transform.position, snowSplosion.rotation);
            transform.localScale = new Vector3(.2f, .2f, .2f);
            rock.transform.position = originalPos;
        }


    }
}
