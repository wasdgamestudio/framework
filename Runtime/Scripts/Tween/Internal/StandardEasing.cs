using UnityEngine;

internal static class StandardEasing
{
    const float HALFPI = Mathf.PI / 2f;
    internal const float BackEaseConst = 1.70158f;
    internal const float DefaultElasticEasePeriod = 0.3f;
    static float InElastic(float t) => 1 - OutElastic(1 - t);

    static float OutElastic(float t)
    {
        const float decayFactor = 1f;
        float decay = Mathf.Pow(2, -10f * t * decayFactor);
        const float phase = DefaultElasticEasePeriod / 4;
        const float twoPi = Mathf.PI * 2f;
        return t > 0.9999f ? 1 : decay * Mathf.Sin((t - phase) * twoPi / DefaultElasticEasePeriod) + 1;
    }

    static float OutBounce(float x)
    {
        const float n1 = 7.5625f;
        const float d1 = 2.75f;
        if(x < 1 / d1)
        {
            return n1 * x * x;
        }
        if(x < 2 / d1)
        {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        }
        if(x < 2.5 / d1)
        {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        }
        return n1 * (x -= 2.625f / d1) * x + 0.984375f;
    }

    internal static float Evaluate(float t, W_Ease ease)
    {
        switch(ease)
        {
            case W_Ease.Linear:
                return t;
            case W_Ease.InSine:
                return 1 - Mathf.Cos(t * HALFPI);
            case W_Ease.OutSine:
                return Mathf.Sin(t * HALFPI);
            case W_Ease.InOutSine:
                return -0.5f * (Mathf.Cos(Mathf.PI * t) - 1);
            case W_Ease.InQuad:
                return t * t;
            case W_Ease.OutQuad:
                return -t * (t - 2);
            case W_Ease.InOutQuad:
                t *= 2f;
                if(t < 1)
                {
                    return 0.5f * t * t;
                }
                return -0.5f * (--t * (t - 2) - 1);
            case W_Ease.InCubic:
                return t * t * t;
            case W_Ease.OutCubic:
                return (t -= 1) * t * t + 1;
            case W_Ease.InOutCubic:
                t *= 2f;
                if(t < 1)
                {
                    return 0.5f * t * t * t;
                }
                return 0.5f * ((t -= 2) * t * t + 2);
            case W_Ease.InQuart:
                return t * t * t * t;
            case W_Ease.OutQuart:
                return -((t -= 1) * t * t * t - 1);
            case W_Ease.InOutQuart:
                t *= 2f;
                if(t < 1)
                {
                    return 0.5f * t * t * t * t;
                }
                return -0.5f * ((t -= 2) * t * t * t - 2);
            case W_Ease.InQuint:
                return t * t * t * t * t;
            case W_Ease.OutQuint:
                return (t -= 1) * t * t * t * t + 1;
            case W_Ease.InOutQuint:
                t *= 2f;
                if(t < 1)
                {
                    return 0.5f * t * t * t * t * t;
                }
                return 0.5f * ((t -= 2) * t * t * t * t + 2);
            case W_Ease.InExpo:
                return t == 0 ? 0 : Mathf.Pow(2, 10 * (t - 1));
            case W_Ease.OutExpo:
                if(t == 1)
                {
                    return 1;
                }
                return -Mathf.Pow(2, -10 * t) + 1;
            case W_Ease.InOutExpo:
                if(t == 0)
                {
                    return 0;
                }
                if(t == 1)
                {
                    return 1;
                }
                t *= 2f;
                if(t < 1)
                {
                    return 0.5f * Mathf.Pow(2, 10 * (t - 1));
                }
                return 0.5f * (-Mathf.Pow(2, -10 * --t) + 2);
            case W_Ease.InCirc:
                return -(Mathf.Sqrt(1 - t * t) - 1);
            case W_Ease.OutCirc:
                return Mathf.Sqrt(1 - (t -= 1) * t);
            case W_Ease.InOutCirc:
                t *= 2f;
                if(t < 1)
                {
                    return -0.5f * (Mathf.Sqrt(1 - t * t) - 1);
                }
                return 0.5f * (Mathf.Sqrt(1 - (t -= 2) * t) + 1);
            case W_Ease.InBack:
                return t * t * ((BackEaseConst + 1) * t - BackEaseConst);
            case W_Ease.OutBack:
                return (t -= 1) * t * ((BackEaseConst + 1) * t + BackEaseConst) + 1;
            case W_Ease.InOutBack:
                t *= 2f;
                const float c1 = BackEaseConst * 1.525f;
                if(t < 1)
                {
                    return 0.5f * (t * t * ((c1 + 1) * t - c1));
                }
                return 0.5f * ((t -= 2) * t * ((c1 + 1) * t + c1) + 2);
            case W_Ease.InElastic:
                return InElastic(t);
            case W_Ease.OutElastic:
                return OutElastic(t);
            case W_Ease.InOutElastic:
                if(t < 0.5f)
                {
                    return InElastic(t * 2) * 0.5f;
                }
                return 0.5f + OutElastic((t - 0.5f) * 2f) * 0.5f;
            case W_Ease.InBounce:
                return 1 - OutBounce(1 - t);
            case W_Ease.OutBounce:
                return OutBounce(t);
            case W_Ease.InOutBounce:
                return t < 0.5
                    ? (1 - OutBounce(1 - 2 * t)) / 2
                    : (1 + OutBounce(2 * t - 1)) / 2;
            case W_Ease.Custom:
            case W_Ease.Default:
            default:
                throw new System.Exception();
        }
    }
}