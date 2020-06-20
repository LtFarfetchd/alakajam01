using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    public GameObject Player;

    [HideInInspector]
    public PlayerManager Play_Man;
    [HideInInspector]
    public LatchMovement Latch_Man;
    [HideInInspector]
    public PlayerController Play_Con;
    [HideInInspector]
    public PlayerStats Play_Stats;
    [HideInInspector]
    public UIManager UI_Man;


    private void Awake()
    {
        Play_Man = Player.GetComponent<PlayerManager>();
        Latch_Man = Player.GetComponent<LatchMovement>();
        Play_Con = Player.GetComponent<PlayerController>();
        Play_Stats = Player.GetComponent<PlayerStats>();
        UI_Man = GetComponent<UIManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
