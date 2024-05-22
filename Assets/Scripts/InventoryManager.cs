using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bag, shop, chest, budgetBlownUI;
    private Money imali;
    public GameObject[] extraSlots;
    public float timer = 35f;
    public enum OnAndOff
    {


        bagAndShop,
        bagAndChest
    }
  
    public OnAndOff inventoryState;
    void Start()
    {
        budgetBlownUI.SetActive(false);
        imali = GetComponent<Money>();
       //bag = GameObject.FindGameObjectWithTag("backpack");
        //shop = GameObject.FindGameObjectWithTag("shop");
        //chest = GameObject.FindGameObjectWithTag("chest");
     
    }

    // Update is called once per frame
    void Update()
    {

        if(imali.amount <= 0)
        {
            Time.timeScale = 0;
            budgetBlownUI.SetActive(true);
        }
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
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {

                timer = 0f;
            }
        }

        if (timer == 0)
        {
            for (int i = 0; i < extraSlots.Length; i++)
            {
                extraSlots[i].gameObject.SetActive(true);
            }
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

    public void RestartGame()
    {
        Time.timeScale = 1; // Ensure the game is unpaused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        budgetBlownUI.SetActive(false);
    }
   
   public void QuitGame()
    {
        Application.Quit();
    }
}
