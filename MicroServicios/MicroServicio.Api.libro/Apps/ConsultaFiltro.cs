using AutoMapper;
using MediatR;
using MicroServicio.Api.libro.Data;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MicroServicio.Api.libro.Models;

namespace MicroServicio.Api.libro.Apps
{
    public class ConsultaFiltro
    {
        public class LibroUnico : MediatR.IRequest<LibroMaterialDto>
        {
            public Guid? LibroId { get; set; }
        }

        public class Manejardo : IRequestHandler<LibroUnico, LibroMaterialDto>
        {
            private readonly DataContext _contexto;
            private readonly IMapper _mapper;
            public Manejardo(DataContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<LibroMaterialDto> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro = await _contexto.libreriaMaterials.Where(x => x.LibreriaMaterialId == request.LibroId).FirstOrDefaultAsync();
                if (libro == null)
                {
                    throw new Exception("No se encontro el libro");
                }
                var libroDto = _mapper.Map<LibreriaMaterial, LibroMaterialDto>(libro);
                return libroDto;
            }
        }
    }
}
