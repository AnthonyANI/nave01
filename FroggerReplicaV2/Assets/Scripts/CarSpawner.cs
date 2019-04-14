using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public float spawnDelay = .3f;
    public GameObject car;
    public Transform[] spawnPoints;

    private float carScale = 1f;
    private float nextTimeToSpawn = 0f;

    void Start()
    {
        ResizeCar();
        UpdateCarSpawnDelay();
    }

    void Update()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            SpawnCar();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void SpawnCar()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }

    void ResizeCar()
    {
        carScale = (float)GameDataManager.carSize * .5f;
        car.transform.localScale = new Vector3(carScale, carScale, 1f);
    }

    void UpdateCarSpawnDelay()
    {
        spawnDelay = .15f * (4 - GameDataManager.initialCarSpawnSpeed);
    }

}
