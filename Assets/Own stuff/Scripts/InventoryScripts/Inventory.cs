using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> characterItemsList = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;

    private void Start()
    {
        
    }

    private void Update()
    {
        //Togglettaa simppelisti inventaario ikkunaa päälle ja pois.
        if (Input.GetKeyDown(KeyCode.I))
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
    }

    //lisää tavara inventaario listaan id:n mukaan
    public void GiveItem(int id)
    {
        Item itemToAddList = itemDatabase.GetItem(id);
        characterItemsList.Add(itemToAddList);
        //inventoryUI.AddNewItem(itemtoAdd);
    }
    //lisää tavara inventaario listaan nimen mukaan
    public void GiveItem(string itemName)
    {
        Item itemtoAddList = itemDatabase.GetItem(itemName);
        characterItemsList.Add(itemtoAddList);
        //inventoryUI.AddNewItem(itemtoAddList);
        Debug.Log("Added item: " + itemtoAddList.title);
    }

    //Katso löytyykö tavaraa listasta
    public Item CheckForItemInList(int id)
    {
        //käydään lista läpi. Tuo oli se joku ihmeen lamd-ba merkintä. Älä TPL naura.
        return characterItemsList.Find(item => item.id == id);
    }

    public void RemoveItemFromList(int id)
    {
        Item itemToRemove = CheckForItemInList(id);
        if(itemToRemove != null)
        {
            characterItemsList.Remove(itemToRemove);
            //inventoryUI.RemoveItem(itemToRemove);
        }
    }

}
