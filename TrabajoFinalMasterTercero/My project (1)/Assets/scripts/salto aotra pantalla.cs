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

    public void OnSubmitLoging()
    {
        
        string username = userNameInputField.text;
        string password = passwordInputField.text;

        Debug.Log("Username: " + username);
        Debug.Log("Password: " + password);
        string _Log = "'Usuarios' WHERE 'UserName' LIKE '" + username +
                       "' AND 'Password' LIKE ' " + password+ " ' ";
        DBManager _DBManager = GameObject.Find("DBManager").GetComponent<DBManager>();
        SqliteDataReader Resultado = _DBManager.Select(_Log);
        string logingcheckMessage = checkLoginInfo(username,password);

        if (string.IsNullOrEmpty(logingcheckMessage) && Resultado.HasRows)
        {
            Debug.Log("Loging");
            Resultado.Close();
            SceneManager.LoadScene(1);//este uno se refiere a que en el file en el bilding setings el numero de la escena a sociado a el main scene es el 1

        }
        else
        {
            Debug.LogError("error: " + logingcheckMessage);
            errorText.text ="ERROR: "+ logingcheckMessage;
            Resultado.Close();

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

   
}
