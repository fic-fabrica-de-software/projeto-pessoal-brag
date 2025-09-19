using UnityEngine;

public static class Extensions
{
    /// <summary>
    /// Define a posição X de um Transform.
    /// </summary>
    public static void SetPositionX(this Transform transform, float x)
    {
        Vector3 position = transform.position;
        position.x = x;
        transform.position = position;
    }

    /// <summary>
    /// Define a posição Y de um Transform.
    /// </summary>
    public static void SetPositionY(this Transform transform, float y)
    {
        Vector3 position = transform.position;
        position.y = y;
        transform.position = position;
    }

    /// <summary>
    /// Retorna um vetor normalizado com base em dois pontos.
    /// </summary>
    public static Vector2 DirectionTo(this Transform from, Transform to)
    {
        return (to.position - from.position).normalized;
    }

    /// <summary>
    /// Retorna um ponto aleatório dentro de um círculo.
    /// </summary>
    public static Vector2 RandomPointInCircle(float radius)
    {
        return Random.insideUnitCircle * radius;
    }
}