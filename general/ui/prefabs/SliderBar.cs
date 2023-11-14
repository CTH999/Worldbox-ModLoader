using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NeoModLoader.General.UI.Prefabs;

public class SliderBar : APrefab<SliderBar>
{
    private Slider _slider;
    public TipButton tip_button { get; private set; }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        tip_button = GetComponent<TipButton>();
    }

    public void Setup(float value, float min, float max, UnityAction<float> value_update)
    {
        _slider.onValueChanged.RemoveAllListeners();
        _slider.minValue = min;
        _slider.maxValue = max;
        _slider.value = value;
        _slider.onValueChanged.AddListener(value_update);
    }
    public void SetSize(Vector2 size)
    {
        GetComponent<RectTransform>().sizeDelta = size;
        transform.Find("Background").GetComponent<RectTransform>().sizeDelta = size - new Vector2(0, 10);
        transform.Find("Fill Area").GetComponent<RectTransform>().sizeDelta = size - new Vector2(0, 10);
        transform.Find("Fill Area/Fill").GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        transform.Find("Handle Slide Area").GetComponent<RectTransform>().sizeDelta = size - new Vector2(10, 0);
        transform.Find("Handle Slide Area/Handle").GetComponent<RectTransform>().sizeDelta = new Vector2(20, 0);
        
    }

    internal static void _init()
    {
        GameObject slider_bar = new GameObject("SliderBar", typeof(Slider), typeof(TipButton));
        slider_bar.transform.SetParent(WorldBoxMod.Transform);
        slider_bar.GetComponent<RectTransform>().sizeDelta = new(172, 20);
        
        GameObject background = new GameObject("Background", typeof(Image));
        background.transform.SetParent(slider_bar.transform);
        background.transform.localScale = Vector3.one;
        background.GetComponent<RectTransform>().sizeDelta = new(0, 0);
        background.GetComponent<Image>().sprite = SpriteTextureLoader.getSprite("ui/special/special_buttonGray");
        background.GetComponent<Image>().type = Image.Type.Sliced;
        
        GameObject fill_area = new GameObject("Fill Area", typeof(RectTransform));
        fill_area.transform.SetParent(slider_bar.transform);
        fill_area.transform.localScale = Vector3.one;
        fill_area.GetComponent<RectTransform>().sizeDelta = new(-20, 0);
        GameObject fill = new GameObject("Fill", typeof(Image));
        fill.transform.SetParent(fill_area.transform);
        fill.transform.localScale = Vector3.one;
        fill.GetComponent<RectTransform>().sizeDelta = new(10, 0);
        fill.GetComponent<Image>().sprite = SpriteTextureLoader.getSprite("ui/special/special_buttonRed");
        fill.GetComponent<Image>().type = Image.Type.Sliced;
        
        GameObject handle_area = new GameObject("Handle Slide Area", typeof(RectTransform));
        handle_area.transform.SetParent(slider_bar.transform);
        handle_area.transform.localScale = Vector3.one;
        handle_area.GetComponent<RectTransform>().sizeDelta = new(-20, 0);
        GameObject handle = new GameObject("Handle", typeof(Image));
        handle.transform.SetParent(handle_area.transform);
        handle.transform.localScale = Vector3.one;
        handle.GetComponent<Image>().sprite = SpriteTextureLoader.getSprite("ui/special/special_buttonRed");
        handle.GetComponent<Image>().type = Image.Type.Sliced;
        handle.GetComponent<RectTransform>().sizeDelta = new(20, 0);
        
        Prefab = slider_bar.AddComponent<SliderBar>();
        
        Slider slider = slider_bar.GetComponent<Slider>();
        slider.fillRect = fill.GetComponent<RectTransform>();
        slider.handleRect = handle.GetComponent<RectTransform>();
        slider.targetGraphic = handle.GetComponent<Image>();
        slider.direction = Slider.Direction.LeftToRight;
        slider.interactable = true;
        
    }
}