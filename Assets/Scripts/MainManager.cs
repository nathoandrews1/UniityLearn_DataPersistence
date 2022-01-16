using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Color TeamColor;
    public static MainManager instance;
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    public void SaveColor()
    {
        SaveData save = new SaveData();
        save.inColor = TeamColor;

        string json = JsonUtility.ToJson(save);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/saveFile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData save = JsonUtility.FromJson<SaveData>(json);
            TeamColor = save.inColor;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public Color inColor;
    }
}
