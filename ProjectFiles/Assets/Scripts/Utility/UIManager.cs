using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameManager Game_Man;
    public Text PlayerLives;
    public Text PlayerHP;

    // Start is called before the first frame update
    private void Awake()
    {
        //Game_Man = GetComponent<GameManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLives.text = "Hive Mind Size = " + Game_Man.Play_Stats.CheckStats.player_Lifepoints.ToString();
        //PlayerHP.text = "Hit points: " + Game_Man.Play_Stats.CheckStats.player_HP.ToString();
        PlayerHP.text = "Hit points: " + Game_Man.Play_Man.PlayStat.CheckStats.player_HP;
    }
}
