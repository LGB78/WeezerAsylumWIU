using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;






public class Customer : MonoBehaviour
{
    public Sprite[] body;
    public Sprite[] shirt;
    [SerializeField] SpriteRenderer bodyrenderer;
    [SerializeField] SpriteRenderer shirtrenderer;
    //by marrrvvvv :3333
    [SerializeField] FoodItem[] foods;
    [SerializeField] FoodItem rice;
    [SerializeField] foodorder order;
    [SerializeField] TMP_Text dialog;
    private int ordersize = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRandomCustomer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnRandomCustomer()
    {
        //randomise body and shirt sprites and set it to the current stuff
        bodyrenderer.sprite = body[UnityEngine.Random.Range(0, body.Length)];
        shirtrenderer.sprite = shirt[UnityEngine.Random.Range(0, shirt.Length)];
        //hi marv if youre reading this this part is where you spawn the customer requsts
        //hi lucars this is mars 
        for (int i = order.order.Count - 1; i >= 0; i--)
        {
            order.order.RemoveAt(i);//remove all items
        }

        for (int i =0; i<ordersize; i++) //for loop for randomize order
        {
            int foodid = UnityEngine.Random.Range(0, foods.Length); //choose random food
            if (i == 0)
            {//force rice for item 1
                order.order.Add(rice);
                continue; //next item immediately
            }
            if (i > 1)//if not first 2 items, chance to have nothing
            {
                if (UnityEngine.Random.Range(0, 2)==0)//50% nothing
                    continue;

            }
            order.order.Add(foods[foodid]);//add item to order
        }
        //dialog.text = i want order.order[0] and order.order [1]
        string ordertext = "I want " + order.order[0].foodName;
        for (int i = 1; i < order.order.Count; i++)
        {
            ordertext += " and " + order.order[i].foodName;
        }
        dialog.text = ordertext;
    }
}
