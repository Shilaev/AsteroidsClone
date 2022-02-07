using System.Collections.Generic;
using ObjectPool;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private List<Pool_SO> _pools = new List<Pool_SO>();

    private Pool _bulletsPool = new Pool();
    // private Pool _asteroidsPool = new Pool();

    private void Start()
    { 
        // _bulletsPool.Initialize(MyPool._tag, _size, _isAutoExpand, _poolElement);
        // _asteroidsPool.Initialize();
    }

    private void Update()
    {
        // if (Mouse.current.leftButton.wasReleasedThisFrame)
        // {
        //     Spawn();
        // }
        //
        // if (Mouse.current.rightButton.wasReleasedThisFrame)
        // {
        //     //
        // }
    }

    public void Spawn()
    {
        // GameObject spawnObject = myPool.GetFreeElement().gameObject;
        //
        // if (spawnObject != null)
        // {
        //     spawnObject.SetActive(true);
        //
        //     var rand = Random.Range(-2, 2);
        //     var rand2 = Random.Range(-2, 2);
        //     spawnObject.transform.position = new Vector3(rand, rand2);
        //
        //     var randC1 = Random.ColorHSV();
        //     spawnObject.GetComponent<SpriteRenderer>().color = randC1;
        // }
    }
}