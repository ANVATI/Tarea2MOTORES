using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameController : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private GameObject textPaused;
    public TMP_Text distanceText;
    private float distance;
    private float totalDistance = 0f;

    private void Update()
    {
        UpdateDistance();
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        textPaused.SetActive(true);
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        isPaused = false;
        textPaused.SetActive(false);
        Time.timeScale = 1;
    }
    private void UpdateDistance()
    {
        totalDistance = totalDistance + Time.deltaTime * 10f;
        distance = totalDistance;
        distanceText.text = "Distance: " + distance.ToString("0") + " m";
    }
}
