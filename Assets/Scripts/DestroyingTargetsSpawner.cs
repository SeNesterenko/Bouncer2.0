using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class DestroyingTargetsSpawner : MonoBehaviour
{
    [SerializeField] private DestroyingTargetBehavior _destroyingTarget;
    [SerializeField] private int _destroyingTargetsCount = 6;
    [SerializeField] private int _randomRadius;

    private ColorsProvider _colorsProvider;
    private List<DestroyingTargetBehavior> _destroyingTargets;

    public void Initialize(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;
        _destroyingTargets = new List<DestroyingTargetBehavior>();

        for (var i = 0; i < _destroyingTargetsCount; i++)
        {
            var destroyingTarget = Instantiate(_destroyingTarget);
            SetDestroyingTargetPosition(destroyingTarget);
            destroyingTarget.Initialize(_colorsProvider.GetColor());
            _destroyingTargets.Add(destroyingTarget);
        }
    }

    public List<DestroyingTargetBehavior> GetDestroyingTargets()
    {
        return _destroyingTargets;
    }

    private void SetDestroyingTargetPosition(DestroyingTargetBehavior destroyingTarget)
    {
        var randomPosition = Random.insideUnitCircle * _randomRadius;
        var destroyingTargetPosition = destroyingTarget.transform.position;

        destroyingTargetPosition.x += randomPosition.x;
        destroyingTargetPosition.z = randomPosition.y;

        destroyingTarget.transform.position = destroyingTargetPosition;
    }
    
    
}
