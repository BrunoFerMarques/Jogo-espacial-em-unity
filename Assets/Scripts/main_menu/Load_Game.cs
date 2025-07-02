using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Game : MonoBehaviour
{

    public void LoadSceneGame()
    {
        Debug.Log("Clicou no botão — tentando carregar cena 'Game'");
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

}
