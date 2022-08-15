using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Playercont : MonoBehaviour
{
    public GameObject target1, target2, player, revBoard, touchspace, Part;

    public AudioSource arDSource;

    public float playerSpeed = 145f;
    public int score = 0;
    public int lifeamount = 0;
    public float rotspeed = 0.2f;
    public Text scoreText, besttxt, timerText, lifetxt;
    public int highscore, k;
    public static int i;
    
    bool check = false;

    public static Playercont instance;

    private void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highscore = PlayerPrefs.GetInt("SaveScore");
        }
    }
    void Start()
    {
        arDSource = GetComponent<AudioSource>();
        target1.transform.position = new Vector3(Random.Range(100f, 230f), 158f, 0f);
        target2.transform.position = new Vector3(Random.Range(100f, 230f), 437f, 0f);
        target1.SetActive(false);
        target2.SetActive(true);
        k = 5;
      /*  if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4073275", false);
        }*/
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
        besttxt.text = "Best: " + highscore;

        lifetxt.GetComponent<Text>().text = "life: " + lifeamount.ToString();
        if (check)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, playerSpeed * Time.deltaTime);
        }
        else 
        { 
            transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, playerSpeed * Time.deltaTime);
        }
        transform.rotation *= Quaternion.Euler(0, 0, rotspeed);

        if (player.transform.position == target2.transform.position && target2.activeInHierarchy)
        {
            target2.SetActive(false);
            target1.transform.position = new Vector3(Random.Range(100f, 230f), 158f, 0f);
            target1.SetActive(true);
            instance.AddScore();
        }
        else if (player.transform.position == target1.transform.position && target1.activeInHierarchy)
        {
           target2.SetActive(true);
            target2.transform.position = new Vector3(Random.Range(100f, 230f), 437f, 0f);
            target1.SetActive(false);
            instance.AddScore();
        }

        if (player.transform.position == target2.transform.position || player.transform.position == target1.transform.position)
        {
            check = !check;
        }
        if(lifeamount < 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Part.SetActive(true);
            StartCoroutine(GameOver());
        }
        if (score > 10)
        {
            playerSpeed = 150f;
        }
        if(score > 20)
        {
            playerSpeed = 155f;
        }  
        if(score > 30)
        {
            playerSpeed = 160f;
        }
        if (score > 50)
        {
            playerSpeed = 165f;
        }
        if (score > 100)
        {
            playerSpeed = 170f;
        }
        if (i == k)
        {
            PlayReklama();
        }
    }
    public void Change()
    {
        check = !check;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifeamount -= 1;
            arDSource.Play();
        }

        if (collision.gameObject.CompareTag("life"))
        {
            lifeamount += 1;
            arDSource.Play();
        }
        if (collision.gameObject.CompareTag("boost"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(VerniRB());
            gameObject.transform.localScale = new Vector3(30f, 30f, 1f);
            rotspeed = -0.5f;
            timerText.enabled = true;
            arDSource.Play();
        }
    } 
    public IEnumerator VerniRB()
    {
        yield return new WaitForSeconds(10f);
        gameObject.GetComponent<Collider2D>().enabled = true;
        gameObject.transform.localScale = new Vector3(20f, 20f, 1f);
        rotspeed = 0.2f;
        timerText.enabled = false;
    }

    public void AddScore()
    {
        score++;
        HighScore();
    }
    public void HighScore()
    {
        if (score > highscore)
        {
            highscore = score;
        }
        PlayerPrefs.SetInt("SaveScore", highscore);
    }

    public void StartPlaying()
    {
        arDSource.Play();
    }
    public void RevNo()
    {   
        i += 1;
        Destroy(player);
        SceneManager.LoadScene(2);    
    }

    public void PlayReklama()
    {
       /* if (Advertisement.IsReady())
        {
            Advertisement.Show("video");
            i = 0;
        }*/
    }
    public void ShowAd()
    {
        Application.ExternalCall("ShowAd");
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        ShowAd();
        i++;
        SceneManager.LoadScene(2);
    }
}

