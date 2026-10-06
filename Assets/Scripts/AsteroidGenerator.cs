using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject smallAsteroidPrefab;
    public GameObject largeAsteroidPrefab;
    public int maxAsteroids = 5;
    public int asteroidCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < maxAsteroids; i++)
        {
            createAsteroids();
        }
    }

    void Update()
    {
        //Debug.Log("Asteroids: " + asteroidCount);
        if(asteroidCount < maxAsteroids)
        {
            createAsteroids();
        }
    }

    void createAsteroids()
    {
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-5f, 5f);

        Vector2 spawnPosition = new Vector2(x, y);

        GameObject asteroidPrefab;
        if(Random.Range(0, 2) == 0)
        {
            asteroidPrefab = smallAsteroidPrefab;
        }
        else
        {
            asteroidPrefab = largeAsteroidPrefab;
        }

        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        newAsteroid.GetComponent<Asteroid>().generator = this; // tells asteroid which generator it was created by
        asteroidCount++;
    }
}
