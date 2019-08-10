using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Button : MonoBehaviour
{
    [SerializeField]
    Image useable;

    [SerializeField]
    Image cooldown;

    [SerializeField]
    private Image cooldownProgress;

    [SerializeField]
    private float cooldownTime = 3f;

    private float cooldownProgressTargetHeight;
    
    [SerializeField]
    private float cooldownTimer = 0f;

    private void Awake()
    {
        cooldownTimer = cooldownTime;
        useable.gameObject.SetActive(true);
        cooldown.gameObject.SetActive(false);
        cooldownProgressTargetHeight = cooldownProgress.rectTransform.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownTimer <= cooldownTime)
        {
            cooldownTimer += Time.deltaTime;
            float cooldownProgresHeight = cooldownTimer / cooldownTime * cooldownProgressTargetHeight;
            Rect r = cooldownProgress.rectTransform.rect;

            r.height = cooldownProgresHeight;
            cooldownProgress.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, cooldownProgresHeight);
            //cooldownProgress.rectTransform.sizeDelta = new Vector2(r.height, r.width);

            if(cooldownTimer >= cooldownTime)
            {
                CooldownOver();
            }
        }
        if (Input.GetKey(KeyCode.J) && cooldownTimer == cooldownTime)
        {
            ClickJ();
        }
    }

    public void CooldownOver()
    {
        cooldownTimer = cooldownTime;
        useable.gameObject.SetActive(true);
        cooldown.gameObject.SetActive(false);
    }

    public void ClickJ()
    {
        cooldownTimer = 0;
        useable.gameObject.SetActive(false);
        cooldown.gameObject.SetActive(true);
    }
}
