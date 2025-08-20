using System;
using UnityEditor.Rendering;
using UnityEngine;




[Serializable]
public struct customersprite
{
    public Sprite body;
    public Sprite shirt;

}

public class Customer : MonoBehaviour
{
    customersprite[] sprites;
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
        bodyrenderer.sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)].body;
        shirtrenderer.sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)].shirt;
        //hi marv if youre reading this this part is where you spawn the customer requsts
        //like you do the rng stuff here ok?
        //ik itll be hard and allat but gllll feel free to ask me for help - lucar


    }
}
