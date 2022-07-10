using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerHealth_3 : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] static int Health = 100;
    public int maxHealth;
    public int heartIncrement;
   // public GameObject gameoverscreen;
    float initx, inity;
    public TextMeshProUGUI maxHealthCounter;

    void Start()
    {
        Health = maxHealth;
        maxHealthCounter.text = "Health: " + Health.ToString();
        initx = transform.position.x;
        inity = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            loseLife();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            Health += heartIncrement;
            if (Health > 100)
                Health = 100;
            updateHealthText();
            Destroy(collision.gameObject);
        }

    }


    public void loseLife()
    {
        //print("die");
        Health--;

        if (Health <= 0)
        {
            //print("gameover");

            //Time.timeScale = 0; //stop gameplay
            //gameoverscreen.SetActive(true);// show game over screen
            Health = 100;
        }
        else if (Health > 0)
        {
            //print("restart");
            //SceneManager.LoadScene("Level");
            //transform.position = new Vector2(initx, inity);

        }
        updateHealthText();


    }

    void updateHealthText()
    {
        maxHealthCounter.text = "Health: " + Health.ToString();
    }



}