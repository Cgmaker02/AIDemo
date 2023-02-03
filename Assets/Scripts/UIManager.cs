using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text aiCount;
    public Text timeRemaining;
    public Text youWin;
    private int _score;
    private int _aiCount;
    public float _timeRemaining = 150;
    public int _killCount = 0;

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
        timeRemaining.text = ("Time: 150");
        youWin.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining = (_timeRemaining - Time.deltaTime);
            timeRemaining.text = ("Time: " + (int)_timeRemaining);
        }

        WinCondition();
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

    public void WinCondition()
    {
        if(_timeRemaining <= 0 && _aiCount == _killCount)
        {
            youWin.gameObject.SetActive(true);
        }
    }

    public void AddKill()
    {
        _killCount++;
    }
}
