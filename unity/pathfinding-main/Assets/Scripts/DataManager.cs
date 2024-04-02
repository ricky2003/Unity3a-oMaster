using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;
    private float Previustime;
    private float logInterval = 1;
    private float previusSaveTime;
    private float logSaveInterval;
    private List<CaracterPosition> playerPosition;
    private List<CaracterPosition> enemyPosition;
    // Start is called before the first frame update
    void Start()
    {
        Previustime = Time.realtimeSinceStartup;//numero de segundo desde que se arranca nuestro juego
        previusSaveTime = Previustime;
        playerPosition = new List<CaracterPosition>();
        enemyPosition = new List<CaracterPosition>();
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
            playerPosition.Add(cp);
            foreach(GameObject enemy in enemies)
            {
                CaracterPosition en = new CaracterPosition(player.name, currenteTime, player.transform.position);
                enemyPosition.Add(en);
            }
            Debug.Log(cp);

        }
        if(currenteTime > previusSaveTime + logSaveInterval)
        {
            previusSaveTime+=logSaveInterval;
            SaveCSVToFile();
        }
    }
    private void SaveCSVToFile()
    {
        string data = "name ; TimeStamp; x; y; z\n";//como lo tendria en el interior de nuestro fichero
        foreach(CaracterPosition cp in playerPosition)
        {
            data += cp.ToCSV() + "\n";

        }
        foreach (CaracterPosition en in enemyPosition)
        {
            data += en.ToCSV() + "\n";

        }
        Debug.Log(data);
        fileManger.WriteToFile("positions.csv", data);
    }
}
