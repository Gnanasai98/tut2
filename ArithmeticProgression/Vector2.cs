using System;
namespace MathCollection;
public struct Vector2
{
    public float x = 0;
    public float y = 0;

    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    // Vector addition
    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x + b.x, a.y + b.y);
    }

    // Vector subtraction
    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x - b.x, a.y - b.y);
    }

    // Scalar multiplication
    public static Vector2 operator *(Vector2 vector, float scalar)
    {
        return new Vector2(vector.x * scalar, vector.y * scalar);
    }

    // Scalar division
    public static Vector2 operator /(Vector2 vector, float scalar)
    {
        if (scalar == 0)
            throw new DivideByZeroException("Division by zero.");

        return new Vector2(vector.x / scalar, vector.y / scalar);
    }

    // Calculate the magnitude (length) of the vector
    public float Magnitude()
    {
        return (float)Math.Sqrt(x * x + y * y);
    }

    // Normalize the vector (make it a unit vector)
    public Vector2 Normalize()
    {
        float magnitude = Magnitude();
        if (magnitude == 0)
            return new Vector2(0, 0);
        else
            return new Vector2(x / magnitude, y / magnitude);
    }

    public Vector2 Zero()
    {
        return new Vector2(0, 0);
    }
}