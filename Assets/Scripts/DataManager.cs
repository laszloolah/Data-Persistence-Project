using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
//using UnityEngine.InputSystem;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public TMP_InputField inputField;

    public string playerName = string.Empty;
    public string bestName = string.Empty;
    public int bestScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBest();
        // For test only
        //bestScore = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        inputField.onEndEdit.AddListener(ProcessNameInput);
    }

    [System.Serializable]
    class SaveData
    {
        public string bestName;
        public int bestScore;
    }

    public void SaveBest()
    {
        SaveData data = new SaveData();
        data.bestName = bestName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBest()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestName = data.bestName;
            bestScore = data.bestScore;
        }
    }

    public void ProcessNameInput(string text)
    {
        Debug.Log("1-USER entered " + text);
        //Debug.Log("2-USER entered " + inputField.text);
        if (text != string.Empty)
        {
            playerName = text;
            Debug.Log("Player Name = " + playerName);
        }
        else
        {
            Debug.Log("No Name Entered");
            // Use default value
            playerName = "None";
        }
    }
}
