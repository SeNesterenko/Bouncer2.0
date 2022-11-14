using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _forceValue = 250;

    private Rigidbody _rigidbody;
    private readonly Vector3 _startPosition = Vector3.zero;
    private Vector3 _target;
    private int _countMovements;

    public int GetCountMovements()
    {
        return _countMovements;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y < 0)
        {
            MoveToStartPoint();
        }

        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            _rigidbody.velocity = Vector3.zero;
            MoveTowardsSelectedPoint(hitInfo);
        }
    }
    
    private void MoveToStartPoint()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector3.zero;
    }

    private void MoveTowardsSelectedPoint(RaycastHit hitInfo)
    {
        var direction = (hitInfo.point - transform.position).normalized;
        _rigidbody.AddForce(direction * _forceValue);
        _countMovements++;
    }
}
