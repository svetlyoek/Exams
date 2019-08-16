using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var hospital = new Dictionary<string, Dictionary<int, List<string>>>();
            var doctorPatients = new Dictionary<string, List<string>>();

            string text = string.Empty;

            while ((text = Console.ReadLine()) != "Output")
            {
                string[] info = text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string department = info[0];
                string doctor = info[1] + " " + info[2];
                string patient = info[3];

                if (!doctorPatients.ContainsKey(doctor))
                {
                    doctorPatients.Add(doctor, new List<string>());
                }

                doctorPatients[doctor].Add(patient);

                if (hospital.ContainsKey(department))
                {
                    if (hospital[department].Values.Count > 20)
                    {
                        continue;
                    }
                    else
                    {
                        if (hospital[department][hospital[department].Values.Count].Count == 3)
                        {
                            hospital[department].Add(hospital[department].Values.Count + 1, new List<string>());
                            hospital[department][hospital[department].Values.Count].Add(patient);
                        }
                        else
                        {
                            hospital[department][hospital[department].Values.Count].Add(patient);
                        }
                    }
                }
                else
                {
                    hospital.Add(department, new Dictionary<int, List<string>>());
                    hospital[department].Add(1, new List<string>());
                    hospital[department][1].Add(patient);
                }

            }

            string command = string.Empty;

            while ((command = Console.ReadLine().Trim()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens.Length == 1)
                {
                    if (hospital.ContainsKey(tokens[0]))
                    {
                        foreach (var dep in hospital[tokens[0]])
                        {
                            foreach (var patient in dep.Value)
                            {
                                Console.WriteLine(patient);
                            }
                        }

                    }
                }
                else
                {

                    if (doctorPatients.ContainsKey(tokens[0] + " " + tokens[1]))
                    {
                        foreach (var kvp in doctorPatients[tokens[0] + " " + tokens[1]].OrderBy(x => x))
                        {

                            Console.WriteLine(kvp);
                        }
                    }
                    else
                    {
                        if (hospital.ContainsKey(tokens[0]) && hospital[tokens[0]].ContainsKey(int.Parse(tokens[1])))
                        {
                            foreach (var kvp in hospital[tokens[0]][int.Parse(tokens[1])].OrderBy(x => x))
                            {
                                Console.WriteLine(kvp);
                            }
                        }
                    }
                }
            }
        }
    }
}
        
    




