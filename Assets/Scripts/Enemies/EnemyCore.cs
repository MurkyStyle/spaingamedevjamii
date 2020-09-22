using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCore : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private Transform _player;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _detectionRange;
    [SerializeField] private Transform _sensorAbyss;
    [SerializeField] private Transform _sensorWalk;

    private bool _awaken;
    
    void Start()
    {
        _awaken = false;
    }

    public void Awaken()
    {
        _awaken = true;
        // Hay que añadir el delay
    }
    public void Doze()
    {
        _awaken = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(IsPlayerClose());

        if (_awaken)
        {
           
        }
    }




    IEnumerator IsPlayerClose()
    {
        yield return new WaitForSeconds(0.5f);

        if (Vector2.Distance(_player.position, transform.position) < _detectionRange)
        {
            Awaken();
        }
        else
        {
            Doze();
        }
    }
}
