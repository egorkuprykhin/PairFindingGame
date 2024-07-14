using System.Collections.Generic;
using System.Linq;
using Core.Game;
using Core.Services;
using Infrastructure.Extensions;
using Infrastructure.Services;
using PairFindingGame.Services;
using UnityEngine;
using UnityEngine.UI;

namespace PairFindingGame
{
    public class PairFindingGame : IGameService
    {
        private List<LineOfElementsView> _createdLines = new List<LineOfElementsView>();
        private List<ElementView> _createdElements = new List<ElementView>();
        private ElementView _lastShowedElement;
        
        private IConfigurationService _configurationService;
        private PairFindingGameFactory _factory;
        private ScoresService _scoresService;
        private SoundService _soundService;
        private CoreFinisherService _coreFinisher;
        private ChipTypesService _chipTypesService;
        private GameSceneDataService _sceneDataService;

        private PairFindingGameSettings _gameSettings;
        private PairFindingSoundSettings _soundSettings;
        private PairFindingScoresSettings _scoresSettings;

        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<IConfigurationService>();
            _factory = ServiceLocator.GetService<PairFindingGameFactory>();
            _scoresService = ServiceLocator.GetService<ScoresService>();
            _soundService = ServiceLocator.GetService<SoundService>();
            _coreFinisher = ServiceLocator.GetService<CoreFinisherService>();
            _chipTypesService = ServiceLocator.GetService<ChipTypesService>();
            _sceneDataService = ServiceLocator.GetService<GameSceneDataService>();

            _gameSettings = _configurationService.Configuration.GetSettings<PairFindingGameSettings>();
            _soundSettings = _configurationService.Configuration.GetSettings<PairFindingSoundSettings>();
            _scoresSettings = _configurationService.Configuration.GetSettings<PairFindingScoresSettings>();
        }

        public void CreateField()
        {
            ClearField();
            CreateLines();
            CreateElementsInLines();
            SortElementsRandomly();
            
            RoundCreatedElements();
        }

        private void RoundCreatedElements()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_sceneDataService.LayoutRoot);
        }

        private void CreateLines()
        {
            foreach (int elementsInLine in _gameSettings.LinesPattern)
            {
                LineOfElementsView lineOfElements = _factory.CreateLineOfElements(elementsInLine);
                _createdLines.Add(lineOfElements);
            }
        }

        private void CreateElementsInLines()
        {
            _chipTypesService.InitUniqueTypesSequence();

            while (_createdLines.Any(line => line.HasEmptySpace))
            {
                Sprite type = _chipTypesService.GetRandomUniqueChipType();
                
                CreateElementInEmptyLine(type);
                CreateElementInEmptyLine(type);
            }
        }

        private void CreateElementInEmptyLine(Sprite type)
        {
            LineOfElementsView emptyLine = GetRandomLineWithEmptySpace();
            ElementView element = _factory.CreateElementView(emptyLine.transform, type);
            
            emptyLine.AddElement(element);
            
            SubscribeElement(element);
            _createdElements.Add(element);
        }

        private LineOfElementsView GetRandomLineWithEmptySpace() =>
            _createdLines
                .Where(line => line.HasEmptySpace)
                .ToList()
                .RandomElement();

        public void ClearField()
        {
            foreach (ElementView element in _createdElements)
            {
                element.OnChipOpened -= OnElementChipOpened;
                element.OnChipClosed -= OnElementChipClosed;
                
                Object.Destroy(element.gameObject);
            }
            _createdElements.Clear();
            
            foreach (LineOfElementsView lineOfElements in _createdLines) 
                Object.Destroy(lineOfElements.gameObject);
            _createdLines.Clear();
        }
        
        private void CheckWinGame()
        {
            if (_createdElements.Count > 0 && _createdElements.All(element => element.Opened)) 
                _coreFinisher.WinGame();
        }

        private void SubscribeElement(ElementView element)
        {
            element.OnChipOpened += OnElementChipOpened;
            element.OnChipClosed += OnElementChipClosed;
        }

        private void SortElementsRandomly()
        {
            foreach (LineOfElementsView line in _createdLines)
            {
                foreach (ElementView element in line.Elements)
                {
                    int randomIndex = Random.Range(0, line.ElementsInLine);
                    element.transform.SetSiblingIndex(randomIndex);
                }
            }
        }

        private void OnElementChipOpened(ElementView element)
        {
            FindPair(element);
            OnMove();
            CheckWinGame();
        }

        private void OnElementChipClosed(ElementView element)
        {
            _soundService.PlaySound(_soundSettings.CloseChip);
        }

        private void FindPair(ElementView element)
        {
            if (!HasLastElement())
                SetLastElement(element);
            else
            {
                if (HasPair(element))
                {
                    OpenPair(element);
                    OnPairFind();
                }
                
                ClearLastElement();
            }
        }

        private void OpenPair(ElementView element)
        {
            element.SetOpened();
            _lastShowedElement.SetOpened();
        }

        private void OnPairFind()
        {
            _scoresService.AddScores(_scoresSettings.ScoresForPair);
            _soundService.PlaySound(_soundSettings.PairFind);
        }

        private void OnMove()
        {
            _scoresService.AddScores(_scoresSettings.ScoresForMove);
            _soundService.PlaySound(_soundSettings.OpenChip);
        }

        private bool HasPair(ElementView element) => 
            HasLastElement() && _lastShowedElement.Type == element.Type;

        private bool HasLastElement() => _lastShowedElement;

        private void SetLastElement(ElementView element) => 
            _lastShowedElement = element;

        private void ClearLastElement() => _lastShowedElement = null;
    }
}