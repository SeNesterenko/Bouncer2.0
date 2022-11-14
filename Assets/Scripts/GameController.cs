using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private ColorsProvider _colorsProvider;
    [SerializeField] private DestroyingTargetsSpawner _destroyingTargetsSpawner;
    [SerializeField] private RecoloringTargetBehavior _recoloringTargetBehavior;
    [SerializeField] private ScreenManager _screenManager;
    [SerializeField] private PlayerMovementController _playerMovementController;

    private List<DestroyingTargetBehavior> _destroyingTargets;

    private void Awake()
    {
        _recoloringTargetBehavior.Initialize(_colorsProvider);
        
        _destroyingTargetsSpawner.Initialize(_colorsProvider);
        _destroyingTargets = _destroyingTargetsSpawner.GetDestroyingTargets();
        
        _screenManager.Initialize(_colorsProvider, _destroyingTargets);
    }

    private void Update()
    {
        var countMovements = _playerMovementController.GetCountMovements();
        _screenManager.SetCountMovements(countMovements);
        
    }
    
    
}
