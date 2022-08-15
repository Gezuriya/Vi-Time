using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart = 10f;
    public Text timerText;
    void Start()
    {
        timerText.text = timeStart.ToString();
        timerText.enabled = false;
    }

    
    void Update()
    {
        if (timerText.enabled == true)
        {
            StartCoroutine(timerr());
        }
    }
    private void Snova()
    {
        timeStart = 10f;
    }

    private IEnumerator timerr()
    {
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString();
        yield return new WaitForSeconds(10f);
        Snova();
    }
}
