using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;
    public int _index;
    private GameObject _currentLevel; 
    public void Awake()
    {
        SpawnNextLevel();
        ColorManager.Instance.ChangeColor();

    }
    public void SpawnNextLevel()
    {
        if (_currentLevel == null)
        {
            Destroy(_currentLevel);
            RandomizeLevelIndex();         
        }
      _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero; 

    }
    private void RandomizeLevelIndex()
    {
        _index = Random.Range(0, levels.Count);
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SpawnNextLevel();
        }
    }
}
