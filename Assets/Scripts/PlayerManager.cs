using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    
    public int playerScore;
    public int highestScore;
    

    public string currentPlayerName;
    public string newPlayerName;

    public TMP_InputField inputName;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadPlayerData();
        
    }

    private void Start()
    {
        inputName.text = currentPlayerName;
    }

    public void SetName()
    {
        newPlayerName = inputName.text;
    }

    public void ResetScore()
    {
        currentPlayerName = "";
        highestScore = 0;
        SavePlayerData();
        LoadPlayerData();
        inputName.text = currentPlayerName;
    }

    [System.Serializable]
    class SaveData
    {
        public string currentPlayerName;
        public int highestScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.currentPlayerName = currentPlayerName;
        data.highestScore = highestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentPlayerName = data.currentPlayerName;
            highestScore = data.highestScore;
        }
    }
}
