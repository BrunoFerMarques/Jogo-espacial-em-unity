using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_Game : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }


}
