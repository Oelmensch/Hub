using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager current;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;

    private void Start()
    {
        current.gameOverText.enabled = false;
    }

    void Awake()
    {
        if(current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }

        current = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void UpdateCoinUI(int coinCount)
    {
        if (current == null)
            return;
        current.coinText.text = coinCount.ToString();
    }

    public static void UpdateTimeUI(float time)
    {
        if (current == null)
            return;

        float seconds = time % 60f;

        current.timerText.text = "Zeit: " + seconds.ToString("00");
    }

    public static void UpdateLivesUI(int livesCount)
    {
        if (current == null)
            return;

        current.livesText.text = livesCount.ToString();
    }

    public static void DisplayGameOverText()
    {
        if (current == null)
            return;

        current.gameOverText.enabled = true;
    }
}
