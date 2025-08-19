using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestFood : MonoBehaviour
{
    private Vector2 offset;
    private Vector2 startPosition;
    private bool isClicked;
    private Collider2D thiscollider;
    private bool isPlated;

    public FoodItem food;
    public GameObject plate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        isClicked = false;
        thiscollider = GetComponent<Collider2D>();
        isPlated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlated)
        {
            if (Input.GetMouseButton(0))
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
                if (hit.collider == thiscollider)
                {
                    isClicked = true;
                }
                else
                {
                    isClicked = false;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (!IsTouchingMouse(plate))
                {
                    transform.position = startPosition;
                }
                else
                {
                    if (isClicked)
                    { 
                        food.Plate(this.gameObject);
                        isPlated = true;
                    }
                }
            }
        }
    }

    void OnMouseDrag()
    {
        if (!isPlated)
        {
            DragObject();
        }

    }

    public bool IsTouchingMouse(GameObject g)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return g.GetComponent<Collider2D>().OverlapPoint(point);
    }

    public void DragObject()
    {
        Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        Vector2 curPosition = new Vector2(Camera.main.ScreenToWorldPoint(curScreenPoint).x, Camera.main.ScreenToWorldPoint(curScreenPoint).y) + offset;
        transform.position = curPosition;
    }
}
