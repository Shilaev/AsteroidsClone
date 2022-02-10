using ObjectPool;
using UnityEngine;

[AddComponentMenu("Controllers/AsteroidSpawner")]
public class AsteroidSpawner : MonoBehaviour
{
    public static void SpawnAsteroid(int amount, string type, Vector3 spawnPoint)
    {
        for (int i = 0; i < amount; i++)
        {
            var newAsteroid = Pool.GetElementFromPool(type);
            newAsteroid.gameObject.SetActive(true);
            newAsteroid.transform.position = spawnPoint;
            SetUpNewAsteroid(newAsteroid);
        }
    }

    private static void SetUpNewAsteroid(GameObject newAsteroid)
    {
        var randomForceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        var randomForceValue = Random.Range(50f, 200f);
        newAsteroid.GetComponent<Rigidbody2D>().AddForce(randomForceDirection * randomForceValue, ForceMode2D.Force);

        newAsteroid.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }
}