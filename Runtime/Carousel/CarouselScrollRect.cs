using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Toggle = UnityEngine.UI.Toggle;

public class CarouselScrollRect : MonoBehaviour
{
      [FormerlySerializedAs("m_Scrollbar")] public Scrollbar mScrollbar;
      public RectTransform scrollContent;

      public RectTransform togglePanel;
      private List<RawImage> _childImageList = new List<RawImage>();
      private List<Toggle> _childToggleList = new List<Toggle>();
      public RawImage imagePrefab;
      public Toggle togglePrefab;
      private EventTrigger _eventTrigger;
      private ToggleGroup _toggleGroup;
      public Button oneButton;
      public Button nextButton;

      public bool automaticRolling = true;

      public float automaticRollingTime = 2;

      private bool _automaticAcquisition = true;
      
      
      private void Awake()
      {
          _childImageList.Clear();
          _childToggleList.Clear();
          _eventTrigger = this.gameObject.AddComponent<EventTrigger>();
          _toggleGroup = togglePanel.gameObject.GetComponent<ToggleGroup>();
          
          oneButton.onClick.AddListener(OnePieceButtonClick);
          nextButton.onClick.AddListener(NextPieceButtonClick);
      }

      public void OnePieceButtonClick()
      {
          if (_childImageList.Count <= 0)
              return;
          
          _currentSelectIndex -- ;
          if (_currentSelectIndex < 0)
              _currentSelectIndex = _childImageList.Count - 1;
          
          _childToggleList[_currentSelectIndex].isOn = true;
      }

      public void NextPieceButtonClick()
      {
           
          if (_childImageList.Count <= 0  )
              return;
          
          _currentSelectIndex++;
          if ( _currentSelectIndex > _childImageList.Count - 1)
              _currentSelectIndex = 0;
          
          _childToggleList[_currentSelectIndex].isOn = true;
      }


      public void SpecifyTheImage(int index)
      {
          if (index <= 0 || index>_childImageList.Count-1)
             return;
          
          _childToggleList[index].isOn = true;
      }
      
      private void Start()
      {
          EventTrigger.Entry entry = new EventTrigger.Entry();
          entry.eventID = EventTriggerType.PointerUp;
          entry.callback.AddListener(OnPointerUpEvent);
          _eventTrigger.triggers.Add(entry);

          if (!_automaticAcquisition)
            return;
          var imagelist = scrollContent.GetComponentsInChildren<RawImage>();
          foreach (var vImage in imagelist)
          {
              var tempButton = Instantiate(togglePrefab, togglePanel);
              tempButton.group = _toggleGroup;
              tempButton.gameObject.SetActive(true);
              _childImageList.Add(vImage);
              _childToggleList.Add(tempButton);
              InitDate();
          }
      }

      public void AddImage(Texture texture)
      {
          _automaticAcquisition = false;
          var tempImage = Instantiate(imagePrefab,scrollContent);
          tempImage.texture = texture;
          tempImage.gameObject.SetActive(true);

          var tempButton = Instantiate(togglePrefab, togglePanel);
          tempButton.group = _toggleGroup;
          tempButton.gameObject.SetActive(true);
          _childImageList.Add(tempImage);
          _childToggleList.Add(tempButton);
          InitDate();
      }
      
      private void InitDate()
      {
          if (_childToggleList == null)
             return;
          
          float scrValue;
          var btnValue = (float) _childToggleList.Count - 1;
          scrValue = _scrollMaxValue / btnValue;
          for (int i = 0; i < _childToggleList.Count; i++)
          {
              var i1 = i;
              _childToggleList[i].onValueChanged.AddListener((change) =>
              {
                  _mTargetValue = scrValue * i1;
                  _currentSelectIndex = i1;
                  _mNeedMove = true;
              });
          }

          if (_childToggleList.Count > 0)
          {
              _childToggleList[0].isOn = true;
          }
      }

      private int _currentSelectIndex;

      private float _scrollMaxValue = 1.0f;
      private void OnPointerUpEvent(BaseEventData baseEventData)
      {
          if ( _childToggleList.Count <= 0)
              return;
          
          var oneTextureValue =  _scrollMaxValue/ (_childImageList.Count - 1);
          var semiTensorValue = oneTextureValue / 2.0f;
          
          if (mScrollbar.value < -semiTensorValue)
          {
              _childToggleList[_childImageList.Count - 1].isOn = true;
              return;
          }

          if (mScrollbar.value > 1 + semiTensorValue)
          {
              _childToggleList[0].isOn = true;
              return;
          }

        
          
          float scrValue;
          var btnValue = (float) _childToggleList.Count - 1;
          scrValue = _scrollMaxValue / btnValue;

          float imagenumber = _scrollMaxValue;
          for (int i = 0; i < _childToggleList.Count; i++)
          {
              if (mScrollbar.value <= semiTensorValue * imagenumber)
              {
                  _mTargetValue = scrValue * i;
                  _childToggleList[i].isOn = true;
                  _currentSelectIndex = i;
                  break;
              }
              imagenumber += 2;
          }
          _mNeedMove = true;
          _mMoveSpeed = 0;
      }

      private float _mTargetValue;
  
      private bool _mNeedMove;
  
      private const float SmoothTime = 0.2F;
  
      private float _mMoveSpeed;

      private float _tempTime;
      void Update()
      {
          if (_mNeedMove)
          {
              if (Mathf.Abs(mScrollbar.value - _mTargetValue) < 0.01f)
              {
                  mScrollbar.value = _mTargetValue;
                  _mNeedMove = false;
                  return;
              }
              mScrollbar.value = Mathf.SmoothDamp(mScrollbar.value, _mTargetValue, ref _mMoveSpeed, SmoothTime);
          }

          if (automaticRolling)
          {
              _tempTime += Time.deltaTime;
              if (_tempTime > automaticRollingTime)
              {
                  _tempTime = 0;
                  AutomaticRolling();
              }
          }
      }

      private void AutomaticRolling()
      {
          if (_currentSelectIndex < 0  || _childImageList.Count <= 0)
              return;
          _currentSelectIndex++;
          
          if (_currentSelectIndex > _childImageList.Count - 1)
          {
              _childToggleList[0].isOn = true;
              _currentSelectIndex = 0;
          }

          _childToggleList[_currentSelectIndex].isOn = true;
      }
}
