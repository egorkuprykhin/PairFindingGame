using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace PairFindingGame
{
    public class ElementView : PairFindingGameView
    {
        [SerializeField] private Image Chip;
        [SerializeField] private GameObject Cover;
        [SerializeField] private Button Button;
        [SerializeField] private LayoutElement LayoutElement;

        private CancellationToken _cancellationToken;
        private bool _showedNow;
        
        public event Action<ElementView> OnChipClosed;
        public event Action<ElementView> OnChipOpened;

        public Sprite Type => Chip.sprite;
        
        public bool Opened { get; private set; }

        protected override void Initialize()
        {
            _cancellationToken = this.GetCancellationTokenOnDestroy();
            Button.onClick.AddListener(OnClickElement);
            SetSize();
        }

        private void OnClickElement()
        {
            try
            {
                ShowElementChip(_cancellationToken).Forget();
            }
            catch (OperationCanceledException e)
            {
                Debug.Log(e);
            }
        }

        public void SetType(Sprite sprite)
        {
            Chip.sprite = sprite;
        }
        
        public void SetOpened()
        {
            Opened = true;
            Cover.SetActive(false);
        }

        private void SetSize()
        {
            PairFindingGameSettings gameSettings = _settings.GetSettings<PairFindingGameSettings>();
            LayoutElement.preferredWidth = gameSettings.ElementSize.x;
            LayoutElement.preferredHeight = gameSettings.ElementSize.y;
        }

        private async UniTaskVoid ShowElementChip(CancellationToken cancellationToken)
        {
            if (IsChipOpened())
                return;
            
            OpenChip();
            
            await ShowOpenedChip(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            
            CloseChip();
        }

        private bool IsChipOpened()
        {
            return _showedNow;
        }

        private async UniTask ShowOpenedChip(CancellationToken cancellationToken)
        {
            float openedShowTime = _settings.GetSettings<PairFindingGameSettings>().OpenedShowTime;
            await UniTask.WaitForSeconds(openedShowTime, cancellationToken: cancellationToken);
        }

        public void CloseChip()
        {
            Cover.SetActive(!Opened);
            _showedNow = false;
            
            if (!Opened)
                OnChipClosed?.Invoke(this);
        }

        public void OpenChip()
        {
            Cover.SetActive(false);
            _showedNow = true;
            
            OnChipOpened?.Invoke(this);
        }
    }
}