using Infrastructure.Core;
using UnityEngine;

namespace PairFindingGame
{
    [CreateAssetMenu(fileName = "PairFindingSfxSettings")]
    public class PairFindingSfxSettings : SettingsBase
    {
        public AudioClip OpenChip;
        public AudioClip CloseChip;
        public AudioClip PairFind;
    }
}