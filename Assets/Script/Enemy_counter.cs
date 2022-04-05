using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_counter : MonoBehaviour
{
  

    //player movement
    private Transform playerMov;
    private Vector3 zonePos;
    // Start is called before the first frame update
    void Start()
    {
        playerMov = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (this.gameObject.tag == "leftCounter")
        {
            zonePos.x = playerMov.position.x - 4;
            // assign the new position for the cam
            this.transform.position = zonePos;
        }
        else if(this.gameObject.tag == "rightCounter") {
            zonePos.x = playerMov.position.x + 5;
            // assign the new position for the cam
            this.transform.position = zonePos;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
