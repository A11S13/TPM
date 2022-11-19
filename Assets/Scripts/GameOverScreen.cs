using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void ResartButton()
    {
        SceneManager.LoadScene("main_game");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("main_menu");
    }
}
