/******************************************************************************

                            Tarea 9 
                            Juan Daniel Ramírez Mojica

*******************************************************************************/
using System;
using System.Collections.Generic;

class Metodo_Diferencias
{
    //Método para construir: tabla de diferencias
    static List<List<double>> ConstruirTablaDeDiferencias(List<double> x, List<double> y)
    {
        int n = x.Count;
        List<List<double>> tabla = new List<List<double>>();

        //Se inicializa la primera columna de la tabla con los valores de y
        for (int i = 0; i < n; i++)
        {
            tabla.Add(new List<double>());
            tabla[i].Add(y[i]);
        }

        //Construir las diferencias finitas
        for (int j = 1; j < n; j++)
        {
            for (int i = 0; i < n - j; i++)
            {
                double diferencia = (tabla[i + 1][j - 1] - tabla[i][j - 1]) / (x[i + j] - x[i]);
                tabla[i].Add(diferencia);
            }
        }

        return tabla;
    }

    // Método para evaluar el polinomio en un valor  x usando la tabla
    static double EvaluarPolinomio(List<double> x, List<List<double>> tabla, double xInput)
    {
        int n = x.Count;
        double answ = tabla[0][0]; //el primer término f(x0)

        double multi = 1.0;
        for (int i = 1; i < n; i++)
        {
            multi *= (xInput - x[i - 1]);
            answ += multi * tabla[0][i]; //Se añade el término correspondiente
        }

        return answ;
    }



//Empeiza el código
    static void Main(string[] args)
    {
        //Ejemplo de puntos y valor de x para que el usuario se guie
        Console.WriteLine("Ejemplo de entrada:");
        Console.WriteLine("Puntos (x, y):");
        Console.WriteLine("x0 = 0, y0 = 1");
        Console.WriteLine("x1 = 1, y1 = 2");
        Console.WriteLine("x2 = 2, y2 = 0");
        Console.WriteLine("x3 = 3, y3 = 5");
        Console.WriteLine("El valor de x a evaluar será: 2.5");
        Console.WriteLine("Resultado esperado: Aproximación del polinomio en x = ...");
        Console.WriteLine();

        //Solicitar  el número de puntos
        Console.Write("Ingrese el número de puntos: ");
        int n = Convert.ToInt32(Console.ReadLine());

        //Listas para almacenar los valores de x , y 
        List<double> x = new List<double>();
        List<double> y = new List<double>();

        // Solicitar los valores de x, y
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Ingrese el valor de x{i}: ");
            x.Add(Convert.ToDouble(Console.ReadLine()));

            Console.Write($"Ingrese el valor de y{i}: ");
            y.Add(Convert.ToDouble(Console.ReadLine()));
        }

        //Construir tabla de diferencias
        var tabla = ConstruirTablaDeDiferencias(x, y);

        //Mostrar la tabla
        Console.WriteLine("\nTabla de Diferencias:");
        for (int i = 0; i < x.Count; i++)
        {
            Console.Write($"X{i}: ");
            foreach (var item in tabla[i])
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        //Solicitar el valor de x para evaluar el polinomio
        Console.Write("\nIngrese el valor de X para evaluar el polinomio: ");
        double xInput = Convert.ToDouble(Console.ReadLine());

        //Evaluar el polinomio
        double answ = EvaluarPolinomio(x, tabla, xInput);
        Console.WriteLine($"El valor aproximado del polinomio en x = {xInput} es: {answ}");
    }
}


