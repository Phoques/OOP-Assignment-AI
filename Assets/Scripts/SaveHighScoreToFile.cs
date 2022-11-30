using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveHighScoreToFile : MonoBehaviour
{
    public void Save(HighScoreData data)
    {
        string jsonToWrite = JsonUtility.ToJson(data);
        string path = Application.dataPath + "highscores.txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(jsonToWrite);
        writer.Close();
    }
    
    public HighScoreData Load()
    {
        try
        {
            string path = Application.dataPath + "highscores.txt";
            StreamReader reader = new StreamReader(path);
            string file = reader.ReadToEnd();
            HighScoreData returnData = JsonUtility.FromJson<HighScoreData>(file);
            reader.Close();
            return returnData;
        }
        catch (FileNotFoundException ex)
        {
            return new HighScoreData();
        }

       
    }
}
