using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Grid_Spacing conflictingLayoutScript;
    private RectTransform rectTransform;
    private int originalSiblingIndex;
    private Vector2 originalAnchoredPosition;
    private Button buttonComponent;

    [SerializeField] float disableHoverDuration = 0.5f;
    private bool hasSpawnedAndInitialized = false;
    private bool isHoverTemporarilyDisabled = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        buttonComponent = GetComponent<Button>();
    }

    private void OnEnable()
    {
        InitializeParentLayoutReference();

        if (Application.isPlaying && !hasSpawnedAndInitialized)
        {
            isHoverTemporarilyDisabled = true;
            this.enabled = false;
            if (buttonComponent != null)
            {
                buttonComponent.interactable = false;
            }
            Invoke("EnableHoverInteraction", disableHoverDuration);
            hasSpawnedAndInitialized = true;
        }
        else if (Application.isPlaying && hasSpawnedAndInitialized)
        {
            this.enabled = true;
            if (buttonComponent != null)
            {
                buttonComponent.interactable = true;
            }
        }
        else if (!Application.isPlaying)
        {
            this.enabled = true;
            if (buttonComponent != null)
            {
                buttonComponent.interactable = true;
            }
        }
    }

    private void OnDisable()
    {
        CancelInvoke("EnableHoverInteraction");
        if (conflictingLayoutScript != null && !conflictingLayoutScript.enabled)
        {
            conflictingLayoutScript.enabled = true;
            conflictingLayoutScript.ForceUpdateLayout();
        }
        hasSpawnedAndInitialized = false;
    }

    private void OnTransformParentChanged()
    {
        InitializeParentLayoutReference();
        if (Application.isPlaying)
        {
            isHoverTemporarilyDisabled = true;
            this.enabled = false;
            if (buttonComponent != null)
            {
                buttonComponent.interactable = false;
            }
            Invoke("EnableHoverInteraction", disableHoverDuration);
            hasSpawnedAndInitialized = true;
        }
    }

    private void InitializeParentLayoutReference()
    {
        if (rectTransform.parent != null)
        {
            conflictingLayoutScript = rectTransform.parent.GetComponent<Grid_Spacing>();
        }
        else
        {
            conflictingLayoutScript = null;
        }
    }

    private void EnableHoverInteraction()
    {
        isHoverTemporarilyDisabled = false;
        this.enabled = true;
        if (buttonComponent != null)
        {
            buttonComponent.interactable = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isHoverTemporarilyDisabled) return;

        originalAnchoredPosition = rectTransform.anchoredPosition;
        originalSiblingIndex = rectTransform.GetSiblingIndex();

        if (conflictingLayoutScript != null)
        {
            conflictingLayoutScript.enabled = false;
        }

        rectTransform.SetAsLastSibling();
        rectTransform.anchoredPosition = originalAnchoredPosition;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.SetSiblingIndex(originalSiblingIndex);

        if (conflictingLayoutScript != null)
        {
            conflictingLayoutScript.enabled = true;
            conflictingLayoutScript.ForceUpdateLayout();
        }
    }
}
