using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
    public Player player;
    public int scorePerSecond = 1;

    private Text winText;
    private float secondCounter = 0.0f;
    private int currentScore;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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

    public void AddScore(int addition)
    {
        currentScore += addition;
    }
}
