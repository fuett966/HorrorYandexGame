using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Transform[] points;

    public Vector3 GetPoint(float t)
    {
        int n = points.Length - 1;
        float u = 1 - t;
        float[] binomialCoefficients = new float[n + 1];
        Vector3[] pointCombinations = new Vector3[n + 1];

        for (int i = 0; i <= n; i++)
        {
            binomialCoefficients[i] = BinomialCoefficient(n, i);
            pointCombinations[i] = points[i].position;
        }

        for (int j = 1; j <= n; j++)
        {
            for (int i = 0; i <= n - j; i++)
            {
                pointCombinations[i] = pointCombinations[i] * u + pointCombinations[i + 1] * t;
            }
        }

        return pointCombinations[0];
    }

    private float BinomialCoefficient(int n, int k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }

    private float Factorial(int n)
    {
        if (n == 0) return 1;
        return n * Factorial(n - 1);
    }

    private void OnDrawGizmos()
    {
        if (points == null || points.Length < 2)
            return;

        Gizmos.color = Color.red;
        for (float t = 0; t <= 1; t += 0.01f)
        {
            Vector3 prevPoint = GetPoint(t - 0.01f);
            Vector3 currentPoint = GetPoint(t);
            Gizmos.DrawLine(prevPoint, currentPoint);
        }

        Gizmos.color = Color.green;
        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawSphere(points[i].position, 0.1f);
        }
    }
}