using UnityEngine.SceneManagement;
using UnityEngine;
public class LoadingAnother : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutoring");
    }
    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
