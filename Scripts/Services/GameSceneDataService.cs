using Services.Core;
using UnityEngine;

namespace PairFindingGame.Services
{
    public class GameSceneDataService : MonoService
    {
        [SerializeField] public GameObject GameRoot;

        public Transform ElementsParent { get; private set; }

        public RectTransform LayoutRoot { get; private set; }

        private void Awake()
        {
            ElementsParent = GameRoot.transform;
            LayoutRoot = GameRoot.GetComponent<RectTransform>();
        }
    }
}