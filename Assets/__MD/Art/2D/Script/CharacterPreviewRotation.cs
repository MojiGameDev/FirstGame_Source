using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterPreviewRotation : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform characterModel;
    [SerializeField] private float rotationSpeed = 0.5f;

    public void OnDrag(PointerEventData eventData)
    {
        float rotation = -eventData.delta.x * rotationSpeed;

        characterModel.Rotate(0f, rotation, 0f);
    }
}