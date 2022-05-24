using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject winnerUI;
    public GameObject player;
    bool gameOver;
    GameObject level1;
    GameObject level2;

    private void Start()
    {
        //level1 = GameObject.Find("Level 1");
        //level2 = GameObject.Find("Level 2");
        //level2.SetActive(false);
    }

    private void Update()
    {
       if (gameOver)
        {
            GameOver();
        }
    }

    void GameOver() {
        player.GetComponent<Player>().enabled = false;
        Destroy(player.GetComponent<Rigidbody>());
        winnerUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void UpdateLevel()
    {  
        if (level1.activeInHierarchy)
        {
            level1.SetActive(false);
            level2.SetActive(true);
        } else
        {
            gameOver = true;
        }
    }
}