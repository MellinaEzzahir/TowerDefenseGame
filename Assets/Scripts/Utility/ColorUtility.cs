using UnityEngine;

public static class ColorUtility
{
    public static readonly Color32 red = new Color32(231, 26, 57, 255);
    public static readonly Color32 orange = new Color32(241, 102, 65, 255);
    public static readonly Color32 yellow = new Color32(239, 204, 109, 255);
    public static readonly Color32 lightGreen = new Color32(102, 166, 54, 255);
    public static readonly Color32 poisonBlue1 = new Color32(60, 158, 154, 255);
    public static readonly Color32 poisonBlue2 = new Color32(120, 177, 182, 255);
    public static readonly Color32 poisonPurple1 = new Color32(121, 126, 160, 255);
    public static readonly Color32 poisonPurple2 = new Color32(116, 88, 156, 255);

    public static readonly Gradient FixedNormalHealthGradient = MakeFixedNormalHealthGradient();
    public static readonly Gradient BlendedNormalHealthGradient = MakeBlendedNormalHealthGradient();
    public static readonly Gradient FixedPoisonHealthGradient = MakeFixedPoisonHealthGradient();
    public static readonly Gradient BlendedPoisonHealthGradient = MakeBlendedPoisonHealthGradient();

    private static Gradient MakeFixedNormalHealthGradient()
    {
        var g = new Gradient();
        g.SetKeys(
            new[]{
                new GradientColorKey(red, 0f),
                new GradientColorKey(red, 0.25f),
                new GradientColorKey(orange, 0.25f),
                new GradientColorKey(orange, 0.5f),
                new GradientColorKey(yellow, 0.5f),
                new GradientColorKey(yellow, 0.75f),
                new GradientColorKey(lightGreen, 0.75f),
                new GradientColorKey(lightGreen, 1f)
            },
            new GradientAlphaKey[0]
        );
        return g;
    }

    private static Gradient MakeBlendedNormalHealthGradient()
    {
        var g = new Gradient();
        g.SetKeys(
            new[]{
                new GradientColorKey(red, 0f),
                new GradientColorKey(orange, 0.33f),
                new GradientColorKey(yellow, 0.66f),
                new GradientColorKey(lightGreen, 1f)
            },
            new GradientAlphaKey[0]
        );
        return g;
    }

    private static Gradient MakeFixedPoisonHealthGradient()
    {
        var g = new Gradient();
        g.SetKeys(
            new[]{
                new GradientColorKey(poisonPurple2, 0f),
                new GradientColorKey(poisonPurple2, 0.25f),
                new GradientColorKey(poisonPurple1, 0.25f),
                new GradientColorKey(poisonPurple1, 0.5f),
                new GradientColorKey(poisonBlue2, 0.5f),
                new GradientColorKey(poisonBlue2, 0.75f),
                new GradientColorKey(poisonBlue1, 0.75f),
                new GradientColorKey(poisonBlue1, 1f)
            },
            new GradientAlphaKey[0]
        );
        return g;

    }

    private static Gradient MakeBlendedPoisonHealthGradient()
    {
        var g = new Gradient();
        g.SetKeys(
            new[]{
                new GradientColorKey(poisonPurple1, 0f),
                new GradientColorKey(poisonPurple1, 0.33f),
                new GradientColorKey(poisonBlue2, 0.66f),
                new GradientColorKey(poisonBlue1, 1f)
            },
            new GradientAlphaKey[0]
        );
        return g;
    }

}