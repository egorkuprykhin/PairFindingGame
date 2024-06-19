using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PairFindingGame
{
    public class LineOfElementsView : PairFindingGameView
    {
        [SerializeField] private HorizontalLayoutGroup LayoutGroup;

        public List<ElementView> Elements { get; } = new List<ElementView>();
        
        public int ElementsInLine { get; private set; }
        
        public bool HasEmptySpace => Elements.Count < ElementsInLine;

        public void SetElementsInLine(int elementsInLine)
        {
            ElementsInLine = elementsInLine;
        }

        public void AddElement(ElementView element)
        {
            Elements.Add(element);
        }
    }
}