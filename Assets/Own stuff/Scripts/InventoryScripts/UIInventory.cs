using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uIItemsList = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;

    private void Awake()
    {
        for(int i =0; i<12; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uIItemsList.Add(instance.GetComponentInChildren<UIItem>());
        }
    }

    public void UpdateSlot(int slot, Item item)
    {
        uIItemsList[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uIItemsList.FindIndex(i=> i.item == null), item);   
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uIItemsList.FindIndex(i => i.item == item), null);
    }
}
