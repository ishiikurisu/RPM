﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Controller;
using Raven.Model;

namespace Testing
{
    class TestCases
    {
        static Aplicador App;
        static Avaliador Eval;

        static void Main(string[] args)
        {
            RunWithTest("valid", GenerateAnswersForColorful());
            RunWithTest("invalid", GenerateInvalidAnswers(36));
            RunWithTest("partially correct", GenerateNotValidAnswers());
            //Console.ReadLine();
            //Console.Clear();
            RunWithEvaluator("valid", GenerateAnswersForColorful());
            RunWithEvaluator("invalid", GenerateInvalidAnswers(36));
            RunWithEvaluator("partially correct", GenerateNotValidAnswers());
            Console.ReadLine();
            Console.Clear();
        }

        static void RunWithTest(string tag, int[] test)
        {
            Console.WriteLine($"--- # Testing {tag} test");
            App = new Aplicador($"lil {tag} one", "cor", 10);
            App.PrepararTeste();
            Console.WriteLine($"Nome: {App.NomeSujeito}");
            Console.WriteLine($"Idade: {App.Idade}");
            //Console.WriteLine("Momento inicial: " + App.MomentoInicial);
            //Console.WriteLine("Respostas dadas:");
            Console.WriteLine($"Tamanho do teste: {App.ObterTamanhoDoTeste()}");
            for (var i = 0; i < App.ObterTamanhoDoTeste(); ++i)
            {
                App.Apresentar(i);
                var resposta = test[i];
                //Console.WriteLine("- " + resposta);
                App.OuvirResposta(i, resposta);
            }
            Console.WriteLine("# Assessing results");
            Console.WriteLine($"Resultado calculado: {App.CalcularResultado()}");
            Console.WriteLine($"Percentil: {App.Percentil}");
            Console.WriteLine("No Respostas corretas: " + App.NoRespostasCorretas);
            Console.WriteLine();
            App.RegistrarCronometro();
        }

        static void RunWithEvaluator(string tag, int[] test)
        {
            Console.WriteLine($"--- # Testing {tag} test");
            App = new Aplicador($"lil {tag} one", "cor", 5);
            App.PrepararTeste();
            Console.WriteLine($"Nome: {App.NomeSujeito}");
            for (var i = 0; i < App.ObterTamanhoDoTeste(); ++i)
            {
                App.Apresentar(i);
                var resposta = test[i];
                App.OuvirResposta(i, resposta);
            }
            Console.WriteLine("# Assessing results");
            Eval = new Avaliador(App);
            Console.WriteLine($"Percentil: {Eval.Percentil}");
            Console.WriteLine();
            App.RegistrarCronometro();
        }

        static int[] GenerateAnswersForColorful()
        {
            return new int[] { 4, 5, 1, 2, 6, 3, 6, 2, 3, 4, 6, 5,
                               4, 5, 1, 6, 2, 1, 3, 3, 6, 4, 5, 5,
                               2, 6, 1, 2, 2, 1, 5 ,6 ,6 ,3, 4, 5, 5};
        }

        static int[] GenerateNotValidAnswers()
        {
            return new int[] { 4, 5, 1, 2, 6, 3, 6, 2, 3, 4, 6, 5,
                               2, 6, 1, 2, 2, 1, 5 ,6 ,6 ,3, 4, 5,
                               1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5 };
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
