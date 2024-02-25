using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _cooldown;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;
        WaitForSeconds waitForSeconds = new WaitForSeconds(_cooldown);

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _speed;

            yield return waitForSeconds;
        }
    }
}