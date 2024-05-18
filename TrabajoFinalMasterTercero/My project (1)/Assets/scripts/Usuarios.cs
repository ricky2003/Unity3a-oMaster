using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Usuarios
{
    [SerializeField]
    private string Username;
    [SerializeField]
    private string Pasword;
    
    public Usuarios(string name, string pasword)
    {
        this.Username = name;
        this.Pasword = pasword;
    }

    public string ToCSV()
    {
        return $"{Username};{Pasword}";
    }

    public override string ToString()
    {
        return $"{Username};{Pasword}";
    }
}
