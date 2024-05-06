using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public int score;
    public List<int> highScores = new List<int>();

    public void ResetData()
    {
        score = 0;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        CheckHighScore();
    }

    private void CheckHighScore()
    {
        highScores.Add(score);

        highScores.Sort((a, b) => b.CompareTo(a));

        if (highScores.Count > 10)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }
    }
    public List<int> GetHighScores()
    {
        return highScores;
    }
}