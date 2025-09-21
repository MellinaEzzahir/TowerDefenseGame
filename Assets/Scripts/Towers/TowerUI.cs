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
    public Sprite bothSprite;
    private Gradient gradient;
    public GameObject healthBar;
    public TowerHealth towerHealth;
    public AudioManager audioManager;

    public void Start()
    {
        HideBar();
        ChangeGradient(1);
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

    public void ShakeTowerHealth()
    {
        ShakeUtility.Shake(healthBar, ShakeUtility.ShakeSize.Big);
    }

    public void PlaySound(string soundName)
    {
        audioManager.Play(soundName);
    }

    public void ChangeSprite(float spriteNum)
    {
        switch (spriteNum)
        {
            case 1:
                heart.sprite = heartSprite;
                break;

            case 2:
                heart.sprite = poisonSprite;
                break;

            case 3:
                heart.sprite = healthSprite;
                break;

            case 4:
                heart.sprite = bothSprite;
                break;

            default:
                heart.sprite = heartSprite;
                break;
        }
    }

    public void ChangeGradient(float gradientNum)
    {
        switch (gradientNum)
        {
            case 1:
                gradient = ColorUtility.FixedNormalHealthGradient;
                break;

            case 2:
                gradient = ColorUtility.BlendedNormalHealthGradient;
                break;

            case 3:
                gradient = ColorUtility.FixedPoisonHealthGradient;
                break;

            case 4:
                gradient = ColorUtility.BlendedPoisonHealthGradient;
                break;

            default:
                gradient = ColorUtility.FixedNormalHealthGradient;
                break;
        }
    }
}