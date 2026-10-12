using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Texture2D rotationCursor;

    private Vector2 cursorHotspot = new Vector2(16, 16);

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(rotationCursor, cursorHotspot, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}