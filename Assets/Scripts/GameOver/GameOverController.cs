using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public PlayerData playerData;
    public TMP_Text highScoreText;

    void Start()
    {
        UpdateHighScoreText();
    }

    void UpdateHighScoreText()
    {
        List<int> highScores = playerData.GetHighScores();

        string textToShow = "High Scores:\n";

        for (int i = 0; i < Mathf.Min(highScores.Count, 10); i++)
        {
            textToShow += (i + 1) + ". " + highScores[i] + "\n";
        }

        highScoreText.text = textToShow;
    }
    public void OnPressButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
