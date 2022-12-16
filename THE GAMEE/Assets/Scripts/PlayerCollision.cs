using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int playerScore;
    bool isInLowScoreZone;
    public int ScorePlus { get { return playerScore; } set { playerScore = value; } }
    
    
    void Start()
    {
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInLowScoreZone)
        {
            playerScore = playerScore + ScorePlus;
        Debug.Log(playerScore);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="LowScore")
        {
            isInLowScoreZone = true;
            Debug.Log("Esta en LowScore");
        }
    }
}
