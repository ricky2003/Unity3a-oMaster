using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;
    private float Previustime;
    private float logInterval = 1;
    private float previusSaveTime;
    private float logSaveInterval;
    private Positions playerPos;
    private Positions enemiesPos;
    // Start is called before the first frame update
    void Start()
    {
        Previustime = Time.realtimeSinceStartup;//numero de segundo desde que se arranca nuestro juego
        previusSaveTime = Previustime;
        enemiesPos = new Positions();
        playerPos = new Positions();
        

    }

    // Update is called once per frame
    void Update()//guaradar los elemeto que sea 
    {
        float currenteTime = Time.realtimeSinceStartup;
        if (currenteTime> Previustime + logInterval)
        {
            Previustime+=logInterval;
            Debug.Log(Previustime);
            CaracterPosition cp = new CaracterPosition(player.name, currenteTime,player.transform.position);
            playerPos.positions.Add(cp);
            foreach(GameObject enemy in enemies)
            {
                CaracterPosition en = new CaracterPosition(player.name, currenteTime, player.transform.position);
                
                enemiesPos.positions.Add(en);
            }
            Debug.Log(cp);

        }
        if(currenteTime > previusSaveTime + logSaveInterval)
        {
            previusSaveTime+=logSaveInterval;
            SaveCSVToFile();
            SaveJSONToFile();
            SaveXMLToFile();
        }
    }
    private void SaveCSVToFile()
    {
        string data = "name ; TimeStamp; x; y; z \n";//como lo tendria en el interior de nuestro fichero
        foreach (CaracterPosition cp in playerPos.positions)
        {
            data += cp.ToCSV() + "\n";

        }
        foreach (CaracterPosition en in enemiesPos.positions)
        {
            data += en.ToCSV() + "\n";

        }
        Debug.Log(data);
        fileManger.WriteToFile("positions.csv", data);
    }
    private void SaveJSONToFile()
    {
        //string data = "[";
        //formar el JSON de forma automatica

        /*foreach(CaracterPosition cp in playerPosition)
         {
             data += JsonUtility.ToJson(cp) + "\n";//te genera el json en esta caso
         }
         foreach (CaracterPosition cp in enemyPosition)
         {
             data += JsonUtility.ToJson(cp) + "\n";//te genera el json en esta caso
         }
         data += "]";*/

        //fileManger.WriteToFile("positions.json", data);
        fileManger.WriteToFile("positionsPlayer.json", JsonUtility.ToJson(playerPos));
        fileManger.WriteToFile("positionsEnemies.json", JsonUtility.ToJson(enemiesPos));
    }
    private void SaveXMLToFile()
    {
        XmlSerializer serialicer = new XmlSerializer(typeof(Positions));
        using (FileStream stream = new FileStream("PlayerPos.xml", FileMode.Create))
        {
            serialicer.Serialize(stream, playerPos);
        }
        using (FileStream stream = new FileStream("EnemyPos.xml", FileMode.Create))
        {
            serialicer.Serialize(stream, playerPos);
        }
    }
}
