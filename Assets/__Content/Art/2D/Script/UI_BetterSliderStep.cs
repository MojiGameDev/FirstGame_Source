using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderStepController : MonoBehaviour
{
    [Min(1)]
    public int step = 5;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(SnapValue);

        // مقدار اولیه هم اسنپ بشه
        SnapValue(slider.value);
    }

    private void SnapValue(float value)
    {
        float snappedValue = Mathf.Round(value / step) * step;

        if (slider.value != snappedValue)
        {
            slider.SetValueWithoutNotify(snappedValue);
        }
    }
}