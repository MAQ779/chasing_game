using UnityEngine;
using UnityEngine.UI;

public class player_movement : MonoBehaviour
{

    [SerializeField]
    private float forceSpeed = 10f;
    [SerializeField]
    private Rigidbody2D playerRigid;

    // to bring the sprite renderer of player (it will help to flip the player's face)
    private SpriteRenderer spritePLayer;

    // to bring the animator of the player
    private Animator playerAnimator;

    // the boolean for walk animation
    [SerializeField]
    private string walkAnimation = "walking";

    private float moveX = 11f;

    // help for jump
    [SerializeField]
    private float forceJump = 11f;

    private bool touchGround = true;


    private string groundTag = "Ground";

    private string enemyTag = "Enemy";
    private string enemyTagRight = "rightZone";
    private string enemyTagLeft = "leftZone";

    // for limiting the player's movement
    [SerializeField]
    private float maxX, minX;


    private Vector3 playerPos;




    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();

        spritePLayer = GetComponent<SpriteRenderer>();

        playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMove();
        PlayerAnimation();
        
    }
     void FixedUpdate()
    {
        PlayerJump();
    }

    // this function for moving the player forward and backward
    void PlayerMove()
    {
        // take the input form the keybaord 
        moveX = Input.GetAxis("Horizontal");


        // add the new position

        if ((this.transform.position.x > minX && this.transform.position.x < maxX) || (this.transform.position.x < minX && this.transform.position.x > maxX))
        {
            this.transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * forceSpeed;
        }
        else if (this.transform.position.x <= minX)
        {
            this.transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * forceSpeed;
        }
        else
        {
            this.transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * forceSpeed;
        }




    } // end of playerMove

    void PlayerAnimation()
    {
        // when the player go to the right
        if (moveX > 0) 
        { 
            //for the walking animation
            playerAnimator.SetBool(walkAnimation, true);

            //for flip the face of the player
            spritePLayer.flipX = false;

        }
        //when the player go to the left
        else if(moveX < 0)
        {
            //for the walking animation
            playerAnimator.SetBool(walkAnimation, true);

            //for flip the face of the player
            spritePLayer.flipX = true;
        }
        //when the player stop moving
        else
        {
            //for the walking animation
            playerAnimator.SetBool(walkAnimation, false);   
        }
    }  //end of playerAnimation

    void PlayerJump()
    {
        //Input.GetButtonDown("Jump") <-- this method sometimes is not working
        if (Input.GetButton("Jump") && touchGround)
        {
            touchGround = false;
            playerRigid.AddForce(new Vector2(0f, forceJump), ForceMode2D.Impulse);
            
        }
    } // end of playerJump

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if the player touch a ground 
        if (collision.gameObject.CompareTag(groundTag))
        {
            touchGround = true;
            
        }
        // this for rigidbody and not trigger  check if the player touch the enemy       
        if (collision.gameObject.CompareTag(enemyTagLeft) || collision.gameObject.CompareTag(enemyTagRight))
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    //this for trigger (ghost) check if the player touch the enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTagLeft) || collision.CompareTag(enemyTagRight))
        {

            gameObject.SetActive(false);
            //Destroy(gameObject);
        } 
    }


}
