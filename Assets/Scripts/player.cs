using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public int lifeCounter;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public LayerMask platformLm;
    public lifeManager lifeSystem;
    public Vector3 originalPos;
    public GameObject wG;
    public float threshold;
    public GameObject blaster;
    public bool hasGun;
    public Sprite idle;
    public Sprite gun;
    public bool facingRight;
    public bool facingLeft;
    public GameObject bullet;

    public Transform blastPoint;

    public float thrust;
    public GameObject origin;
    //Shooting
    public bool heldShoot2;
    public Sprite gun2;
    public Sprite gun3;
    public Transform smallMuzzleFlash;
    public Transform bigMuzzleFlash;
    public GameObject bulletToRight;
    public GameObject bulletToLeft;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0f;
    public float fireRate2 = .05f;
    public float fireRate3 = .1f;
    float nextFire2 = 0f;
    public bool iShoot;
    public bool iShoot2;
    public bool iShoot3;
    public GameObject bigBulletToLeft;
    public GameObject bigBulletToRight;
    //CountSystem
    public float startingEnemies = 3;
    public float enemyCounter;
    public GameObject warp;
    public Transform boom;
    public Transform reSpawn;
    public bool held;
    public bool heldLeft;


    public float moveSpeed = 6f;
    //NewRB for touch
    public float moveX;

    public float speed;
    public VariableJoystick variableJoystick;
    public GameObject bubble;
    public bool cantHurt;

    public Vector3 run;

    public GameObject levelScreen;
    public GameObject PlayButton;

    public GameObject snowBall2;






    private void Start()
    {
        originalPos = wG.transform.position;
        //Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 4.0f, 0.0f);
        run = new Vector3(3.0f, 0.0f, 0.0f);

    }

    // Start is called before the first frame update
    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        bc = transform.GetComponent<BoxCollider2D>();
        lifeSystem = FindObjectOfType<lifeManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        if(held == true)
        {
            rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        }
        if (heldLeft == true)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (held == true)
        {
            fireRate2 = .05f;
        }

        //JUMPING

        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            float jumpVelocity = 7f;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        HandleMovement();
        //FallingDeath
        if (transform.position.y < threshold)
        {
            lifeSystem.TakeLife();
            wG.transform.position = originalPos;
            Instantiate(reSpawn, originalPos, reSpawn.rotation);
        }
        //Shooting
        if (iShoot == true && Input.GetKey(KeyCode.S) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            touchShoot();


        }
        //CountSystem
        if (enemyCounter == startingEnemies)
        {
            warp.SetActive(true);
        }

    }
    //JoyStick
    //public void FixedUpdate()
    // {
    // Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
    //  rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);

    // }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, platformLm);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    public void HandleMovement()
    {

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            Flip();
            facingRight = false;
            facingLeft = true;

        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                // rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
                stayRight();
                facingRight = true;
                facingLeft = false;

            }
            else
            {
                //NO KEYS PRESSED UNDISABLE THIS FOR COMPUTER BUILD
                //rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("movingPlatform"))
        {
            this.transform.parent = col.transform;
        }

        if (col.gameObject.tag.Equals("nextLevel"))
        {
            levelScreen.SetActive(true);
            PlayButton.SetActive(true);
            //lifeSystem.AddScene();
        }

        if (col.gameObject.tag == "blaster" && this.gameObject.GetComponent<SpriteRenderer>().sprite == idle)
        {
            iShoot = true;
            iShoot2 = false;
            iShoot3 = false;
            Destroy(col.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = gun;

        }
        if (col.gameObject.tag == "blaster2")
        {
            iShoot = false;
            iShoot2 = true;
            iShoot3 = false;
            Destroy(col.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = gun2;

        }
        if (col.gameObject.tag == "blaster3")
        {
            iShoot = false;
            iShoot2 = false;
            iShoot3 = true;
            Destroy(col.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = gun3;
        }

            if (col.gameObject.tag == "bubble")
            {
                cantHurt = true;
                Destroy(col.gameObject);

            }
            if (cantHurt == true)
            {
                bubble.SetActive(true);
            }

        if (col.gameObject.tag == "snowBallTrigger2")
        {
            snowBall2.SetActive(true);
        }

        if (col.gameObject.tag == "snowBall")
        {
            if (cantHurt == false)
            {
                lifeSystem.TakeLife();
                Instantiate(boom, transform.position, boom.rotation);
                Instantiate(reSpawn, originalPos, reSpawn.rotation);
                

                wG.transform.position = originalPos;
            }

            if (cantHurt == true)
            {
               
               
              
                bubble.SetActive(false);
                cantHurt = false;
            }
        }

        if (col.gameObject.tag == "enemy")
            {
                if (cantHurt == false)
                {
                    lifeSystem.TakeLife();
                    Instantiate(boom, transform.position, boom.rotation);
                    Instantiate(reSpawn, originalPos, reSpawn.rotation);
                    enemyCounter++;
                     
                     wG.transform.position = originalPos;
                }

                if (cantHurt == true)
                {
                    enemyCounter++;
                    Destroy(col.gameObject);
                    Instantiate(boom, transform.position, boom.rotation);
                    bubble.SetActive(false);
                    cantHurt = false;
                }
            }
        if (col.gameObject.tag == "extraLife")
        {
            lifeSystem.GiveLife();
            Destroy(col.gameObject);
        }

            if (col.gameObject.tag == "enemyBullet")
        {
            if (cantHurt == false)
            {
                lifeSystem.TakeLife();
                Instantiate(boom, transform.position, boom.rotation);
                Instantiate(reSpawn, originalPos, reSpawn.rotation);
               

                wG.transform.position = originalPos;
            }

            if (cantHurt == true)
            {
                
                Destroy(col.gameObject);
                Instantiate(boom, transform.position, boom.rotation);
                bubble.SetActive(false);
                cantHurt = false;
            }
        }



    }
        public void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.tag.Equals("movingPlatform"))
                this.transform.parent = null;
        }
        public void Flip()
        {
            transform.localScale = new Vector2(-.5f, transform.localScale.y);
        }

        public void stayRight()
        {

            transform.localScale = new Vector2(.5f, transform.localScale.y);

        }


    public void touchShoot()

    {


        bulletPos = transform.position;
        if (facingRight)
        {

            if (iShoot == true || iShoot2 == true)
            {
                bulletPos += new Vector2(.5f, -.3f);
                Instantiate(bulletToRight, bulletPos, Quaternion.identity);
                Instantiate(smallMuzzleFlash, bulletPos, smallMuzzleFlash.rotation);
            }

            if (iShoot3 == true)
            {
                bulletPos += new Vector2(.5f, -.3f);
                Instantiate(bigMuzzleFlash, bulletPos, bigMuzzleFlash.rotation);
                Instantiate(bigBulletToRight, bulletPos, Quaternion.identity);
            }
        }
        else
        {

            if (iShoot == true || iShoot2 == true)
            {
                bulletPos += new Vector2(-.5f, -.3f);
                Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
                Instantiate(smallMuzzleFlash, bulletPos, smallMuzzleFlash.rotation);
            }
            if (iShoot3 == true)
            {
                bulletPos += new Vector2(-.5f, -.3f);
                Instantiate(bigMuzzleFlash, bulletPos, bigMuzzleFlash.rotation);
                Instantiate(bigBulletToLeft, bulletPos, Quaternion.identity);
            }



        }
    }

        //ForTouchControls
        public void goLeft()
        {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        //rb.AddForce(transform.right * -moveSpeed, ForceMode2D.Impulse);

        Flip();
            facingRight = false;
            facingLeft = true;
        }

        public void goRight()
        {
        //rb.AddForce(transform.right * +moveSpeed, ForceMode2D.Impulse);
        rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);



            stayRight();
            facingRight = true;
            facingLeft = false;
        }
    public void isHeldShoot2()
    {
        heldShoot2 = true;
    }

    public void isHeldShoot2False()
    {
        heldShoot2 = false;
    }
    public void isHeldRight()
    {
        held = true;
    }

    public void isHeldRightFalse()
    {
        held = false;
    }

    public void isHeldLeft()
    {
        heldLeft = true;
    }

    public void isHeldLeftFalse()
    {
        heldLeft = false;
    }










    public void noMove()
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        public void goJump()
        {
            if (IsGrounded())
            {
                rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            }
        }

        public void goShoot()
        {
            if (iShoot == true && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                touchShoot();


            }
        if (iShoot2 == true && Time.time > nextFire2)
        {
            nextFire2 = Time.time + fireRate2;
            touchShoot();


        }
        if (iShoot3 == true && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate3;
            touchShoot();


        }
    }


    public void MoveLeft(float horizontalInput)
    {

        //Vector2 moveVel = rb.velocity;
        // moveVel.x = horizontalInput * moveSpeed;
        // rb.velocity = moveVel;
        float runVelocity = -3f;
        rb.velocity = Vector2.right * runVelocity;
        Flip();
        facingRight = false;
        facingLeft = true;

    }
    public void MoveRight(float horizontalInput)
    {

        //Vector2 moveVel = rb.velocity;
        //moveVel.x = horizontalInput * moveSpeed;
        // rb.velocity = moveVel;
        float runVelocity = 3f;
        rb.velocity = Vector2.right * runVelocity;
        stayRight();
        facingRight = true;
        facingLeft = false;

    }





}

