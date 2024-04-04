using System;
using System.Collections.Generic;

namespace Practice4_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinearSystemFactory factory = null;
            Console.WriteLine("Choose type of linear system: 2D or 3D");
            var result = Console.ReadLine();

            while (result != "2D" && result != "3D")
            {
                result = Console.ReadLine();
            }
            if (result == "2D")
            {
                factory = new LinearSystem2DFactory();
            }
            else if (result == "3D")
            {
                factory = new LinearSystem3DFactory();
            }
            LinearSystem system = factory.CreateLinearSystem(result);
            system.GetValues();
            system.IsSatisfiedByVector();
        }
    }

    public abstract class LinearSystem
    {
        public List<double> ConstantTerms { get; set; }

        public abstract void GetValues();

        public abstract bool IsSatisfiedByVector();
    }

    public class LinearSystem2D : LinearSystem
    {
        public List<double> Coefficients1 { get; set; }
        public List<double> Coefficients2 { get; set; }

        public LinearSystem2D()
        {
            Coefficients1 = new List<double>();
            Coefficients2 = new List<double>();
            ConstantTerms = new List<double>();
        }

        public override string ToString()
        {
            string equationString1 = "";
            for (int i = 0; i < Coefficients1.Count; i++)
            {
                if (Coefficients1[i] != 0)
                {
                    if (i < Coefficients1.Count - 1 && Coefficients1[i + 1] < 0)
                    {
                        equationString1 += $"{Coefficients1[i]}x{i + 1} ";
                    }
                    else if (i < Coefficients1.Count - 1)
                    {
                        equationString1 += $"{Coefficients1[i]}x{i + 1} + ";
                    }
                    else
                    {
                        equationString1 += $"{Coefficients1[i]}x{i + 1} ";
                    }
                }
                else
                {
                    if (i < Coefficients1.Count - 1)
                    {
                        equationString1 += $"x{i + 1} + ";
                    }
                    else
                    {
                        equationString1 += $"x{i + 1} ";
                    }
                }
            }
            equationString1 += $"= {ConstantTerms[0]}";
            string equationString2 = "";
            for (int i = 0; i < Coefficients2.Count; i++)
            {
                if (Coefficients2[i] != 0)
                {
                    if (i < Coefficients2.Count - 1 && Coefficients2[i + 1] < 0)
                    {
                        equationString2 += $"{Coefficients2[i]}x{i + 1} ";
                    }
                    else if (i < Coefficients2.Count - 1)
                    {
                        equationString2 += $"{Coefficients2[i]}x{i + 1} + ";
                    }
                    else
                    {
                        equationString2 += $"{Coefficients2[i]}x{i + 1} ";
                    }
                }
                else
                {
                    if (i < Coefficients2.Count - 1)
                    {
                        equationString2 += $"x{i + 1} + ";
                    }
                    else
                    {
                        equationString2 += $"x{i + 1} ";
                    }
                }
            }
            equationString2 += $"= {ConstantTerms[1]}";
            string totalEquations = $"{equationString1 + '\n' + equationString2}";
            return totalEquations;
        }
        public override void GetValues()
        {
            int x = 2;
            double str = 0;
            Console.WriteLine("2D linear system was created. Please enter coefficients for the first equation: ");
            for (int i = 0; i < x; i++)
            {
                str = Double.Parse(Console.ReadLine());
                Coefficients1.Add(str);
            }
            Console.WriteLine("Please enter coefficients for the second equation: ");
            for (int i = 0; i < x; i++)
            {
                str = Double.Parse(Console.ReadLine());
                Coefficients2.Add(str);
            }
            Console.WriteLine("Please enter constant terms for the equations (in order): ");
            for (int i = 0; i < x; i++)
            {
                str = Double.Parse(Console.ReadLine());
                ConstantTerms.Add(str);
            }
            Console.WriteLine(this);
        }

        public override bool IsSatisfiedByVector()
        {
            double[] vector = new double[2];
            Console.WriteLine("\nIf you want to check if the vector is appropriate to this.");
            Console.WriteLine("Enter x1 coordinate:");
            vector[0] = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter x2 coordinate:");
            vector[1] = double.Parse(Console.ReadLine());

            Console.WriteLine($"x1 coordinate: {vector[0]}, x2 coordinate: {vector[1]}");

            if (vector == null || vector.Length != 2)
            {
                throw new ArgumentException("Vector size must match the number of variables in the equation");
            }

            double result1 = 0;
            double result2 = 0;
            int index = 0;
            for (int i = 0; i < Coefficients1.Count; i++)
            {
                result1 += Coefficients1[i] * vector[index];
                index++;
            }
            index = 0;
            for (int i = 0; i < Coefficients2.Count; i++)
            {
                result2 += Coefficients2[i] * vector[index];
                index++;
            }
            if (result1 == ConstantTerms[0] && result2 == ConstantTerms[1])
            {
                Console.WriteLine("True" + '\n');
                return true;
            }
            Console.WriteLine("False" + '\n');
            return false;
        }
    
    }

    public class LinearSystem3D : LinearSystem
    {
        public List<double> Coefficients1 { get; set; }
        public List<double> Coefficients2 { get; set; }
        public List<double> Coefficients3 { get; set; }

        public LinearSystem3D()
        {
            Coefficients1 = new List<double>();
            Coefficients2 = new List<double>();
            Coefficients3 = new List<double>();
            ConstantTerms = new List<double>();
        }

        public override string ToString()
        {
            string equationString1 = "";
            for (int i = 0; i < Coefficients1.Count; i++)
            {
                if (Coefficients1[i] != 0)
                {
                    if (i < Coefficients1.Count - 1 && Coefficients1[i + 1] < 0)
                    {
                        equationString1 += $"{Coefficients1[i]}x{i + 1} ";
                    }
                    else if (i < Coefficients1.Count - 1)
                    {
                        equationString1 += $"{Coefficients1[i]}x{i + 1} + ";
                    }
                    else
                    {
                        equationString1 += $"{Coefficients1[i]}x{i + 1} ";
                    }
                }
                else
                {
                    if (i < Coefficients1.Count - 1)
                    {
                        equationString1 += $"x{i + 1} + ";
                    }
                    else
                    {
                        equationString1 += $"x{i + 1} ";
                    }
                }
            }
            equationString1 += $"= {ConstantTerms[0]}";
            string equationString2 = "";
            for (int i = 0; i < Coefficients2.Count; i++)
            {
                if (Coefficients2[i] != 0)
                {
                    if (i < Coefficients2.Count - 1 && Coefficients2[i + 1] < 0)
                    {
                        equationString2 += $"{Coefficients2[i]}x{i + 1} ";
                    }
                    else if (i < Coefficients2.Count - 1)
                    {
                        equationString2 += $"{Coefficients2[i]}x{i + 1} + ";
                    }
                    else
                    {
                        equationString2 += $"{Coefficients2[i]}x{i + 1} ";
                    }
                }
                else
                {
                    if (i < Coefficients2.Count - 1)
                    {
                        equationString2 += $"x{i + 1} + ";
                    }
                    else
                    {
                        equationString2 += $"x{i + 1} ";
                    }
                }
            }
            equationString2 += $"= {ConstantTerms[1]}";

            string equationString3 = "";
            for (int i = 0; i < Coefficients3.Count; i++)
            {
                if (Coefficients3[i] != 0)
                {
                    if (i < Coefficients3.Count - 1 && Coefficients3[i + 1] < 0)
                    {
                        equationString3 += $"{Coefficients3[i]}x{i + 1} ";
                    }
                    else if (i < Coefficients3.Count - 1)
                    {
                        equationString3 += $"{Coefficients3[i]}x{i + 1} + ";
                    }
                    else
                    {
                        equationString3 += $"{Coefficients3[i]}x{i + 1} ";
                    }
                }
                else
                {
                    if (i < Coefficients3.Count - 1)
                    {
                        equationString3 += $"x{i + 1} + ";
                    }
                    else
                    {
                        equationString3 += $"x{i + 1} ";
                    }
                }
            }
            equationString3 += $"= {ConstantTerms[2]}";

            string totalEquations = $"{equationString1}\n{equationString2}\n{equationString3}";
            return totalEquations;
        }

        public override void GetValues()
        {
            int x = 3;
            double str = 0;
            Console.WriteLine("3D linear system was created. Please enter coefficients for the first equation: ");
            for (int i = 0; i < x; i++)
            {
                str = Double.Parse(Console.ReadLine());
                Coefficients1.Add(str);
            }
            Console.WriteLine("Please enter coefficients for the second equation: ");
            for (int i = 0; i < x; i++)
            {
                str = Double.Parse(Console.ReadLine());
                Coefficients2.Add(str);
            }
            Console.WriteLine("Please enter coefficients for the second equation: ");
            for (int i = 0; i < x; i++)
            {
                str = Double.Parse(Console.ReadLine());
                Coefficients3.Add(str);
            }
            Console.WriteLine("Please enter constant terms for the equations (in order): ");
            for (int i = 0; i < x; i++)
            {
                str = Double.Parse(Console.ReadLine());
                ConstantTerms.Add(str);
            }
            Console.WriteLine(this);
        }
        public override bool IsSatisfiedByVector()
        {
            double[] vector = new double[3];

            Console.WriteLine("Type vector coordinates");
            Console.WriteLine("Enter x1 coordinate:");
            vector[0] = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter x2 coordinate:");
            vector[1] = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter x3 coordinate:");
            vector[2] = double.Parse(Console.ReadLine());

            Console.WriteLine($"x1 coordinate: {vector[0]}, x2 coordinate: {vector[1]}, x3 coordinate: {vector[2]}");

            if (vector == null || vector.Length != 3)
            {
                throw new ArgumentException("Vector size must match the number of variables in the equation");
            }

            double result1 = 0;
            double result2 = 0;
            double result3 = 0;
            int index = 0;
            for (int i = 0; i < Coefficients1.Count; i++)
            {
                if (Coefficients1[i] == 0)
                {
                    result1 += vector[index];
                }
                else
                {
                    result1 += Coefficients1[i] * vector[index];
                }
                index++;
            }
            index = 0;
            for (int i = 0; i < Coefficients2.Count; i++)
            {
                if (Coefficients2[i] == 0)
                {
                    result1 += vector[index];
                }
                else
                {
                    result2 += Coefficients2[i] * vector[index];
                }
                index++;
            }
            index = 0;
            for (int i = 0; i < Coefficients3.Count; i++)
            {
                if (Coefficients3[i] == 0)
                {
                    result3 += vector[index];
                }
                else
                {
                    result3 += Coefficients3[i] * vector[index];
                }
                index++;
            }
            if (result1 == ConstantTerms[0] && result2 == ConstantTerms[1] && result3 == ConstantTerms[2])
            {
                Console.WriteLine("True" + '\n');
                return true;
            }
            Console.WriteLine("False" + '\n');
            return false;
        }
    }

    public abstract class LinearSystemFactory
    {
        public abstract LinearSystem CreateLinearSystem(string type);
    }

    public class LinearSystem2DFactory : LinearSystemFactory
    {
        public override LinearSystem CreateLinearSystem(string type)
        {
            return new LinearSystem2D();
        }
    }

    public class LinearSystem3DFactory : LinearSystemFactory
    {
        public override LinearSystem CreateLinearSystem(string type)
        {
            return new LinearSystem3D();
        }
    }
}
