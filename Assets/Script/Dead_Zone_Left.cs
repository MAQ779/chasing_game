using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Zone_Left : MonoBehaviour
{

        private string enemyTag = "destroyLeft";

        //player movement
        private Transform playerMov;
        private Vector3 zonePos;

        //count the passed enemy
        //public static int enemyPassedLeft;


        // Start is called before the first frame update
        void Start()
        {
        //bring the trnasform info of player
        playerMov = GameObject.FindWithTag("Player").transform;
        }

        
        void LateUpdate()
        {
             zonePos.x = playerMov.position.x - 13f;
            // assign the new position for the cam
            this.transform.position = zonePos;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // if the enemy reach the end and collid with dead zone then they will destroied
            if (collision.CompareTag(enemyTag))
            {
                Destroy(collision.gameObject);
                //enemyPassedLeft++;
            }
        }
    }


