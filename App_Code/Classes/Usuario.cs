using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Usuario
/// </summary>
public class Usuario
{
    public int id { get; set; }
    public string email { get; set; }
    public string senha { get; set; }
    public string nome { get; set; }
    public string redirecionar { get; set; }
    
    public string tipo { get; set; }
}
