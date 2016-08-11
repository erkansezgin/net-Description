# Description

[![][build-img]][build]
[![][nuget-img]][nuget]

Get the [DescriptionAttribute] text from classes, enum values, properties and others.

[build]:                https://ci.appveyor.com/project/TallesL/net-Description
[build-img]:            https://ci.appveyor.com/api/projects/status/github/tallesl/net-Description?svg=true
[nuget]:                https://www.nuget.org/packages/Description
[nuget-img]:            https://badge.fury.io/nu/Description.svg
[DescriptionAttribute]: https://msdn.microsoft.com/library/System.ComponentModel.DescriptionAttribute

## Usage

```cs
using System.ComponentModel;
using DescriptionLibrary;

public enum StarterPokemon
{
    [Description("It can go for days without eating a single morsel. In the bulb on its back, it stores energy.")]
    Bulbasaur,

    [Description("The flame at the tip of its tail makes a sound as it burns. You can only hear it in quiet places.")]
    Charmander,

    [Description("Shoots water at prey while in the water. Withdraws into its shell when in danger.")]
    Squirtle,
}

Console.WriteLine("Bulbasaur: {0}", StarterPokemon.Bulbasaur.Description());
Console.WriteLine("Charmander: {0}", StarterPokemon.Charmander.Description());
Console.WriteLine("Squirtle: {0}", StarterPokemon.Squirtle.Description());
```