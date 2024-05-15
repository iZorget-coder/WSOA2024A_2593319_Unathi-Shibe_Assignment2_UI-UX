using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour, IDropHandler
{
    public TextMeshProUGUI stackCount;
  
    void Start()
    {
         
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragableObject drag = dropped.GetComponent<DragableObject>();
        drag.parent = transform;
    }

   void Update()
    {
        int childCount = transform.childCount;
       // Debug.Log("Number of children: " + childCount);
    }

   
    
}
