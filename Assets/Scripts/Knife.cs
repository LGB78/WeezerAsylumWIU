using UnityEngine;

public class Knife : MonoBehaviour
{
    private bool isClicked;
    private DraggableObject draggable;
    private Vector2 startPosition;

    public GameObject board;
    public GameObject food;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isClicked = false;
        draggable = GetComponent<DraggableObject>();
        startPosition = transform.position;
    }

    private void OnMouseDown()
    {
        isClicked = !isClicked;
        if (!isClicked)
        {
            if (IsTouchingMouse(board))
            {
                isClicked = true;
                if (board.transform.GetChild(0).GetChild(0).gameObject != null)
                {
                    food = board.transform.GetChild(0).GetChild(0).gameObject;
                    if (IsTouchingMouse(food))
                    {
                        var foodrenderer = food.GetComponent<SpriteRenderer>();

                    }
                }
            }
            else
            {
                transform.position = startPosition;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            draggable.DragObject();
        }
    }

    public bool IsTouchingMouse(GameObject obj)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return obj.GetComponent<Collider2D>().OverlapPoint(point);
    }

    private void CutFood(GameObject obj)
    {

    }
}
