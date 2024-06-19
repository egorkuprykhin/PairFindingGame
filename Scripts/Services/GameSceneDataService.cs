using Services.Core;
using UnityEngine;

namespace PairFindingGame.Services
{
    public class GameSceneDataService : MonoService
    {
        [SerializeField] public Transform ElementsParent;
        [SerializeField] public RectTransform LayoutRoot;
    }
}