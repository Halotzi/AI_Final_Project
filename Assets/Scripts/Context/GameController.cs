using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject foodParticlePrefab; // Reference to the food particle prefab
    public Vector3 spawnBoundsMin; // Minimum bounds for spawning
    public Vector3 spawnBoundsMax; // Maximum bounds for spawning

    private GameObject currentFoodParticle;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnBoundsMin.x, spawnBoundsMax.x),
            Random.Range(spawnBoundsMin.y, spawnBoundsMax.y),
            Random.Range(spawnBoundsMin.z, spawnBoundsMax.z)
        );

        currentFoodParticle = Instantiate(foodParticlePrefab, randomPosition, Quaternion.identity);
        currentFoodParticle.GetComponent<FoodParticle>().Setup(this);
    }

    public void Reset()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnBoundsMin.x, spawnBoundsMax.x),
            Random.Range(spawnBoundsMin.y, spawnBoundsMax.y),
            Random.Range(spawnBoundsMin.z, spawnBoundsMax.z)
        );

        currentFoodParticle.transform.position = randomPosition;
    }
}
