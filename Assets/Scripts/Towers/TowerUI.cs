using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Image border;
    public Image heart;
    public Sprite heartSprite;
    public Sprite poisonSprite;
    public Sprite healthSprite;
    private Gradient gradient;
    public GameObject healthBar;
    public TowerHealth towerHealth;
    public AudioManager audioManager;

    public void Start()
    {
        HideBar();
        gradient = ColorUtility.FixedNormalHealthGradient;
    }

    public void SetHealth()
    {
        slider.value = towerHealth.Health / towerHealth.maxHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        ShowBar();
    }

    public void ShowBar()
    {
        fill.enabled = true;
        border.enabled = true;
        heart.enabled = true;
    }

    public void HideBar()
    {
        fill.enabled = false;
        border.enabled = false;
        heart.enabled = false;
    }

    public void HealthPotion(bool state)
    {
        if (state)
        {
            heart.sprite = healthSprite;
            gradient = ColorUtility.BlendedNormalHealthGradient;
        }
        else
        {
            Debug.Log("health");
            heart.sprite = heartSprite;
            gradient = ColorUtility.FixedNormalHealthGradient;
            SetHealth();
        }
    }

    public void PoisonHealthEffect(bool state)
    {
        if (state)
        {
            heart.sprite = poisonSprite;
            gradient = ColorUtility.FixedPoisonHealthGradient;
        }
        else
        {
            Debug.Log("poison");
            heart.sprite = heartSprite;
            gradient = ColorUtility.FixedNormalHealthGradient;
            SetHealth();
        }
    }

    public void ShakeTowerHealth()
    {
        ShakeUtility.Shake(healthBar, ShakeUtility.ShakeSize.Big);
    }

    public void PlaySound(string soundName)
    {
        audioManager.Play(soundName);
    }
}
