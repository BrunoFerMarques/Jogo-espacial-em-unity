using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_game : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void loadSceneGame()
    {
        Debug.Log("Loading Game Scene");
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
