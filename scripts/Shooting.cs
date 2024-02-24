using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _cooldown;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject newBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return new WaitForSeconds(_cooldown);
        }
    }
}