using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Selectione : MonoBehaviour
{

    public void LoadSceneSelection()
    {
        Debug.Log("Clicou no botão — tentando carregar cena 'Selection'");
        SceneManager.LoadScene("Selection", LoadSceneMode.Single);
    }

}
