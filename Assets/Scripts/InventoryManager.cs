using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bag, shop, chest;

    public enum OnAndOff
    {
        bagAndShop,
        bagAndChest
    }

    public OnAndOff inventoryState;
    void Start()
    {
       //bag = GameObject.FindGameObjectWithTag("backpack");
        //shop = GameObject.FindGameObjectWithTag("shop");
        //chest = GameObject.FindGameObjectWithTag("chest");
     
    }

    // Update is called once per frame
    void Update()
    {
     switch(inventoryState)
        {
            case OnAndOff.bagAndShop:
                bag.SetActive(true);
                shop.SetActive(true);
                chest.SetActive(false);
                break;
            case OnAndOff.bagAndChest:
                bag.SetActive(true);
                shop.SetActive(false);
                chest.SetActive(true);
                break;
        }
        
    }
    public void BagAndChets()
    {
        inventoryState = OnAndOff.bagAndShop;

    }
    public void BagAndShop()
    {
        inventoryState = OnAndOff.bagAndChest;
    }
   
   
}
