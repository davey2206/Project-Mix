using System.Collections.Generic;
using UnityEngine;

public class Grid_Spacing : MonoBehaviour
{
    [SerializeField] RectTransform parent;
    [SerializeField] int maxObjectsBeforeNoPadding = 5;
    [SerializeField] float animationSpeed = 10f;

    float initialPadding = 400f;

    void Start()
    {
        UpdateLayout();
    }

    void Update()
    {
        UpdateLayout();
    }

    public void ForceUpdateLayout()
    {
        UpdateLayout();
    }

    public void UpdateLayout()
    {
        if (parent == null || parent.childCount == 0) return;

        int count = parent.childCount;
        RectTransform sample = parent.GetChild(0) as RectTransform;
        if (sample == null) return;

        float childWidth = sample.rect.width;
        float parentWidth = parent.rect.width;
        float totalInitialPadding = initialPadding;

        float paddingRatio = Mathf.Clamp01(1f - (float)(count - 1) / (maxObjectsBeforeNoPadding - 1));
        float padding = totalInitialPadding * paddingRatio;

        float usableWidth = parentWidth - padding;
        float totalChildrenWidth = count * childWidth;

        float spacing = (count > 1) ? (usableWidth - totalChildrenWidth) / (count - 1) : 0f;
        float totalRowWidth = totalChildrenWidth + spacing * (count - 1);
        float startX = -totalRowWidth / 2f + childWidth / 2f;

        float yPos = 0f;

        for (int i = 0; i < count; i++)
        {
            RectTransform child = parent.GetChild(i) as RectTransform;
            if (child == null) continue;

            Vector2 targetPos = new Vector2(startX + i * (childWidth + spacing), yPos);

            if (!Application.isPlaying)
            {
                child.anchoredPosition = targetPos;
            }
            else
            {
                child.anchoredPosition = Vector2.Lerp(child.anchoredPosition, targetPos, Time.deltaTime * animationSpeed);
            }
        }
    }
}
