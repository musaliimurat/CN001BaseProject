using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
	public class ProductImageAddDto : IDto
	{
        public int ProductId { get; set; }
        public bool IsFeautred { get; set; }
        public IFormFile Photo { get; set; }
    }
}
