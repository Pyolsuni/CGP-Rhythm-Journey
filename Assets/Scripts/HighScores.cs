/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighScores : MonoBehaviour
{
    public List<int> _score = new List<int>();
    public List<int> _combo = new List<int>();

    public List<TMP_Text> _mainMenuScore, _mainMenuCombo, _gameScore, _gameCombo;

    private int _highscoreToSet, _tempScore, _tempCombo;
    private string _scoreList, _comboList;

    public void SetHighScore(int score, int combo)
    {
        for (int i = 0; i < _score.Count; i++)
        {
            if (_highscoreToSet <= 1)
            {
                _tempScore = _score[i];
                _score[i] = score;
                score = _tempScore;

                _tempCombo = _combo[i];
                _combo[i] = combo;
                combo = _tempCombo;

                _scoreList = "Score" + i;
                _comboList = "Combo" + i;

                PlayerPrefs.SetInt(_scoreList, _score[i]);
                PlayerPrefs.SetInt(_comboList, _combo[i]);

            }
        }
    }

    private void LoadScores()
    {
        _score.Clear();
        _combo.Clear();
        for (int i = 0; i < 10; i++)
        {
            _scoreList = "Score" + i;
            _comboList = "Combo" + i;
            _score.Add(PlayerPrefs.GetInt(_scoreList));
            _combo.Add(PlayerPrefs.GetInt(_comboList));
        }
    }

    public int checkScore(int score)
    {
        LoadScores();
        _highscoreToSet = 99;

        for (int i = 0; i < _score.Count; i++)
        {
            if (score > _score[i])
            {
                _highscoreToSet = i;
                i = 10;
            }
        }
        return _highscoreToSet;
    }

    public void SetGameScoreBoard()
    {
        LoadScores();
        int loop = 0;
        foreach(TMP_Text score in _gameScore)
        {
            score.text = _score[loop].ToString();
            loop++;
        }
        loop = 0;
        foreach (TMP_Text combo in _gameCombo)
        {
            combo.text = _combo[loop].ToString();
            loop++;
        }
        loop = 0;
    }
}*/