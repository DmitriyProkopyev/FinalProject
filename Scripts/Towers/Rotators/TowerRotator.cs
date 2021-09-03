using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerRotator : MonoBehaviour
{
    [SerializeField] private Transform _turret;

    private TowerShootZone _shootZone;
    private Enemy _currentEnemy;

    private int _rotationDelay = 3;
    private float _rotationTime;
    private float _elapsedTime;

    private bool _isLookingAtEnemy = false;
    private bool _hasShootZone;

    public void Initialize(float rotationTime)
    {
        _rotationTime = rotationTime;
        _currentEnemy = null;
        StartCoroutine(ChooseRandomRotation(_rotationDelay));
    }

    private void OnEnable()
    {
        _hasShootZone = TryGetComponent(out _shootZone);
        
        if (_hasShootZone)
            _shootZone.LastEnemyChanged += OnEnemyChanged;
    }

    private void OnDisable()
    {
        if (_hasShootZone)
            _shootZone.LastEnemyChanged -= OnEnemyChanged;
    }

    private void Update()
    {
        if (_currentEnemy != null)
        {
            if (_isLookingAtEnemy)
                _turret.LookAt(_currentEnemy.ShootPoint);
            else
            {
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime >= _rotationTime)
                {
                    _elapsedTime = 0;
                    _isLookingAtEnemy = true;
                }
            }
        }
    }

    private IEnumerator ChooseRandomRotation(float delay)
    {
        var waitForSeconds = new WaitForSeconds(delay);

        while (true)
        {
            if (_currentEnemy == null)
            {
                var rotate = new Vector3(_turret.rotation.x, Random.Range(0, 180), _turret.rotation.z);
                _turret.DOLocalRotate(rotate, _rotationTime, RotateMode.Fast);
            }

            yield return waitForSeconds;
        }
    }

    private void OnEnemyChanged(Enemy enemy)
    {
        _currentEnemy = enemy;
        _isLookingAtEnemy = false;
        
        if (enemy != null)
            _turret.DOLookAt(enemy.ShootPoint, _rotationTime);
    }
}
