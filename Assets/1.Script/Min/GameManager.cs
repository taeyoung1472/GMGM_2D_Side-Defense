using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager1234 : MonoBehaviour
{
    /*private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";
    
    [SerializeField]
    private User user = new User();
    public User CurrentUser
    {
        get
        {
            return user;
        }
    }



    void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Save"; // persistentDataPath
        if (Directory.Exists(SAVE_PATH) == false)
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        //InvokeRepeating("SaveToJson", 1f, 3f);
        LoadFromJson();
    }

    private void LoadFromJson()
    {
        string json = "";
        if (File.Exists(SAVE_PATH + SAVE_FILENAME) == true)
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
    }

    public void SaveToJson()
    {
        SAVE_PATH = Application.dataPath + "/Save"; // persistentDataPath  dataPath
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }
    */
}




