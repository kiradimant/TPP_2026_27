using System;
using System.Collections.Generic;

class Program {
    
    // Функция вывода баланса (с опциональным параметром валюты)
    static void PrintBalance(double balance, string currency = "₽") {
        Console.WriteLine($"Баланс: {balance}");
    }

    // Функция пополнения счёта
    static void Deposit(ref double balance, List<string> history) {
        Console.Write("Введите сумму для пополнения(>0): ");
        double platej = double.Parse(Console.ReadLine());
        
        if (platej <= 0) {
            Console.WriteLine("Платёж <=0. нельзя ");
        } else {
            balance += platej;
            history.Add($"Пополнение: +{platej}");
        }
    }

    // Функция снятия денег (исправлена логика проверок)
    static void Withdraw(ref double balance, List<string> history) {
        Console.Write("Введите сумму для снятия(>0)");
        double minus = double.Parse(Console.ReadLine());

        if (minus <= 0) {
            Console.WriteLine("сумма <=0. нельзя");
        } else if (minus > balance) {
            Console.WriteLine("Недостатоно средств");
        } else {
            balance -= minus;
            history.Add($"Вычет: -{minus}");
        }
    }

    // Функция вывода истории через цикл for
    static void ShowHistory(List<string> history) {
        if (history.Count == 0) {
            Console.WriteLine("История пуста");
        } else {
            Console.WriteLine("История операций:");
            for (int i = 0; i < history.Count; i++) {
                Console.WriteLine($"{i + 1}. {history[i]}");
            }
        }
    }

    static void Main() {
        Console.Write("Введите начальный баланс");
        double blc = double.Parse(Console.ReadLine());
        string ans = "";
        List<string> history = new List<string>();

        while (ans != "0") {
            Console.WriteLine("1. Показать баланс");
            Console.WriteLine("2. Пополнить счёт");
            Console.WriteLine("3. Снять деньги");
            Console.WriteLine("4. Показать историю операций");
            Console.WriteLine("0. Выйти");
            ans = Console.ReadLine();

            if (ans == "1") {
                PrintBalance(blc);
            }
            else if (ans == "2") {
                Deposit(ref blc, history);
            }
            else if (ans == "3") {
                Withdraw(ref blc, history);
            }
            else if (ans == "4") {
                ShowHistory(history);
            }
            else if (ans == "0") {
                break;
            }
        }
    }
}