using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Models.Auttitulos;
using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Entities.Responses;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Backend.Shared.BusinessRules
{
    public class StatusBusiness : IStatusBusiness
    {
        private readonly Repositories.Context.dbaeusdsdevpamecContext _pamecContext;
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;
        private readonly IStatusRepository _repositorystatus;



        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CementerioBusiness"/> class.
        /// </summary>
        /// <param name="oracleContext"></param>
        /// <param name="telemetryException"></param>
        /// <param name="cache"></param>
        public StatusBusiness(Repositories.Context.dbaeusdsdevpamecContext pamecContext,
            Utilities.Telemetry.ITelemetryException telemetryException,                   
                  IStatusRepository repositorystatus,
                   
            IDistributedCache cache)
        {
            _pamecContext = pamecContext;
            TelemetryException = telemetryException;           
            _repositorystatus = repositorystatus;
            

        }

        #endregion


        /// <summary>
        /// Gets status by rol
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<List<Status_types>>> GetStatusbyrol(string rol)
        {

            try
            {
                var result = await _repositorystatus.GetAllAsync();
                var statusbyrol = new List<Status_types>();

                foreach (var item in result)
                {
                    if(rol.Equals("Funcionario"))
                    {
                        if (item.IdStatusType == 1 ||
                            item.IdStatusType == 2 ||
                            item.IdStatusType == 3 ||
                            item.IdStatusType == 7 ||
                            item.IdStatusType == 8 ||
                            item.IdStatusType == 9)
                        {
                            statusbyrol.Add(item);
                        }
                    }

                    if (rol.Equals("Coordinador"))
                    {
                        if (item.IdStatusType == 4 ||
                            item.IdStatusType == 5 ||
                            item.IdStatusType == 6 ||
                            item.IdStatusType == 7 ||
                            item.IdStatusType == 8 ||
                            item.IdStatusType == 10)
                        {
                            statusbyrol.Add(item);
                        }
                    }
                    if (rol.Equals("Subdirector"))
                    {
                        if (item.IdStatusType == 7 ||
                            item.IdStatusType == 11 ||
                            item.IdStatusType == 12)
                        {
                            statusbyrol.Add(item);
                        }
                    }
                    if (rol.Equals("AdminTI"))
                    {
                       
                            statusbyrol.Add(item);
                        
                    }
                }
                



                return new Entities.Responses.ResponseBase<List<Status_types>>(code: HttpStatusCode.OK,
                   message: Middle.Messages.GetOk, data: statusbyrol, count: statusbyrol.Count);

            }
            catch (Exception ex)
            {
                return new Entities.Responses.ResponseBase<List<Status_types>>(code: HttpStatusCode.OK,
                 message: "ha ocurrido un error mientras se traia la información", data: null);
            }


            throw new NotImplementedException();
        }
    }
}
