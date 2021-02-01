using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    bool rightHeld = false;
    bool leftHeld = false;
    bool upHeld = false;
    bool downHeld = false;
    bool onFloor = false;
    bool hasBeenHit = false;

    bool jump = false;
    float jumpTime = 0;
    public float speed = 10.0f;
    public float movementSpeed = 2.0f;
    private int twoPlayer = 1;

    GameObject target;
    PlayerMovement enemy;

    float xVal, yVal, zVal;

    float leftVal, rightVal, upVal, downVal = 0.0f;

    Rigidbody rb = null;

    public SpawnScript newCoin;
    public GameObject time;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = GameObject.FindGameObjectWithTag("Timer");
    }

    // Update is called once per frame
    void Update()
    {

        if (hasBeenHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.12f, transform.position.z);
        }

        rightHeld = Input.GetKey(KeyCode.RightArrow) ? true : false;
        leftHeld = Input.GetKey(KeyCode.LeftArrow) ? true : false;
        upHeld = Input.GetKey(KeyCode.UpArrow) ? true : false;
        downHeld = Input.GetKey(KeyCode.DownArrow) ? true : false;
        if (Input.GetKeyDown(KeyCode.RightShift) && onFloor)
        {
            jump = true;
        }
        /*else
        {
            jump = false;
        }*/
    }

    private void FixedUpdate()
    {
        leftVal = leftHeld ? movementSpeed : 0.0f;
        rightVal = rightHeld ? movementSpeed : 0.0f;
        upVal = upHeld ? movementSpeed : 0.0f;
        downVal = downHeld ? movementSpeed : 0.0f;

        if (jump)
        {
            rb.AddForce(Vector3.up * 15, ForceMode.VelocityChange);
            if (jumpTime == 8)
            {
                jumpTime = 0;
                jump = false;
            }
            jumpTime++;
        }

        if (!onFloor)
        {
            rb.AddForce(Vector3.down * 4, ForceMode.VelocityChange);
        }

        float xVal = rightVal - leftVal;
        float zVal = upVal - downVal;

        rb.velocity = new Vector3(xVal, 0, zVal);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MinuteHand" || collision.gameObject.tag == "HourHand")
        {
            target = collision.gameObject;
            hasBeenHit = true;
        }

        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }

        if (collision.gameObject.tag == "Coin")
        {
            if (twoPlayer == 1)
            {
                ScoreVar.p2Score++;
                slowEnemy();
            }
            else
            {
                GameManager.instance.TimeIncrease(5.0f);
            }
            Destroy(collision.gameObject);
            newCoin.spawnNewCoin();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MinuteHand")
        {
            //hasBeenHit = false;
        }

        if (collision.gameObject.tag == "Floor")
        {
            onFloor = false;
        }

    }

    private void slowEnemy()
    {
        GameObject enemyObj = GameObject.FindGameObjectWithTag("Player");

        if (enemyObj != null)
        {
            enemy = enemyObj.GetComponent<PlayerMovement>();
            enemy.movementSpeed = 1.5f;
            StartCoroutine(debuffDuration());
        }
    }

    IEnumerator debuffDuration()
    {
        yield return new WaitForSeconds(5.0f);
        GameObject enemyObj = GameObject.FindGameObjectWithTag("Player");

        if (enemyObj != null)
        {
            enemy = enemyObj.GetComponent<PlayerMovement>();
            enemy.movementSpeed = 2.0f;
        }
    }
}

