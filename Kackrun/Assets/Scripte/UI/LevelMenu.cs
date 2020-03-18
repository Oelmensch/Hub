using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    private string _curLevel;

    void Start()
    {
        PlayerPrefs.SetInt("Back", 1);
        PlayerPrefs.SetInt("Level (1)", 1);

        if (PlayerPrefs.GetInt(_curLevel.ToString()) == 1)
        {
            //Level freigeschaltet
            this.GetComponent<Button>().interactable = true;
        }
        else
        {
            //Level gesperrt
            this.GetComponent<Button>().interactable = false;

        }

        _curLevel = gameObject.name;
    }

    public void LoadScene()
    {
            SceneManager.LoadScene(_curLevel);
    }
}
