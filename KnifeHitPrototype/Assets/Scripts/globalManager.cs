using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class globalManager : MonoBehaviour {
    public enum swordMode : int
    {
        sword = 0,
        buster = 1,
        blood = 2,
        flame = 3
    };

    public Text totalScore;
    public static int totalScoreNum=0;
    public static swordMode swordSelected = 0;
    public Text[] swordText = new Text[4];
    
    // Use this for initialization
    void Start () {
      
    }

    // Update is called once per frame
    void Update () {
        totalScore.text = "Current Points:\n" + totalScoreNum;
    }

    public void BeginGame()
    {
        gameManager.wave = 0;
        SceneManager.LoadScene("MainGame");
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void ChoiceSelection(int selected)
    {
        if (selected == 0)
        {
            swordSelected = (swordMode)selected;
        }
        else if (totalScoreNum >= 10 && selected == 1)
        {
            if (swordText[selected].text != "V") 
            swordText[selected].text = "V";
            swordSelected = (swordMode)selected;

        }
        else if (totalScoreNum >= 50 && selected == 2)
        {
            if (swordText[selected].text != "V")
            swordText[selected].text = "V";
            swordSelected = (swordMode)selected;
        }
        else if (totalScoreNum >= 100 && selected == 3)
        {
            if (swordText[selected].text != "V")
            swordText[selected].text = "V";
            swordSelected = (swordMode)selected;
        }
    }
}
