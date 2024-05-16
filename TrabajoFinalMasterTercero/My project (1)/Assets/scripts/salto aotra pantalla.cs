using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
public class saltoaotrapantalla : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField userNameInputField;
    [SerializeField]
    private TMP_InputField passwordInputField;
    [SerializeField]
    private TextMeshProUGUI errorText;
    /// <summary>
    /// yamar cuanod esta logeado
    /// </summary>
    ///
    public string username;
     public string password;

    public void OnSubmitLoging()
    {
        
        username = userNameInputField.text;
        password = passwordInputField.text;

        Debug.Log("Username: " + username);
        Debug.Log("Password: " + password);
      
        string logingcheckMessage = checkLoginInfo(username,password);

        if (string.IsNullOrEmpty(logingcheckMessage))
        {
            Debug.Log("Loging");
        
            SceneManager.LoadScene(1);//este uno se refiere a que en el file en el bilding setings el numero de la escena a sociado a el main scene es el 1

        }
        else
        {
            Debug.LogError("error: " + logingcheckMessage);
            errorText.text ="ERROR: "+ logingcheckMessage;


        }
    }
    /// <summary>
    /// te dice si el user y el password esta en la base de datos
    /// </summary>
    /// <returns>te devolvera porque no has podido logearte </returns>
    private string checkLoginInfo(string username, string password)
    {
        string retirnString= "";


        if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
        {
            retirnString = "User and password are empty";
        }
        if (string.IsNullOrEmpty(username))
        {
            retirnString = "User is empty";
        }else if (string.IsNullOrEmpty(password))
        {
            retirnString = "Password is empty";
        }
        Debug.Log("fallo: " + retirnString);
        
        return retirnString;
    }

    public void Registarse()
    {
            Debug.Log("Registarndose");
            SceneManager.LoadScene(4);//este uno se refiere a que en el file en el bilding setings el numero de la escena a sociado a el registrador es el 4

    }
    public void IniciarSasion()
    {
        Debug.Log("ComenzarJuego");
        SceneManager.LoadScene(1);//este uno se refiere a que en el file en el bilding setings el numero de la escena a sociado a el registrador es el 4

    }

    

}
