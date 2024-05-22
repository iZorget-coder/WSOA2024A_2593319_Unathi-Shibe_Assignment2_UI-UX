using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour
{
    public Vector3 offsetValue;
    // Start is called before the first frame update
    public string[] message;
    public GameObject[] slots;
 
    public string messageText;
   
    void Start()
    {
      

        
    }
    private void OnMouseEnter()
    {
      
            Tooltip.Instance.ShowTip(messageText);
        Tooltip.Instance.offset = offsetValue;
    }
    private void OnMouseExit()
    {
        Tooltip.Instance.HideTip(string.Empty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void SlotAdd()
    {
        int slotAdd = 0;
        if (slotAdd < 4)
        {
            slotAdd++;
            slots[slotAdd].SetActive(true);
        }
       

    }
}
