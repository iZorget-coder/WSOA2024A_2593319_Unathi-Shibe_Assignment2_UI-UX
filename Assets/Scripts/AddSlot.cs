using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject slotPrefab;
    public Transform chestParent;
    private int slotCount;
    private Money mulla;
    void Start()
    {
        mulla = GameObject.FindGameObjectWithTag("Management").GetComponent<Money>();  
        slotCount = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddInventorySlotBag()
    {
        
        if(slotCount <= 5)
        {
            slotCount++;
            GameObject newSlot = Instantiate(slotPrefab, chestParent);
            slotPrefab.tag = "backpack inventory slot";
            newSlot.transform.SetParent(chestParent);
            transform.SetAsLastSibling();
            mulla.Buying(2);


        }
        


    }
    public void AddInventorySlotChest()
    {

        if (slotCount <= 5)
        {
            slotCount++;
            GameObject newSlot = Instantiate(slotPrefab, chestParent);
            slotPrefab.tag = "chest inventory slot";
            newSlot.transform.SetParent(chestParent);
            transform.SetAsLastSibling();
            mulla.Buying(2);

        }



    }
}
