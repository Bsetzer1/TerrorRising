using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour{

    public Text pointsText;

    public void Setup(float points)
    {
        gameObject.SetActive(true);
        pointsText.text = points.ToString() + " POINTS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitButton()
    {
        Application.Quit();
    }

}
