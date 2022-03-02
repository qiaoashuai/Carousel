

using System.Runtime.CompilerServices;
using UnityEngine;

public sealed class RectTransformUtilityForMultiDisPlays
{
   
    public static bool ScreenPointToLocalPointInRectangle(
        RectTransform rect,
        Vector2 screenPoint,
        Camera cam,
        out Vector2 localPoint)
    {
#if !UNITY_EDITOR
        screenPoint = Display.RelativeMouseAt(screenPoint);
#endif
        return RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, cam, out localPoint);
    }
    
    public static bool ScreenPointToWorldPointInRectangle(
        RectTransform rect,
        Vector2 screenPoint,
        Camera cam,
        out Vector3 worldPoint)
    {
#if !UNITY_EDITOR
        screenPoint = Display.RelativeMouseAt(screenPoint);
#endif
        return RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, screenPoint, cam, out worldPoint);
    }

    public static Vector2 WorldToScreenPoint(Camera cam, Vector3 worldPoint)
    {
        var screenPoint = RectTransformUtility.WorldToScreenPoint(cam, worldPoint);
#if !UNITY_EDITOR
        screenPoint = Display.RelativeMouseAt(screenPoint);
#endif
        return screenPoint;
    }
    
    public static bool RectangleContainsScreenPoint(RectTransform rect, Vector2 screenPoint)
    {
#if !UNITY_EDITOR
        screenPoint = Display.RelativeMouseAt(screenPoint);
#endif
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPoint);
    }

    public static bool RectangleContainsScreenPoint(
        RectTransform rect,
        Vector2 screenPoint,
        Camera cam)
    {
#if !UNITY_EDITOR
        screenPoint = Display.RelativeMouseAt(screenPoint);
#endif
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPoint, cam);
    }
    public static bool RectangleContainsScreenPoint(
            RectTransform rect,
            Vector2 screenPoint,
            Camera cam,
            Vector4 offset)
    {
#if !UNITY_EDITOR
        screenPoint = Display.RelativeMouseAt(screenPoint);
#endif
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPoint, cam);
    }
}
