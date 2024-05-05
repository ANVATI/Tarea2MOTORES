using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    public void OnPressButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
