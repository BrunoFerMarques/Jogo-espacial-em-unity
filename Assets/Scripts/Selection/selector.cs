using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipSelector : MonoBehaviour
{
    public static SpaceshipSelector Instance { get; private set; }

    [Header("Componentes")]
    public MeshFilter meshFilter;          // Componente que exibe o modelo
    public Renderer meshRenderer;         // Componente que renderiza o material

    [Header("Opções")]
    public Mesh[] shipModels;             // Array de modelos de naves
    public Material[] shipMaterials;      // Array de materiais/texturas
    public bool loopSelection = true;     // Se deve voltar ao início após o último
    public KeyCode nextKey = KeyCode.RightArrow;  // Tecla para próxima nave
    public KeyCode prevKey = KeyCode.LeftArrow;   // Tecla para nave anterior
    public KeyCode nextMaterialKey = KeyCode.UpArrow;    // Tecla para próximo material
    public KeyCode prevMaterialKey = KeyCode.DownArrow;  // Tecla para material anterior

    private int currentModelIndex = 0;
    private int currentMaterialIndex = 0;

    void Awake()
    {
        // Implementação do Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // Auto-atribui componentes se não estiverem configurados
        if (meshFilter == null) meshFilter = GetComponent<MeshFilter>();
        if (meshRenderer == null) meshRenderer = GetComponent<Renderer>();

        // Aplica a seleção inicial
        UpdateSelection();
    }

    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.qKey.wasPressedThisFrame)
        {
            SelectNextModel();
        }
        else if (keyboard.eKey.wasPressedThisFrame)
        {
            SelectPreviousModel();
        }

        else if (keyboard.aKey.wasPressedThisFrame)
        {
            SelectNextMaterial();
        }
        else if (keyboard.dKey.wasPressedThisFrame)
        {
            SelectPreviousMaterial();
        }
    }

    public void SelectNextModel()
    {
        if (shipModels.Length == 0) return;

        currentModelIndex++;
        if (loopSelection && currentModelIndex >= shipModels.Length)
        {
            currentModelIndex = 0;
        }
        UpdateSelection();
    }

    public void SelectPreviousModel()
    {
        if (shipModels.Length == 0) return;

        currentModelIndex--;
        if (currentModelIndex < 0)
        {
            currentModelIndex = loopSelection ? shipModels.Length - 1 : 0;
        }
        UpdateSelection();
    }

    public void SelectNextMaterial()
    {
        if (shipMaterials.Length == 0) return;

        currentMaterialIndex++;
        if (loopSelection && currentMaterialIndex >= shipMaterials.Length)
        {
            currentMaterialIndex = 0;
        }
        UpdateSelection();
    }

    public void SelectPreviousMaterial()
    {
        if (shipMaterials.Length == 0) return;

        currentMaterialIndex--;
        if (currentMaterialIndex < 0)
        {
            currentMaterialIndex = loopSelection ? shipMaterials.Length - 1 : 0;
        }
        UpdateSelection();
    }

    private void UpdateSelection()
    {
        // Atualiza o modelo 3D
        if (meshFilter != null && shipModels.Length > 0)
        {
            currentModelIndex = Mathf.Clamp(currentModelIndex, 0, shipModels.Length - 1);
            meshFilter.mesh = shipModels[currentModelIndex];
        }

        // Atualiza o material
        if (meshRenderer != null && shipMaterials.Length > 0)
        {
            currentMaterialIndex = Mathf.Clamp(currentMaterialIndex, 0, shipMaterials.Length - 1);
            meshRenderer.material = shipMaterials[currentMaterialIndex];
        }

        Debug.Log($"Nave {currentModelIndex + 1}/{shipModels.Length} " +
                 $"| Material {currentMaterialIndex + 1}/{shipMaterials.Length}");
    }

    public Mesh GetMesh()
    {
        return shipModels[currentModelIndex];
    }
    public Material GetMaterial()
    {
        return shipMaterials[currentMaterialIndex];
    }
    
    
    // Métodos para UI (caso queira usar botões)
    public void UI_NextModel() => SelectNextModel();
    public void UI_PrevModel() => SelectPreviousModel();
    public void UI_NextMaterial() => SelectNextMaterial();
    public void UI_PrevMaterial() => SelectPreviousMaterial();
}