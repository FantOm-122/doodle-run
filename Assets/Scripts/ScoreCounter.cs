using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text HighScoreText;

    private float _score=0f;
    private int _record;
    private Transform _transform;
    private float _startPositionY;
    private float _scoreMultilier=25f;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _startPositionY=_transform.position.y;
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        _score+=(_transform.position.y-_startPositionY)*_scoreMultilier;
        ScoreText.text=((int)(_score)).ToString();
        _startPositionY=_transform.position.y;
        if (_score>_record)
        {
            _record=(int)_score;
            SaveScore();
        }
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("Record",_record);
        PlayerPrefs.Save(); 
    }
    private void LoadScore()
    {
        _record=PlayerPrefs.GetInt("Record",0);
        HighScoreText.text="High Score: "+_record.ToString();
    }
}
