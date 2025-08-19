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
        //if it's not plated, then check for mouse button down and such
        //if its plated then dont cause u cant move it anymore
        //same logic goes for the onmousedrag part
        if (!isPlated)
        {
            if (Input.GetMouseButton(0))
            {
                //raycast from mouse position and see if it click object
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
                //if it wasnt dropped on the plate then put it back at the start
                if (!IsTouchingMouse(plate))
                {
                    transform.position = startPosition;
                }
                else
                {
                    //i realised that if i didnt check if its the object clicked then
                    //both objects would be clicked. so this is just to check for
                    //the actual objec being clicked
                    //tbh the mouse code could probably be moved to another file but
                    if (isClicked)
                    {
                        food.Plate(this.gameObject);
                        isPlated = true;
                        transform.position = plate.transform.position;
                        //plate food (prevent further movement) and snap to plate position
                        //the last line about transform.position can be changed as desired 
                        //for different food snapping once we have the actual plate sprite and we're
                        //arranging the food
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

    //code that checks for if the mouse is inside the plate's collider area
    public bool IsTouchingMouse(GameObject g)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return g.GetComponent<Collider2D>().OverlapPoint(point);
    }

    //code that drags clicked object while mouse is down.
    public void DragObject()
    {
        Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        Vector2 curPosition = new Vector2(Camera.main.ScreenToWorldPoint(curScreenPoint).x, Camera.main.ScreenToWorldPoint(curScreenPoint).y) + offset;
        transform.position = curPosition;
    }
}
