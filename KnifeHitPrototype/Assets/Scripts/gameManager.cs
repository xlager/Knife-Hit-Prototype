using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public GameObject[] swordPrefab = new GameObject[4];
    public Text circleLife;
    public Text life;
    public Text score;
    public static int scoreNum = 0;
    public static int lifeNum = 3;
    public static int circleLifeNum = 5;
    public Text lose;
    public Image image;
    public static int wave=0;
    public Scene actual;
    private GameObject swordToLoad;
    private bool die = false;
    // Use this for initialization
    void Start()
    {

        if (wave == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            scoreNum = 0;
            lifeNum = 3;
            attTexts();
            
        }
        GameObject standSword = Instantiate(swordPrefab[(int)globalManager.swordSelected]);
        Destroy(standSword.GetComponent<CapsuleCollider2D>());
        Destroy(standSword.GetComponent<Rigidbody2D>());
        standSword.transform.position = swordPrefab[(int)globalManager.swordSelected].transform.position;
        standSword.SetActive(true);
        wave++;
        circleLifeNum = circle.life;
        die = false;
    }

    // Update is called once per frame
    void Update()
    {
        attTexts();

        if (Input.GetMouseButtonDown(0) && !die)
        {
            createSword();
        }
        if (lifeNum == 0)
            Lose();
        if (circleLifeNum == 0 && !die)
            NewOpponent();
    }
    void createSword()
    {
        GameObject newSword = Instantiate(swordPrefab[(int)globalManager.swordSelected]);
        newSword.transform.position = swordPrefab[(int)globalManager.swordSelected].transform.position;
        newSword.SetActive(true);
    }
    void attTexts()
    {
        score.text = "Score: " + scoreNum;
        life.text = "Life: " + lifeNum;
        circleLife.text = "Enemy: " + circleLifeNum;
    }
    void Lose()
    {
        image.gameObject.SetActive(true);
        lose.text = "YOU LOSE\nScore: " + scoreNum;
        die = true;
    }
    public void LoadMenu()
    {
        if(die)
            globalManager.totalScoreNum += scoreNum;
        SceneManager.LoadScene("MainMenu");

    }
    public void NewOpponent()
    {
        SceneManager.LoadScene("MainGame");
    }

}
    
