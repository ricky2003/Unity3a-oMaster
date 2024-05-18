using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;
using System.Data;
using System.Xml.Serialization;
using System.IO;

public class DataManager : MonoBehaviour
{
    public Usuarios player;
    [SerializeField]
    private TMP_InputField userNameInputField;
    [SerializeField]
    private TMP_InputField passwordInputField;
    private float prevtime;
    private float preSavetime;
    private float logInterval =5;
    private float LogSaveInterval =5;

    private List<Usuarios> users;
    private Stream stream;

    void Start()
    {
        prevtime = Time.realtimeSinceStartup;
        preSavetime = prevtime;
        users = new List<Usuarios>();
    }
    void Update()
    {
        float currentTime = Time.realtimeSinceStartup;
        if(currentTime>prevtime + logInterval)
        {
            prevtime += logInterval;
            Usuarios u = new Usuarios(userNameInputField.text, passwordInputField.text);
            users.Add(u);
        }

        if(currentTime >preSavetime + LogSaveInterval)
        {
            preSavetime += LogSaveInterval;
            SaveJSONFile();
            SaveXMLFile();

        }
    }

    private void SaveJSONFile()
    {
        string data = "[";
        foreach (Usuarios u in users)
        {
            data += JsonUtility.ToJson(u) + "\n";
        }
        data += "]";
        FileManager.WriteFile("UsuariosJSON.json", data);
    }
    private void SaveXMLFile()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Usuarios));
        using (FileStream stream = new FileStream("UsuariosXML.xml", FileMode.Create))
        {
            serializer.Serialize(stream, users);
        }
    }
}
