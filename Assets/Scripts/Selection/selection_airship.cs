using UnityEngine;

// Vamos dar um nome novo para refletir sua nova funcionalidade
public class SpaceshipAndTextureSelector : MonoBehaviour
{
    // --- NOSSAS LISTAS ---
    public GameObject[] spaceships;       // Sua lista de naves
    public Texture2D[] availableTextures; // Nossa nova lista de texturas

    // --- ÍNDICES DE SELEÇÃO ---
    private int currentShipIndex = 0;
    private int currentTextureIndex = 0;

    void Start()
    {
        // Garante que a primeira nave e a primeira textura sejam aplicadas no início
        UpdateSelection();
    }

    // --- MÉTODOS PARA TROCAR DE NAVE (Para os botões de Nave) ---
    public void NextShip()
    {
        currentShipIndex = (currentShipIndex + 1) % spaceships.Length;
        UpdateSelection();
    }

    public void PreviousShip()
    {
        currentShipIndex = (currentShipIndex - 1 + spaceships.Length) % spaceships.Length;
        UpdateSelection();
    }

    // --- NOVOS MÉTODOS PARA TROCAR DE TEXTURA (Para os botões de Textura) ---
    public void NextTexture()
    {
        currentTextureIndex = (currentTextureIndex + 1) % availableTextures.Length;
        UpdateSelection();
    }

    public void PreviousTexture()
    {
        currentTextureIndex = (currentTextureIndex - 1 + availableTextures.Length) % availableTextures.Length;
        UpdateSelection();
    }


    // --- O CÉREBRO DO SCRIPT ---
    // Esta função central atualiza tudo de uma vez
    private void UpdateSelection()
    {
        // ETAPA 1: ATUALIZAR QUAL NAVE ESTÁ ATIVA (Lógica que você já conhece)
        for (int i = 0; i < spaceships.Length; i++)
        {
            // Desativa todas as naves, exceto a selecionada
            spaceships[i].SetActive(i == currentShipIndex);
        }

        // ETAPA 2: APLICAR A TEXTURA NA NAVE ATIVA
        GameObject activeShip = spaceships[currentShipIndex];
        Texture activeTexture = availableTextures[currentTextureIndex];

        // Pega o componente Renderer da nave que está ativa
        Renderer shipRenderer = activeShip.GetComponent<Renderer>();

        // Verifica se a nave realmente tem um Renderer antes de tentar mudar a textura
        if (shipRenderer != null)
        {
            // Aplica a textura selecionada no material da nave ativa
            shipRenderer.material.mainTexture = activeTexture;
        }

        Debug.Log("Nave Ativa: " + activeShip.name + " | Textura Ativa: " + activeTexture.name);
    }
}