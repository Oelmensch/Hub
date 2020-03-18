using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager current;
    public Animatorcontroller anim;

    public GameObject currentCheckPoint;
    public GameObject player;

    public float deathSequenceDuration = 1.5f;
    //List<Coin> coins;
    SceneFader sceneFader;

    private int numberOfLives;
    private float totalGameTime;
    private bool isGameOver;

    private void Awake()
    {

        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }

        current = this;

        // coins = new List<Coins>();
        currentCheckPoint = GameObject.Find("StartPunkt");
        player = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {

    }
    void Update()
    {
        if (isGameOver)
            return;

        totalGameTime += Time.deltaTime;
        UIManager.UpdateTimeUI(totalGameTime);
    }

    public static bool IsGameOver()
    {
        if (current == null)
            return false;

        return current.isGameOver;
    }

    public static void RegisterSceneFader(SceneFader fader)
    {
        if (current == null)
            return;

        current.sceneFader = fader;
    }



    /* public static void RegisterCoin(Coin coin)
     {
         if (current == null)
             return;

         if (!current.coins.Contains(coin))
             current.coins.Add(coin);

         UIManager.UpdateCoinUI(current.coins.Count);
     }

     public static void PlayerGrabbedCoin(Coin coin)
     {
         if (current == null)
             return;

         if (!current.coins.Contains(coin))
             return;

         current.coins.Remove(coin);

         UIManager.UpdateCoinUI(current.coins.Count);
     }
     */
    public static void PlayerDie()
    {
        if (current == null)
            return;


        current.sceneFader.FadeSceneOut();

        current.Invoke("RestartScene", current.deathSequenceDuration);
        
    }

    public static void PlayerWon()
    {
        if (current == null)
            return;

        current.isGameOver = true;

        UIManager.DisplayGameOverText();
        AudioManager.PlayWonAudio();
    }

    public void RestartScene()
    {
        //coins.Clear();
        AudioManager.PlaySceneRestartAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
