using System;

namespace CRA.AgroManagement
{
	/// <summary>
	/// Management types enumerator
	/// </summary>
	public abstract class AManagementTypes
	{
		/// <summary>
		/// This list should be extended according to need	
		/// </summary>
		public enum ManagType
		{
			/// <summary>
			/// Soil tillage.
			/// </summary>
			TILLAGE,
			/// <summary>
			/// Fresh and saline water irrigation.
			/// </summary>
			IRRIGATION,
			/// <summary>
			/// Mineral nitrogen fertilization.
			/// </summary>
			NITROGEN_FERTILIZATION,
			/// <summary>
			/// Organic fertilization including green manuring.
			/// </summary>
			ORGANIC_FERTILIZATION,
            /// <summary>
            /// Mineral phosporus fertilization.
            /// </summary>
            PHOSPHORUS_FERTILIZATION,
            /// <summary>
            /// Mineral nitrogen fertilization.
            /// </summary>
            POTASSIUM_FERTILIZATION,
			/// <summary>
			/// Mineral fertilization (N,P,K possible)
			/// </summary>
		    MINERAL_FERTILIZATION,
		    /// <summary>
			/// Crop management.
			/// </summary>
			CROP_OPERATION,
			/// <summary>
			/// Pesticide spray.
			/// </summary>
			PESTICIDE,
			/// <summary>
			/// Weeding
			/// </summary>
			WEEDING,
			/// <summary>
			/// Vineyards summer and dormancy pruning
			/// </summary>
			VINEYARD_OPERATION,
		    /// <summary>
		    /// Trees opeartions
		    /// </summary>
		    TREE_OPERATION,
		    /// <summary>
		    /// Orchards operation
		    /// </summary>
		    ORCHARD_OPERATION,
		}
	}
}
