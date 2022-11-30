using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMarble : MonoBehaviour
{
    public GameObject marble;
    float _randX;
    Vector3 whereToSpawn;
    public float spawnRate = 0.1f;
    float nextSpawn = 0f;
    public int marbleScoreCount;


    private static SpawnMarble _instance;
    public static SpawnMarble Instance
    {
        get => _instance;
        private set
        {
            //check if instance of this class already exists and if so keep orignal existing instance
            if (_instance == null)
            {
                _instance = value;
            }
            else if (_instance != value)
            {
                Debug.Log($"{nameof(SpawnMarble)} instance already exists, destroy the duplicate!");
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        Instance = this; //sets the static class instance
    }

    private void Start()
    {

        
    }

    void Update()
    {
        SpwnMarble();
    }

   void SpwnMarble()
    {

        if (Time.time > nextSpawn)
        {
            
            nextSpawn = Time.time + spawnRate;
            _randX = Random.Range(-6f, 2f);
            whereToSpawn = new Vector3(_randX, 92f, 0f);
            Instantiate(marble, whereToSpawn, Quaternion.identity, transform);
        }

    }

    
}

