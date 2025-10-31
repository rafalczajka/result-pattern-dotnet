using System;
using SimpleApp;

const decimal a = 4;
const decimal b = 0;

var result = SimpleService.Divide(a, b);

var resultMessage = result.Match(
    r => $"{a} / {b} = {r}",
    e => e.Message);

Console.WriteLine(resultMessage);
