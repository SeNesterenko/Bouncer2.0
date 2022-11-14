using System;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecoloringTargetBehavior : MonoBehaviour
{
    [SerializeField] private int _randomRadius = 40;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private ColorsProvider _colorsProvider;
    [SerializeField] private Vector3 _startPosition = new Vector3(0, (float)5.1, 0);
    
    private Color _color;
    

    public void Initialize(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;
        _color = _renderer.material.color;
    }

    private void Start()
    {
        SetNewRandomPosition();
        SetNewRandomColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            player.SetColor(_color);
            
            SetNewRandomPosition();
            SetNewRandomColor();
        }
    }

    private void SetNewRandomPosition()
    {
        var randomPosition = Random.insideUnitCircle * _randomRadius;
        var position = _startPosition;

        position.x += randomPosition.x;
        position.z += randomPosition.y;

        transform.position = position;
    }

    private void SetNewRandomColor()
    {
        var newColor = _colorsProvider.GetColor();

        _renderer.material.color = newColor;
        _color = newColor;
    }
}
