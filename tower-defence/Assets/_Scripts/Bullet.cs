using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bulletParticle;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 70f;
    
    
    public void BulletSet(Transform target) => _target = target;

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        Debug.Log("Die you bitch");
        GameObject effect = Instantiate(_bulletParticle, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect, 2f);
    }
}
