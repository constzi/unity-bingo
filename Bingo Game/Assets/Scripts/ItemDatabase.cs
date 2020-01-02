using UnityEngine;
using LitJson;
using System.IO;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Questions.json"));
        BuildItemDatabase();
        //Debug.Log("test: " + GetItemByID(1001).Question);
    }

    public Item GetItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].Id == id)
                return database[i];
        }              
        return null;
    }

    void BuildItemDatabase()
    {
        for (int i = 0; i < itemData["Questions"].Count; i++)
        {
            database.Add(new Item((int)itemData["Questions"][i]["id"], itemData["Questions"][i]["question"].ToString(),
                itemData["Questions"][i]["helpImage2"].ToString()));
        }
    }
}

public class Item
{
    public int Id { get; set; }
    public string Question { get; set;}

    public string HelpImage2;

    public Item(int id, string question, string HelpImage2)
    {
        this.Id = id;
        this.Question = question;
        this.HelpImage2 = HelpImage2;
    }

    public Item()
    {
        this.Id = -1;
    }

}