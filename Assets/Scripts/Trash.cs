using UnityEngine;

public class Trash : MonoBehaviour
{
    public Transform foodContainer;

    private void Awake()
    {
        if (foodContainer == null)
            foodContainer = transform;
    }

    private void Update()
    {
        // Left mouse click check
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D col = GetComponent<Collider2D>();

            // If we clicked on the trash object
            if (col != null && col.OverlapPoint(mousePos))
            {
                ClearFood();
            }
        }
    }

    public void ClearFood()
    {
        // Destroy all children of the foodContainer
        for (int i = foodContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(foodContainer.GetChild(i).gameObject);
        }
    }
}
