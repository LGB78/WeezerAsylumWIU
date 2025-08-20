using System;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;






public class Customer : MonoBehaviour
{
    public Sprite[] body;
    public Sprite[] shirt;
    [SerializeField] SpriteRenderer bodyrenderer;
    [SerializeField] SpriteRenderer shirtrenderer;
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
        //like you do the rng stuff here ok?
        //ik itll be hard and allat but gllll feel free to ask me for help - lucar

        //render text mesh pro thing where u like have the items be the name of the thing??????
        TMP_Text dialogue;

        dialogue = GetComponent<TMP_Text>();
        dialogue.text = "test";
        //like how my 2dgeng had the item be like ironshackle and shit
        //base dialogue: "I want..."
        //also once they pick nothing on any option, they stop all later stuff
        //(etc orders nothing on line 2, end there)
        //1-> 90% rice, 10% [random meat]
        //2->80% [random meat], 20% nothing
        //3-> 80% cucumber 20% nothing
        //4-> 50% extra [anything]
        //5 -> 25% extra [anything but rice]
    }
}
