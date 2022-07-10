using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerLoseLife_1 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] static int playerLives = 3;
    public int Lives;
    public GameObject gameoverscreen;
    float initx, inity;
    public TextMeshProUGUI livesCounter;

    void Start()
    {
        playerLives = Lives;
        livesCounter.text = "Lives: " + playerLives.ToString();
        initx = transform.position.x;
        inity = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Enemy")
           loseLife();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            playerLives++;
            livesCounter.text = "Lives: " + playerLives.ToString();
            Destroy(collision.gameObject);
        }
    }


    public void loseLife()
    {
        //print("die");
        playerLives--;
        
        if(playerLives<=0)
        {
            //print("gameover");
            
            Time.timeScale = 0; //stop gameplay
            gameoverscreen.SetActive(true);// show game over screen
            playerLives = 3;
        }
        else if (playerLives > 0)
        {
            //print("restart");
            //SceneManager.LoadScene("Level");
            transform.position=new Vector2(initx,inity);

        }
        livesCounter.text = "Lives: " + playerLives.ToString();


    }


}
