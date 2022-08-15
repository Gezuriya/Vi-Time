using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject panelka;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        panelka.SetActive(true);
    }
    public void Yes()
    {
        Application.Quit();
    }
    public void No()
    {
        panelka.SetActive(false);
    }
}
