using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    [SerializeField] private Vector2 offset;

    //code that drags clicked object while mouse is down.
    public void DragObject()
    {
        Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        Vector2 curPosition = new Vector2(Camera.main.ScreenToWorldPoint(curScreenPoint).x, Camera.main.ScreenToWorldPoint(curScreenPoint).y) + offset;
        transform.position = curPosition;
    }
}
