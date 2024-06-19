using Core.Sfx;
using Infrastructure.Core;
using UnityEngine;

namespace PairFindingGame
{
    [CreateAssetMenu(fileName = "PairFindingSfxSettings")]
    public class PairFindingSfxSettings : SettingsBase
    {
        public SfxType OpenChip;
        public SfxType CloseChip;
        public SfxType PairFind;
    }
}