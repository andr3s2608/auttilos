using Backend.Shared.BusinessRules;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Entities.Interface.Repository.Base;
using Backend.Shared.Repositories;
using Backend.Shared.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wkhtmltopdf.NetCore;

namespace Backend.Shared.API.Injections
{
    /// <summary>
    /// Business Injection
    /// </summary>
    public static class BusinessInjection
    {
        /// <summary>
        /// Adds the business configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration"></param>
        public static void AddBusinessConfig(this IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddDbContext<dbaeusdsdevpamecContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<dbaeusdsdevSirepContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionSirep")));
            
            // inyeccion de repository

          
            services.AddScoped(typeof(IConstantesRepository), typeof(ConstantesRepository));
            services.AddScoped(typeof(IDocuments_typeRepository), typeof(Document_typesRepository));
            services.AddScoped(typeof(IEntitiesRepository), typeof(EntitiesRepository));
            services.AddScoped(typeof(IProcedure_requestsRepository), typeof(Procedure_requestsRepository));
            services.AddScoped(typeof(IResolutionsRepository), typeof(ResolutionsRepository));
            services.AddScoped(typeof(IStatusRepository), typeof(StatusRepository));
            services.AddScoped(typeof(ITitle_typesRepository), typeof(Title_typesRepository));
            services.AddScoped(typeof(ITrackingRepository), typeof(TrackingRepository));         
         


            // inyeccion de business rules
           
            services.AddTransient<IConstantesBusiness, ConstantesBusiness>();
            services.AddTransient<IDocumentBusiness, DocumentBusiness>();
            services.AddTransient<IEntitiesBusiness, EntitiesBusiness>();
            services.AddTransient<IPDFBussines, PDFBusiness>();
            services.AddTransient<IProgramasBusiness, ProgramasBusiness>();
            services.AddTransient<IRequestBusiness, RequestBusiness>();
            services.AddTransient<IResolutionsBusiness, ResolutionsBusiness>();
            services.AddTransient<IStatusBusiness, StatusBusiness>();
            services.AddTransient<ITitleBusiness, TitleBusiness>();
            services.AddTransient<ITrackingBusiness, TrackingBusiness>();
           
            //services.AddScoped(typeof(IPamecBusiness), typeof(PamecBusiness));

            // services.AddScoped(typeof(IGeneratePdf), typeof(GeneratePdf));


            // services.AddScoped(typeof(IRazorViewToStringRenderer), typeof(RazorViewToStringRenderer));
            //services.AddScoped(typeof(IGeneratePdf), typeof(GeneratePdf));

            //       services.AddTransient<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
            // services.AddTransient<IGeneratePdf, GeneratePdf>();
            //services.AddScoped(typeof(IGeneratePdf), typeof(GeneratePdf));
            //services.AddTransient<IGeneratePdf, GeneratePdf>();

        }
    }
}
