using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoSingleton<GameManager>
{
    bool isPause;
    public PoolManager PoolManager { get { return poolManager; } set { poolManager = value; } }

    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";

    [SerializeField] private User user = new User();
    [SerializeField] private Transform player;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private PoolManager poolManager;
    public User CurrentUser { get { return user;} }
    void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Save"; // persistentDataPath
        if (Directory.Exists(SAVE_PATH) == false)
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        InvokeRepeating("SaveToJson", 1f, 3f);
        LoadFromJson();
    }
    public void Pause(bool isTrue)
    {
        pausePanel.SetActive(isTrue);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                Pause(isPause);
                isPause = true;
            }
            else
            {
                Pause(isPause);
                isPause = false;
            }
        }
    }
    #region Json 저장 함수
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
    #endregion
    #region 정적 함수
    public static Transform Player
    {
        get
        {
            if (Instance != null)
            {
                return Instance.player;
            }
            else
            {
                return null;
            }

        }
    }
    private static float timeScale = 1f;
    public static float TimeScale
    {
        get
        {
            if (Instance != null)
            {
                return timeScale;
            }
            else
            {
                return 0f;
            }
        }
        set
        {
            timeScale = Mathf.Clamp(value, 0, 1);
        }
    }
    #endregion
}