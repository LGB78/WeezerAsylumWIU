using UnityEngine;

public class ServeFoodItem : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] Sprite havesprite;
    [SerializeField] Sprite nosprite;
    [SerializeField] FoodStock stock;
    TestFood testfood;

    void Start()
    {
        testfood = GetComponent<TestFood>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stock.stock <= 0)
        {
            if (nosprite != null) 
                sprite.sprite = nosprite;
            else
                sprite.enabled = false;
            testfood.enabled = false;
        }
        else
        {
            sprite.enabled = true;
            sprite.sprite = havesprite;
            testfood.enabled = true;
        }
    }
}
