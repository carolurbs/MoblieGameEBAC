using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class LevelManager : Singleton<LevelManager>
{
    public Transform container;
    public List<GameObject> levels;
    public int _index;
    private GameObject _currentLevel; 
    public void Awake()
    {
        SpawnNextLevel();
    }
    public void SpawnNextLevel()
    {
        if (_currentLevel == null)
        {
            Destroy(_currentLevel);
            _index++;
            if(_index>= levels.Count)
            {
                ResetLevelIndex();
            }
        }
      _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero; 

    }
    private void ResetLevelIndex()
    {
        _index = 0;
    }
}
