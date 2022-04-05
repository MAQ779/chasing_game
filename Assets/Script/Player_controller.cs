using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_controller : MonoBehaviour
{
    public static Player_controller playerNum;

    private int characterIndex;

    public int charIndex
    {
        get { return characterIndex; }
        set { characterIndex = value; }
    }

    [SerializeField]
    private GameObject[] characters;


    private void Awake()
    {
        // (singleton patern) so it will kepp one player_controller and load it to the game play
        if(playerNum == null)
        {
            playerNum = this;
            // when we will move to the others scene it will not destroy the selected gameObject 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    
     void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("GamePlay"))
        {
            Instantiate(characters[characterIndex]);
        }
    }

}
