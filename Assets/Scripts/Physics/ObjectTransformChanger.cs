using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectTransformChanger : MonoBehaviour
{
    public BezierCurve bezierCurve; // Кривая, по которой будет двигаться объект
    public bool loop = true; // Будет ли объект двигаться циклично
    public float timeBetweenPoints = 1f; // Время между точками
    public bool lookAtTarget = true; // Поворот объекта во время движения

    private void OnDrawGizmos()
    {
        if (bezierCurve == null)
            return;

        Gizmos.color = Color.blue;
        for (float t = 0; t <= 1; t += 0.01f)
        {
            Vector3 prevPoint = bezierCurve.GetPoint(t - 0.01f);
            Vector3 currentPoint = bezierCurve.GetPoint(t);
            Gizmos.DrawLine(prevPoint, currentPoint);

            if (lookAtTarget)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(currentPoint, currentPoint + (currentPoint - prevPoint).normalized * 0.5f);
            }
        }

        // Отображение линии от текущей позиции объекта до траектории движения
        if (Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Vector3 closestPoint = GetClosestPointOnCurve();
            Gizmos.DrawLine(transform.position, closestPoint);
        }
    }

    private Vector3 GetClosestPointOnCurve()
    {
        float closestT = 0f;
        float closestDistance = float.MaxValue;

        for (float t = 0; t <= 1; t += 0.01f)
        {
            Vector3 pointOnCurve = bezierCurve.GetPoint(t);
            float distance = Vector3.Distance(transform.position, pointOnCurve);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestT = t;
            }
        }

        return bezierCurve.GetPoint(closestT);
    }

    private void Start()
    {
        if (bezierCurve == null)
        {
            Debug.LogError("Bezier curve is not set.");
            return;
        }

        Sequence sequence = DOTween.Sequence();

        for (float t = 0; t <= 1; t += 0.01f)
        {
            Vector3 currentPoint = bezierCurve.GetPoint(t);
            sequence.Append(transform.DOMove(currentPoint, timeBetweenPoints)); 
            if (lookAtTarget)
            {
                Vector3 nextPoint = bezierCurve.GetPoint(t + 0.01f);
                Vector3 direction = (nextPoint - currentPoint).normalized;
                Quaternion rotation = Quaternion.LookRotation(direction);
                sequence.Join(transform.DORotateQuaternion(rotation, timeBetweenPoints).SetEase(Ease.Linear));
            }
        }

        if (loop)
        {
            sequence.SetLoops(-1, LoopType.Restart);
        }
    }
}
