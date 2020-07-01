using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ProdavnicaAspDarko.Application;
using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.Queries;
using ProdavnicaAspDarko.Implementation.Commands;
using ProdavnicaAspDarko.Implementation.Queries;
using ProdavnicaAspDarko.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdavnicaAspDarko.Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUsesCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateKlijentCommand, EFCreateKlijentCommand>();
            services.AddTransient<ICreateProizvodCommand, EFCreateProizvodCommand>();
            services.AddTransient<ICreateUlogaCommand, EFCreateUlogaCommand>();
            services.AddTransient<ICreateKategorijaCommand, EFCreateKategorijaCommand>();
            services.AddTransient<ICreateCenaCommand, EFCreateCenaCommand>();
            services.AddTransient<ICreateSlikaCommand, EFCreateSlikaCommand>();
            services.AddTransient<ICreatePorudzbinaCommand, EFCreatePorudzbinaCommand>();
            services.AddTransient<ICreateChangeStatusCommand, EFChangeStatusCommand>();
            services.AddTransient<IGetProizvodiQuery, EFGetProizvodiQuery>();
            services.AddTransient<IGetKlijentiQuery, EFGetKlijentiQuery>();
            services.AddTransient<IGetPorudzbineQuery, EFGetPorudzbinaDatum>();
            services.AddTransient<IGetUseCaseLogsQuery, EFGetUseCaseLogQuery>();
            services.AddTransient<IGetKlijentById,EFGetOneKlijent>();
            services.AddTransient<IDeleteKlijentCommand, EFDeleteKlijentCommand>(); 
            services.AddTransient<IUpdateKlijentCommand, EFUpdateKlijentCommand>();


            services.AddTransient<IGetUlogaByIdQuery, EFGetJednaUlogaQuery>();
            services.AddTransient<IGetUlogeQuery, EFGetUlogeQuery>(); 

            services.AddTransient<IDeleteUlogaCommand, EFDeleteUlogaCommand>();

            services.AddTransient<IUpdateUlogaCommand, EFUpdateUlogaCommand>(); 
            services.AddTransient<IGetKategorijaByIdQuery, EFGetJednaKategorija>();

            services.AddTransient<IGetKategorijeQuery, EFGetKategorije>(); 

            services.AddTransient<IDeleteKategorijaCommand, EFDeleteKategorijaCommand>(); 

            services.AddTransient<IUpdateKategorijaCommand, EFUpdateKategorijaCommand>(); 
            services.AddTransient<IGetPorudzbinaByIdQuery, EFGetJednaPorudzbinaQuery>();

            services.AddTransient<IDeleteProizvodCommand, EFDeleteProizvodCommand>();

            services.AddTransient<IGetProizvodByIdQuery, EFGetJedanProizvod>(); 
            services.AddTransient<IUpdateProizvodCommand, EFUpdateProizvodCommand>(); 

            services.AddTransient<IGetProizvodSlikeQuery, EFDohvatiSlikeProizvoda>();

            services.AddTransient<IDeleteSlikeProizvodaCommand, EFDeleteSlikeProizvodaCommand>();



            services.AddTransient<CreateKlijentValidator>();
            services.AddTransient<CreateProizvodValidator>();
            services.AddTransient<CreateUlogaValidator>();
            services.AddTransient<CreateKategorijaValidator>();
            services.AddTransient<CreateCenaValidator>();
            services.AddTransient<CreateSlikaValidator>();
            services.AddTransient<CreatePorudzbinaValidator>();
            services.AddTransient<UpdateEmailValidator>();
            services.AddTransient<CreateDetaljiPorudzbineValidator>(); 
            services.AddTransient<UpdateKlijentValidator>(); 
            services.AddTransient<DaLiPostojiUlogaUbaziValidator>();
            services.AddTransient<UpdateProizvodValidator>();


        }
        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;
                if (user.FindFirst("ActorData") == null)
                {
                    return new NotLoggedInActor();
                }
                var actorString = user.FindFirst("ActorData").Value;
                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);
                return actor;


            });
        }
    }
}
