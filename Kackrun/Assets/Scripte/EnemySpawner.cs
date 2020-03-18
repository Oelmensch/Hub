using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnTime = 2;
    public GameObject[] Enemys;
    public int Index = 1;

    private float _tempTime;
    private int _rand;
    public bool _spawn;
    private int _indexControll;

    void Start()
    {
        _tempTime = SpawnTime;
        _spawn = true;
        _indexControll = Index;
    }

    void Spawn(bool spawn)
    {
        _spawn = spawn;
    }

    void SpawnerIndex(int _index)
    {
        _indexControll = _index;
    }

    void Update()
    {
        if(_spawn && _indexControll == Index)
        {
            _tempTime += 1 * Time.deltaTime;

            if ( _tempTime >= SpawnTime)
            {
                _rand = Random.Range(0, Enemys.Length - 1);
                var obj = GameObject.Instantiate(Enemys[_rand], transform.position, Quaternion.identity) as GameObject;
                obj.SendMessage("EnemySpawner", Index);
                obj.SendMessage("SpawnerIndex", this.gameObject);
                _spawn = false;
                _indexControll = 0;
                _tempTime = 0;
            }
        }
    }
}
