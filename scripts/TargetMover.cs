using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _movedSpeed;

    private Transform[] _points;
    private int _currentPointIndex;

    private void Start() => FillPoints();

    private void Update()
    {
        Transform target = _points[_currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _movedSpeed * Time.deltaTime);

        if (transform.position == target.position)
        {
            SelectNextTarget();
        }
    }

    private void FillPoints()
    {
        _points = new Transform[_target.childCount];

        for (int i = 0; i < _target.childCount; i++)
        {
            if (_target.GetChild(i).TryGetComponent(out Transform transform))
            {
                _points[i] = transform;
            }
        }
    }

    private void SelectNextTarget()
    {
        _currentPointIndex++;

        if (_currentPointIndex == _points.Length)
        {
            _currentPointIndex = 0;
        }

        Vector3 thisPointVector = _points[_currentPointIndex].transform.position;
        transform.forward = thisPointVector - transform.position;
    }
}