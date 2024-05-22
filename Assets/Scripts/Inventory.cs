using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour, IDropHandler
{
    public string dominantTag;
    public string firstWordOfFirstChildName = "";
    private bool canDrop;
    private DragableObject dragObject;


  
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragableObject drag = dropped.GetComponent<DragableObject>();
        drag.parent = transform;
      


    }


    

   

}
