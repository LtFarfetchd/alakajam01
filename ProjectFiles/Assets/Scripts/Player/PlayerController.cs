using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Holds the player stats
    [HideInInspector]
    public PlayerStats play_Stats;

    //Holds the player Rigidbody
    [HideInInspector]
    public Rigidbody2D rigBod;
    //Checks to see if the player is on a surface to jump off of
    public bool Grounded;

    //Stores the player within its own script
    public GameObject Player;

    //Check whether or not the player is latched to something.
    public bool Latched;

    private void Awake()
    {
        play_Stats = GetComponent<PlayerStats>();
        //Store the player rigidBody
        rigBod = GetComponent<Rigidbody2D>();
        Grounded = false;
        Latched = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Using 2D Rigidbody physics to controll jumping, adds the gravity without any extra hassle
        if (Input.GetKeyDown(KeyCode.W) && Grounded == true) 
        {
            Debug.Log("Jump pls");
            rigBod.AddForce(Vector2.up * play_Stats.CheckStats.player_JumpForce, ForceMode2D.Impulse);
        }


        //Using transform manipulation with Time.Deltatime to smooth it over
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.position = new Vector2(transform.position.x - play_Stats.CheckStats.player_MoveSpeed * Time.deltaTime, transform.position.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + play_Stats.CheckStats.player_MoveSpeed * Time.deltaTime, transform.position.y);
        }

        //Should only run if latched is true
        if (Latched == true && Input.GetKey(KeyCode.W)) 
        {
            Debug.Log("Rise");
            transform.position = new Vector2(transform.position.x, transform.position.y + play_Stats.CheckStats.player_MoveSpeed * Time.deltaTime);
        }

    }


  


    //Stops the player from spam jumping
    public void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Ground"  || Other.gameObject.tag == "Platform")
        {
            Debug.Log("Grounded = " + Grounded);
            Grounded = true;

           
        }

        //Should latch the player to a wall, just testing with walls, will move on to platforms once this works
        if (Other.gameObject.tag == "Wall" && Latched == false) 
        {
            if (Input.GetKey(KeyCode.LeftShift)) 
            {
                Latched = true;
                //Should for as long as you're colliding with a wall and pressing Shift down =, make the position equal the x position of that wall offset by 0.1 so you don't glitch into the wall
                gameObject.transform.position = new Vector2(Other.gameObject.transform.position.x + 1, transform.position.y);
                
            }
            
        }
        //Should detatch you from the wall
        if (Other.gameObject.tag == "Wall" && Latched == true)
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Latched = false;
                gameObject.transform.position = new Vector2(transform.position.x, transform.position.y);
            }
        }

    }
    public void OnCollisionExit2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Ground" ||  Other.gameObject.tag == "Platform")
        {
            Debug.Log("Grounded = " + Grounded);
            Grounded = false;
        }

     
    }
}
