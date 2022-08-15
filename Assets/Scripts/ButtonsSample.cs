using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ButtonsSample : MonoBehaviour
{
    public GameObject panelka1, pause, panelka2, toucher, lifeamtxt;
    public Playercont Playercont;
    public int lifeamount;
    public static int i;

   // void Start()
 //   {
  //      Playercont.GetComponent<Playercont>();
  //  }
 //   void Update()
 //   {
 //       lifeamount = Playercont.lifeamount;
  //      if (i == 1 && lifeamount < 0)
  //      {
   //         SceneManager.LoadScene(2);
   //         i = 0;
   //     }     
   // }
        public void PauseGame()
    {
        Time.timeScale = 0;
        panelka1.SetActive(true);
        pause.SetActive(false);
        toucher.SetActive(false);
    }
    public void Return()
    {
        panelka1.SetActive(false);
        Time.timeScale = 1;
        pause.SetActive(true);
        toucher.SetActive(true);
    }
    public void MainMen()
    {
        panelka1.SetActive(false);
        panelka2.SetActive(true);
    }
    public void MainNo()
    {
        Time.timeScale = 1;
        panelka2.SetActive(false);
        pause.SetActive(true);
        toucher.SetActive(true);
    }
    public void MainYes()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
   // public void RevYes()
   // {
     //   Playercont.revBoard.SetActive(false);
     //   panelka2.SetActive(true);
     //   if (Advertisement.IsReady())
     //   {
     //       Advertisement.Show("rewardedVideo");
     //   }
   // }
  //  public void RetToGame()
  //  {
  //      Playercont.lifeamount = 0;
  //      Playercont.revBoard.SetActive(false);
  //      panelka2.SetActive(false);
  //      pause.SetActive(true);
  //      i++;
  //  }
}
