using UnityEngine;

public class TestFood : MonoBehaviour
{
    public FoodItem food;                // assign which food this source gives
    private GameObject heldObj;          // temporary sprite following the mouse
    private DraggableObject draggable;   // reference to draggable component

    void OnMouseDown()
    {
        if (food == null || heldObj != null) return;

        // Spawn the held food sprite object
        heldObj = new GameObject("Held_" + food.foodName);

        var sr = heldObj.AddComponent<SpriteRenderer>();
        sr.sprite = food.unplatedFoodSprite;
        sr.sortingOrder = 69; // render above everything

        //lucas drag script
        draggable = heldObj.AddComponent<DraggableObject>();
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
                TryPlaceFood(heldObj.transform.position);
                Destroy(heldObj);
                heldObj = null;
                draggable = null;
            }
        }
    }

    private void TryPlaceFood(Vector3 dropPosition)
    {
        Collider2D hit = Physics2D.OverlapPoint(dropPosition);
        if (hit != null)
        {
            FoodTarget target = hit.GetComponent<FoodTarget>();
            if (target != null)
            {
                if (food.isCuttable && target.isBoard)
                    target.ReceiveFood(food);
                else if (!food.isCuttable && !target.isBoard)
                    target.ReceiveFood(food);
            }
        }
    }


}
