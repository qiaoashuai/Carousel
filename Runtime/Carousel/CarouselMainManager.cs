using UnityEngine;
using UnityEngine.Serialization;

public class CarouselMainManager : MonoBehaviour
{
    [FormerlySerializedAs("_carouselScroll")] public CarouselScrollRect carouselScroll;
    
    public ImageValueEvent onImageAddValueChanged = new ImageValueEvent();
    public CarouselColorEvent onToggleColorValueChanged = new CarouselColorEvent();
    public CarouselBoolEvent onAutomaticValueChanged = new CarouselBoolEvent();
    public CarouselFloatEvent onAutomaticTime = new CarouselFloatEvent();
    public CarouselButtonEvent onButtonTime = new CarouselButtonEvent();
    public CarouselIntEvent onSpecifyTheImage = new CarouselIntEvent();
    

    private Texture _addImage;
    /// <summary>
    /// 新增图片
    /// </summary>
    public Texture AddImage
    {
        get => _addImage;
        set
        {
            _addImage = value; 
            carouselScroll.AddImage(value);
        }
    }

    private bool _automaticRolling;
    /// <summary>
    /// 是否开启滚动播放
    /// </summary>
    public bool AutomaticRolling
    {
        get => _automaticRolling;
        set
        {
            _automaticRolling = value;
            carouselScroll.automaticRolling = value;
        }
    }
    
    private float _carouselScrollTime;
    /// <summary>
    /// 滚动播放的速度
    /// </summary>
    public float CarouselScrollTime
    {
        get => _carouselScrollTime;
        set
        {
            _carouselScrollTime = value;
            carouselScroll.automaticRollingTime = value;
        }
    }

    private int _specifyTheImage;
/// <summary>
/// 指定图片
/// </summary>
    public int SpecifyTheImage
    {
        get => _specifyTheImage;
        set
        {
            _specifyTheImage = value;
            carouselScroll.SpecifyTheImage(value);
        }
    }
    

    /// <summary>
    /// 下一张图片
    /// </summary>
    public void Next()
    {
        carouselScroll.NextPieceButtonClick();
    }

    /// <summary>
    /// 下一张图片
    /// </summary>
    public void Prev()
    {
        carouselScroll.OnePieceButtonClick();
    }
    
}
