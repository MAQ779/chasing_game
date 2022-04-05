using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_navigation : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayScene()
    {
        

        // Note i put UnityEngine.EventSystems instead of import the whole library above (using UnityEngine.EventSystems;)
         int buttonIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        //assign the palyer index
        Player_controller.playerNum.charIndex = buttonIndex;
        // move to the play scene
        SceneManager.LoadScene("GamePlay");



    }
}
