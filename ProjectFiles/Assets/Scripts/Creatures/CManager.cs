using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CManager : MonoBehaviour
{
    public CreatureStats Creature_Stats;
    public CreatureMovement Creature_Movement;
    public bool Hived;
    public Animator[] C_animator;
    public string[] Animations;
    //public Animation[] Animations;


    private void Awake()
    {
        Creature_Stats = GetComponent<CreatureStats>();
        Creature_Movement = GetComponent<CreatureMovement>();
        Hived = false;
        C_animator = GetComponentsInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Hived == true)
        {
            //C_animator[C_animator.].SetBool("Hived", true);
            //C_animator[1].SetBool("Hived", true);
            foreach (Animator an in C_animator) 
            {
                an.SetBool("Hived", true);
                
            }

        }

        //if (Hived == false)
        //{
        //    if (!Input.anyKey)
        //    {
        //        if (Hived == false)
        //        {
        //            C_animator.SetBool("Idle", true);
        //            C_animator.Play(Animations[0].ToString());
        //        }
        //        else
        //        {
        //            C_animator.SetBool("Idle", true);
        //            C_animator.Play(Animations[3].ToString());
        //        }
        //    }
        //}
    }
}
