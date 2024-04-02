using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class fileManger 
{
    public static bool WriteToFile(string FileName, string Data)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, FileName);
        try
        {
            File.WriteAllText(fullPath, Data);
            Debug.Log("FicherGuaradado corectamente en: " + fullPath);
            return true;
        }catch(IOException ex)
        {
            Debug.Log("error al guardadr el fichero en : " + FileName+" con error: "+ex);
            return false;
        }
    }  
}
