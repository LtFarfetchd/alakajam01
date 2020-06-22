using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float interactRange = 2.0f;
    public Vector3 NewPosL;
    public Vector3 NewPosR;
    // public int speed = 2;


    public SpriteRenderer CRenderer;

    public int WalkArea;


    private Vector3 pos1 = new Vector3(-4, 0, 0);
    private Vector3 pos2 = new Vector3(4, 0, 0);
    public float speed = 1.0f;
    public int ChaseSpeed = 2;

    public bool Wandering;
   



    // Start is called before the first frame update
    void Start()
    {
  
        SetArea();
        Wandering = true;
        CRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    public void SetArea() 
    {
        NewPosL = new Vector3(transform.position.x + WalkArea, transform.position.y, transform.position.z);
        NewPosR = new Vector3(transform.position.x - WalkArea, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (Wandering == false) 
        {
            SetArea();
        }

        if (Vector2.Distance(gameObject.transform.position, GameManager.instance.Player.transform.position) < interactRange)
        {
            AttackPlayer();
        }
        else 
        {
            Wandering = true;
        }

            if (Wandering == true) 
        {
            CMOVE();
        }
       
    }
    public void CMOVE() 
    {
        //transform.position = new Vector2(NewPosR * speed * Time.deltaTime);
        transform.position = Vector3.Lerp(NewPosR, NewPosL, Mathf.PingPong(Time.time * speed, 1.0f));
    }


    public void AttackPlayer() 
    {
        
            Wandering = false;
           
            transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.Player.transform.position, ChaseSpeed * Time.deltaTime);

            //FLIPS TO FACE THE PLAYER	
            if (transform.position.x > transform.position.x)
            {
            transform.localScale = new Vector3(-1,1,1 );
            //transform.Scale(-1, 1, 1);
            //CRenderer.flipX = true;
            }
            else if (transform.position.x < transform.position.x)
            {
            transform.localScale = new Vector3(1, 1, 1);
           // CRenderer.flipX = false;
        }

        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
