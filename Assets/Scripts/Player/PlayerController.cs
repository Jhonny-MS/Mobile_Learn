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

    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;

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
            if (!invencible) EndGame();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheckEndLine)
        {
            if (!invencible) EndGame();
        }
    }
    private void EndGame()
    {
        _canRun = false;
        uiEndGame.SetActive(true);
    }
    public void StartGame()
    {
        _canRun = true;

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
    #endregion
}
