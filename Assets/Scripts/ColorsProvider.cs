using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    [Serializable]
    public class ColorsProvider
    {
        public Color[] _colors;

        public Color GetColor()
        {
            var index = Random.Range(0, _colors.Length);

            return _colors[index];
        }
    }
}