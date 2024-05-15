using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Linq;
using System.Collections.Generic;
// haven't finished this script but i shall return on resubmission. duty calls hahaha. ps: so nervous for saturday's presentation. see you at the game jam
public class DragableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public RectTransform rectTransform, initial;
    public Image childImage;
    [HideInInspector] public Transform parent;
    public Camera mainCamera;
    public Image image;
    public bool isDragging, isBuying, canDropItem = false;
    private GameObject initialParent, newParent;
    private Money cash;
    private Tip cashMessage;
    private Transform initialPosition;
    private float lastClickTime = 0f;
    private float doubleClickTimeThreshold = 0.3f;
    public List<GameObject> targetObjects;


    void Start()
    {
        
       cashMessage = GetComponent<Tip>();
        childImage = GetComponent<Image>();
        cash = GameObject.FindGameObjectWithTag("Management").GetComponent<Money>();
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
        }
        if(initialParent != null && newParent != null)
        {
            if(isBuying)
            {
                cash.Buying(int.Parse(new string(cashMessage.message.Where(char.IsDigit).ToArray())));
                isBuying = false;
            }

        }
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialParent = transform.parent.gameObject;
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
    
        transform.position = worldPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
        transform.SetParent(parent);
        image.raycastTarget = true;
        newParent = transform.parent.gameObject;
        Debug.Log(newParent.tag);
        if (initialParent.tag == "shop inventory slot" && newParent.tag == "backpack inventory slot")
        {
            isBuying = true;
        }
    }
    void CheckChildCounts()
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj.transform.childCount == 0)
            {
                Debug.Log(obj.name + " has no children.");
             canDropItem = true;
             
               
            }
            else
            {
                Debug.Log(obj.name + " has children.");
                canDropItem = false;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        if (Time.time - lastClickTime < doubleClickTimeThreshold)
        {
            if (canDropItem)
            {
                CheckChildCounts();

            }
        }
        lastClickTime = Time.time;

    }  
}
