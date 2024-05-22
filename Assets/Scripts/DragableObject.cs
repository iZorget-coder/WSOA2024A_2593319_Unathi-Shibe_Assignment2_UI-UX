using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Linq;
using System.Collections.Generic;
// haven't finished this script but i shall return on resubmission. duty calls hahaha. ps: so nervous for saturday's presentation. see you at the game jam
public class DragableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform rectTransform, initial;
    public Image childImage;
    [HideInInspector] public Transform parent;
    public Camera mainCamera;
    public Image image;
    public bool isDragging, isBuying, isSelling, canDropItem = false;
    public GameObject initialParent, newParent;
    private Money cash;
    private Tip cashMessage;
    public GameObject[] Items;
   
   


    void Start()
    {
       
        isBuying = isSelling = false;
       cashMessage = GetComponent<Tip>();
        childImage = GetComponent<Image>();
        cash = GameObject.FindGameObjectWithTag("Management").GetComponent<Money>();
        cashMessage.messageText = cashMessage.message[0];
    }

    void Update()
    {
        if ((rectTransform.anchoredPosition.y != -40f) && (rectTransform.anchoredPosition.x == 40))
        {
            childImage.enabled = false;
          gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            childImage.enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if(initialParent != null && newParent != null)
        {
            if(isBuying)
            {
                cash.Buying(int.Parse(new string(cashMessage.message[0].Where(char.IsDigit).ToArray())));
                isBuying = false;
            }
            if (isSelling)
            {
                cash.Selling(int.Parse(new string(cashMessage.message[0].Where(char.IsDigit).ToArray())));
                isSelling = false;
            }
        }
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialParent = transform.parent.gameObject;
        cashMessage.messageText = cashMessage.message[0];
        parent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;

        Debug.Log(initialParent.tag);

 
      
    }
    
    public void OnDrag(PointerEventData eventData)
    {
      
        Vector3 worldPos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform.parent as RectTransform, eventData.position, mainCamera, out worldPos);
        isDragging = true;
        cashMessage.messageText = cashMessage.message[1];
        transform.position = worldPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
        transform.SetParent(parent);
        image.raycastTarget = true;
        newParent = transform.parent.gameObject;
        Debug.Log(newParent.tag);
        cashMessage.message[1] = cashMessage.message[1];
        if (initialParent.tag == "shop inventory slot" && newParent.tag == "backpack inventory slot")
        {
            isBuying = true;
        }
        if(initialParent.tag == "backpack inventory slot" && newParent.tag == "shop inventory slot")
        {
            isSelling = true;
            
        }
    }
 
}
