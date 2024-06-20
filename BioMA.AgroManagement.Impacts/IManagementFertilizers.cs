using System;
using CRA.AgroManagement;

namespace CRA.AgroManagement.Impacts
{
    // Interface for N P K mineral fertilization
    public interface IManagementFertilizers : IManagement
    {
        double NitrogenFraction { get; set; }
        double PotassiumFraction { get; set; }
        double PhosphorusFraction { get; set; }
        double TotalAmount { get; set; }
    }
}
