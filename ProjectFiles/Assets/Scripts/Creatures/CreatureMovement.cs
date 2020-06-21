using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    
    public PlayerStats Parasyte_Stats;
   
    public Rigidbody2D Creature_RigBod;
    public bool Grounded;
    public CreatureStats CStats;

    public bool Flyer;
    public bool Tank;
    public bool Legs;

    public Vector2 movement;

    // Start is called before the first frame update
    private void Awake()
    {
        Parasyte_Stats = FindObjectOfType<PlayerStats>();
    }
    void Start()
    {
        //Parasyte_Stats = GetComponentInChildren<PlayerStats>();
        
        Creature_RigBod = GetComponent<Rigidbody2D>();
      
        
        CStats = GetComponent<CreatureStats>();
        
        Grounded = false;

        this.enabled = false;
}

    // Update is called once per frame
    private void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        SpeciesCheck();
    }
    private void FixedUpdate()
    {
        
        if (Flyer == true) 
        {
            MovePlayer(movement);
        }
        if (Tank == true) 
        {
            TankMovement();
        }
    }
    public void SpeciesCheck() 
    {
        switch (CStats.CreatureName)
        {
            case "Flyer":
                Debug.Log("Flyer = " + Flyer);
                Flyer = true;
                break;
            case "Tank":
                Debug.Log("Flyer = " + Tank);
                Tank = true;
                break;
            case "Legs":
                Debug.Log("Flyer = " + Legs);
                Legs = true;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Ground") 
        {
            Grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Ground") 
        {
            Grounded = false;
        }
    }

    void MovePlayer(Vector2 direction)
    {
        Creature_RigBod.MovePosition((Vector2)transform.position + (direction * (CStats.MovementBuff + Parasyte_Stats.CheckStats.player_MoveSpeed) * Time.deltaTime));
    }

    public void TankMovement() 
    {
        if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
        {
            //Debug.Log("Jump pls");
            Creature_RigBod.AddForce(Vector2.up * (CStats.MovementBuff * 2), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - CStats.MovementBuff * Time.deltaTime, transform.position.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + CStats.MovementBuff * Time.deltaTime, transform.position.y);

        }
    }
}
