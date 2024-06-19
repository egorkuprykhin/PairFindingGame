using System.Collections.Generic;
using Core.Services;
using Infrastructure.Services;
using UnityEngine;

namespace PairFindingGame.Services
{
    public class ChipTypesService : IInitializableService
    {
        private List<Sprite> _sprites = new List<Sprite>();
        private List<Sprite> _uniqueSprites = new List<Sprite>();

        private IConfigurationService _configurationService;
        private PairFindingGameSettings _gameSettings;
        

        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<IConfigurationService>();
            _gameSettings = _configurationService.Configuration.GetSettings<PairFindingGameSettings>();
            _sprites.AddRange(_gameSettings.ElementTypes);
        }

        public Sprite GetRandomChipType()
        {
            return _sprites[Random.Range(0, _sprites.Count)];
        }

        public void InitUniqueTypesSequence()
        {
            _uniqueSprites.Clear();
            _uniqueSprites.AddRange(_sprites);
        }

        public Sprite GetRandomUniqueChipType()
        {
            Sprite sprite = _uniqueSprites[Random.Range(0, _uniqueSprites.Count)];
            _uniqueSprites.Remove(sprite);

            return sprite;
        }
    }
}