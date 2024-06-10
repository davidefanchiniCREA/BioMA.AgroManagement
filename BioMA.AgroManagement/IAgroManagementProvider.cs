using CRA.ModelLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.AgroManagement
{
    public interface IAgroManagementProvider
    {
        ITestsOutput PreconditionsWriter { get; set; }

        /// <summary>
        /// Returns the agromanagement <see cref="CRA.AgroManagement.Scheduling"> CRA.Agromanagement.Scheduling</see> object related to the specified location and year
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        Scheduling GetAgromanagementAPIScheduling(string locationId, int year);


        /// <summary>
        /// Returns the number of crop life cycles defined in the agromanagement 
        /// </summary>
        /// <returns></returns>
        List<string> PlantingCycles();
    }
}
