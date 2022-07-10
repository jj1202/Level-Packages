using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovt_1 : MonoBehaviour
{
    public GameObject head, gameoverscreen, cam, winScreen, collectKeyWarn;
    bool jumpkeypressed;
    float horizontalinput;
    [Range(0,100)]public int jumpforce;
    [Range(0, 500)] public int speed;
    public bool faceleft = false;
    public Transform groundlimit, groundCheck, winPoint;
    public static bool hasKey = false;

    
    //private playerLoseLife player;
    // Start is called before the first frame update
    void Start()
    {
        //normal speed gameplay
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //get amount of horizontal input
        horizontalinput = Input.GetAxis("Horizontal");
        // get jump input
        if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            jumpkeypressed = true;
        }

        //to flip character right
        if (horizontalinput > 0.01f && faceleft)
        {
            transform.Rotate(0, 180, 0);
            faceleft = false;
        }
        //to flip character left
        else if (horizontalinput < -0.01f && !faceleft)
        {
            transform.Rotate(0, 180, 0);
            faceleft = true;
        }

        //to check if player has fallen below limits
        if (head.transform.position.y < groundlimit.transform.position.y)
        {
            //gameoverscreen.SetActive(true);// show game over screen
            //Time.timeScale = 0; //stop gameplay
            GetComponent<playerLoseLife_1>().loseLife();
            
        }
        if ((head.transform.position.x >= winPoint.position.x))
        {
            if(hasKey == false)
                collectKeyWarn.SetActive(true);

            else
            {
                winScreen.SetActive(true);// show level complete screen
                Time.timeScale = 0; //stop gameplay
            }
            

        }

    }

    private void FixedUpdate()
    {
        collectKeyWarn.SetActive(false);
        //implement jumping
        if (jumpkeypressed && (Physics2D.OverlapCircleAll(groundCheck.position, 0.25f).Length == 2))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse);
            jumpkeypressed = false;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalinput*speed, GetComponent<Rigidbody2D>().velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            //print("key");
            hasKey = true;
            Destroy(collision.gameObject);
        }




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jump Platform")
        {
            jumpforce *= 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jump Platform")
        {
            jumpforce /= 2;
        }
    }



}
