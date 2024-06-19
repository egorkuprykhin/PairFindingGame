using Infrastructure.Core;
using UnityEngine;

namespace PairFindingGame
{
    [CreateAssetMenu(fileName = "PairFindingScoresSettings")]
    public class PairFindingScoresSettings : SettingsBase
    {
        [SerializeField] public int ScoresForMove;
        [SerializeField] public int ScoresForPair;
    }
}