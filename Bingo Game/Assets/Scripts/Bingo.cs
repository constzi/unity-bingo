using UnityEngine;
using System.IO;
using LitJson;
using System.Collections.Generic;

public class Bingo : MonoBehaviour
{
    string jsonString;
    JsonData itemData;
    Question q = new Question(99999, "question 1", "question audio", 1, 1, new int[] { 0, 1 }, "h1", "h1m", "h2", "h2m", 0);

    void Start()
    {
        string path = Application.dataPath + "/StreamingAssets/Questions.json";
        jsonString = File.ReadAllText(path);
        itemData = JsonMapper.ToObject(jsonString);

        //1. read record
        //ebug.Log(itemData["Questions"][5]["question"]);
        //Debug.Log(GetItem("7020")["question"]);

        //2. insert data
        itemData = JsonMapper.ToJson(q);
        //Debug.Log(itemData);
        //File.WriteAllText(path, itemData.ToString()); -> overrides file pb
    }

    JsonData GetItem(string id)
    {
        for (int i = 0; i < itemData["Questions"].Count; i++)
        {
            if (itemData["Questions"][i]["id"].ToString() == id)
            {
                return itemData["Questions"][i];
            }
        }
        return null;
    }

    public class Question
    {
        public int id;
        public string question;
        public string questionAudio;
        public int level;
        public int seconds;
        public int[] correctAnswers;
        public string helpText1;
        public string helpImage1;
        public string helpText2;
        public string helpImage2;
        public int helpStyle;

    public Question(int id, string question, string questionAudio, int level, int seconds, int[] correctAnswers,
        string helpText1, string helpImage1, string helpText2, string helpImage2, int helpStyle)
        {
            this.id = id;
            this.question = question;
            this.questionAudio = questionAudio;
            this.level = level;
            this.seconds = seconds;
            this.correctAnswers = correctAnswers;
            this.helpText1 = helpImage1;
            this.helpImage1 = questionAudio;
            this.helpText2 = helpText2;
            this.helpImage2 = helpImage2;
            this.helpStyle = helpStyle;
        }
    }

}