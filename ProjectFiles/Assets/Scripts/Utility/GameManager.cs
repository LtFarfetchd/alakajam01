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
        //Play_Man = FindObjectOfType<PlayerManager>();
        //Latch_Man = FindObjectOfType<LatchMovement>();
        //Play_Con = FindObjectOfType<PlayerController>();
        //Play_Stats = FindObjectOfType<PlayerStats>();
        //UI_Man = GetComponent<UIManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        Play_Man = FindObjectOfType<PlayerManager>();
        Latch_Man = FindObjectOfType<LatchMovement>();
        Play_Con = FindObjectOfType<PlayerController>();
        Play_Stats = FindObjectOfType<PlayerStats>();
        UI_Man = GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
