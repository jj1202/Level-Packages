using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartGame4 : MonoBehaviour
{     public GameObject GameFullOverPanel;
public float timeLeft = 10.0f;
[SerializeField] TextMeshProUGUI countdowntext;


void Update()
{
timeLeft -= Time.deltaTime;
countdowntext.text = ("Time Left : "+ (timeLeft).ToString("0.0"));
    
if (timeLeft < 0 && GameObject.FindGameObjectWithTag("Player") != null)
{ 
GameFullOverPanel.SetActive(true);
timeLeft = 0;
}
else if (timeLeft < 0)
        {
            timeLeft = 0;
        }

}
}
