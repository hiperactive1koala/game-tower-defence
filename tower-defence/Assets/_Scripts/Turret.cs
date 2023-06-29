using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _firePos;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _range = 15f;
    [SerializeField] private float _fireRate = 1f;
    

    private float _fireCountdown;
    
    private WaveSpawner _waveSpawner;
    private void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.4f);
        _waveSpawner = FindObjectOfType<WaveSpawner>();
    }

    private void UpdateTarget()
    {
        var enemyList = _waveSpawner.GetEnemyList();
        var shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (var enemy in enemyList)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy !=null && shortestDistance <= _range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }

    private void Update()
    {
        // ReSharper disable once RedundantJumpStatement
        if (_target == null) return;
        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }

        _fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        var bullet = Instantiate(_bullet, _firePos.position, _firePos.rotation);
        bullet.GetComponent<Bullet>().BulletSet(_target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
