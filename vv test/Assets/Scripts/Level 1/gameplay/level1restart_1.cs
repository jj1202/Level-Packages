using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1restart_1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void restartlevel()
    {
        //restart level by reloading scene
        SceneManager.LoadScene("Level 1");
    }
}
