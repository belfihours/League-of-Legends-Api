using System.Text.Json.Serialization;

namespace League.Service.Dtos;

[Serializable]
public class StatDto
{
    [JsonPropertyName("hp")]
    public double Hp { get; set; }
    [JsonPropertyName("hpperlevel")]
    public double Hpperlevel {get;set;}
    [JsonPropertyName("mp")]
    public double Mp {get;set;}
    [JsonPropertyName("mpperlevel")]
    public double Mpperlevel {get;set;}
    [JsonPropertyName("movespeed")]
    public double Movespeed {get;set;}
    [JsonPropertyName("armor")]
    public double Armor {get;set;}
    [JsonPropertyName("armorperlevel")]
    public double Armorperlevel {get;set;}
    [JsonPropertyName("spellblock")]
    public double Spellblock {get;set;}
    [JsonPropertyName("spellblockperlevel")]
    public double Spellblockperlevel {get;set;}
    [JsonPropertyName("attackrange")]
    public double Attackrange {get;set;}
    [JsonPropertyName("hpregen")]
    public double Hpregen {get;set;}
    [JsonPropertyName("hregenperlevel")]
    public double Hregenperlevel {get;set;}
    [JsonPropertyName("mpregen")]
    public double Mpregen {get;set;}
    [JsonPropertyName("mpregenperlevel")]
    public double Mpregenperlevel {get;set;}
    [JsonPropertyName("crit")]
    public double Crit {get;set;}
    [JsonPropertyName("critperlevel")]
    public double Critperlevel {get;set;}
    [JsonPropertyName("attackdamage")]
    public double Attackdamage {get;set;}
    [JsonPropertyName("attackdamageperlevel")]
    public double Attackdamageperlevel {get;set;}
    [JsonPropertyName("attackspeedperlevel")]
    public double Attackspeedperlevel {get;set;}
    [JsonPropertyName("attackspeed")]
    public double Attackspeed {get;set;}
}
