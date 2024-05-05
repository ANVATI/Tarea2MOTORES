using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject Options;
    public void Startlevel()
    {
        SceneManager.LoadScene("Game");
    }
    public void AppearOptions()
    {
        Options.SetActive(true);
    }
    public void DisappearOptions()
    {
        Options.SetActive(false);
    }

}
