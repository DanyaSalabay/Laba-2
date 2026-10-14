using System;

internal class Polyline
{
    private Point[] points;

    public Polyline()
    {
        this.points = new Point[0];
    }

    public Polyline(Point[] points)
    {
        this.points = points;
    }

    public Point[] Points
    {
        get { return this.points; }
    }

    public void AddPoint(Point point)
    {
        Point[] newPoints = new Point[points.Length + 1];

        for (int i = 0; i < points.Length; i++)
        {
            newPoints[i] = points[i];
        }

        newPoints[points.Length] = point;
        this.points = newPoints;
    }

    public void AddPoints(Point[] newPoints)
    {
        for (int i = 0; i < newPoints.Length; i++)
        {
            AddPoint(newPoints[i]);
        }
    }

    public double GetLength()
    {
        double length = 0;

        for (int i = 0; i < points.Length - 1; i++)
        {
            double dx = points[i + 1].X - points[i].X;
            double dy = points[i + 1].Y - points[i].Y;
            length += Math.Sqrt(dx * dx + dy * dy);
        }

        return length;
    }

    public override string ToString()
    {
        string result = "Линия [";

        for (int i = 0; i < points.Length; i++)
        {
            result += points[i].ToString();

            if (i < points.Length - 1)
            {
                result += ",";
            }
        }

        result += "]";
        return result;
    }
}
