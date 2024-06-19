using System.Collections.Generic;
using System.Linq;
using Infrastructure.Core;
using UnityEngine;

namespace PairFindingGame
{
    [CreateAssetMenu(fileName = "PairFindingGameSettings")]
    public class PairFindingGameSettings : SettingsBase
    {
        [SerializeField] public List<int> LinesPattern;
        [SerializeField] public Vector2 ElementSize;
        [SerializeField] public float OpenedShowTime;
        [SerializeField] public List<Sprite> ElementTypes;
    }
}