using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    
    [SerializeField]
    private GameObject[] enemies;

    private GameObject chosenEnemy;

    private int enemeyIndex, spawnerSideIndex;


    [SerializeField]
    private Transform leftSpawnPosition, rightSpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReswanEnemy());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReswanEnemy() {
        
        // this loop help to create many enemyies clone 
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            // choose randomly the index for enemy 
            enemeyIndex = Random.Range(0, enemies.Length);
            // choose randomly the side for respawing the enemy [0,2)
            spawnerSideIndex = Random.Range(0, 2);


            chosenEnemy = Instantiate(enemies[enemeyIndex]);


            // left spawner
            if (spawnerSideIndex == 0)
            {
                chosenEnemy.gameObject.tag = "rightZone";
                chosenEnemy.transform.position = leftSpawnPosition.position;
                // give a random value for speed of enemy
                chosenEnemy.GetComponent<Enemy>().enemySpeed = Random.Range(4, 9);

            }
            else
            {
                chosenEnemy.gameObject.tag = "leftZone";
                chosenEnemy.transform.position = rightSpawnPosition.position;
                // give a random value for speed of enemy
                chosenEnemy.GetComponent<Enemy>().enemySpeed = -(Random.Range(4, 9));
                // change the face of enemy
                // way1
                // chosenEnemy.GetComponent<SpriteRenderer>().flipX = true;
                //or
                //way2
                chosenEnemy.transform.localScale = new Vector3(-1, 1, 1);
            }

            

        }//end of while loop

    }
}
