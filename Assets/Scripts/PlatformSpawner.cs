using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject PlatformPrefab;
    public float StartPlatformCount;
    public float SpawnBorderPositionX;
    public float PlatformDistance;
    public Vector3 FirstSpawnPointPlatform;    
    public GameObject BreakingPlatformPrefab;
    public float BreakingPlatformDistance;

    private Transform _transform;
    private float _lastBreakingPlatformSpawnPosition;
    
    internal Transform _lastPlatform;

    private void Start()
    { 
      
        Instantiate(PlatformPrefab, new Vector3(FirstSpawnPointPlatform.x, FirstSpawnPointPlatform.y, FirstSpawnPointPlatform.z), 
        Quaternion.identity);

        _transform = GetComponent<Transform>();
        for(int i = 0; i < StartPlatformCount; i++)
        {
            _lastPlatform=Instantiate(PlatformPrefab, new Vector3(Random.Range(-SpawnBorderPositionX, SpawnBorderPositionX),
            FirstSpawnPointPlatform.y + PlatformDistance*i, FirstSpawnPointPlatform.z ), Quaternion.identity).transform;
        }        
    }

     private void Update()
     {
        if(_transform.position.y>_lastPlatform.position.y)
        {
            _lastPlatform=Instantiate(PlatformPrefab,new Vector3(Random.Range(-SpawnBorderPositionX,SpawnBorderPositionX),
            _lastPlatform.position.y+PlatformDistance,_lastPlatform.position.z),Quaternion.identity).transform;

        }
        if(_transform.position.y>_lastBreakingPlatformSpawnPosition)
        {
            if((_transform.position.y - _lastBreakingPlatformSpawnPosition) > Random.Range(0,60))
            {
                Instantiate(BreakingPlatformPrefab,new Vector3(Random.Range(-SpawnBorderPositionX,SpawnBorderPositionX),
                 _transform.position.y+BreakingPlatformDistance,_transform.position.z),Quaternion.identity);
            }
            _lastBreakingPlatformSpawnPosition = _transform.position.y;
        }

        
       
        
        
     }
}
