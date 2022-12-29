using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ebac.Core.Singleton;


public class PlayerController : Singleton<PlayerController>
{
    public float speed = 1f;
    [Header("LERP")]
    public Transform target;
    public float lerpSpeed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public GameObject EndGameScreen;
    //privates
    private Vector3 _pos;
    private bool _canRun;
    private float _currentspeed;
    public void Start()
    {
        _canRun = true;
        ResetSpeed();
    }
    void Update()
    {
        if (!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            _canRun = false;
            Invoke("EndGame", .5f);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(tagToCheckEndLine))
        {
            Invoke("EndGame", .5f);

        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);

    }
    #region POWER UPS
    public void PowerUpSpeedUp(float f)
    {
        _currentspeed = f;
    }
    public void ResetSpeed()
    {
        _currentspeed = speed;
    }
    #endregion
}
