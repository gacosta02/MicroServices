using FluentValidation;
using MediatR;
using MicroServicio.Api.libro.Data;
using MicroServicio.Api.libro.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroServicio.Api.libro.Apps
{
    public class Nuevo
    {
        
        
        public class Ejecuta : IRequest
        {
           
            public string Titulo { get; set; }

            public DateTime? FechaPublicacion { get; set; }

            public Guid? AutorLibro { get; set; }
        }

        public class EjectutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjectutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
                RuleFor(x => x.AutorLibro).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly DataContext _contexto;

            public Manejador(DataContext contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var test = _contexto.libreriaMaterials.Where(x => x.Titulo == "1");
                var libro = new LibreriaMaterial()
                {
                        Titulo = request.Titulo,
                        FechaPublicacion = request.FechaPublicacion,
                        AutorLibro = request.AutorLibro
                    };
           
            
                _contexto.libreriaMaterials.Add(libro);
                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el libro");

            } }
        }
    }

