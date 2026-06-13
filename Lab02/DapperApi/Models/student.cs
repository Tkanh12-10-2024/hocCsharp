using System;
namespace DapperApi.Models;

public class Student {
    public int ID {get;set;}
    public int age {get;set;}
    public string? name {get;set;} = "";
    public string? email {get;set;} = "";
}