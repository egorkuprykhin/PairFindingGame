using Core.Services;
using Infrastructure.Core;
using Infrastructure.Services;
using PairFindingGame.Services;
using UnityEngine;

namespace PairFindingGame
{
    public class PairFindingGameFactory : GameFactory<IConfigurationService>
    {
        private GameSceneDataService _gameSceneData;

        public override void Initialize()
        {
            base.Initialize();
            _gameSceneData = ServiceLocator.GetService<GameSceneDataService>();
        }

        public LineOfElementsView CreateLineOfElements(int elementsInLine)
        {
            LineOfElementsView view = CreateView<LineOfElementsView>(_gameSceneData.ElementsParent);
            view.SetElementsInLine(elementsInLine);
            
            return view;
        }

        public ElementView CreateElementView(Transform parent, Sprite type)
        {
            ElementView view = CreateView<ElementView>(parent);
            view.SetType(type);
            view.CloseChip();

            return view;
        }
    }
}
