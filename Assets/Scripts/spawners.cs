using System.Collections;
using UnityEngine;

public class spawners : MonoBehaviour
{
    GameObject[] Enemies = new GameObject[6];
    GameObject[] RandSpawn = new GameObject[2];
    GameObject[] Boosts = new GameObject[2];
    public Playercont Playercont;
    public GameObject zero, one, two, three, four, five, spawn1, spawn2, boost, life;
    int N, S, K;
    public int score;
    public float boostspawn, enemyspawn;

    void Start()
    {
        boostspawn = Random.Range(20f,40f);
        enemyspawn = 2.5f;
        RandSpawn[0] = spawn1; 
        RandSpawn[1] = spawn2;

        Enemies[0] = zero;
        Enemies[1] = one;
        Enemies[2] = two;
        Enemies[3] = three;
        Enemies[4] = four;
        Enemies[5] = five;

        Boosts[0] = boost;
        Boosts[1] = life;

        N = Random.Range(0, 6);
        S = Random.Range(0, 2);
        K = 0;

        Repeat();
        RepeatBoost();
        Playercont.GetComponent<Playercont>();
        
    }
    
    void Update()
    {
        score = Playercont.score;
        S = Random.Range(0, 2);
        if (S == 0)
        {
            N = Random.Range(0, 3);
            K = 0;
        }
        else
        {
            N = Random.Range(3, 6);
            K = 1;
        }

        spawn1.transform.position = new Vector3(Random.Range(-270, -110), Random.Range(350, 250), 0);
        spawn2.transform.position = new Vector3(Random.Range(424, 584), Random.Range(350, 250), 0);
        if (score > 10)
        {
            enemyspawn = 2.25f;
        }
        if (score > 20)
        {
            enemyspawn = 2f;
        }
        if (score > 30)
        {
            enemyspawn = 1.8f;
        }
        if (score > 40)
        {
            enemyspawn = 1.6f;
        }
        if (score > 50)
        {
            enemyspawn = 1.4f;
        }
        if (score > 75)
        {
            enemyspawn = 1.25f;
        }
        if (score > 100)
        {
            enemyspawn = 1.1f;
        }
        if (score > 150)
        {
            enemyspawn = 1f;
        }
        if (score > 200)
        {
            enemyspawn = 0.8f;
        }
        if (score > 300)
        {
            enemyspawn = 0.6f;
        }
    }
    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }
    void RepeatBoost()
    {
        StartCoroutine(SpawnBoost());
    }
    void ResetTime()
    {
        boostspawn = Random.Range(20f, 40f);
    }
   
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(enemyspawn);
        Instantiate(Enemies[N], RandSpawn[S].transform.position, Quaternion.identity);
        Repeat();
    }
    IEnumerator SpawnBoost()
    {
        yield return new WaitForSeconds(boostspawn);
        Instantiate(Boosts[K], RandSpawn[S].transform.position, Quaternion.identity);
        RepeatBoost();
        ResetTime();
    }

}
