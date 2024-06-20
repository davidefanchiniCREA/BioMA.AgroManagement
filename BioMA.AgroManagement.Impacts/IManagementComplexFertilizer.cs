using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace CRA.AgroManagement.Impacts
{
    /// <summary>
    ///  Interface for N P K mineral fertilization
    /// </summary>
    public interface IManagementComplexFertilizer : IManagement
    {
        /// <summary>Fraction of nitrogen in ammonia form</summary>
        double AmmoniaFraction { get; set; }

        /// <summary> Fraction of nitrogen in nitrate form</summary>
        double NitrateFraction { get; set; }

        /// <summary> Fraction of potassium</summary>
        double PotassiumFraction { get; set; }

        /// <summary> Fraction of phosporus</summary>
        double PhosphorusFraction { get; set; }

        /// <summary>Total amount of fertilizer</summary>
        double TotalAmount { get; set; }
    }
}
