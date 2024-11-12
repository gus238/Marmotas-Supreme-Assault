// File name: ItemDragHandler

using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public SlotsInv currentSlot;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        if (eventData.pointerEnter == null || eventData.pointerEnter.GetComponent<SlotsInv>() == null)
        {
            // If the dragged item is not dropped on a slot, return to original slot
            rectTransform.anchoredPosition = currentSlot.GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public void ClearItem()
    {
        currentSlot.ClearSlot();
    }
}

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public bool isStackable;
}
