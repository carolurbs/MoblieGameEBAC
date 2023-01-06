using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ebac.Core.Singleton;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    public float speed = 1f;
    [Header("LERP")]
    public Transform target;
    public float lerpSpeed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public bool invencible;
    public GameObject coinCollector; 
    //privates
    private Vector3 _pos;
    private bool _canRun;
    private float _currentSpeed;
    public Vector3 _startPosition;

    [Header("Animation Payer")]
    public string triggerRun = "Run";
    public string triggerDeath = "Death";
    public Animator animator;

    [Header("lEVEL")]
    public LevelManager levelManager;
    public void Start()
    {
        _startPosition = transform.position;
        _canRun = false;
        invencible = false;
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
           if (!invencible)
            {
                MoveBack();
                animator.SetTrigger(triggerDeath);
                _canRun = false;
                Invoke("EndGame", 3f);

            }
        }

    }
    private void MoveBack()
    {
        transform.DOMoveZ(-1f,.3f).SetRelative(); 
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(tagToCheckEndLine))
        {
            if (levelManager._index < 3)
            {
                levelManager.SpawnNextLevel();
                _startPosition=transform.position;
            }
            else if (levelManager._index >= 3)
            {
            Invoke("EndGame", .5f);

            }

        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);

    }
    public void PlayButton()
    {

    _canRun= true;
        animator.SetTrigger(triggerRun);


    }
    #region Power Ups
    public void PowerUpSpeedUp (float f)
    {
        _currentSpeed = f; 
        animator.speed= 2;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed; 

    }

    public void SetInvencible(bool  b = true)
    {
        invencible = b; 
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }
    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);

    }

    public void ChangeCoinCollectorSize(float amount )
    {
        coinCollector.transform.localScale= Vector3.one * amount;
    }
    #endregion
}
