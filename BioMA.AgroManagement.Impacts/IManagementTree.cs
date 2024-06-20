using System;
using System.Collections.Generic;
using System.Text;

using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
    interface IManagementTree : IManagement
    {
        /// <summary>Tree/grapewine/fruit tree name</summary>
        string TreeName { get; set;}
        
        /// <summary>Tree type (e.g. tree, fruit tree, olive, grapewine</summary>
        string TreeType { get; set;}

        /// <summary>Tree management operation</summary>
        string TreeOperation { get; set;}
    }
}
