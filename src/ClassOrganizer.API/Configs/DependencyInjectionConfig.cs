using ClassOrganizer.Application;
using ClassOrganizer.Application.Commands;
using ClassOrganizer.Application.Commands.Alunos.CriarAluno;
using ClassOrganizer.Application.Pipeline;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Core.Services;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Infrastructure.CrossCutting;
using ClassOrganizer.Infrastructure.Dados;
using ClassOrganizer.Infrastructure.Dados.Repositories;
using ClassOrganizer.Infrastructure.Mediator;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ClassOrganizer.API.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(t => t.RegisterServicesFromAssemblyContaining(typeof(BaseCommandHandler<>)));
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();

            services.AddScoped<IHashingService, HashService>();

            services.AddValidatorsFromAssembly(typeof(CriarAlunoCommand).Assembly);
        }
    }
}
