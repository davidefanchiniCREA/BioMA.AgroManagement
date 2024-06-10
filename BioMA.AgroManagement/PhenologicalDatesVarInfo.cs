//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRA.AgroManagement 
{
    using System;
    using System.Collections;
    using CRA.ModelLayer.Core;
    
    
   /// <summary>PhenologicalDatesRainDataVarInfo contains the attributes for each variable in the domain class PhenologicalDates. Attributes are valorized via the static constructor. The data-type VarInfo causes  a dependency to the assembly CRA.Core.Preconditions.dll</summary>
   /// <remark>DCC - Domain Class Coder, http://www.isci.it/asp/asp2/utils.asp </remark>
   public class PhenologicalDatesVarInfo : IVarInfoClass
   {

        #region Fields

        static  VarInfo _datePlanting = new VarInfo();
        
        static  VarInfo _dateEmergence = new VarInfo();
        
        static  VarInfo _dateFiveLeaves = new VarInfo();
        
        static  VarInfo _dateEndJuvanilePhase = new VarInfo();
        
        static  VarInfo _dateHeading = new VarInfo();
        
        static  VarInfo _dateBeginTillering = new VarInfo();
        
        static  VarInfo _dateTuberRootInitiation = new VarInfo();
        
        static  VarInfo _dateEndPhotoInductivePhase = new VarInfo();
        
        static  VarInfo _dateBeginStemElongation = new VarInfo();
        
        static  VarInfo _dateBeginFlowering = new VarInfo();
        
        static  VarInfo _dateBeginGrainFilling = new VarInfo();
        
        static  VarInfo _dateMilkDough = new VarInfo();
        
        static  VarInfo _dateSoftDough = new VarInfo();
        
        static  VarInfo _datePhysiologicalMaturity = new VarInfo();

        static  VarInfo _dateTenTwelveLeaves = new VarInfo();

        static  VarInfo _dateEarOneCm = new VarInfo();

        static  VarInfo _dateLastLeaf = new VarInfo();

        static  VarInfo _dateBeginLeafSenescence = new VarInfo();

        static  VarInfo _dateHarvest = new VarInfo();

        static VarInfo _dateLastCut = new VarInfo();

        #endregion

        #region Constructor

        static PhenologicalDatesVarInfo() 
        {
			DescribeVariables();
        }

        #endregion

        #region IVarInfoClass Members

       /// <summary>
        /// Attributes of phenological dates
       /// </summary>
       public string Description
        {
            get { return "Attributes of phenological dates."; }
        }

        /// <summary>
        /// Domain class of reference
        /// </summary>
        public string DomainClassOfReference
        {
            get { return "CRA.AgroManagement.PhenologicalDates"; }
        }

        /// <summary>
        /// Description of the domain class on the knowledge base
        /// </summary>
        public string URL
        {
            get { return ("Web reference to the knowledge base"); }
        }

        #endregion

        #region VarInfo properties 

        /// <summary>Date of last cut of forage</summary>
        public static VarInfo DateLastCut
        {
            get { return _dateLastCut; }
        }

        /// <summary>Date of final harvest</summary>
        public static VarInfo DateHarvest
        {
            get { return _dateHarvest; }
        }

        /// <summary>Date of beginning of leaves senescence</summary>
        public static VarInfo DateBeginLeafSenescence
        {
            get { return _dateBeginLeafSenescence; }
        }

        /// <summary>Date of last leaf expansion</summary>
        public static VarInfo DateLastLeaf
        {
            get { return _dateLastLeaf; }
        }

        /// <summary>Date ear one centimeter long</summary>
        public static VarInfo DateEarOneCm
        {
            get { return _dateEarOneCm; }
        }

        /// <summary>Date of ten - twelve leaves expanded</summary>
        public static VarInfo DateTenTwelveLeaves
        {
            get { return _dateTenTwelveLeaves; }
        }

        /// <summary>Date of planting</summary>
        public static  VarInfo DatePlanting 
        {
            get { return  _datePlanting; }
        }
        
        /// <summary>Date of emergence</summary>
        public static  VarInfo DateEmergence 
        {
            get { return  _dateEmergence; }
        }
        
        /// <summary>Date of five leaves fully formed</summary>
        public static  VarInfo DateFiveLeaves 
        {
            get { return  _dateFiveLeaves; }
        }
        
        /// <summary>Date of end of juvanile phase</summary>
        public static  VarInfo DateEndJuvanilePhase 
        {
            get { return  _dateEndJuvanilePhase; }
        }
        
        /// <summary>Date of head emission</summary>
        public static  VarInfo DateHeading 
        {
            get { return  _dateHeading; }
        }
        
        /// <summary>Date when tillering begins</summary>
        public static  VarInfo DateBeginTillering 
        {
            get { return  _dateBeginTillering; }
        }
        
        /// <summary>Date when tuber formation begins</summary>
        public static  VarInfo DateTuberRootInitiation 
        {
            get { return  _dateTuberRootInitiation; }
        }
        
        /// <summary>Date when photo-inductive phase ends</summary>
        public static  VarInfo DateEndPhotoInductivePhase 
        {
            get { return  _dateEndPhotoInductivePhase; }
        }
        
        /// <summary>Date when stem elongation begins</summary>
        public static  VarInfo DateBeginStemElongation 
        {
            get { return  _dateBeginStemElongation; }
        }
        
        /// <summary>Date when flowering begins</summary>
        public static  VarInfo DateBeginFlowering 
        {
            get { return  _dateBeginFlowering; }
        }
        
        /// <summary>Date when grain filling begins</summary>
        public static  VarInfo DateBeginGrainFilling 
        {
            get { return  _dateBeginGrainFilling; }
        }
        
        /// <summary>Date when millk stage occurs in cereals </summary>
        public static  VarInfo DateMilkDough 
        {
            get { return  _dateMilkDough; }
        }
        
        /// <summary>Date when soft dough stage occurs in cereals</summary>
        public static  VarInfo DateSoftDough 
        {
            get { return  _dateSoftDough; }
        }
        
        /// <summary>Date of physiological maturity</summary>
        public static  VarInfo DatePhysiologicalMaturity 
        {
            get { return  _datePhysiologicalMaturity; }
        }

        #endregion

        #region Constructor methods

        static void DescribeVariables() {
            //
            _dateLastCut.Name = "DateLastCut";
            _dateLastCut.Description = "Date Last cut of forage";
            _dateLastCut.MaxValue = 365;
            _dateLastCut.MinValue = 1;
            _dateLastCut.DefaultValue = 300;
            _dateLastCut.Units = "d";
            _dateLastCut.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //
            _dateTenTwelveLeaves.Name = "DateTenTwelveLeaves";
            _dateTenTwelveLeaves.Description = "Date 10-12 leaves expanded";
            _dateTenTwelveLeaves.MaxValue = 365;
            _dateTenTwelveLeaves.MinValue = 1;
            _dateTenTwelveLeaves.DefaultValue = 150;
            _dateTenTwelveLeaves.Units = "d";
            _dateTenTwelveLeaves.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //
            _dateEarOneCm.Name = "DateEarOneCm";
            _dateEarOneCm.Description = "Date when ear is one centimeter long";
            _dateEarOneCm.MaxValue = 365;
            _dateEarOneCm.MinValue = 1;
            _dateEarOneCm.DefaultValue = 120;
            _dateEarOneCm.Units = "d";
            _dateEarOneCm.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //
            _dateLastLeaf.Name = "dateLastLeaf";
            _dateLastLeaf.Description = "Date last leaf expanded";
            _dateLastLeaf.MaxValue = 365;
            _dateLastLeaf.MinValue = 1;
            _dateLastLeaf.DefaultValue = 300;
            _dateLastLeaf.Units = "d";
            _dateLastLeaf.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //
            _dateBeginLeafSenescence.Name = "DateBeginLeafSenescence";
            _dateBeginLeafSenescence.Description = "Date begin canopy senescence";
            _dateBeginLeafSenescence.MaxValue = 365;
            _dateBeginLeafSenescence.MinValue = 1;
            _dateBeginLeafSenescence.DefaultValue = 180;
            _dateBeginLeafSenescence.Units = "d";
            _dateBeginLeafSenescence.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //
            _dateHarvest.Name = "DateHarvest";
            _dateHarvest.Description = "Date final harvest";
            _dateHarvest.MaxValue = 365;
            _dateHarvest.MinValue = 1;
            _dateHarvest.DefaultValue = 242;
            _dateHarvest.Units = "d";
            _dateHarvest.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _datePlanting.Name = "DatePlanting";
            _datePlanting.Description = "Date of planting";
            _datePlanting.MaxValue = 365;
            _datePlanting.MinValue = 0;
            _datePlanting.DefaultValue = 90;
            _datePlanting.Units = "d";
            _datePlanting.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateEmergence.Name = "DateEmergence";
            _dateEmergence.Description = "Date of emergence";
            _dateEmergence.MaxValue = 365;
            _dateEmergence.MinValue = 0;
            _dateEmergence.DefaultValue = 95;
            _dateEmergence.Units = "d";
            _dateEmergence.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateFiveLeaves.Name = "DateFiveLeaves";
            _dateFiveLeaves.Description = "Date of five leaves fully formed";
            _dateFiveLeaves.MaxValue = 365;
            _dateFiveLeaves.MinValue = 0;
            _dateFiveLeaves.DefaultValue = 120;
            _dateFiveLeaves.Units = "d";
            _dateFiveLeaves.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateEndJuvanilePhase.Name = "DateEndJuvanilePhase";
            _dateEndJuvanilePhase.Description = "Date of end of juvanile phase";
            _dateEndJuvanilePhase.MaxValue = 365;
            _dateEndJuvanilePhase.MinValue = 0;
            _dateEndJuvanilePhase.DefaultValue = 180;
            _dateEndJuvanilePhase.Units = "d";
            _dateEndJuvanilePhase.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateHeading.Name = "DateHeading";
            _dateHeading.Description = "Date of head emission";
            _dateHeading.MaxValue = 365;
            _dateHeading.MinValue = 0;
            _dateHeading.DefaultValue = 212;
            _dateHeading.Units = "d";
            _dateHeading.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateBeginTillering.Name = "DateBeginTillering";
            _dateBeginTillering.Description = "Date when tillering begins";
            _dateBeginTillering.MaxValue = 365;
            _dateBeginTillering.MinValue = 0;
            _dateBeginTillering.DefaultValue = 190;
            _dateBeginTillering.Units = "d";
            _dateBeginTillering.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateTuberRootInitiation.Name = "DateTuberRootInitiation";
            _dateTuberRootInitiation.Description = "Date when tuber formation begins";
            _dateTuberRootInitiation.MaxValue = 365;
            _dateTuberRootInitiation.MinValue = 0;
            _dateTuberRootInitiation.DefaultValue = 200;
            _dateTuberRootInitiation.Units = "d";
            _dateTuberRootInitiation.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateEndPhotoInductivePhase.Name = "EndPhotoInductivePhase";
            _dateEndPhotoInductivePhase.Description = "Date when photo-inductive phase ends";
            _dateEndPhotoInductivePhase.MaxValue = 365;
            _dateEndPhotoInductivePhase.MinValue = 0;
            _dateEndPhotoInductivePhase.DefaultValue = 212;
            _dateEndPhotoInductivePhase.Units = "d";
            _dateEndPhotoInductivePhase.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateBeginStemElongation.Name = "BeginStemElongation";
            _dateBeginStemElongation.Description = "date when stem elongation begins";
            _dateBeginStemElongation.MaxValue = 365;
            _dateBeginStemElongation.MinValue = 0;
            _dateBeginStemElongation.DefaultValue = 190;
            _dateBeginStemElongation.Units = "d";
            _dateBeginStemElongation.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateBeginFlowering.Name = "BeginFlowering";
            _dateBeginFlowering.Description = "Date when flowering begins";
            _dateBeginFlowering.MaxValue = 365;
            _dateBeginFlowering.MinValue = 0;
            _dateBeginFlowering.DefaultValue = 210;
            _dateBeginFlowering.Units = "d";
            _dateBeginFlowering.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateBeginGrainFilling.Name = "DateBeginGrainFilling";
            _dateBeginGrainFilling.Description = "Date when grain filling begins";
            _dateBeginGrainFilling.MaxValue = 365;
            _dateBeginGrainFilling.MinValue = 0;
            _dateBeginGrainFilling.DefaultValue = 240;
            _dateBeginGrainFilling.Units = "d";
            _dateBeginGrainFilling.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateMilkDough.Name = "DateMilkDough";
            _dateMilkDough.Description = "Date when millk stage occurs in cereals ";
            _dateMilkDough.MaxValue = 365;
            _dateMilkDough.MinValue = 0;
            _dateMilkDough.DefaultValue = 240;
            _dateMilkDough.Units = "d";
            _dateMilkDough.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _dateSoftDough.Name = "DateSoftDough";
            _dateSoftDough.Description = "Date when soft dough stage occurs in cereals";
            _dateSoftDough.MaxValue = 365;
            _dateSoftDough.MinValue = 0;
            _dateSoftDough.DefaultValue = 220;
            _dateSoftDough.Units = "d";
            _dateSoftDough.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _datePhysiologicalMaturity.Name = "DatePhysiologicalMaturity";
            _datePhysiologicalMaturity.Description = "Date of physiological maturity";
            _datePhysiologicalMaturity.MaxValue = 365;
            _datePhysiologicalMaturity.MinValue = 0;
            _datePhysiologicalMaturity.DefaultValue = 345;
            _datePhysiologicalMaturity.Units = "d";
            _datePhysiologicalMaturity.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
        }

        #endregion
    }
}