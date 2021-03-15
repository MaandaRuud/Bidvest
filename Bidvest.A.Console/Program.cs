using Bidvest.C.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Bidvest.A._Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appSettings.json")
                  .Build();

                var appConfig = builder.GetSection("Application").Get<Application>(); ;

                List<Employee> employees = new List<Employee>();

                string line;
                using (StreamReader file = new StreamReader(appConfig.InputPath))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] record = line.Split("|");
                        if (record.Length > 4)
                        {
                            employees.Add(new Employee()
                            {
                                IPAddress = record[5],
                                Email = record[3],
                                Firstname = record[1],
                                Gender = record[4],
                                Id = int.Parse(record[0]),
                                Surname = record[2],
                            });
                        }
                    }
                }
                string fileName = appConfig.OutputPath;

                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file    
                    Byte[] json = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(employees));
                    fs.Write(json, 0, json.Length);
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        public class Application
        {
            public string InputPath { get; set; }
            public string OutputPath { get; set; }
        }
    }
}