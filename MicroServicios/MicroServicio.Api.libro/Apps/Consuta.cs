using AutoMapper;
using MediatR;
using MicroServicio.Api.libro.Data;
using MicroServicio.Api.libro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroServicio.Api.libro.Apps
{
    public class Consuta
    {
        public class Ejecuta : IRequest<List<LibroMaterialDto>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDto>>
        {
            private readonly DataContext _contexto;
            private readonly IMapper _mapper;
            public Manejador(DataContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<LibroMaterialDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libros = await _contexto.libreriaMaterials.ToListAsync();
                var librosDto = _mapper.Map<List<LibreriaMaterial>, List<LibroMaterialDto>>(libros);

                return librosDto;
            }
        }
    }
}
