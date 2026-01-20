using System;
using System.Collections.Generic;
using System.Threading;
using Sys = Cosmos.System;

namespace GooberOS
{
    public class Kernel : Sys.Kernel
    {
        private DateTime _bootTime;
        private readonly List<CommandInfo> _commands = new List<CommandInfo>();
        protected override void BeforeRun()
        {
            _bootTime = DateTime.UtcNow;
            _commands.Add(new CommandInfo("hello", "Greets the user.", Greet));
            _commands.Add(new CommandInfo("uptime", "Shows how long GooberOS has been running.", UpTime));
            _commands.Add(new CommandInfo("exit", "Shuts down the machine.", Exit));
            _commands.Add(new CommandInfo("reboot", "Restarts the machine.", Reboot));
            _commands.Add(new CommandInfo("help", "Lists available commands.", Help));

            Console.WriteLine("Welcome to GooberOS!");
            Console.WriteLine("Type 'help' to see available commands.");
        }
        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine()?.ToLower();

            if (string.IsNullOrEmpty(input))
                return;
            bool found = false;
            foreach (var cmd in _commands)
            {
                if (cmd.Name == input)
                {
                    cmd.Handler();
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine($"Unknown command: {input}");
            }
        }
        private void Greet() => Console.WriteLine("\nHello World!\n");
        private void UpTime()
        {
            var upTime = DateTime.UtcNow - _bootTime;
            Console.WriteLine($"Uptime: {upTime.Days}d {upTime.Hours}h {upTime.Minutes}m {upTime.Seconds}s");
        }
        private void Exit()
        {
            Console.WriteLine("Exiting GooberOS. Goodbye!");
            Thread.Sleep(1500);
            Sys.Power.Shutdown();
        }
        private void Reboot()
        {
            Console.WriteLine("Rebooting GooberOS...");
            Thread.Sleep(1500);
            Sys.Power.Reboot();
        }
        private void Help()
        {
            Console.WriteLine("Available commands:");
            foreach (var cmd in _commands)
            {
                Console.WriteLine($"- {cmd.Name}: {cmd.Description}");
            }
        }
        private class CommandInfo
        {
            public string Name { get; }
            public string Description { get; }
            public Action Handler { get; }
            public CommandInfo(string name, string description, Action handler)
            {
                Name = name;
                Description = description;
                Handler = handler;
            }
        }
    }
}