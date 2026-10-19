using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    //List of Items
    [SerializeField] private List<GameObject> _lootItem = new List<GameObject>();

    //Random range of items spawning from chest
    [SerializeField] [Range(1, 19)] private int _minNumber = 1;
    [SerializeField] [Range(2, 20)] private int _maxNumber = 5;

    //Reference to a spawn point in chest
    [SerializeField] private Transform _spawnPoint;

    //Check if chest has been interacted with
    private bool _isCollected = false;
    //don't spawn loot if interacted with once, is public to be able to set from Chest
    public bool _isSpawned = false;
    
    private void Update()
    {
        if(_isSpawned && !_isCollected)//spawned, but not collected yet
        {
            _isSpawned = false;
            Loot();
        }
    }

    //instantiate the loot
    private void Loot()
    {
        Debug.Log("Spawn loot!");
        int number = Random.Range(_minNumber, _maxNumber);
        StartCoroutine(CreateLoot(number));
    }

    //use a coroutine to have items spawn one after another
    IEnumerator CreateLoot(int number)
    {
        yield return new WaitForSeconds(1f);

        for(int i = 0; i < number; i++)
        {
            GameObject loot = Instantiate(_lootItem[Random.Range(0, _lootItem.Count)], _spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
