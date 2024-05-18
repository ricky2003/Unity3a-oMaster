using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public static class FileManager
{
    public static bool WriteFile(string FileName,string Data)
    {
        string FullPath = Path.Combine(Application.persistentDataPath, FileName);

        try
        {
            File.WriteAllText(FullPath, Data);
            Debug.Log(" "+ FullPath);
            Debug.Log("Fichero guardado Correctamente");
            return true;
        }
        catch(Exception e)
        {
            Debug.Log("error al guanrdar el fuchero en : " + FileName + "con el error : " + e);
            return false;
        }
    }
}
