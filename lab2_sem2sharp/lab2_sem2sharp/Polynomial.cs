using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_sem2sharp
{
    class Polynomial
    {
        private List<double> coefficients = new List<double>();

        public Polynomial()
        {
            coefficients.Add(0.0d);
        }
        public Polynomial(params double[] coef)
        {
            for (int i = 0; i < coef.Length; i++)
            {
                coefficients.Add(coef[i]);
            }
            DeleteZero();
        }
        public Polynomial(Polynomial polyCopy)
        {
            for (int i = 0; i <= polyCopy.Step; i++)
            {
                coefficients.Add(polyCopy.GetCoefficient(i));
            }
            DeleteZero();
        }

        public double this[int i]
        {
            get
            {
                return GetCoefficient(i);
            }
        }
        public int Step
        {
            get
            {
                return coefficients.Count - 1;
            }
        }

        public double GetCoefficient(int i)
        {
            if (i < 0)
                throw new IndexOutOfRangeException("Многочлен не имеет членов с отрицательными степенями!");
            else if (i > Step)
                throw new IndexOutOfRangeException(string.Format("Степень многочлена меньше указанного числа! Step = {0}", Step));
            return coefficients[i];
        }
        public double GetValue(double x)
        {
            double result = 0;
            for (int i = 0; i <= Step; i++)
            {
                result += coefficients[i] * Math.Pow(x, i);
            }
            return result;
        }

        public static Polynomial operator+(Polynomial poly1, Polynomial poly2)
        {
            double[] coef = new double[Math.Max(poly1.Step, poly2.Step) + 1];

            int minIndex = Math.Min(poly1.Step, poly2.Step) + 1;

            for (int i = 0; i < minIndex; i++)
            {
                coef[i] = poly1[i] + poly2[i];
            }
            for (int i = minIndex; i < coef.Length; i++)
            {
                if (poly1.Step >= i)
                    coef[i] = poly1[i];
                else
                    coef[i] = poly2[i];
            }

            return new Polynomial(coef);
        }
        public static Polynomial operator-(Polynomial poly)
        {
            double[] coef = new double[poly.Step + 1];
           
            for (int i = 0; i <= poly.Step; i++)
            {
                coef[i] = -poly[i];
            }

            return new Polynomial(coef);
        }
        public static Polynomial operator-(Polynomial poly1, Polynomial poly2)
        {
            return poly1 + (-poly2);
        }
        public static Polynomial operator*(Polynomial poly1, Polynomial poly2)
        {
            double[] coef = new double[poly1.Step + poly2.Step + 1];

            for (int i = 0; i <= poly1.Step; i++)
            {
                for (int j = 0; j <= poly2.Step; j++)
                {
                    coef[i + j] += poly1[i] * poly2[j];
                }
            }

            return new Polynomial(coef);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Insert(0, "Polynomial: \n P (x) = ");
            
            for (int i = 0; i < Step; i++)
            {
                str.Insert(str.Length - 1, 
                           string.Format(" {0} * x ^ {1} {2} ", Math.Abs(coefficients[i]),
                                                               i, 
                                                               coefficients[i + 1] > 0 ? '+' : '-'));
            }

            str.Insert(str.Length - 1, Math.Abs(coefficients[Step])  + string.Format(" * x ^ {0} \n", Step));

            return str.ToString();
        }
        public void WritePoly()
        {
            Console.WriteLine(ToString());
        }

        private void DeleteZero()
        {
            int i = Step;
            while (coefficients[i] == 0 && i > 0)
            {
                coefficients.Remove(coefficients[i]);
                i--;
            }
        }
    }
}
