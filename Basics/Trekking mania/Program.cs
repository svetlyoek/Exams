using System;

namespace Trekking_mania
{
    class Program
    {
        static void Main(string[] args)
        {
            double groupCount = double.Parse(Console.ReadLine());
            double musalaPerc = 0;
            double monblanPerc = 0;
            double k2Perc = 0;
            double everestPerc = 0;
            double kilimPerc = 0;
            double allPeople = 0;
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            double sum4 = 0;
            double sum5 = 0;
            for (int i = 1; i <= groupCount; i++)
            {
                double peopleInGroup = double.Parse(Console.ReadLine());


                if (peopleInGroup <= 5)
                {

                    sum1 += peopleInGroup;

                }
                else if (peopleInGroup >= 6 && peopleInGroup <= 12)
                {
                    sum2 += peopleInGroup;

                }
                else if (peopleInGroup >= 13 && peopleInGroup <= 25)
                {
                    sum3 += peopleInGroup;

                }
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                {
                    sum4 += peopleInGroup;

                }
                else if (peopleInGroup >= 41)
                {
                    sum5 += peopleInGroup;

                }



            }
            allPeople = sum1 + sum2 + sum3 + sum4 + sum5;
            musalaPerc = (sum1 / allPeople) * 100;
            monblanPerc = (sum2 / allPeople) * 100;
            kilimPerc = (sum3 / allPeople) * 100;
            k2Perc = (sum4 / allPeople) * 100;
            everestPerc = (sum5 / allPeople) * 100;
            Console.WriteLine("{0:f2}%", musalaPerc);
            Console.WriteLine("{0:f2}%", monblanPerc);
            Console.WriteLine("{0:f2}%", kilimPerc);
            Console.WriteLine("{0:f2}%", k2Perc);
            Console.WriteLine("{0:f2}%", everestPerc);
        }
    }
}
