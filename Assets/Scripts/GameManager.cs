using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    private GameObject _curentplayer;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer() 
    {
        _curentplayer = Instantiate(playerPrefab);
        _curentplayer.transform.position = startPoint.transform.position;
        _curentplayer.transform.DOScale(0, duration).SetEase(ease).From();
    }
}
