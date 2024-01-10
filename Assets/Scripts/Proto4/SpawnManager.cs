using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
       
    }

    // Update is called once per frame
    void Update()
    {
       
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp();
        }
    }
    void SpawnEnemyWave(int enemySpawn)
    {
        for (int i = 0; i < enemySpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab,GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-9, 9);
        float spawnZ = Random.Range(-10, 10);
        Vector3 pos = new Vector3(spawnX, 0, spawnZ);
        return pos;
    }
}
