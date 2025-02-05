using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    private void OnEnable()
    {
        PlayerLife.OnPlayerDeath += GameOver;
    }
    private void OnDisable()
    {
        PlayerLife.OnPlayerDeath -= GameOver;
    }
    public void GameOver()
    {
        gameOverScreen.Setup();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /*
    public void MainMenu()
    {
        SceneManager.LoadScene(0?);
    }
    */
}
