using UnityEngine;

public class TextureSelector : MonoBehaviour
{
    // Parte 1: As "coisas" para selecionar
    // ==========================================================

    // A lista de texturas que podemos escolher
    public Texture[] textures;

    // O objeto no mundo que vai receber a textura (ex: a nave)
    public Renderer objectRenderer;

    // O índice da textura atualmente selecionada
    public int selectedIndex = 0;

    // ==========================================================


    void Start()
    {
        // Aplica a primeira textura da lista quando o jogo começa
        UpdateTexture();
    }

    // Funções para os botões da UI (exatamente como antes)
    public void NextTexture()
    {
        selectedIndex = (selectedIndex + 1) % textures.Length;
        UpdateTexture();
    }

    public void PreviousTexture()
    {
        selectedIndex = (selectedIndex - 1 + textures.Length) % textures.Length;
        UpdateTexture();
    }


    // Parte 2: A "Ação" a ser feita
    // ==========================================================

    // Esta função é o coração do script. Ela aplica a textura.
    void UpdateTexture()
    {
        // 1. Pega a textura que queremos usar da nossa lista
        Texture selectedTexture = textures[selectedIndex];

        // 2. Aplica essa textura no material do nosso objeto alvo
        objectRenderer.material.mainTexture = selectedTexture;
    }

    // ==========================================================
}