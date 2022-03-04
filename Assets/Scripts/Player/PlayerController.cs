using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Master.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public float lerpSpeed = 1f;
    public Transform target;
    public float speed = 2f;
    public GameObject uiEndGame;

    public bool invencible;

    [Header("Text")]
    public TextMeshPro uiTextPowerUp;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("Animation")]
    public AnimationManager animationManager;

    //privates
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 7f;

    private void Start()
    {
        ResetSpeed();        
    }
    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
            if (!invencible)
            {
                MoveBack(collision.transform);
                EndGame(AnimationManager.AnimationType.DEAD);
            } 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheckEndLine)
        {
            if (!invencible) EndGame();
        }
    }
    private void MoveBack(Transform t)
    {
        t.DOMoveZ(1f, .3f).SetRelative();
    }
    private void EndGame(AnimationManager.AnimationType animationType = AnimationManager.AnimationType.IDLE)
    {
        _canRun = false;
        uiEndGame.SetActive(true);
        animationManager.Play(animationType);

    }
    public void StartGame()
    {
        _canRun = true;
        animationManager.Play(AnimationManager.AnimationType.RUN, _currentSpeed / _baseSpeedToAnimation);

    }
    #region POWERUPS
    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }
    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        /* var p = transform.position;
         p.y = _startPosition.y + amount;   
         transform.position = p;
          */

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease); // .OnComplete(ResetHeight);
        Invoke(nameof(ResetHeight), duration);
    }
    public void ResetHeight()
	{
        /* var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p; */
        transform.DOMoveY(_startPosition.y, .1f);
    }
    public void ChangeCoinCollectorSize(float amount)
	{
        coinCollector.transform.localScale = Vector3.one * amount;
	}
    #endregion
}
