
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Data;

public class saltoaotrapantalla : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField userNameInputField;
    [SerializeField]
    private TMP_InputField passwordInputField;
    [SerializeField]
    private TextMeshProUGUI errorText;
    private IDbConnection dbConnection;
    /// <summary>
    /// yamar cuanod esta logeado
    /// </summary>
    ///
   

    public void OnSubmitLoging()
    {

    Debug.Log("Username: " + userNameInputField.text);
        Debug.Log("Password: " + passwordInputField.text);
        DBManager dbmanager = new DBManager();
        dbmanager.init();
        string command = "INSERT INTO Usuarios(UserName,Password) VALUES";
        command += $"({userNameInputField.text} ,{ passwordInputField.text}),";
        command = command.Remove(command.Length - 1, 1);
        command += ";";
        Debug.Log(command);
        string logingcheckMessage = checkLoginInfo(userNameInputField.text, passwordInputField.text);//CONSULTA PARA VER SI EXISTE EL USUARIO Y COINCIDE LA CONTRASEL;A (INICIO DE SESION)
        dbmanager.close();
        

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
    private string checkLoginInfo(string usuario, string password)
    {
        string returnString= "";


        if (SerchForThePassword(password))
        {
            returnString = "el usuario y la contraseña son correctos";
        }
        else if (string.IsNullOrEmpty(usuario))
        {
            returnString = "User is empty";
        }else if (string.IsNullOrEmpty(password))
        {
            returnString = "Password is empty";
        }
        else if (string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(password))
        {
            returnString = "el usuario y la contraseña estan vacias";
        }
        Debug.Log(returnString);

        return returnString;
    }
    private bool SerchForThePassword(string password)//no hace falata el dbConnection porque esta inicializado como parametro
    {
        string contraseña="";
        IDbCommand dbcm = dbConnection.CreateCommand();
        dbcm.CommandText = $"SELECT '{contraseña}' FROM Usuarios WHERE UserName='{userNameInputField.text}';";
        if (contraseña== password)
        {
            return true; 
        }
        else
        {
            return false;
        }
        Debug.Log(password);
        
    }
    private void SerchByUser(string usuario)//te dice solo si existe el usuario pasado por parametro,
    {
        bool resultado = false;
        IDbCommand dbcm = dbConnection.CreateCommand();
        //dbcm.CommandText = $"SELECT UserName FROM Usuarios WHERE UserName='{usuario}';";
        dbcm.CommandText = $"SELECT EXISTS(SELECT Password from Usuarios WHERE Username ='{usuario}') as '{resultado}';";
        Debug.Log("el usuario pedido tiene contraseña asociada");
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
