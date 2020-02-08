using System;
using System.Collections.Generic;
using UnityEngine;

namespace utils
{
    [Serializable]
    public struct RangeFloat
    {
        public float MaxValue;
        public float MinValue;
    }

    [Serializable]
    public struct RangeInt
    {
        public int MaxValue;
        public int MinValue;
    }

    public static class Utils
    {
        public static int GetRandomIntValue(RangeInt range)
        {
            return UnityEngine.Random.Range(range.MinValue, range.MaxValue);
        }

        public static int GetRandomIntValue(int min, int max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        public static float GetRandomFloatValue(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        public static float GetRandomFloatValue(RangeFloat range)
        {
            return UnityEngine.Random.Range(range.MinValue, range.MaxValue);
        }
    }
}
