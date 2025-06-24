using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Arraste a nave para este campo no Inspector

    void Update()
    {
        if (target != null)
        {
            // Faz a câmera olhar para o alvo
            transform.LookAt(target);
        }
    }
}