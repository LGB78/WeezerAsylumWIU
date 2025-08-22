using UnityEngine;

public class TestFood : MonoBehaviour
{
    public FoodItem food;                // assign which food this source gives
    public FoodItem foodCut;

    public GameObject heldObj;          // temporary sprite following the mouse
    private DraggableObject draggable;   // reference to draggable component
    public FoodItem activeFood;
    public BoolSO isKnifeHeld;      //sorry julian i kinda changed your isheld for each of these scripts to a scriptable obj
    private Bounds bounds;

    public void clickfood()
    {
        if (food == null || heldObj != null || isKnifeHeld.value == true) return;
        
        // Spawn the held food sprite object
        heldObj = new GameObject("Held_" + food.foodName);

        var sr = heldObj.AddComponent<SpriteRenderer>();
        sr.sprite = activeFood.unplatedFoodSprite;
        sr.sortingOrder = 69; // render above everything
        var srscript = heldObj.AddComponent<TestFood>();
        srscript.food = activeFood;
        srscript.foodCut = foodCut;
        srscript.isKnifeHeld = isKnifeHeld;//i added this line to carry the boolso over

        srscript.enabled = true;
        srscript.activeFood = activeFood;
        //lucas drag script
        draggable = heldObj.AddComponent<DraggableObject>();
    }
 

    private void Awake()
    {
        activeFood = food;
        getbounds();
    }

    void Update()
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (bounds != null)
        {
            if (bounds.Contains(point) && heldObj == null && Input.GetMouseButtonDown(0))
            {
                //disable sprite renderer to pretend that you took it off, while also keeping this code active so that the moving code works
                if (transform.parent.gameObject.tag == "board" && isKnifeHeld.value == false)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
                clickfood();
            }
        }
        
        if (heldObj != null)
        {
            // call drag script
            draggable.DragObject();

            // Release check
            if (Input.GetMouseButtonUp(0))
            {
                TryPlaceFood(heldObj);
                Destroy(heldObj);
                heldObj = null;
                draggable = null;
                //reenable sprite renderer since if its on cutting board object sprite renderer is disabled
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }



    private void TryPlaceFood(GameObject thefood)
    {
        Collider2D hit = Physics2D.OverlapPoint(thefood.transform.position, LayerMask.GetMask("BoardNTray"));
        if (hit != null)
        {
            FoodTarget target = hit.GetComponent<FoodTarget>();
            if (target != null)
            {
                //used the heldobj activefood here to make it more accurate
                if (thefood.GetComponent<TestFood>().activeFood.isCuttable && target.isBoard)
                {
                    target.ReceiveFood(activeFood, thefood);
                }
                else if (!thefood.GetComponent<TestFood>().activeFood.isCuttable && !target.isBoard)
                {
                    target.ReceiveFood(activeFood, thefood);
                    //delete object if its a cutting board object
                    if (gameObject.transform.parent.gameObject.tag == "board")
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    //deleted knifehold function sorry

    public void SetActiveFood(FoodItem newActive)
    {
        activeFood = newActive;
    }

    public Sprite GetUnplatedSprite()
    {
        return activeFood.unplatedFoodSprite;
    }
    //get bounds component again
    public void getbounds()
    {
        bounds = GetComponent<Collider2D>().bounds;
    }
}
