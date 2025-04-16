using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> carPrefab;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float minSpawnInterval = 1.0f;
    [SerializeField] private float maxSpawnInterval = 3.0f;
    [SerializeField] private int maxCars = 3;

    [SerializeField] private float minSpeed = 5.0f;
    [SerializeField] private float maxSpeed = 10.0f;

    [SerializeField] private float despawnDistancex = -15.0f;
    [SerializeField] private float maxHeighty = 1.5f;
    [SerializeField] private float despawnHeighty = 1.5f;
    [SerializeField] private float maxSpawnTime = 8.0f;

    private Dictionary<GameObject, float> spawnedCars = new Dictionary<GameObject, float>();
    void Start()
    {
        if(spawnPoints == null ||  spawnPoints.Count == 0)
        {
            Debug.LogError("Missing Spawnpoints!");
            enabled = false;
            return;
        }

        StartCoroutine(spawnCars());
    }

    // Update is called once per frame
    IEnumerator spawnCars()
    {
        while (true)
        {
            if (spawnedCars.Count < maxCars)
            {
                int randomIndex = Random.Range(0, spawnPoints.Count);
                Transform spawnpoint = spawnPoints[randomIndex];

                int randomPrefabIndex = Random.Range(0, carPrefab.Count);
                GameObject selectedCarPrefab = carPrefab[randomPrefabIndex];

                GameObject newCar = Instantiate(selectedCarPrefab, spawnpoint.position, spawnpoint.rotation);
                spawnedCars.Add(newCar, Time.time);

                CarMovement carMovement = newCar.GetComponent<CarMovement>();

                if (carMovement != null)
                {
                    carMovement.SetMoveSpeed(Random.Range(minSpeed, maxSpeed));
                }
                else
                {
                    Debug.LogWarning("Car Prefab is missing movement.");
                }
            }

            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        }
    }

    public void DestroyCar(GameObject car)
    {
        if (spawnedCars.ContainsKey(car))
        {
            spawnedCars.Remove(car);
            Destroy(car);
        }
    }

    void Update()
    {
        List <GameObject> carsToDespawn =  new List <GameObject>();
        foreach (KeyValuePair<GameObject, float> pair in spawnedCars)
        {
            GameObject car = pair.Key;
            float spawnTime = pair.Value;
            CarMovement carMovement = car.GetComponent<CarMovement>();

            if (despawnDistancex < 0)
            {
                if (car.transform.position.x < despawnDistancex || Time.time > spawnTime + maxSpawnTime)
                {
                    carsToDespawn.Add(car);
                }
            }
            else
            {
                if (car.transform.position.x > despawnDistancex || Time.time > spawnTime + maxSpawnTime)
                {
                    carsToDespawn.Add(car);
                }
            }

            if (gameObject.tag == "WhaleSpawner")
            {
                if (car.transform.position.y > maxHeighty)
                {
                    carMovement.SetMoveDirection(Vector3.down); // Reverse direction
                    //carsToDespawn.Add(car);
                }

                if (car.transform.position.y < despawnHeighty || Time.time > spawnTime + maxSpawnTime)
                {
                    carsToDespawn.Add(car);
                }

                //Debug.Log("Whale height is currently:" + car.transform.position.y);
            }

        }

        foreach (GameObject car in carsToDespawn)
        {
            DestroyCar(car);
        }
    }
}
