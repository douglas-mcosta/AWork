using System;
using System.ComponentModel.DataAnnotations;

namespace AWork.Candidatos.API.Application.Queries.ViewModels
{
    public class MaritalStatusViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}