using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GenericSelector : MonoBehaviour
{
    [Serializable]
    public class OptionData
    {
        public string displayName;
        public string id;
    }

    [Header("Options")]
    public List<OptionData> options = new();

    [Header("UI")]
    public TMP_Text valueText;
    public Animator selectorAnimator;

    [Header("Indicators")]
    public Transform indicatorsParent;
    public GameObject indicatorPrefab;

    [Header("Colors")]
    public Color activeColor = Color.white;
    public Color inactiveColor = Color.gray;

    [Header("Save")]
    public bool saveSelection = true;
    public string playerPrefsKey = "SelectorIndex";

    [Header("Events")]
    public UnityEvent<int> onSelectionChanged;

    private readonly List<Graphic> indicators = new();

    private int currentIndex;

    public int CurrentIndex => currentIndex;

    public OptionData CurrentOption =>
        options.Count > 0 ? options[currentIndex] : null;

    private void Awake()
    {
        ValidateReferences();
    }

    private void Start()
    {
        LoadSelection();
        GenerateIndicators();
        RefreshUI();
    }

    public void Next()
    {
        if (options.Count <= 1)
            return;

        currentIndex++;

        if (currentIndex >= options.Count)
            currentIndex = 0;

        SelectionChanged();

        if (selectorAnimator != null)
            selectorAnimator.Play("Forward", 0, 0);
    }

    public void Previous()
    {
        if (options.Count <= 1)
            return;

        currentIndex--;

        if (currentIndex < 0)
            currentIndex = options.Count - 1;

        SelectionChanged();

        if (selectorAnimator != null)
            selectorAnimator.Play("Previous", 0, 0);
    }

    public void SetIndex(int index)
    {
        if (index < 0 || index >= options.Count)
            return;

        currentIndex = index;

        SelectionChanged();
    }

    private void SelectionChanged()
    {
        RefreshUI();

        if (saveSelection)
            SaveSelection();

        onSelectionChanged?.Invoke(currentIndex);
    }

    private void RefreshUI()
    {
        if (options.Count == 0)
            return;

        if (valueText != null)
            valueText.text = options[currentIndex].displayName;

        for (int i = 0; i < indicators.Count; i++)
        {
            if (indicators[i] == null)
                continue;

            indicators[i].color =
                i == currentIndex
                ? activeColor
                : inactiveColor;
        }
    }

    private void GenerateIndicators()
    {
        if (indicatorPrefab == null || indicatorsParent == null)
            return;

        for (int i = indicatorsParent.childCount - 1; i >= 0; i--)
        {
            Destroy(indicatorsParent.GetChild(i).gameObject);
        }

        indicators.Clear();

        for (int i = 0; i < options.Count; i++)
        {
            GameObject item =
                Instantiate(indicatorPrefab, indicatorsParent);

            Graphic graphic =
                item.GetComponent<Graphic>() ??
                item.GetComponentInChildren<Graphic>(true);

            indicators.Add(graphic);
        }
    }

    private void SaveSelection()
    {
        PlayerPrefs.SetInt(playerPrefsKey, currentIndex);
        PlayerPrefs.Save();
    }

    private void LoadSelection()
    {
        if (!saveSelection)
        {
            currentIndex = 0;
            return;
        }

        currentIndex = PlayerPrefs.GetInt(playerPrefsKey, 0);

        if (currentIndex >= options.Count)
            currentIndex = 0;
    }

    private void ValidateReferences()
    {
        if (valueText == null)
            Debug.LogWarning($"{name}: Value Text Missing");

        if (indicatorsParent == null)
            Debug.LogWarning($"{name}: Indicators Parent Missing");

        if (indicatorPrefab == null)
            Debug.LogWarning($"{name}: Indicator Prefab Missing");
    }
}