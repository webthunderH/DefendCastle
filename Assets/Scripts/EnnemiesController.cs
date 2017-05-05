using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesController : MonoBehaviour {
    
    public Transform exitPoint;
    public float navigationUpdate;

    private GameObject[] checkPoints;
    private int wave;
    private Transform ennemy;
    private float navigationTime;

	// Use this for initialization
	void Start () {
        ennemy = GetComponent<Transform>();
        checkPoints = GameObject.FindGameObjectsWithTag("Checkpoint");

	}
	
	// Update is called once per frame
	void Update () 
    {
       
        
	}
    GameObject CheckNextPoint()
    {
        GameObject nextPoint=null;
        float distance = Mathf.Infinity;

        foreach (GameObject a in checkPoints)
        { 
            if (a.transform.position != ennemy.position)
            {
                Vector3 difference = a.transform.position - ennemy.position;
                float curDistance = difference.sqrMagnitude;
                if (curDistance < distance)
                {
                    nextPoint = a;
                    distance = curDistance;
                }
            }
        }
        return nextPoint;
    }
    void ennemyWayToGo()
    {
		GameObject nextPoint = CheckNextPoint();
		if (nextPoint != null)
		{
			navigationTime += Time.deltaTime;
			if (navigationTime > navigationUpdate)
			{
                if(nextPoint.name != "End")
                {
                    ennemy.position = Vector2.MoveTowards(ennemy.position, nextPoint.transform.position, Time.deltaTime);
                    //TODO mouvement to the checkpoint
                   
                }
                else
                {
                    //TODO before destroy move to;
                    GameManager.castleLifePoint--;
                    Destroy(this);
                }

			}
		}
		else
		{

		}
    }
}
