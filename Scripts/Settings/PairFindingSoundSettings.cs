using Infrastructure.Core;
using UnityEngine;

namespace PairFindingGame
{
    [CreateAssetMenu(fileName = "PairFindingSfxSettings")]
    public class PairFindingSoundSettings : SettingsBase
    {
        public AudioClip OpenChip;
        public AudioClip CloseChip;
        public AudioClip PairFind;
    }
}