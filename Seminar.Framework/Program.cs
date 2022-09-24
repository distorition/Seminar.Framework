using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar.Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.Title = Properties.Settings.Default.AplicationNameDebug;//AplicationNameDebug это наше св-ва которые мы задали через настройки проекта(его можно увидеть в св-ва проекта->параметры ) 
#else
            Console.Title = Properties.Settings.Default.ApplicationName;//в таких св-вах реализован толкь get потому что это насткройки самого приложения
#endif
            if(string.IsNullOrEmpty(Properties.Settings.Default.FIO)|| Properties.Settings.Default.Age <= 0)
            {
                Console.WriteLine("Enter Fio");
                Properties.Settings.Default.FIO =Console.ReadLine();//в этом св-ве реализован get и set потому что это св-ва пользователя   
                Console.WriteLine("Enter AGe");
                if(int.TryParse(Console.ReadLine(), out int age))
                {
                    Properties.Settings.Default.Age = age;
                }
                else
                {
                    Properties.Settings.Default.Age = 0;
                }
                Properties.Settings.Default.Save();
                Console.WriteLine($"FIO:{Properties.Settings.Default.FIO}");//при помощи таких св-в можно постоянно хранить как либо значения ( то есть они всегда будут запускаться с теми значениями что мы указываем когда запускаем наше приложения в первый раз)
                Console.WriteLine($"AGE:{Properties.Settings.Default.Age}");

            }

        }
    }
}
