using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float enemySpeed;

    private Rigidbody2D enemyBody;

    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // moving the enemy
        enemyBody.velocity = new Vector2(enemySpeed, enemyBody.velocity.y);
    }
}
