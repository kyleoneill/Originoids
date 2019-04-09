using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Player player; //Player must be linked to update score from the player?
    public int scorePerSecond = 1;

    private Text winText;
    private float secondCounter = 0.0f;
    private int currentScore;

    // Start is called before the first frame update
    void Awake()
    {
        winText = GetComponent<Text>();
        currentScore = 0;
        winText.text = $"Score: {currentScore}";
    }

    // Update is called once per frame
    void Update()
    {
        secondCounter += Time.deltaTime;
        if(secondCounter >= 1 && player.getLifeStatus())
        {
            currentScore += scorePerSecond;
            winText.text = $"Score: {currentScore}";
            secondCounter = 0;
        }
    }
}
