using System;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Random = UnityEngine.Random;

public class SpawnParallel : MonoBehaviour
{
    public GameObject sheepPrefab;
    private Transform[] allSheep;
    
    const int numSheep = 15000;

    private MoveJob moveJob;
    private JobHandle moveHandle;
    private TransformAccessArray transforms;
    struct MoveJob : IJobParallelForTransform
    {
        public void Execute(int index, TransformAccess transform)
        {
            transform.position += 0.1f * (transform.rotation * new Vector3(0, 0, 1));
            if (transform.position.z > 50)
            {
                transform.position = new Vector3(transform.position.x,0,-50);
            }
        }
    }

    void Start()
    {
        allSheep = new Transform[numSheep];
        for (int i = 0; i < numSheep; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)); 
            GameObject sheep = Instantiate(sheepPrefab, pos, Quaternion.identity);
            allSheep[i] = sheep.transform;
        }
        transforms = new TransformAccessArray(allSheep);
    }

    private void Update()
    {
        moveJob = new MoveJob{};
        moveHandle = moveJob.Schedule(transforms);
    }

    private void LateUpdate()
    {
        moveHandle.Complete();
    }

    private void OnDestroy()
    {
        transforms.Dispose();
    }
}
