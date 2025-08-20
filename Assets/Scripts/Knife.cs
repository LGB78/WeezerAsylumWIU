using UnityEngine;

public class Knife : MonoBehaviour
{
    private bool isClicked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isClicked = false;
    }

    private void OnMouseDown()
    {
        /*if (food == null || heldObj != null) return;

        // Spawn the held food sprite object
        heldObj = new GameObject("Held_" + food.foodName);

        var sr = heldObj.AddComponent<SpriteRenderer>();
        sr.sprite = food.unplatedFoodSprite;
        sr.sortingOrder = 69; // render above everything

        //lucas drag script
        draggable = heldObj.AddComponent<DraggableObject>();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
