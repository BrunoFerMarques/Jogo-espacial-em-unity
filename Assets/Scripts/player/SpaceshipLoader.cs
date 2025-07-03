using UnityEngine;

public class SpaceshipLoader : MonoBehaviour // Nome mais descritivo
{
    [Header("Component References")]
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private Renderer meshRenderer;
    
    [Header("Spaceship Selection")]
    [SerializeField] private SpaceshipSelector spaceshipSelector;
    
    private void Start()
    {
        TryLoadSpaceship();
    }

    public void TryLoadSpaceship()
    {
        // Tenta encontrar o seletor se não estiver atribuído
        if (spaceshipSelector == null)
        {
            spaceshipSelector = FindAnyObjectByType<SpaceshipSelector>();
            
            if (spaceshipSelector == null)
            {
                Debug.LogError("SpaceshipSelector não encontrado na cena!");
                return;
            }
        }

        // Auto-atribui componentes se necessário
        if (meshFilter == null) meshFilter = GetComponent<MeshFilter>();
        if (meshRenderer == null) meshRenderer = GetComponent<Renderer>();

        // Carrega a nave selecionada
        LoadSelectedSpaceship();
    }

    private void LoadSelectedSpaceship()
    {
        if (spaceshipSelector == null)
        {
            Debug.LogError("SpaceshipSelector não atribuído!");
            return;
        }

        // Obtém os assets da nave selecionada
        Mesh selectedMesh = spaceshipSelector.GetMesh();
        Material selectedMaterial = spaceshipSelector.GetMaterial();

        // Verifica e aplica o mesh
        if (selectedMesh != null && meshFilter != null)
        {
            meshFilter.mesh = selectedMesh;
        }
        else
        {
            Debug.LogWarning("Mesh não encontrado ou MeshFilter não atribuído");
        }

        // Verifica e aplica o material
        if (selectedMaterial != null && meshRenderer != null)
        {
            meshRenderer.material = selectedMaterial;
        }
        else
        {
            Debug.LogWarning("Material não encontrado ou Renderer não atribuído");
        }
    }
}