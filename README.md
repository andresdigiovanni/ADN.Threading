# Threading Library for .NET

ADN.Threading is a cross-platform open-source library which provides graphs utilities to .NET developers.

[![Build Status](https://travis-ci.org/andresdigiovanni/ADN.Threading.svg?branch=master)](https://travis-ci.org/andresdigiovanni/ADN.Threading)
[![NuGet](https://img.shields.io/nuget/v/ADN.Threading.svg)](https://www.nuget.org/packages/ADN.Threading/)
[![BCH compliance](https://bettercodehub.com/edge/badge/andresdigiovanni/ADN.Threading?branch=master)](https://bettercodehub.com/)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=andresdigiovanni_ADN.Threading&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=andresdigiovanni_ADN.Threading)
[![Quality](https://sonarcloud.io/api/project_badges/measure?project=andresdigiovanni_ADN.Threading&metric=alert_status)](https://sonarcloud.io/dashboard?id=andresdigiovanni_ADN.Threading)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Basic usage

Example safe overlap timer with try enter:

```csharp
public void Foo(object state) { }

object state = new object();
int dueTime = 0;
int period = 10;

var timer = new TimerWithTryEnter(Foo, state, dueTime, period);
```

## Installation

ADN.Threading runs on Windows, Linux, and macOS.

Once you have an app, you can install the ADN.Threading NuGet package from the NuGet package manager:

```
Install-Package ADN.Threading
```

Or alternatively you can add the ADN.Threading package from within Visual Studio's NuGet package manager.

## Examples

Please find examples and the documentation at the [wiki](https://github.com/andresdigiovanni/ADN.Threading/wiki) of this repository.

## Contributing

We welcome contributions! Please review our [contribution guide](CONTRIBUTING.md).

## License

ADN.Threading is licensed under the [MIT license](LICENSE).
