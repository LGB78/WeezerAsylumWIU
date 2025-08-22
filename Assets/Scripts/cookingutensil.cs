using UnityEngine;

public class cookingutensil : MonoBehaviour
{
    //this shows the target raw and cooked food like raw duck ->braised duck
    [SerializeField] FoodItem targetrawfood;
    [SerializeField] FoodStock rawfoodstock;
    [SerializeField] FoodStock targetfoodstock;

    [SerializeField] Sprite nocook;
    [SerializeField] Sprite cooking;

    [SerializeField] GameObject particles;
    [SerializeField] GameObject alert;

    SpriteRenderer sprrenderer;
    
    //cooking time for the ingredients
    float cooktime;
    [SerializeField] float maxcooktime;
    [SerializeField] float burntime;

    bool iscooking;

    private Bounds bounds;

    public int cookamt;

    public StockUIManager stockUIManager;

    private void Start()
    {
        cooktime = 0;
        iscooking = false;
        sprrenderer = GetComponent<SpriteRenderer>();
        sprrenderer.sprite = nocook;
        particles.SetActive(false);
        alert.SetActive(false);
        bounds = GetComponent<BoxCollider2D>().bounds;
    }

    public void cook (FoodItem food)
    {
        //if food isnt the valid raw food return to ignore it
        if (food != targetrawfood || iscooking || rawfoodstock.stock - cookamt < 0)
        { 
            return;
        }
        rawfoodstock.stock -= cookamt;
        cooktime = maxcooktime;
        sprrenderer.sprite = cooking;

        particles .SetActive(true);
        iscooking = true;
        stockUIManager.updateUI();
    }
    private void Update()
    {
        if (cooktime > -burntime && iscooking)
        {
            cooktime -= Time.deltaTime;
        }
        if (cooktime <= 0 && iscooking)
        {
            alert.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (bounds.Contains(point))
                {
                    claimfood();
                }
            }
        }
        if (cooktime < -burntime && iscooking)
        {
            iscooking = false;
            alert.SetActive(false);
            particles.SetActive(false);
            sprrenderer.sprite = nocook;
        }
    }
    public void claimfood()
    {
        iscooking = false;
        alert.SetActive(false);
        particles.SetActive(false);
        sprrenderer.sprite = nocook;
        targetfoodstock.stock += cookamt;
        stockUIManager.updateUI();
    }
}
