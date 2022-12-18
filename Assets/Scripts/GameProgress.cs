using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance;

    public string playerName;
    public int playerScore;

    public int tempScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;

        if (tempScore > playerScore)
        {
            playerScore = tempScore;
        }

        data.playerScore = playerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            playerScore = data.playerScore;
        }
    }
}
