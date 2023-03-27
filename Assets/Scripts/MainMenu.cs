using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private FloatSO damageSO;

    public void StartGame()
    {
        SceneManager.LoadScene("main_game", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void God()
    {
        damageSO.Value = 0.1f;
    }
    public void Easy()
    {
        damageSO.Value = 0.2f;
    }

    public void Normal()
    {
        damageSO.Value = 1f;
    }

    public void Hard()
    {
        damageSO.Value = 3f;
    }

    public void Expert()
    {
        damageSO.Value = 10f;
    }
}
