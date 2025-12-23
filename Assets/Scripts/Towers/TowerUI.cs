using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Image border;
    public Image heart;
    public SpriteRenderer towerSpriteRenderer;
    public Sprite heartSprite;
    public Sprite poisonSprite;
    public Sprite healthSprite;
    public Sprite bothSprite;
    public Sprite poisonTowerSprite;
    public Sprite normalTowerSprite;
    private Gradient gradient;
    public GameObject healthBar;
    public TowerHealth towerHealth;
    public AudioManager audioManager;
    private Animator _animator;

    public void Start()
    {
        HideBar();
        ChangeGradient(1);
        _animator = GetComponent<Animator>();
        towerSpriteRenderer.sprite = poisonTowerSprite;
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

    public void PlayAnimation(int type, string parameterName)
    {
        if (type == 0)
        {
            _animator.SetTrigger(parameterName);
        }
        else if (type == 1)
        {
            _animator.SetBool(parameterName, true);
        }
        else if (type == 2)
        {
            _animator.SetBool(parameterName, false);
        }
    }

    public void ChangeSprite(float spriteNum)
    {
        switch (spriteNum)
        {
            case 1:
                heart.sprite = heartSprite;
                towerSpriteRenderer.sprite = normalTowerSprite;
                break;

            case 2:
                heart.sprite = poisonSprite;
                towerSpriteRenderer.sprite = poisonTowerSprite;
                break;

            case 3:
                heart.sprite = healthSprite;
                towerSpriteRenderer.sprite = normalTowerSprite;
                break;

            case 4:
                heart.sprite = bothSprite;
                towerSpriteRenderer.sprite = poisonTowerSprite;
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