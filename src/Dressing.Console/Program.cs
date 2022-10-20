// See https://aka.ms/new-console-template for more information

using Dressing.Domain.Model.Commands;
using Dressing.Domain.Model.Dressings;
using Dressing.Domain.Model.Reports;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddTransient<ICommandCenter, CommandCenter>()
    .AddTransient<ICommandInvoker, CommandInvoker>()
    .AddTransient<ICommandParser, StringCommandParser>()
    .AddTransient<IDressingFactory, DressingFactory>()
    .AddTransient<IDressingReport, DressingReport>()
    .BuildServiceProvider();

ICommandCenter commandCenter = serviceProvider.GetService<ICommandCenter>();

commandCenter.Execute("HOT 8, 6, 4, 2, 1, 7");

Console.WriteLine("Hit <Enter> to exit...");
Console.Read();