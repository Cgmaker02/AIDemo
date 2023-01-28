using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text aiCount;
    public Text timeRemaining;
    private int _score;
    private int _aiCount;
    private float _timeRemaining = 120;

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("the text instance is null");    
            }
            return _instance;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        scoreText.text = "Score: 0";
        timeRemaining.text = ("Time: 120");
    }

    // Update is called once per frame
    void Update()
    {
        _timeRemaining =(_timeRemaining - Time.deltaTime);
        timeRemaining.text = ("Time: " +(int) _timeRemaining);
    }

    public void AddScore()
    {
        _score += 50;
        scoreText.text = ("Score: " + _score);
    }

    public void AddAI()
    {
        _aiCount++;
        aiCount.text = ("AICount: " + _aiCount);
    }

    public void SubtractAI()
    {
        _aiCount--;
        aiCount.text = ("AICount: " + _aiCount);
    }
}
