using System;
using System.Net.NetworkInformation;

public interface ICommand
{
    string Name { get; }
    void Execute();
}
