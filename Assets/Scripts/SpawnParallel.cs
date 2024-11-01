using UnityEngine;

public class SpawnParallel : MonoBehaviour
{
    public GameObject sheepPrefab;
    private GameObject[] allSheep;
    
    const int numSheep = 15000;
    
    void Start()
    {
        allSheep = new GameObject[numSheep];
        for (int i = 0; i < numSheep; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)); 
            allSheep[i] = Instantiate(sheepPrefab, pos, Quaternion.identity);
        }
    }

    private void Update()
    {
        for (int i = 0; i < allSheep.Length; i++)
        {
            allSheep[i].transform.Translate(0,0,0.1f);
            if (allSheep[i].transform.position.z > 50)
                allSheep[i].transform.position = new Vector3(allSheep[i].transform.position.x, 0, -50);
        } 
    }
}
