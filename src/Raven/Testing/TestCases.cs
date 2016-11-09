﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Controller;
using System.Diagnostics;

namespace Testing
{
    class TestCases
    {
        static Aplicador App;

        static void Main(string[] args)
        {
            RunWithTest("valid", GenerateAnswersForColorful());
            RunWithTest("invalid", GenerateInvalidAnswers(36));
            Console.ReadLine();
        }

        static void RunWithTest(string tag, int[] test)
        {
            Console.WriteLine($"--- # Testing {tag} test");
            App = new Aplicador("lil one", "cor", 10);
            Stopwatch clock = new Stopwatch();
            App.PrepararTeste();
            //Console.WriteLine("Momento inicial: " + App.MomentoInicial);
            //Console.WriteLine("Respostas dadas:");
            for (var i = 0; i < App.ObterTamanhoDoTeste(); ++i)
            {
                clock.Start();
                var resposta = test[i];
                //Console.WriteLine("- " + resposta);
                App.OuvirResposta(i, resposta);
                clock.Stop();
                App.OuvirDuracao(i, clock.ElapsedMilliseconds);
                clock.Reset();

            }
            Console.WriteLine("# Assessing results");
            Console.WriteLine($"Resultado calculado:\n\t{App.CalcularResultado()}");
            Console.WriteLine($"Percentil: {App.Percentil}");
            Console.WriteLine("No Respostas corretas: " + App.NoRespostasCorretas);
            Console.WriteLine();
            Console.WriteLine("# Turning stuff functional");
            var rsr = App.RelacionarSeriesERespostas();
            foreach (var key in rsr.Keys)
            {
                Console.WriteLine($"{key}: {rsr[key]}");
            }
        }

        static int[] GenerateAnswersForColorful()
        {
            return new int[] { 4, 5, 1, 2, 6, 3, 6, 2, 3, 4, 6, 5,
                               4, 5, 1, 6, 2, 1, 3, 3, 6, 4, 5, 5,
                               2, 6, 1, 2, 2, 1, 5 ,6 ,6 ,3, 4, 5, 5};
        }

        static int[] GenerateInvalidAnswers(int size)
        {
            List<int> answers = new List<int>();

            for (int i = 0; i < size; ++i)
            {
                answers.Add((i % 6) + 1);
            }

            return answers.ToArray();
        }
    }
}
