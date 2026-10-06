using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hearts : MonoBehaviour
{
    public int lives = 3;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public GameObject gameOverText;

    void Start()
    {
        gameOverText.SetActive(false);
    }

    public void LoseLife()
    {
        lives--;

        if(lives == 2)
        {
            heart3.gameObject.SetActive(false);
        }
        else if(lives == 1)
        {
            heart2.gameObject.SetActive(false);
        }
        else if(lives == 0)
        {
            heart1.gameObject.SetActive(false);
            gameOverText.SetActive(true);
            Time.timeScale = 0; //stops movement in game
        }
    }
}
