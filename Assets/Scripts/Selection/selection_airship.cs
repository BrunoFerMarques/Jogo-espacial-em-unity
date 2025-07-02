using UnityEngine;

// Vamos dar um nome novo para refletir sua nova funcionalidade
public class SpaceshipAndTextureSelector : MonoBehaviour
{
    // --- NOSSAS LISTAS ---
    public GameObject[] spaceships;       // Sua lista de naves
    public Texture2D[] availableTextures; // Nossa nova lista de texturas

    // --- �NDICES DE SELE��O ---
    private int currentShipIndex = 0;
    private int currentTextureIndex = 0;

    void Start()
    {
        // Garante que a primeira nave e a primeira textura sejam aplicadas no in�cio
        UpdateSelection();
    }

    // --- M�TODOS PARA TROCAR DE NAVE (Para os bot�es de Nave) ---
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

    // --- NOVOS M�TODOS PARA TROCAR DE TEXTURA (Para os bot�es de Textura) ---
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


    // --- O C�REBRO DO SCRIPT ---
    // Esta fun��o central atualiza tudo de uma vez
    private void UpdateSelection()
    {
        // ETAPA 1: ATUALIZAR QUAL NAVE EST� ATIVA (L�gica que voc� j� conhece)
        for (int i = 0; i < spaceships.Length; i++)
        {
            // Desativa todas as naves, exceto a selecionada
            spaceships[i].SetActive(i == currentShipIndex);
        }

        // ETAPA 2: APLICAR A TEXTURA NA NAVE ATIVA
        GameObject activeShip = spaceships[currentShipIndex];
        Texture activeTexture = availableTextures[currentTextureIndex];

        // Pega o componente Renderer da nave que est� ativa
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