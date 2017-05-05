using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
	public GameObject SpawnPoint1,SpawnPoint2,End;
    public GameObject[] Ennemies;
    public int maxEnnemiesOnMap,totalEnnemies,ennemiesPerSpawn;
    public static int castleLifePoint=10;
   
    private int ennemiesOnScreen;
    private int waves = 10;
    // Use this for initialization
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else if (instance !=this)
        {
            DestroyObject(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start ()
    {
        SpawnEnnemies(SpawnPoint1);
        waves++;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(waves%2==0)
        {
            SpawnEnnemies(SpawnPoint1);
            waves--;
        }
        else
        {
            SpawnEnnemies(SpawnPoint2);
            waves--;
        }
	}

    void SpawnEnnemies(GameObject Spawn)
    {
        if(ennemiesPerSpawn>0 && ennemiesOnScreen<totalEnnemies)
        {
            for (int i = 0; i < ennemiesPerSpawn; i++)
            {
                if (ennemiesOnScreen<maxEnnemiesOnMap)
                {
                    GameObject newEnnemies = Instantiate(Ennemies[0]) as GameObject;
                    newEnnemies.transform.position = Spawn.transform.position;
                    ennemiesOnScreen++;
                }
            }
        }
    }

}
