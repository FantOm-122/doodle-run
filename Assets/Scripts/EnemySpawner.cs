using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlatformSpawner PlatformSpawner;
    public GameObject MonsterPrefab;
    public float EnemySpawnBorderPositionX;
    public int EnemySpawnDistance;
    public int ProbabilityNumber;
    public float OffsetSpawnPosition;
    public GameObject UfoPrefab;
    public int ProbabilityNumber2;
    public float UfoSpawnDistance;
    
    private Transform _transform;
    private float _lastSpawnEnemyPositionY;
    private float _lastSpawnUfoPositionY;
    // Start is called before the first frame update
    void Start()
    {
        _transform=GetComponent<Transform>();
        _lastSpawnEnemyPositionY=_transform.position.y;
        _lastSpawnUfoPositionY=_transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(_transform.position.y>_lastSpawnEnemyPositionY+EnemySpawnDistance)
        {
            int probability=Random.Range(0,11);
            if(ProbabilityNumber>probability)
            {
                Instantiate(MonsterPrefab,new Vector3(PlatformSpawner._lastPlatform.position.x,PlatformSpawner._lastPlatform.position.y+OffsetSpawnPosition,
                PlatformSpawner._lastPlatform.position.z),Quaternion.identity);
            }
          _lastSpawnEnemyPositionY=_transform.position.y;
        }

        if(_transform.position.y>_lastSpawnUfoPositionY+UfoSpawnDistance)
        {
            int probabity2 = Random.Range(0, 5);
            if(ProbabilityNumber2 > probabity2)
            {
                Instantiate(UfoPrefab, new Vector3(Random.Range(-EnemySpawnBorderPositionX, EnemySpawnBorderPositionX),
                _transform.position.y, _transform.position.z), Quaternion.identity);
            }
            _lastSpawnUfoPositionY = _transform.position.y;
        } 
    }

    
}
