using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class TextFileReader : MonoBehaviour
{
    public static string ContentOfTxtFile(string path)
    {
        //テキストファイルが存在すれば読み取る
        if (File.Exists(path)) { return ReadText(path); }
        //ないならnull
        Debug.LogError("file not found");
        return null;
    }

    private static string ReadText(string path)
    {
        string content = "";
        using (var file = new StreamReader(path, Encoding.UTF8))
        {
            content = file.ReadToEnd();
            Debug.Log("completed");
        }
        return content;
    }
}
