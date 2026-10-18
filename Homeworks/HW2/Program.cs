using System;
using System.Collections.Generic;
using System.Linq;

class Polynomial
{
    private List<double> _coefs;
    public IReadOnlyList<double> Coefs => _coefs;

    public Polynomial(IEnumerable<double> coefs)
    {
        _coefs = coefs.ToList();
    }

    public double Evaluate(double x)
    {
        double result = 0;
        for (int i = _coefs.Count - 1; i >= 0; i--)
            result = result * x + _coefs[i];
        return result;
    }

    public double this[int i]
    {
        get => _coefs[i];
        set => _coefs[i] = value;
    }

    public override string ToString()
    {
        var terms = new List<string>();
        for (int i = 0; i < _coefs.Count; i++)
        {
            double c = _coefs[i];
            if (i == 0) terms.Add($"{c}");
            else if (i == 1) terms.Add($"{c}x");
            else terms.Add($"{c}x^{i}");
        }
        return "P(x) = " + string.Join(" + ", terms);
    }


    public void PrintCoefs()
    {
        Console.WriteLine("Коэффициенты полинома:");
        for (int i = 0; i < _coefs.Count; i++)
        {
            Console.WriteLine($"  x^{i}: {_coefs[i]}");
        }
    }

    // Метод сложения двух полиномов
    public Polynomial Add(Polynomial other)
    {
        int maxLen = Math.Max(_coefs.Count, other._coefs.Count);
        List<double> result = new List<double>(new double[maxLen]);

        for (int i = 0; i < _coefs.Count; i++)
            result[i] += _coefs[i];

        for (int i = 0; i < other._coefs.Count; i++)
            result[i] += other._coefs[i];

        return new Polynomial(result);
    }
}

class Program
{
    static void Main()
    {
        Polynomial p1 = new Polynomial(new double[] { 1, 2, 3 });
        Polynomial p2 = new Polynomial(new double[] { 4, 5 });

        Console.WriteLine("Первый полином: " + p1);
        Console.WriteLine("Второй полином: " + p2);

        Console.WriteLine("\nКоэффициенты первого полинома:");
        p1.PrintCoefs();

        Polynomial sum = p1.Add(p2);
        Console.WriteLine("\nСумма полиномов: " + sum);
    }
}