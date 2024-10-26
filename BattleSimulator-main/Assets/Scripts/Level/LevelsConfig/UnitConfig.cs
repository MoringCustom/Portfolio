using System.Collections.Generic;
using BS.Units;
using UnityEngine;

namespace BS.Level.LevelsConfig
{
    [CreateAssetMenu(fileName = "New UnitConfig", menuName = "Levels/Create new UnitConfig", order = 52)]
    public class UnitConfig : ScriptableObject
    {
        [SerializeField] private Unit _unitPrefab;
        [SerializeField] private List<Vector3> _positions;

        public Unit UnitPrefab => _unitPrefab;
        public IReadOnlyList<Vector3> Positions => _positions;
    }
}