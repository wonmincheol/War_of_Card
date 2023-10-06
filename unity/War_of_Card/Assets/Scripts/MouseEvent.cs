using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    public Material hoverMaterial; // 마우스가 오브젝트에 닿았을 때의 마테리얼
    private Material originalMaterial; // 원래의 마테리얼

    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material = hoverMaterial;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = originalMaterial;
    }
}
