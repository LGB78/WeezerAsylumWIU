using UnityEngine;

[CreateAssetMenu(fileName = "FoodItem", menuName = "Scriptable Objects/FoodItem")]
public class FoodItem : ScriptableObject
{
    //variable names should be self explanatory i think?
    public string foodName;
    public string foodDescription;
    public Sprite unplatedFoodSprite;
    public Sprite platedFoodSprite;

    //isedible is basically if u try to plate something raw
    //dont give ur customers salmonella
    public bool isEdible;

    //called when the food item is dragged onto the plate
    public bool Plate(GameObject item)
    {
        //if ur trying to plate raw food, kys
        if (isEdible == false)
        {
            return false;
        }

        //get the sprite renderer, then if sprenderer exists then change sprite
        //theoretically all food item's gameobject should have a sprite renderer but
        //the != null is just to handle if it somehow doesnt
        //like e.g. u forgor to add
        //lol
        var sprenderer = item.GetComponent<SpriteRenderer>();
        if (sprenderer != null)
        {
            sprenderer.sprite = platedFoodSprite;
            return true;
        }

        //return false by default bc sprite wasnt changed
        //returns true only when plating is successful i.e. sprite changed to plated
        return false;
    }
}
