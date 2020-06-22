using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //This class holds the base stats that won't be buffed and are only called once
    [HideInInspector]
    public class BaseStats
    {
        public int hitPoints = 1;
        public int lifePoints = 0;
        public float jumpForce = 5;
        public float moveSpeed = 1;
    }
    //Holds the BaseStat class in a variable for the player stat class to access
    [HideInInspector]
    public BaseStats b_Stats;

    //This class holds the stats that are derived from the base, these are the stats that are checked in game and are buffed depending on the creature
    [System.Serializable]
    public class StatsToBuff 
    {
        public int player_HP;
        public int player_Lifepoints;
        public float player_JumpForce;
        public float player_MoveSpeed;
    }
    //Stores the StatsToBuff class in a variable for this script to access
    public StatsToBuff CheckStats;

    void start() 
    {
       
    }
    //Assigns the stat values, making the initial starting stats derived from the base stats
   public void StartStats(BaseStats b_Stats, StatsToBuff CheckStats)
    {
        
        CheckStats.player_HP = b_Stats.hitPoints;
        CheckStats.player_Lifepoints = b_Stats.lifePoints;
        CheckStats.player_JumpForce = b_Stats.jumpForce;
        CheckStats.player_MoveSpeed = b_Stats.moveSpeed;
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
