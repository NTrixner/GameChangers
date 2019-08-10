using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    [SerializeField]
    Image useable;

    [SerializeField]
    Image cooldown;

    [SerializeField]
    private Image cooldownProgress;

    private float cooldownProgressTargetHeight;

    private void Awake()
    {
        useable.gameObject.SetActive(false);
        cooldown.gameObject.SetActive(true);
        cooldownProgressTargetHeight = cooldownProgress.rectTransform.rect.height;
    }

    public void UpdateState(float cooldownState)
    {
        float cooldownProgresHeight = cooldownState * cooldownProgressTargetHeight;
        Rect r = cooldownProgress.rectTransform.rect;

        r.height = cooldownProgresHeight;
        cooldownProgress.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, cooldownProgresHeight);
    }

    public void OnReady()
    {
        useable.gameObject.SetActive(true);
        cooldown.gameObject.SetActive(false);
    }

    public void OnUsed()
    {
        useable.gameObject.SetActive(false);
        cooldown.gameObject.SetActive(true);
    }
}
