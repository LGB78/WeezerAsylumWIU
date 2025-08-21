using UnityEngine;

public class TestFood : MonoBehaviour
{
    public FoodItem food;                // assign which food this source gives
    public FoodItem foodCut;

    public GameObject heldObj;          // temporary sprite following the mouse
    private DraggableObject draggable;   // reference to draggable component
    public FoodItem activeFood;
    public bool isKnifeHeld;

    void OnMouseDown()
    {
        if (food == null || heldObj != null || isKnifeHeld == true) return;
        
        // Spawn the held food sprite object
        heldObj = new GameObject("Held_" + food.foodName);

        var sr = heldObj.AddComponent<SpriteRenderer>();
        sr.sprite = food.unplatedFoodSprite;
        sr.sortingOrder = 69; // render above everything
        var srscript = heldObj.AddComponent<TestFood>();
        srscript.food = food;
        srscript.foodCut = foodCut;

        //lucas drag script
        draggable = heldObj.AddComponent<DraggableObject>();
    }

    private void Awake()
    {
        activeFood = food;
        isKnifeHeld = false;
    }

    void Update()
    {
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
            }
        }
    }

    private void TryPlaceFood(GameObject thefood)
    {
        Collider2D hit = Physics2D.OverlapPoint(thefood.transform.position);
        if (hit != null)
        {
            FoodTarget target = hit.GetComponent<FoodTarget>();
            if (target != null)
            {
                if (activeFood.isCuttable && target.isBoard)
                    target.ReceiveFood(food, thefood);
                else if (!activeFood.isCuttable && !target.isBoard)
                    target.ReceiveFood(food, thefood);
            }
        }
    }

    public void KnifeHold(bool isHold)
    {
        isKnifeHeld = isHold;
    }
}
