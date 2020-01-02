using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Board : MonoBehaviour
{
    GameObject boardPanel;
    GameObject boardSlotPanel;
    ItemDatabase database;
    public GameObject boardSlot;
    public GameObject boardItem;

    int slotAmount;
    public List<Item> characters = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();

        slotAmount = 15;
        boardPanel = GameObject.Find("Board Panel");
        boardSlotPanel = boardPanel.transform.Find("Slot Panel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            characters.Add(new Item());
            slots.Add(Instantiate(boardSlot));
            slots[i].transform.SetParent(boardSlotPanel.transform, false);
        }
        AddItem(1002); AddItem(1002); AddItem(1002); AddItem(1002); AddItem(1002); AddItem(1002); AddItem(1002); AddItem(1002); AddItem(1002); AddItem(1002); AddItem(1002); AddItem(1002); AddItem(1002);
    }

    public void AddItem(int id)
    {
        Item itemToAdd = database.GetItemByID(id);
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].Id == -1) //blank spot
            {
                characters[i] = itemToAdd;
                GameObject characterObj = Instantiate(boardItem);
                characterObj.transform.SetParent(slots[i].transform);
                characterObj.transform.position = Vector2.zero;
                characterObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Items/" + itemToAdd.HelpImage2);
                characterObj.name = itemToAdd.HelpImage2;
                break;
            }
        }
    }
}