using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Offsets : MonoBehaviour
{
    //position of the cam
    private Vector3 camPos;

    //player movement
    private Transform playerMov;

    // get the limition of camera position
    [SerializeField]
    private float maxX, minX;
    
    //[SerializeField] // my way for Instantiate a player
   // private GameObject[] characters; // my way for Instantiate a player

    // Start is called before the first frame update
    void Start()
    {
        // my way for Instantiate a player
       // Instantiate(characters[Player_controller.playerNum.charIndex]);

        //bring the trnasform info of player
        playerMov = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        //check if the player was destroied
        // (!playerMov) --> (playerMov == null)
        if (!playerMov){
            return;
        }
        //the position of cam
        camPos = this.transform.position;
        //make the cam follow the player
        camPos.x = playerMov.position.x;

        if (camPos.x < minX)
        {
            camPos.x = minX;
        }
        else if(camPos.x > maxX)
        {
            camPos.x = maxX;
        }

        // assign the new position for the cam
        this.transform.position = camPos;

    }
}
