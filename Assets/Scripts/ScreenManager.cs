using System;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countMovements;
    [SerializeField] private TextMeshProUGUI _redTarget;
    [SerializeField] private TextMeshProUGUI _yellowTarget;
    [SerializeField] private TextMeshProUGUI _greenTarget;
    
    
    private ColorsProvider _colorsProvider;
    
    public void Initialize(ColorsProvider colorsProvider, List<DestroyingTargetBehavior> destroyingTargets)
    {
        _colorsProvider = colorsProvider;

        foreach (var destroyingTarget in destroyingTargets)
        {
            if (destroyingTarget.gameObject.GetComponent<Renderer>().material.color == _colorsProvider._colors[0])
            {
                IncreaseCountRedTargets();
                destroyingTarget.OnTargetDestroyed += ReduceCountRedTargets;
            }
            
            if (destroyingTarget.gameObject.GetComponent<Renderer>().material.color == _colorsProvider._colors[1])
            {
                IncreaseCountGreenTargets();
                destroyingTarget.OnTargetDestroyed += ReduceCountGreenTargets;
            }
            
            if (destroyingTarget.gameObject.GetComponent<Renderer>().material.color == _colorsProvider._colors[2])
            {
                IncreaseCountYellowTargets();
                destroyingTarget.OnTargetDestroyed += ReduceCountYellowTargets;
            }
        }
    }

    public void SetCountMovements(int countMovements)
    {
        _countMovements.text = countMovements.ToString();
    }

    private void IncreaseCountRedTargets()
    {
        var currentCount = Convert.ToInt32(_redTarget.text) + 1;
        _redTarget.text = currentCount.ToString();
    }
    
    private void IncreaseCountGreenTargets()
    {
        var currentCount = Convert.ToInt32(_greenTarget.text) + 1;
        _greenTarget.text = currentCount.ToString();
    }
    
    private void IncreaseCountYellowTargets()
    {
        var currentCount = Convert.ToInt32(_yellowTarget.text) + 1;
        _yellowTarget.text = currentCount.ToString();
    }
    
    private void ReduceCountRedTargets()
    {
        var currentCount = Convert.ToInt32(_redTarget.text) - 1;
        _redTarget.text = currentCount.ToString();
    }
    
    private void ReduceCountGreenTargets()
    {
        var currentCount = Convert.ToInt32(_greenTarget.text) - 1;
        _greenTarget.text = currentCount.ToString();
    }
    
    private void ReduceCountYellowTargets()
    {
        var currentCount = Convert.ToInt32(_yellowTarget.text) - 1;
        _yellowTarget.text = currentCount.ToString();
    }
}
