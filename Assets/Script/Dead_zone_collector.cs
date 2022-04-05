using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dead_zone_collector : MonoBehaviour
{
    public static Dead_zone_collector spawner;
    private string enemyTagRight = "rightZone";
    private string enemyTagLeft = "leftZone";
    private string playerTag = "Player";

    //count the passed enemy
    public static int enemyPassed;

    static bool playerTouched = false;

    [SerializeField]
    private Text countText;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        countText.text = "COUNT: " + enemyPassed;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (player.active)
        {
            // if the enemy reach the end and collid with dead zone then they will destroied
            if ((collision.CompareTag(enemyTagLeft) && this.gameObject.tag == "leftCounter"))
            {
                collision.tag = "destroyLeft";
                enemyPassed++;
            }
            else if ((collision.CompareTag(enemyTagRight) && this.gameObject.tag == "rightCounter"))
            {
                collision.tag = "destroyRight";
                enemyPassed++;
            }

        }
    }
}
