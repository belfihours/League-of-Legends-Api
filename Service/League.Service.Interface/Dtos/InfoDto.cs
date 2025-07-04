﻿using System.Text.Json.Serialization;

namespace League.Service.Dtos;

[Serializable]
public class InfoDto
{
    [JsonPropertyName("attack")]
    public int Attack { get; set; }
    [JsonPropertyName("defense")]
    public int Defense {get;set;}
    [JsonPropertyName("magic")]
    public int Magic {get;set;}
    [JsonPropertyName("difficulty")]
    public int Difficulty {get;set;}
}
