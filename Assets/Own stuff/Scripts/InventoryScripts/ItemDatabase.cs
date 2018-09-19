using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    public List<Item> itemsList = new List<Item>();

	// Use this for initialization
	void Awake () {
        BuildDatabase();
	}

    public Item GetItem(int id)
    {
        return itemsList.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return itemsList.Find(item => item.title == itemName);
    }

    void BuildDatabase()
    {
        itemsList = new List<Item>()
        {
             new Item(0, "tmp_key", " Let's hope I can get this working.\n It should open a door.",
            new Dictionary<string, int>
            {
                {"Value", 0},

            } ),
        };
    }

}
