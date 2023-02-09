#nullable disable
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models;

public class ToDo
{
    public int ToDoId { get; set; }

    [Required(ErrorMessage = "El campo es requerido")]
    [MinLength(5, ErrorMessage = "El campo tiene que tener un minimo de 5 caracteres")]
    [Display(Name = "Contenido")]
    public string Content { get; set; }
}