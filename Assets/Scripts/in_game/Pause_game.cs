using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause_game : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PauseGame()
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Single);
    }
}
