// See https://aka.ms/new-console-template for more information

using Dressing.Domain.Model.Commands;
using Dressing.Domain.Model.Dressings;
using Dressing.Domain.Model.Reports;
using Dressing.Domain.Model.Rules;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddTransient<ICommandCenter, CommandCenter>()
    .AddTransient<ICommandInvoker, CommandInvoker>()
    .AddTransient<ICommandParser, StringCommandParser>()
    .AddTransient<IDressingFactory, DressingFactory>()
    .AddTransient<IDressingReport, DressingReport>()
    .AddTransient<IRuleValidator, RuleValidator>()
    .BuildServiceProvider();

ICommandCenter commandCenter = serviceProvider.GetService<ICommandCenter>();

var commandStrings = new[]
            {
                "HOT 8, 6, 4, 2, 1, 7",
                "COLD 8, 6, 3, 4, 2, 5, 1, 7",
                "HOT 7",
                "HOT 8, 6, 6",
                "HOT 8, 6, 3",
                "COLD 8, 6, 3, 4, 2, 5, 7"
            };
foreach (var commandString in commandStrings)
{
    Console.WriteLine(commandString);
    commandCenter.Execute(commandString);
    Console.WriteLine();
}

Console.WriteLine("Hit <Enter> to exit...");
Console.Read();