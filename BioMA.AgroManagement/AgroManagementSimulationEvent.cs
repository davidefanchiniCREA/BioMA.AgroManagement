using CRA.ModelLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.AgroManagement
{
    public delegate void HandleEventDelegateType(AgroManagementSimulationEvent simulationEvent);

    public class AgroManagementSimulationEvent
    {

        /// <summary>
        /// Returns the ActEvents objects from the impacts of the <see cref="IManagement">IManagement interface</see>
        /// </summary>
        /// <returns></returns>
        public ActEvents GetActEvents()
        {
            return new ActEvents(GetImpacts<IManagement>());
        }


        private ManagementCollection<IManagement> _impacts;

        #region Overrides of SimulationEvent

        /// <summary>
        /// Returns the <see cref="IManagementBase"> impacts </see> of the event 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ManagementCollection<T> GetImpacts<T>()
            where T : class, IManagementBase
        {
            ManagementCollection<T> toreturn = new ManagementCollection<T>();
            toreturn.ProductionActivity = _impacts.ProductionActivity;
            foreach (IManagement m in _impacts.Management)
            {
                toreturn.Management.Add(m as T);
            }
            return toreturn;
        }

        /// <summary>
        /// Set the <see cref="IManagementBase"> impacts </see> of the event
        /// </summary>
        /// <param name="impacts"></param>
        public void SetImpacts(ManagementCollection<IManagementBase> impacts)
        {
            _impacts = new ManagementCollection<IManagement>();
            foreach (IManagementBase impact in impacts.Management)
            {
                _impacts.Management.Add(impact as IManagement);
            }
            _impacts.ProductionActivity = impacts.ProductionActivity;
        }

        #endregion
    }
}
