using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    
    public PlayerStats Parasyte_Stats;
   
    public Rigidbody2D Creature_RigBod;
    public bool Grounded;
    public CreatureStats CStats;
    public CManager C_man;

    public bool Flyer;
    public bool Tank;
    public bool Legs;

    public bool Flying;
    public Floating FlyFloating;

    public SpriteRenderer[] Creature_Image;

    public Vector2 movement;

    // Start is called before the first frame update
    private void Awake()
    {
        Parasyte_Stats = FindObjectOfType<PlayerStats>();
        Creature_Image = GetComponentsInChildren<SpriteRenderer>();
        CStats = GetComponent<CreatureStats>();
        C_man = GetComponent<CManager>();
       
        
    }
    void Start()
    {
        
        //Parasyte_Stats = GetComponentInChildren<PlayerStats>();
        
        Creature_RigBod = GetComponent<Rigidbody2D>();
      
        
        CStats = GetComponent<CreatureStats>();
        
        Grounded = false;

        this.enabled = false;
}

    //Update is called once per frame
    private void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        SpeciesCheck();

       
    }
    private void FixedUpdate()
    {
        
        if (Flyer == true)
        {
            FlyMovement(movement);
        }
        if (Tank == true) 
        {
            TankMovement();
        }
        if (Legs == true)
        {
            LegsMovement();
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
                Debug.Log("Tank = " + Tank);
                Tank = true;
                break;
            case "Legs":
                Debug.Log("Legs = " + Legs);
                Legs = true;
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Ground" || Other.gameObject.tag == "Platform") 
        {
            Grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Ground" || Other.gameObject.tag == "Platform") 
        {
            Grounded = false;
        }
    }

    //FLYER MOVEMENT
    void FlyMovement(Vector2 direction)
    {
        
            if (!Input.anyKey)
            {
                if (C_man.Hived == false)
                {
                    C_man.C_animator[0].SetBool("Move", false);
                    C_man.C_animator[0].Play(C_man.Animations[0].ToString());
                }
                else 
                {
                    C_man.C_animator[0].SetBool("Move", false);
                    C_man.C_animator[0].Play(C_man.Animations[3].ToString());
                }
            }
        
       
        Creature_RigBod.MovePosition((Vector2)transform.position + (direction * (CStats.MovementBuff + Parasyte_Stats.CheckStats.player_MoveSpeed) * Time.deltaTime));
        if (Input.GetKey(KeyCode.D))
        {
            Creature_Image[0].flipX = true;
            C_man.C_animator[0].SetBool("Move", true);
            if (C_man.Hived == false) 
            {
                C_man.C_animator[0].Play(C_man.Animations[1].ToString());
            }
            if (C_man.Hived == true) 
            {
                C_man.C_animator[0].Play(C_man.Animations[3].ToString());
            }



        }
        if (Input.GetKey(KeyCode.A))
        {
            Creature_Image[0].flipX = false;
            C_man.C_animator[0].SetBool("Move", true);
            if (C_man.Hived == false)
            {
                C_man.C_animator[0].Play(C_man.Animations[01].ToString());
            }
            if (C_man.Hived == true)
            {
                C_man.C_animator[0].Play(C_man.Animations[3].ToString());
            }
        }



        
    }
    

    //TANK MOVEMENT
    public void TankMovement() 
    {

        if (!Input.anyKey)
        {
            if (C_man.Hived == false)
            {
                C_man.C_animator[0].SetBool("Move", false);
                C_man.C_animator[0].Play(C_man.Animations[0].ToString());
            }
            else
            {
                C_man.C_animator[0].SetBool("Move", false);
                C_man.C_animator[0].Play(C_man.Animations[3].ToString());
            }
        }


        if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
        {
            //Debug.Log("Jump pls");
            Creature_RigBod.AddForce(Vector2.up * (CStats.MovementBuff * 2), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - CStats.MovementBuff * Time.deltaTime, transform.position.y);
            Creature_Image[0].flipX = false;

            C_man.C_animator[0].SetBool("Move", true);
          
            if (C_man.Hived == false)
            {
                C_man.C_animator[0].Play(C_man.Animations[1].ToString());
               
            }
            if (C_man.Hived == true)
            {
                C_man.C_animator[0].Play(C_man.Animations[3].ToString());
            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + CStats.MovementBuff * Time.deltaTime, transform.position.y);
            Creature_Image[0].flipX = true;
            C_man.C_animator[0].SetBool("Move", true);

            if (C_man.Hived == false)
            {
                C_man.C_animator[0].Play(C_man.Animations[1].ToString());

            }
            if (C_man.Hived == true)
            {
                C_man.C_animator[0].Play(C_man.Animations[3].ToString());
            }

        }
    }


    //LEGS MOVEMENT
    public void LegsMovement() 
    {
        
            if (!Input.anyKey)
            {
                if (C_man.Hived == false)
                {
                    C_man.C_animator[0].SetBool("Move", false);
                    C_man.C_animator[1].SetBool("Move", false);
                    C_man.C_animator[0].Play(C_man.Animations[0].ToString());
                    C_man.C_animator[1].Play(C_man.Animations[2].ToString());
                }
                else
                {
                    C_man.C_animator[0].SetBool("Move", false);
                    C_man.C_animator[1].SetBool("Move", false);
                    C_man.C_animator[0].Play(C_man.Animations[4].ToString());
                    C_man.C_animator[1].Play(C_man.Animations[2].ToString());
                }
            }
        

        if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
        {
            //Debug.Log("Jump pls");
            Creature_RigBod.AddForce(Vector2.up * (CStats.MovementBuff * 2), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - CStats.MovementBuff * Time.deltaTime, transform.position.y);
            Creature_Image[0].flipX = false;
            Creature_Image[1].flipX = false;
            C_man.C_animator[0].SetBool("Move", true);
            C_man.C_animator[1].SetBool("Move", true);
            if (C_man.Hived == false)
            {
                C_man.C_animator[0].Play(C_man.Animations[1].ToString());
                C_man.C_animator[1].Play(C_man.Animations[3].ToString());
            }
            if (C_man.Hived == true)
            {
                C_man.C_animator[0].Play(C_man.Animations[5].ToString());
                C_man.C_animator[1].Play(C_man.Animations[3].ToString());
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + CStats.MovementBuff * Time.deltaTime, transform.position.y);
            Creature_Image[0].flipX = true;
            Creature_Image[1].flipX = true;

            C_man.C_animator[0].SetBool("Move", true);
            C_man.C_animator[1].SetBool("Move", true);
            if (C_man.Hived == false)
            {
                C_man.C_animator[0].Play(C_man.Animations[1].ToString());
                C_man.C_animator[1].Play(C_man.Animations[3].ToString());
            }
            if (C_man.Hived == true)
            {
                C_man.C_animator[0].Play(C_man.Animations[5].ToString());
                C_man.C_animator[1].Play(C_man.Animations[3].ToString());
            }

        }
    }
}
