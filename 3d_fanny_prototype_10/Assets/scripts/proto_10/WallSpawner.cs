using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level { DEFAULT, WALLS_TO_LEFT, WALLS_TO_RIGHT };

public class WallSpawner : MonoBehaviour {

    [SerializeField]
    Level level;
    [SerializeField]
    List<GameObject> lstWall;
    [SerializeField]
    int wallIndex;
    [SerializeField]
    float startYpos, yDistance;
    [SerializeField]
    float spawnSpeed;
    const float Z_POSITION = 15.3f;

    [SerializeField] ObjectPooler pooler;



    [SerializeField] int spawnCount;
    [SerializeField] WallsToLeftDesign wallsToLeft;
    float _recentSpawnPointX = 0;

    void Start () {
        wallsToLeft = new WallsToLeftDesign(startYpos, Z_POSITION);

        //InvokeRepeating("SpawnWalls", spawnSpeed, spawnSpeed);
        for(int i=0; i<200; i++)
        {
            SpawnWalls();
        }
	}
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            wallIndex = Random.Range(0,3);
        }
    }

    void SpawnWalls() {
        GameObject _obj = null;
        WallController _wall = null;
        Vector3 _spawnPoint = Vector3.zero;


        _obj = pooler.GetGameObject(false);

        switch (level)
        {
            case Level.WALLS_TO_LEFT:
                _spawnPoint = wallsToLeft.GetPosition(ref wallIndex);
                if (_spawnPoint == Vector3.zero)
                {
                    print("BOOM");
                    level = Level.DEFAULT;
                    wallIndex = 0;
                    SpawnWalls();
                    return;
                }

                break;
            default:
             
                if(spawnCount < 10)
                {
                    wallIndex = 0;
                }
                else if(spawnCount >= 10 && spawnCount < 20)
                {
                    wallIndex = Random.Range(0,2);
                }
                else if (spawnCount >= 20 && spawnCount < 30)
                {
                    wallIndex = 1;
                }
                else if (spawnCount >= 40 && spawnCount < 50)
                {
                    wallIndex = Random.Range(0, 3);
                }
                else if (spawnCount >= 60 && spawnCount < 70)
                {
                    wallIndex = Random.Range(1, 3);
                }
                else if (spawnCount >= 80 && spawnCount < 90)
                {
                    wallIndex = 2;
                }
                else
                {
                    wallIndex = Random.Range(0, 3);
                }
                break;
        }

        if (_obj != null)
        {
            _obj.SetActive(true);
        }
        else
        {
           
            pooler.PoolGameObject(_obj = Instantiate(lstWall[wallIndex], _spawnPoint, Quaternion.identity));
        }

        if(level == Level.DEFAULT)
        {
            _wall = _obj.GetComponent<WallController>();

            //prevent blocking here
            //.......
            /*
             * 
             * save recent wall
             * save recent spawnpoint
             * create new spawnpoint near recent spawnpoint with the distance of the opening space of the recent wall
             * 
             */
            float _minX = _recentSpawnPointX - _wall.GetXPositionDistance();
            float _maxX = _recentSpawnPointX + _wall.GetXPositionDistance();
            _minX = _minX < _wall.GetMinXPosition() ? _wall.GetMinXPosition() : _minX;
            _maxX = _maxX > _wall.GetMaxXPosition() ? _wall.GetMaxXPosition() : _maxX;
            _spawnPoint = new Vector3(Random.Range(_minX, _maxX), startYpos, Z_POSITION);
            _recentSpawnPointX = _spawnPoint.x;

        }
        //if (spawnCount < 20) _spawnPoint = new Vector3(0, startYpos, Z_POSITION);
        _obj.transform.position = _spawnPoint;
        spawnCount++;
        startYpos += yDistance;
    }
}
