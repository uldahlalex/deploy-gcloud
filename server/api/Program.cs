// Copyright 2022 Google Inc.

using System;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";
var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";

var app = builder.Build();

app.MapGet("/", () => $"Hello {target}!");

Console.WriteLine(JsonSerializer.Serialize(Environment.GetEnvironmentVariables()));
app.Run(url);