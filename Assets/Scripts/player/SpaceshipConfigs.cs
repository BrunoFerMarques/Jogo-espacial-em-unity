using UnityEngine;
public class SpaceshipConfigs : MonoBehaviour
{
    public float scaleMultiplier = 0.3f; // 0.5 = 50% do tamanho original
    public Vector3 iniPosition = new Vector3(0f, 0f, -300f); 
    void Start()
    {
        // Aplica a escala ao iniciar
        transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, scaleMultiplier);
        transform.position = new Vector3(iniPosition.x, iniPosition.y, iniPosition.z);
    }
}