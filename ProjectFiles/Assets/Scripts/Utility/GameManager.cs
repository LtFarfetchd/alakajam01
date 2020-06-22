using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    public GameObject Player;
    public Vector2 PlayPos;

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

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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
        PlayPos = Player.transform.position;
    }
}
