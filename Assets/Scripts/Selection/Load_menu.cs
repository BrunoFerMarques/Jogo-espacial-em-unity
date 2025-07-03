using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void loadSceneGame()
    {
        Debug.Log("Loading Menu Scene");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}

