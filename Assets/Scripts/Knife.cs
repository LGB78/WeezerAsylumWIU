using UnityEngine;
using UnityEngine.Events;

public class Knife : MonoBehaviour
{
    private bool isClicked;
    private DraggableObject draggable;
    private Vector2 startPosition;

    public GameObject board;
    public UnityEvent onHold;
    public UnityEvent onRelease;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isClicked = false;
        draggable = GetComponent<DraggableObject>();
        startPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            draggable.DragObject();
        }
        if (Input.GetMouseButtonDown(0) && IsTouchingMouse(gameObject))
        {
            KnifeUse();
        }
    }

    public bool IsTouchingMouse(GameObject obj)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Bounds bounds = obj.GetComponent<Collider2D>().bounds;
        return bounds.Contains(point);
    }

    private void KnifeUse()
    {
        // allow toggling of isclicked to allow knife to be dragged 
        //without having to hold down left mouse button
        //since u need to click food on the board
        isClicked = !isClicked;

        //if not clicked i.e. knife is attempting to be put down theres two cases
        //one is the player is trying to chop smt (check if knife overlap with board)
        //the other is player trying to put knife down
        if (!isClicked)
        {
            if (IsTouchingMouse(board))
            {
                //if player trying to like. cut shit then knife is not actually being
                //put down so isclicked set back to true
                isClicked = true;
                //if theres shit on the board's foodcontainer then ya
                if (board.transform.GetChild(0).GetChild(0) != null)
                {
                    var food = board.transform.GetChild(0).GetChild(0).gameObject;
                    //if mouse is touching food (on the click)
                    if (IsTouchingMouse(food))
                    {
                        var foodobj = food.GetComponent<TestFood>();
                        var foodrenderer = food.GetComponent<SpriteRenderer>();

                        //set the active fooditem scriptable object to the cut version
                        //ya i made there be able to like. have cut versions of food
                        //for stuff that cant be cut just set it to be the same as
                        //the normal one
                        //and then set the sprite of the foodrenderer to the activefood's sprite
                        //the problem is that activefood isnt being set to foodcut
                        //which leads me to believe that IsTouchingMouse(food) isn't working
                        //but idk why
                        foodobj.activeFood = foodobj.foodCut;
                        foodrenderer.sprite = foodobj.activeFood.unplatedFoodSprite;
                    }
                }
            }
            else
            {
                transform.position = startPosition;
                onRelease.Invoke();
            }
        }
        //if isclicked then the knife is being held
        //so invoke event accordingly
        //the event is supposed to set all food items' isKnifeHeld to true
        //this is a bit hardcoding but like [!] Rushed status type shit
        //if isknifeheld is true then the object when clicked wont spawn another food obj
        else
        {
            onHold.Invoke();
        }
    }
}
