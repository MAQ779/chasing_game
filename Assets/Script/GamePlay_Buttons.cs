using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay_Buttons : MonoBehaviour
{
    // home button
    public void ReturnToHomePage()
    {
        SceneManager.LoadScene("Menu");
    }

    // restart button
    public void restartScene()
    {
        //way 1
        //SceneManager.GetActiveScene().name <-- it is bring the name of the current active scene
        Dead_zone_collector.enemyPassed = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);



        //way 2
        //SceneManager.LoadScene("Menu");
    }

}
